using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.CharacterData.InventoryData;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Inventory
{
    public XmlAttribute<int> Money { get; }
    public XmlAttribute<int> EssenceCount { get; }
    public List<Clothing> Clothes { get; } = [];
    public List<Item> Items { get; } = [];
    public List<Weapon> Weapons { get; } = [];

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