using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.InventoryData;

public class Weapon : InventoryElement
{

    public XmlAttribute<string> CoreEnchantment { get; }
    public XmlAttribute<string> DamageType { get; }
    
    public Weapon(XElement weaponNode) : base(weaponNode)
    {
        CoreEnchantment = new XmlAttribute<string>(weaponNode.Attribute("coreEnchantment")!);
        DamageType = new XmlAttribute<string>(weaponNode.Attribute("damageType")!);
    }
}