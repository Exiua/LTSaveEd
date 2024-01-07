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
    
    public int Count => Clothes.Count + Items.Count + Weapons.Count;

    private readonly List<XElement> _clothingNodes = [];
    private readonly List<XElement> _itemNodes = [];
    private readonly List<XElement> _weaponNodes = [];

    public Inventory(XElement inventoryNode)
    {
        Money = new XmlAttribute<int>(inventoryNode.GetChildsAttributeNode("money"));
        EssenceCount = new XmlAttribute<int>(inventoryNode.GetChildsAttributeNode("essenceCount"));

        AddInventoryElements(inventoryNode, "itemsInInventory", Items, _itemNodes, element => new Item(element));
        AddInventoryElements(inventoryNode, "clothingInInventory", Clothes, _clothingNodes, element => new Clothing(element));
        AddInventoryElements(inventoryNode, "weaponsInInventory", Weapons, _weaponNodes, element => new Weapon(element));
    }

    public void Add(InventoryElement element, XElement elementNode)
    {
        switch (element)
        {
            case Clothing clothing:
                Clothes.Add(clothing);
                _clothingNodes.Add(elementNode);
                break;
            case Item item:
                Items.Add(item);
                _itemNodes.Add(elementNode);
                break;
            case Weapon weapon:
                Weapons.Add(weapon);
                _weaponNodes.Add(elementNode);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(element), element, null);
        }
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

    private static void AddInventoryElements<T>(XElement inventoryNode, string childName, List<T> elementsList,
        List<XElement> elementNodesList, Func<XElement, T> constructor) where T : InventoryElement
    {
        var elementsInInventory = inventoryNode.Element(childName);
        if (elementsInInventory is null)
        {
            return;
        }

        var elements = elementsInInventory.Elements();
        foreach (var element in elements)
        {
            var elementObject = constructor(element);
            elementsList.Add(elementObject);
            elementNodesList.Add(element);
        }
    }
}