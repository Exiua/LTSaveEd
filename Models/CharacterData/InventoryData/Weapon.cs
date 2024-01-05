using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.InventoryData;

public class Weapon : InventoryElement
{
    private readonly ValueDisplayPair<string>[] _damageTypes =
    [
        new ValueDisplayPair<string>("Physical", "PHYSICAL"), new ValueDisplayPair<string>("Fire", "FIRE"),
        new ValueDisplayPair<string>("Ice", "ICE"), new ValueDisplayPair<string>("Poison", "POISON")
    ];
    
    private readonly ValueDisplayPair<string>[] _damageTypesAlt = [new ValueDisplayPair<string>("Lust", "LUST")];

    public ValueDisplayPair<string>[] AvailableDamageTypes => DamageType.Value == "LUST"
        ? _damageTypesAlt
        : _damageTypes;
    
    public XmlAttribute<string> CoreEnchantment { get; }
    public XmlAttribute<string> DamageType { get; }
    
    public Weapon(XElement weaponNode) : base(weaponNode)
    {
        CoreEnchantment = new XmlAttribute<string>(weaponNode.Attribute("coreEnchantment")!);
        DamageType = new XmlAttribute<string>(weaponNode.Attribute("damageType")!);
    }
}