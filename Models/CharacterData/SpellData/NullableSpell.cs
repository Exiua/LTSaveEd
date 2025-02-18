using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class NullableSpell(XElement spellUpgradesNode, string type, string nodeName = "upgrade") : NullableXmlAttribute(spellUpgradesNode)
{
    private string Type { get; } = type;
    private string NodeName { get; } = nodeName;

    private XElement SpellUpgradesNode => Parent; // Makes the relationship a bit more clear
    
    protected override XElement CreateNode()
    {
        var upgrade = new XElement(NodeName, new XAttribute("type", Type));
        SpellUpgradesNode.Add(upgrade);
        return upgrade;
    }
}