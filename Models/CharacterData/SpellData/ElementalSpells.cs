using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.SpellData;

public abstract class ElementalSpells(XElement knownSpellsNode, XElement spellUpgradesNode)
{
    protected XElement KnownSpellsNode { get; } = knownSpellsNode;
    protected XElement SpellUpgradesNode { get; } = spellUpgradesNode;
    public XmlAttribute<int> UpgradePoints { get; protected init; } = null!;

    protected static XmlAttribute<int> GetUpgradePointNode(XElement spellUpgradePointsNode, string schoolName)
    {
        var spellUpgradePoints = spellUpgradePointsNode.Elements();
        foreach (var upgradePoint in spellUpgradePoints)
        {
            if (upgradePoint.GetAttributeValue<string>("school") == schoolName)
            {
                return new XmlAttribute<int>(upgradePoint.Attribute("points")!);
            }
        }

        var pointAttribute = new XAttribute("points", 0);
        var upgradeEntry = new XElement("upgradeEntry", pointAttribute, new XAttribute("school", schoolName));
        spellUpgradePointsNode.Add(upgradeEntry);
        return new XmlAttribute<int>(pointAttribute);
    }
}