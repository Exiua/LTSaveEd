using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class Inventory(XElement inventoryNode)
{
    public XmlAttribute<int> Money { get; } = new(inventoryNode.GetChildsAttributeNode("money"));
    public XmlAttribute<int> EssenceCount { get; } = new(inventoryNode.GetChildsAttributeNode("essenceCount"));
}