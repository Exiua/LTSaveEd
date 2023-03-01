using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Models.CharacterModel.Elements;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel;

public class CharacterAttributes
{
    private readonly FloatElement _healthCore;
    private readonly FloatElement _manaCore;
    private readonly FloatElement _experience;
    private readonly FloatElement _actionPoints;
    private readonly FloatElement _arousal;
    private readonly FloatElement _lustCore;
    private readonly FloatElement _restingLust;
    private readonly FloatElement _physiqueCore;
    private readonly FloatElement _arcaneCore;
    private readonly FloatElement _corruptionCore;
    private readonly FloatElement _enchantmentLimit;
    private readonly FloatElement _fertility;
    private readonly FloatElement _virility;
    private readonly FloatElement _spellCostModifier;
    private readonly FloatElement _criticalDamage;
    private readonly FloatElement _energyShielding;
    private readonly FloatElement _physicalResistance;
    private readonly FloatElement _lustResistance;
    private readonly FloatElement _fireResistance;
    private readonly FloatElement _iceResistance;
    private readonly FloatElement _poisonResistance;
    private readonly FloatElement _unarmedDamage;
    private readonly FloatElement _meleeDamage;
    private readonly FloatElement _rangedDamage;
    private readonly FloatElement _spellDamage;
    private readonly FloatElement _physicalDamage;
    private readonly FloatElement _lustDamage;
    private readonly FloatElement _fireDamage;
    private readonly FloatElement _iceDamage;
    private readonly FloatElement _poisonDamage;
    
    public float HealthCore { get => _healthCore.Value; set => _healthCore.Value = value; }
    public float ManaCore { get => _manaCore.Value; set => _manaCore.Value = value; }
    public float Experience { get => _experience.Value; set => _experience.Value = value; }
    public float ActionPoints { get => _actionPoints.Value; set => _actionPoints.Value = value; }
    public float Arousal { get => _arousal.Value; set => _arousal.Value = value; }
    public float LustCore { get => _lustCore.Value; set => _lustCore.Value = value; }
    public float RestingLust { get => _restingLust.Value; set => _restingLust.Value = value; }
    public float PhysiqueCore { get => _physiqueCore.Value; set => _physiqueCore.Value = value; }
    public float ArcaneCore { get => _arcaneCore.Value; set => _arcaneCore.Value = value; }
    public float CorruptionCore { get => _corruptionCore.Value; set => _corruptionCore.Value = value; }
    public float EnchantmentLimit { get => _enchantmentLimit.Value; set => _enchantmentLimit.Value = value; }
    public float Fertility { get => _fertility.Value; set => _fertility.Value = value; }
    public float Virility { get => _virility.Value; set => _virility.Value = value; }
    public float SpellCostModifier { get => _spellCostModifier.Value; set => _spellCostModifier.Value = value; }
    public float CriticalDamage { get => _criticalDamage.Value; set => _criticalDamage.Value = value; }
    public float EnergyShielding { get => _energyShielding.Value; set => _energyShielding.Value = value; }
    public float PhysicalResistance { get => _physicalResistance.Value; set => _physicalResistance.Value = value; }
    public float LustResistance { get => _lustResistance.Value; set => _lustResistance.Value = value; }
    public float FireResistance { get => _fireResistance.Value; set => _fireResistance.Value = value; }
    public float IceResistance { get => _iceResistance.Value; set => _iceResistance.Value = value; }
    public float PoisonResistance { get => _poisonResistance.Value; set => _poisonResistance.Value = value; }
    public float UnarmedDamage { get => _unarmedDamage.Value; set => _unarmedDamage.Value = value; }
    public float MeleeDamage { get => _meleeDamage.Value; set => _meleeDamage.Value = value; }
    public float RangedDamage { get => _rangedDamage.Value; set => _rangedDamage.Value = value; }
    public float SpellDamage { get => _spellDamage.Value; set => _spellDamage.Value = value; }
    public float PhysicalDamage { get => _physicalDamage.Value; set => _physicalDamage.Value = value; }
    public float LustDamage { get => _lustDamage.Value; set => _lustDamage.Value = value; }
    public float FireDamage { get => _fireDamage.Value; set => _fireDamage.Value = value; }
    public float IceDamage { get => _iceDamage.Value; set => _iceDamage.Value = value; }
    public float PoisonDamage { get => _poisonDamage.Value; set => _poisonDamage.Value = value; }

    public CharacterAttributes(XElement attributesElement)
    {
        if (attributesElement.Name != "attributes")
        {
            throw new IncorrectElementException(attributesElement);
        }

        var attributes = attributesElement.Elements();
        foreach (var attribute in attributes)
        {
            switch (attribute.Attribute("type")?.Value)
            {
                case "HEALTH_MAXIMUM":
                    _healthCore = new FloatElement(attribute, () => CreateElement("HEALTH_MAXIMUM"), true);
                    break;
                case "MANA_MAXIMUM":
                    _manaCore = new FloatElement(attribute, () => CreateElement("MANA_MAXIMUM"), true);
                    break;
                case "EXPERIENCE":
                    _experience = new FloatElement(attribute, () => CreateElement("EXPERIENCE"), true);
                    break;
                case "ACTION_POINTS":
                    _actionPoints = new FloatElement(attribute, () => CreateElement("ACTION_POINTS"), true);
                    break;
                case "AROUSAL":
                    _arousal = new FloatElement(attribute, () => CreateElement("AROUSAL"), true);
                    break;
                case "LUST":
                    _lustCore = new FloatElement(attribute, () => CreateElement("LUST"), true);
                    break;
                case "RESTING_LUST":
                    _restingLust = new FloatElement(attribute, () => CreateElement("RESTING_LUST"), true);
                    break;
                case "MAJOR_PHYSIQUE":
                    _physiqueCore = new FloatElement(attribute, () => CreateElement("MAJOR_PHYSIQUE"), true);
                    break;
                case "MAJOR_ARCANE":
                    _arcaneCore = new FloatElement(attribute, () => CreateElement("MAJOR_ARCANE"), true);
                    break;
                case "MAJOR_CORRUPTION":
                    _corruptionCore = new FloatElement(attribute, () => CreateElement("MAJOR_CORRUPTION"), true);
                    break;
                case "ENCHANTMENT_LIMIT":
                    _enchantmentLimit = new FloatElement(attribute, () => CreateElement("ENCHANTMENT_LIMIT"), true);
                    break;
                case "FERTILITY":
                    _fertility = new FloatElement(attribute, () => CreateElement("FERTILITY"), true);
                    break;
                case "VIRILITY":
                    _virility = new FloatElement(attribute, () => CreateElement("VIRILITY"), true);
                    break;
                case "SPELL_COST_MODIFIER":
                    _spellCostModifier = new FloatElement(attribute, () => CreateElement("SPELL_COST_MODIFIER"), true);
                    break;
                case "CRITICAL_DAMAGE":
                    _criticalDamage = new FloatElement(attribute, () => CreateElement("CRITICAL_DAMAGE"), true);
                    break;
                case "ENERGY_SHIELDING":
                    _energyShielding = new FloatElement(attribute, () => CreateElement("ENERGY_SHIELDING"), true);
                    break;
                case "RESISTANCE_PHYSICAL":
                    _physicalResistance = new FloatElement(attribute, () => CreateElement("RESISTANCE_PHYSICAL"), true);
                    break;
                case "RESISTANCE_LUST":
                    _lustResistance = new FloatElement(attribute, () => CreateElement("RESISTANCE_LUST"), true);
                    break;
                case "RESISTANCE_FIRE":
                    _fireResistance = new FloatElement(attribute, () => CreateElement("RESISTANCE_FIRE"), true);
                    break;
                case "RESISTANCE_ICE":
                    _iceResistance = new FloatElement(attribute, () => CreateElement("RESISTANCE_ICE"), true);
                    break;
                case "RESISTANCE_POISON":
                    _poisonResistance = new FloatElement(attribute, () => CreateElement("RESISTANCE_POISON"), true);
                    break;
                case "DAMAGE_UNARMED":
                    _unarmedDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_UNARMED"), true);
                    break;
                case "DAMAGE_MELEE_WEAPON":
                    _meleeDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_MELEE_WEAPON"), true);
                    break;
                case "DAMAGE_RANGED_WEAPON":
                    _rangedDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_RANGED_WEAPON"), true);
                    break;
                case "DAMAGE_SPELLS":
                    _spellDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_SPELLS"), true);
                    break;
                case "DAMAGE_PHYSICAL":
                    _physicalDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_PHYSICAL"), true);
                    break;
                case "DAMAGE_LUST":
                    _lustDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_LUST"), true);
                    break;
                case "DAMAGE_FIRE":
                    _fireDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_FIRE"), true);
                    break;
                case "DAMAGE_ICE":
                    _iceDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_ICE"), true);
                    break;
                case "DAMAGE_POISON":
                    _poisonDamage = new FloatElement(attribute, () => CreateElement("DAMAGE_POISON"), true);
                    break;
            }
        }
        
        // Assign if null
        _healthCore ??= new FloatElement(attributesElement, () => CreateElement("HEALTH_MAXIMUM"));
        _manaCore ??= new FloatElement(attributesElement, () => CreateElement("MANA_MAXIMUM"));
        _experience ??= new FloatElement(attributesElement, () => CreateElement("EXPERIENCE"));
        _actionPoints ??= new FloatElement(attributesElement, () => CreateElement("ACTION_POINTS"));
        _arousal ??= new FloatElement(attributesElement, () => CreateElement("AROUSAL"));
        _lustCore ??= new FloatElement(attributesElement, () => CreateElement("LUST"));
        _restingLust ??= new FloatElement(attributesElement, () => CreateElement("RESTING_LUST"));
        _physiqueCore ??= new FloatElement(attributesElement, () => CreateElement("MAJOR_PHYSIQUE"));
        _arcaneCore ??= new FloatElement(attributesElement, () => CreateElement("MAJOR_ARCANE"));
        _corruptionCore ??= new FloatElement(attributesElement, () => CreateElement("MAJOR_CORRUPTION"));
        _enchantmentLimit ??= new FloatElement(attributesElement, () => CreateElement("ENCHANTMENT_LIMIT"));
        _fertility ??= new FloatElement(attributesElement, () => CreateElement("FERTILITY"));
        _virility ??= new FloatElement(attributesElement, () => CreateElement("VIRILITY"));
        _spellCostModifier ??= new FloatElement(attributesElement, () => CreateElement("SPELL_COST_MODIFIER"));
        _criticalDamage ??= new FloatElement(attributesElement, () => CreateElement("CRITICAL_DAMAGE"));
        _energyShielding ??= new FloatElement(attributesElement, () => CreateElement("ENERGY_SHIELDING"));
        _physicalResistance ??= new FloatElement(attributesElement, () => CreateElement("RESISTANCE_PHYSICAL"));
        _lustResistance ??= new FloatElement(attributesElement, () => CreateElement("RESISTANCE_LUST"));
        _fireResistance ??= new FloatElement(attributesElement, () => CreateElement("RESISTANCE_FIRE"));
        _iceResistance ??= new FloatElement(attributesElement, () => CreateElement("RESISTANCE_ICE"));
        _poisonResistance ??= new FloatElement(attributesElement, () => CreateElement("RESISTANCE_POISON"));
        _unarmedDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_UNARMED"));
        _meleeDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_MELEE_WEAPON"));
        _rangedDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_RANGED_WEAPON"));
        _spellDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_SPELLS"));
        _physicalDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_PHYSICAL"));
        _lustDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_LUST"));
        _fireDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_FIRE"));
        _iceDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_ICE"));
        _poisonDamage ??= new FloatElement(attributesElement, () => CreateElement("DAMAGE_POISON"));
    }

    private XElement CreateElement(string elementType)
    {
        return new XElement("attribute", new XAttribute("type", elementType), new XAttribute("value", "1.0"));
    }
}