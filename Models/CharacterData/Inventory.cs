using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Inventory(XElement inventoryNode)
{
    public XmlAttribute<int> Money { get; } = new(inventoryNode.GetChildsAttributeNode("money"));
    public XmlAttribute<int> EssenceCount { get; } = new(inventoryNode.GetChildsAttributeNode("essenceCount"));
}