using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.InventoryData.Weapons;

public class Weapon : InventoryElement
{
    private readonly ValueDisplayPair<string>[] _damageTypes =
    [
        new("Physical", "PHYSICAL"), new("Fire", "FIRE"),
        new("Ice", "ICE"), new("Poison", "POISON")
    ];
    
    private readonly Dictionary<string, ValueDisplayPair<string>[]> _damageTypeLookup = new()
    {
        {"PHYSICAL", [new ValueDisplayPair<string>("Physical", "PHYSICAL")]},
        {"FIRE", [new ValueDisplayPair<string>("Fire", "FIRE")]},
        {"ICE", [new ValueDisplayPair<string>("Ice", "ICE")]},
        {"POISON", [new ValueDisplayPair<string>("Poison", "POISON")]},
        {"LUST", [new ValueDisplayPair<string>("Lust", "LUST")]}
    };

    public ValueDisplayPair<string>[] AvailableDamageTypes =>
        CoreEnchantment.Value switch
        {
            "null" => _damageTypeLookup[DamageType.Value],
            "DAMAGE_LUST" => _damageTypeLookup["LUST"],
            _ => _damageTypes
        };

    public XmlAttribute<string> CoreEnchantment { get; }
    public XmlAttribute<string> DamageType { get; }
    
    public Weapon(XElement weaponNode) : base(weaponNode)
    {
        CoreEnchantment = new XmlAttribute<string>(weaponNode.Attribute("coreEnchantment")!);
        DamageType = new XmlAttribute<string>(weaponNode.Attribute("damageType")!);
    }
}