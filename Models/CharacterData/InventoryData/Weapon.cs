using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.InventoryData;

public class Weapon : InventoryElement
{
    private readonly ValueDisplayPair[] _damageTypes =
    [
        new ValueDisplayPair("Physical", "PHYSICAL"), new ValueDisplayPair("Fire", "FIRE"),
        new ValueDisplayPair("Ice", "ICE"), new ValueDisplayPair("Poison", "POISON")
    ];
    
    private readonly ValueDisplayPair[] _damageTypesAlt = [new ValueDisplayPair("Lust", "LUST")];

    public ValueDisplayPair[] AvailableDamageTypes => DamageType.Value == "LUST"
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