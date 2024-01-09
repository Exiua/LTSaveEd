using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.CharacterData.InventoryData;
using LTSaveEd.Models.CharacterData.InventoryData.Clothes;
using LTSaveEd.Models.CharacterData.InventoryData.Items;
using LTSaveEd.Models.CharacterData.InventoryData.Weapons;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Inventory
{
    public const int MaxInventorySize = 150; // TODO: Validate this value in-game
    
    public XmlAttribute<int> Money { get; }
    public XmlAttribute<int> EssenceCount { get; }
    public List<Clothing> Clothes { get; } = [];
    public List<Item> Items { get; } = [];
    public List<Weapon> Weapons { get; } = [];

    private int Count => Clothes.Count + Items.Count + Weapons.Count;
    public bool Full => Count >= MaxInventorySize;

    private readonly XElement _clothingInInventoryNode;
    private readonly XElement _itemsInInventoryNode;
    private readonly XElement _weaponsInInventoryNode;
    private readonly List<XElement> _clothingNodes = [];
    private readonly List<XElement> _itemNodes = [];
    private readonly List<XElement> _weaponNodes = [];

    public Inventory(XElement inventoryNode)
    {
        Money = new XmlAttribute<int>(inventoryNode.GetChildsAttributeNode("money"));
        EssenceCount = new XmlAttribute<int>(inventoryNode.GetChildsAttributeNode("essenceCount"));

        _clothingInInventoryNode = GetOrCreateElement(inventoryNode, "clothingInInventory");
        _itemsInInventoryNode = GetOrCreateElement(inventoryNode, "itemsInInventory");
        _weaponsInInventoryNode = GetOrCreateElement(inventoryNode, "weaponsInInventory");
        
        AddInventoryElements(_itemsInInventoryNode, Items, _itemNodes, element => new Item(element));
        AddInventoryElements(_clothingInInventoryNode, Clothes, _clothingNodes, element => new Clothing(element));
        AddInventoryElements(_weaponsInInventoryNode, Weapons, _weaponNodes, element => new Weapon(element));
    }

    private static XElement GetOrCreateElement(XElement parent, string childName)
    {
        var node = parent.Element(childName);
        if (node is not null)
        {
            return node;
        }

        node = new XElement(childName);
        parent.Add(node);

        return node;
    }
    
    public void Add(InventoryElementData elementData)
    {
        switch (elementData)
        {
            case ClothingData clothing:
                CreateClothing(clothing);
                break;
            case ItemData item:
                CreateItem(item);
                break;
            case WeaponData weapon:
                CreateWeapon(weapon);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(elementData), elementData, null);
        }
    }

    private void CreateClothing(ClothingData clothingData)
    {
        var colors = new XElement("colours");
        for (var i = 0; i < clothingData.ColorCount; i++)
        {
            var color = new XElement("colour", new XAttribute("i", i))
            {
                Value = "CLOTHING_BLACK"
            };
            colors.Add(color);
        }
        var clothingNode = new XElement("clothing",
            new XAttribute("count", 1),
            new XAttribute("enchantmentKnown", true),
            new XAttribute("id", clothingData.Value),
            new XAttribute("isDirty", false),
            new XAttribute("name", clothingData.DisplayValue),
            new XAttribute("sealed", false),
            colors);
        
        _clothingInInventoryNode.Add(clothingNode);
        var clothing = new Clothing(clothingNode);
        Clothes.Add(clothing);
        _clothingNodes.Add(clothingNode);
    }

    private void CreateItem(ItemData itemData)
    {
        var itemNode = new XElement("item",
            new XAttribute("colour", "BASE_TAN"), // TODO: Maybe fix, cause item colors are a mess in-game
            new XAttribute("count", 1),
            new XAttribute("id", itemData.Value),
            new XAttribute("name", itemData.DisplayValue));
        
        _itemsInInventoryNode.Add(itemNode);
        var item = new Item(itemNode);
        Items.Add(item);
        _itemNodes.Add(itemNode);
    }

    private void CreateWeapon(WeaponData weaponData)
    {
        var colors = new XElement("colours");
        for (var i = 0; i < weaponData.ColorCount; i++)
        {
            var color = new XElement("colour", new XAttribute("i", i))
            {
                Value = "CLOTHING_BLACK"
            };
            colors.Add(color);
        }
        
        var weaponNode = new XElement("weapon",
            new XAttribute("coreEnchantment", weaponData.CoreEnchantment),
            new XAttribute("count", 1),
            new XAttribute("damageType", weaponData.DefaultEnchantment),
            new XAttribute("id", weaponData.Value),
            new XAttribute("name", weaponData.DisplayValue),
            colors,
            new XElement("effects"),
            new XElement("spells"),
            new XElement("combatMoves"));
        
        _weaponsInInventoryNode.Add(weaponNode);
        var weapon = new Weapon(weaponNode);
        Weapons.Add(weapon);
        _weaponNodes.Add(weaponNode);
    }
    
    public void Delete(int index, InventoryElementType type)
    {
        switch (type)
        {
            case InventoryElementType.None:
                return;
            case InventoryElementType.Clothing:
                _clothingNodes[index].Remove();
                _clothingNodes.RemoveAt(index);
                Clothes.RemoveAt(index);
                break;
            case InventoryElementType.Item:
                _itemNodes[index].Remove();
                _itemNodes.RemoveAt(index);
                Items.RemoveAt(index);
                break;
            case InventoryElementType.Weapon:
                _weaponNodes[index].Remove();
                _weaponNodes.RemoveAt(index);
                Weapons.RemoveAt(index);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private static void AddInventoryElements<T>(XElement inventoryElementNode, List<T> elementsList,
        List<XElement> elementNodesList, Func<XElement, T> constructor) where T : InventoryElement
    {
        var elements = inventoryElementNode.Elements();
        foreach (var element in elements)
        {
            var elementObject = constructor(element);
            elementsList.Add(elementObject);
            elementNodesList.Add(element);
        }
    }
}