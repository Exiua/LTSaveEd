using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class NullableSpell(XElement spellUpgradesNode, string type) : NullableXmlAttribute(spellUpgradesNode)
{
    private XElement SpellUpgradesNode { get; } = spellUpgradesNode;
    private string Type { get; } = type;
    
    protected override XElement CreateElement()
    {
        var upgrade = new XElement("upgrade", new XAttribute("type", Type));
        SpellUpgradesNode.Add(upgrade);
        return upgrade;
    }
}