import sys
import json
from pathlib import Path

from lxml import etree
from titlecase import titlecase


class InventoryElement:
    def __init__(self, name: str, id_: str):
        self.name = name
        self.id_ = id_

    def __str__(self):
        return f'new ValueDisplayPair<string>("{self.name}", "{self.id_}")'

    def __repr__(self):
        return self.__str__()


class ClothingData(InventoryElement):
    def __init__(self, name: str, id_: str, color_count: int):
        super().__init__(name, id_)
        self.color_count = color_count

    def __str__(self):
        return f'new ClothingData("{self.name}", "{self.id_}", {self.color_count})'

    def __repr__(self):
        return self.__str__()


class ItemData(InventoryElement):
    def __init__(self, name: str, id_: str):
        super().__init__(name, id_)

    def __str__(self):
        return f'new ItemData("{self.name}", "{self.id_}")'

    def __repr__(self):
        return self.__str__()


class WeaponData(InventoryElement):
    def __init__(self, name: str, id_: str, color_count: int, damage_type: str, default_type: str):
        super().__init__(name, id_)
        self.color_count = color_count
        self.damage_type = damage_type
        self.default_type = default_type

    def __str__(self):
        return f'new WeaponData("{self.name}", "{self.id_}", {self.color_count}, "{self.damage_type}", "{self.default_type}")'

    def __repr__(self):
        return self.__str__()


def main(filepath: str):
    path = Path(filepath)
    if not any(ext in str(file) for file in path.iterdir() for ext in
               ("LT.exe", ".jar")):  # Basic sanity check for game dir
        raise Exception("Filepath to game not provided: " + filepath)
    res_dir_path = path / "res"
    clothing_dir_path = res_dir_path / "clothing"
    items_dir_path = res_dir_path / "items"
    weapons_dir_path = res_dir_path / "weapons"
    clothing_ids = get_item_ids(clothing_dir_path)
    item_ids = get_item_ids(items_dir_path)
    weapon_ids = get_item_ids(weapons_dir_path)
    write("scripts2/clothes.json", clothing_ids)
    write("scripts2/items.json", item_ids)
    write("scripts2/weapons.json", weapon_ids)
    write_csharp(clothing_ids, item_ids, weapon_ids)


def write_csharp(clothes_dict: dict[str, list[InventoryElement]], items_dict: dict[str, list[InventoryElement]],
                 weapons_dict: dict[str, list[InventoryElement]]):
    with open("scripts2/c#.txt", "w") as f:
        f.write("#region Clothes Initialization\n\n")

        for key in clothes_dict:
            items = construct_items(clothes_dict[key])
            key = construct_key(key)
            f.write(f"ClothingMap.Add(ClothingType.{key}, [{items}]);\n")

        f.write("\n#endregion\n\n#region Items Initialization\n\n")

        for key in items_dict:
            items = construct_items(items_dict[key])
            key = construct_key(key)
            f.write(f"ItemsMap.Add(ItemType.{key}, [{items}]);\n")

        f.write("\n#endregion\n\n#region Weapons Initialization\n\n")

        for key in weapons_dict:
            items = construct_items(weapons_dict[key])
            key = construct_key(key)
            f.write(f"WeaponsMap.Add(WeaponType.{key}, [{items}]);\n")

        f.write("\n#endregion")


def construct_items(items: list[InventoryElement]) -> str:
    items = [str(item) for item in items]
    items = ", ".join(items)
    return items


def construct_key(key: str) -> str:
    key = key.split("_")
    key = [w.title() for w in key]
    key = "".join(key)
    return key


def construct_item_name(item: str) -> str:
    c = item.count("_")
    match c:
        case 0 | 1:
            return item.title()
        case 2:
            item = item.split("_")
            return item[-1].title()
        case 3:
            item = item.split("_")
            return f"{item[-2].title()} {item[-1].title()}"


def get_item_ids(path: Path) -> dict[str, list[InventoryElement]]:
    item_ids: dict[str, list[InventoryElement]] = {}
    for file in path.rglob("*.xml"):
        parts = file.parts
        if parts[-3] == "clothing":
            item_id = "_".join(parts[-2:]).replace(".xml", "")
        else:
            item_id = "_".join(parts[-3:]).replace(".xml", "")
        root: etree.ElementBase = etree.parse(file).getroot()
        name = root.find(".//name").text
        name = titlecase(name).replace('"', r'\"')
        # print(item_id)
        match root.tag:
            case "clothing":
                # Check if the value attribute exists for the secondaryColours element
                second_color: etree.ElementBase = root.find(".//secondaryColours")
                if second_color is not None and (second_color.get("values") is not None or second_color.getchildren()):
                    third_color: etree.ElementBase = root.find(".//tertiaryColours")
                    if third_color is not None and (third_color.get("values") is not None or third_color.getchildren()):
                        colors = 3
                    else:
                        colors = 2
                else:
                    colors = 1
                item = ClothingData(name, item_id, colors)
                equip_slots = root.find(".//equipSlots")
                if equip_slots is not None:
                    for slot in equip_slots:
                        add_element(item_ids, slot.text, item)
                else:
                    slot = root.find(".//slot")
                    add_element(item_ids, slot.text, item)
            case "item":
                item = ItemData(name, item_id)
                add_element(item_ids, "ITEM", item)
            case "weapon":
                secondary_colors: etree.ElementBase = root.find(".//secondaryColours")
                if secondary_colors is not None and (
                        secondary_colors.get("values") is not None or secondary_colors.getchildren()):
                    colors = 2
                else:
                    colors = 1
                available_damage_types: etree.ElementBase = root.find(".//availableDamageTypes")
                damage_types = available_damage_types.getchildren()
                default_type = damage_types[0].text
                if len(damage_types) > 1:
                    if "_feather_" in item_id:
                        damage_type = f"RESISTANCE_{default_type}"
                    elif "_crystal_" in item_id:
                        damage_type = f"DAMAGE_{default_type}"
                    elif item_id in ("innoxia_bow_shortbow", "c4mg1rl_bows_hama_yumi"):
                        damage_type = "CRITICAL_DAMAGE"
                    else:
                        damage_type = "DAMAGE_MELEE_WEAPON"
                else:
                    if default_type == "LUST":
                        damage_type = "DAMAGE_LUST"
                    else:
                        damage_type = "null"
                item = WeaponData(name, item_id, colors, damage_type, default_type)
                melee_tag = root.find(".//melee")
                match melee_tag.text:
                    case "true":
                        add_element(item_ids, "MELEE", item)
                    case "false":
                        if item.damage_type == "DAMAGE_MELEE_WEAPON":
                            item.damage_type = "DAMAGE_RANGED_WEAPON"
                        add_element(item_ids, "RANGED", item)
    return item_ids


def add_element(dictionary: dict[str, list[InventoryElement]], key: str, value: InventoryElement):
    if key not in dictionary:
        dictionary[key] = []
    dictionary[key].append(value)


def write(filepath: str, data: dict[str, list[InventoryElement]]):
    path = Path(filepath)
    path.parent.mkdir(parents=True, exist_ok=True)
    serializable_data = {}
    for key in data:
        serializable_data[key] = [str(item) for item in data[key]]
    with open(filepath, "w") as f:
        json.dump(serializable_data, f, indent=4)


if __name__ == "__main__":
    main(sys.argv[1])
