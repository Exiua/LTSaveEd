import sys
import os
import json

from lxml import etree


def get_items(filepath: str):
    top_files = next(os.walk(filepath), (None, None, []))[2]
    if not any(ext in file for file in top_files for ext in ("LT.exe", ".jar")):  # Basic sanity check for game dir
        raise Exception("Filepath to game not provided: " + filepath)
    res_dir_path = os.path.join(filepath, "res")
    clothing_dir_path = os.path.join(res_dir_path, "clothing")
    items_dir_path = os.path.join(res_dir_path, "items")
    weapons_dir_path = os.path.join(res_dir_path, "weapons")
    clothing_ids = get_item_ids(clothing_dir_path)
    item_ids = get_item_ids(items_dir_path)
    weapon_ids = get_item_ids(weapons_dir_path)
    write("scripts/clothes.json", clothing_ids)
    write("scripts/items.json", item_ids)
    write("scripts/weapons.json", weapon_ids)
    write_java(clothing_ids, item_ids, weapon_ids)


def write_java(clothes_dict, items_dict, weapons_dict):
    f = open("scripts/java.txt", "w")
    f.write("// region Clothes Initialization\n\n")

    for key in clothes_dict:
        items = clothes_dict[key]
        items = [f'"{item}"' for item in items]
        items = ", ".join(items)
        f.write(f"clothesMap.put(ClothingType.{key}, new String[]{{{items}}});\n")

    f.write("\n// endregion\n\n// region Items Initialization\n\n")

    for key in items_dict:
        items = items_dict[key]
        items = [f'"{item}"' for item in items]
        items = ", ".join(items)
        f.write(f"itemsMap.put(ItemType.{key}, new String[]{{{items}}});\n")

    f.write("\n// endregion\n\n// region Weapons Initialization\n\n")

    for key in weapons_dict:
        items = weapons_dict[key]
        items = [f'"{item}"' for item in items]
        items = ", ".join(items)
        f.write(f"weaponsMap.put(WeaponType.{key}, new String[]{{{items}}});\n")

    f.write("\n// endregion")
    f.close()


def write(filepath: str, data):
    with open(filepath, "w") as f:
        json.dump(data, f, indent=4)


def get_item_ids(item_dir_path) -> dict[str, list[str]]:
    item_ids = {}
    contributors = os.listdir(item_dir_path)
    for contributor in contributors:
        contributor_dir_path = os.path.join(item_dir_path, contributor)
        _, contributor_directories, contributor_files = next(os.walk(contributor_dir_path), (None, [], []))

        for directory in contributor_directories:  # Gets nested files (e.g. innoxia dir)
            contributor_subdir_path = os.path.join(contributor_dir_path, directory)
            items = os.listdir(contributor_subdir_path)

            for item in items:
                if ".xml" not in item:
                    continue
                item_id = f"{contributor}_{directory}_{item.replace('.xml', '')}"
                item_path = os.path.join(contributor_subdir_path, item)
                sort_item_id(item_ids, item_id, item_path)

        for file in contributor_files:  # Gets top level files (e.g. TonyJC dir)
            if ".xml" not in file:
                continue
            item_id = f"{contributor}_{file.replace('.xml', '')}"
            item_path = os.path.join(contributor_dir_path, file)
            sort_item_id(item_ids, item_id, item_path)

    return item_ids


def sort_item_id(item_ids: dict[str, list[str]], item_id: str, item_path: str):
    root = etree.parse(item_path).getroot()
    match root.tag:
        case "clothing":
            equip_slots = root.find(".//equipSlots")
            if equip_slots is not None:
                for slot in equip_slots:
                    add_element(item_ids, slot.text, item_id)
            else:
                slot = root.find(".//slot")
                add_element(item_ids, slot.text, item_id)
        case "item":
            add_element(item_ids, "ITEM", item_id)
        case "weapon":
            melee_tag = root.find(".//melee")
            match melee_tag.text:
                case "true":
                    add_element(item_ids, "MELEE", item_id)
                case "false":
                    add_element(item_ids, "RANGED", item_id)


def add_element(dictionary: dict[str, list[str]], key: str, value: str):
    if key not in dictionary:
        dictionary[key] = []
    dictionary[key].append(value)


if __name__ == '__main__':
    get_items(sys.argv[1])
