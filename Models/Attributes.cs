using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models;

public class Attributes
{
    public XmlAttribute<float> HealthCore { get; } = null!;
    public XmlAttribute<float> ManaCore { get; } = null!;
    public XmlAttribute<float> Experience { get; } = null!;
    public XmlAttribute<float> ActionPoints { get; } = null!;
    public XmlAttribute<float> Arousal { get; } = null!;
    public XmlAttribute<float> LustCore { get; } = null!;
    public XmlAttribute<float> RestingLust { get; } = null!;
    public XmlAttribute<float> PhysiqueCore { get; } = null!;
    public XmlAttribute<float> ArcaneCore { get; } = null!;
    public XmlAttribute<float> CorruptionCore { get; } = null!;
    public XmlAttribute<float> EnchantmentLimit { get; } = null!;
    public XmlAttribute<float> Fertility { get; } = null!;
    public XmlAttribute<float> Virility { get; } = null!;
    public XmlAttribute<float> SpellCostModifier { get; } = null!;
    public XmlAttribute<float> CriticalDamage { get; } = null!;
    public XmlAttribute<float> EnergyShielding { get; } = null!;
    public XmlAttribute<float> PhysicalResistance { get; } = null!;
    public XmlAttribute<float> LustResistance { get; } = null!;
    public XmlAttribute<float> FireResistance { get; } = null!;
    public XmlAttribute<float> IceResistance { get; } = null!;
    public XmlAttribute<float> PoisonResistance { get; } = null!;
    public XmlAttribute<float> UnarmedDamage { get; } = null!;
    public XmlAttribute<float> MeleeDamage { get; } = null!;
    public XmlAttribute<float> RangedDamage { get; } = null!;
    public XmlAttribute<float> SpellDamage { get; } = null!;
    public XmlAttribute<float> PhysicalDamage { get; } = null!;
    public XmlAttribute<float> LustDamage { get; } = null!;
    public XmlAttribute<float> FireDamage { get; } = null!;
    public XmlAttribute<float> IceDamage { get; } = null!;
    public XmlAttribute<float> PoisonDamage { get; } = null!;

    public Attributes(XElement attributesNode)
    {
        var attributes = attributesNode.Elements("attribute");
        var typesSet = AttributeType.None;
        foreach (var attribute in attributes)
        {
            var type = attribute.GetAttributeValue<string>("type");
            switch (type)
            {
                case "HEALTH_MAXIMUM":
                    typesSet |= AttributeType.HealthCore;
                    HealthCore = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "MANA_MAXIMUM":
                    typesSet |= AttributeType.ManaCore;
                    ManaCore = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "EXPERIENCE":
                    typesSet |= AttributeType.Experience;
                    Experience = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "ACTION_POINTS":
                    typesSet |= AttributeType.ActionPoints;
                    ActionPoints = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "AROUSAL":
                    typesSet |= AttributeType.Arousal;
                    Arousal = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "LUST":
                    typesSet |= AttributeType.LustCore;
                    LustCore = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "RESTING_LUST":
                    typesSet |= AttributeType.RestingLust;
                    RestingLust = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "MAJOR_PHYSIQUE":
                    typesSet |= AttributeType.PhysiqueCore;
                    PhysiqueCore = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "MAJOR_ARCANE":
                    typesSet |= AttributeType.ArcaneCore;
                    ArcaneCore = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "MAJOR_CORRUPTION":
                    typesSet |= AttributeType.CorruptionCore;
                    CorruptionCore = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "ENCHANTMENT_LIMIT":
                    typesSet |= AttributeType.EnchantmentLimit;
                    EnchantmentLimit = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "FERTILITY":
                    typesSet |= AttributeType.Fertility;
                    Fertility = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "VIRILITY":
                    typesSet |= AttributeType.Virility;
                    Virility = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "SPELL_COST_MODIFIER":
                    typesSet |= AttributeType.SpellCostModifier;
                    SpellCostModifier = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "CRITICAL_DAMAGE":
                    typesSet |= AttributeType.CriticalDamage;
                    CriticalDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "ENERGY_SHIELDING":
                    typesSet |= AttributeType.EnergyShielding;
                    EnergyShielding = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "RESISTANCE_PHYSICAL":
                    typesSet |= AttributeType.PhysicalResistance;
                    PhysicalResistance = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "RESISTANCE_LUST":
                    typesSet |= AttributeType.LustResistance;
                    LustResistance = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "RESISTANCE_FIRE":
                    typesSet |= AttributeType.FireResistance;
                    FireResistance = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "RESISTANCE_ICE":
                    typesSet |= AttributeType.IceResistance;
                    IceResistance = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "RESISTANCE_POISON":
                    typesSet |= AttributeType.PoisonResistance;
                    PoisonResistance = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_UNARMED":
                    typesSet |= AttributeType.UnarmedDamage;
                    UnarmedDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_MELEE_WEAPON":
                    typesSet |= AttributeType.MeleeDamage;
                    MeleeDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_RANGED_WEAPON":
                    typesSet |= AttributeType.RangedDamage;
                    RangedDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_SPELLS":
                    typesSet |= AttributeType.SpellDamage;
                    SpellDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_PHYSICAL":
                    typesSet |= AttributeType.PhysicalDamage;
                    PhysicalDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_LUST":
                    typesSet |= AttributeType.LustDamage;
                    LustDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_FIRE":
                    typesSet |= AttributeType.FireDamage;
                    FireDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_ICE":
                    typesSet |= AttributeType.IceDamage;
                    IceDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
                case "DAMAGE_POISON":
                    typesSet |= AttributeType.PoisonDamage;
                    PoisonDamage = new XmlAttribute<float>(attribute.Attribute("value")!);
                    break;
            }
        }
        
        if ((typesSet & AttributeType.HealthCore) == 0)
        {
            HealthCore = CreateAttribute("HEALTH_MAXIMUM", attributesNode);
        }
        if ((typesSet & AttributeType.ManaCore) == 0)
        {
            ManaCore = CreateAttribute("MANA_MAXIMUM", attributesNode);
        }
        if ((typesSet & AttributeType.Experience) == 0)
        {
            Experience = CreateAttribute("EXPERIENCE", attributesNode);
        }
        if ((typesSet & AttributeType.ActionPoints) == 0)
        {
            ActionPoints = CreateAttribute("ACTION_POINTS", attributesNode);
        }
        if ((typesSet & AttributeType.Arousal) == 0)
        {
            Arousal = CreateAttribute("AROUSAL", attributesNode);
        }
        if ((typesSet & AttributeType.LustCore) == 0)
        {
            LustCore = CreateAttribute("LUST", attributesNode);
        }
        if ((typesSet & AttributeType.RestingLust) == 0)
        {
            RestingLust = CreateAttribute("RESTING_LUST", attributesNode);
        }
        if ((typesSet & AttributeType.PhysiqueCore) == 0)
        {
            PhysiqueCore = CreateAttribute("MAJOR_PHYSIQUE", attributesNode);
        }
        if ((typesSet & AttributeType.ArcaneCore) == 0)
        {
            ArcaneCore = CreateAttribute("MAJOR_ARCANE", attributesNode);
        }
        if ((typesSet & AttributeType.CorruptionCore) == 0)
        {
            CorruptionCore = CreateAttribute("MAJOR_CORRUPTION", attributesNode);
        }
        if ((typesSet & AttributeType.EnchantmentLimit) == 0)
        {
            EnchantmentLimit = CreateAttribute("ENCHANTMENT_LIMIT", attributesNode);
        }
        if ((typesSet & AttributeType.Fertility) == 0)
        {
            Fertility = CreateAttribute("FERTILITY", attributesNode);
        }
        if ((typesSet & AttributeType.Virility) == 0)
        {
            Virility = CreateAttribute("VIRILITY", attributesNode);
        }
        if ((typesSet & AttributeType.SpellCostModifier) == 0)
        {
            SpellCostModifier = CreateAttribute("SPELL_COST_MODIFIER", attributesNode);
        }
        if ((typesSet & AttributeType.CriticalDamage) == 0)
        {
            CriticalDamage = CreateAttribute("CRITICAL_DAMAGE", attributesNode);
        }
        if ((typesSet & AttributeType.EnergyShielding) == 0)
        {
            EnergyShielding = CreateAttribute("ENERGY_SHIELDING", attributesNode);
        }
        if ((typesSet & AttributeType.PhysicalResistance) == 0)
        {
            PhysicalResistance = CreateAttribute("RESISTANCE_PHYSICAL", attributesNode);
        }
        if ((typesSet & AttributeType.LustResistance) == 0)
        {
            LustResistance = CreateAttribute("RESISTANCE_LUST", attributesNode);
        }
        if ((typesSet & AttributeType.FireResistance) == 0)
        {
            FireResistance = CreateAttribute("RESISTANCE_FIRE", attributesNode);
        }
        if ((typesSet & AttributeType.IceResistance) == 0)
        {
            IceResistance = CreateAttribute("RESISTANCE_ICE", attributesNode);
        }
        if ((typesSet & AttributeType.PoisonResistance) == 0)
        {
            PoisonResistance = CreateAttribute("RESISTANCE_POISON", attributesNode);
        }
        if ((typesSet & AttributeType.UnarmedDamage) == 0)
        {
            UnarmedDamage = CreateAttribute("DAMAGE_UNARMED", attributesNode);
        }
        if ((typesSet & AttributeType.MeleeDamage) == 0)
        {
            MeleeDamage = CreateAttribute("DAMAGE_MELEE_WEAPON", attributesNode);
        }
        if ((typesSet & AttributeType.RangedDamage) == 0)
        {
            RangedDamage = CreateAttribute("DAMAGE_RANGED_WEAPON", attributesNode);
        }
        if ((typesSet & AttributeType.SpellDamage) == 0)
        {
            SpellDamage = CreateAttribute("DAMAGE_SPELLS", attributesNode);
        }
        if ((typesSet & AttributeType.PhysicalDamage) == 0)
        {
            PhysicalDamage = CreateAttribute("DAMAGE_PHYSICAL", attributesNode);
        }
        if ((typesSet & AttributeType.LustDamage) == 0)
        {
            LustDamage = CreateAttribute("DAMAGE_LUST", attributesNode);
        }
        if ((typesSet & AttributeType.FireDamage) == 0)
        {
            FireDamage = CreateAttribute("DAMAGE_FIRE", attributesNode);
        }
        if ((typesSet & AttributeType.IceDamage) == 0)
        {
            IceDamage = CreateAttribute("DAMAGE_ICE", attributesNode);
        }
        if ((typesSet & AttributeType.PoisonDamage) == 0)
        {
            PoisonDamage = CreateAttribute("DAMAGE_POISON", attributesNode);
        }
    }

    private static XmlAttribute<float> CreateAttribute(string type, XElement attributesNode)
    {
        var valueAttribute = new XAttribute("value", "0.0");
        var element = new XElement("attribute", new XAttribute("type", type), valueAttribute);
        attributesNode.Add(element);
        return new XmlAttribute<float>(valueAttribute);
    }
}

[Flags]
internal enum AttributeType
{
    None                = 0,
    HealthCore          = 1 << 0,
    ManaCore            = 1 << 1,
    Experience          = 1 << 2,
    ActionPoints        = 1 << 3,
    Arousal             = 1 << 4,
    LustCore            = 1 << 5,
    RestingLust         = 1 << 6,
    PhysiqueCore        = 1 << 7,
    ArcaneCore          = 1 << 8,
    CorruptionCore      = 1 << 9,
    EnchantmentLimit    = 1 << 10,
    Fertility           = 1 << 11,
    Virility            = 1 << 12,
    SpellCostModifier   = 1 << 13,
    CriticalDamage      = 1 << 14,
    EnergyShielding     = 1 << 15,
    PhysicalResistance  = 1 << 16,
    LustResistance      = 1 << 17,
    FireResistance      = 1 << 18,
    IceResistance       = 1 << 19,
    PoisonResistance    = 1 << 20,
    UnarmedDamage       = 1 << 21,
    MeleeDamage         = 1 << 22,
    RangedDamage        = 1 << 23,
    SpellDamage         = 1 << 24,
    PhysicalDamage      = 1 << 25,
    LustDamage          = 1 << 26,
    FireDamage          = 1 << 27,
    IceDamage           = 1 << 28,
    PoisonDamage        = 1 << 29
}