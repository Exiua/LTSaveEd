using System.Xml.Linq;

namespace LTSaveEd.Models;

public class Perks
{
    #region First Row Perks

    public PerkNode NaturalFitness { get; }
    public PerkNode LewdKnowledge { get; }
    public PerkNode NaturalArcanePower { get; }

    #endregion

    #region Second Row Perks
    
    public PerkNode PhysicallyFit { get; }
    public PerkNode Observant { get; }
    public PerkNode StableEnchantmentsPhysical { get; }
    public PerkNode Sterile { get; }
    public PerkNode Virile { get; }
    public PerkNode Seductive { get; }
    public PerkNode Fertile { get; }
    public PerkNode Barren { get; }
    public PerkNode StableEnchantmentsArcane { get; }
    public PerkNode ArcanePrecision { get; }
    public PerkNode ArcaneTraining { get; }

    #endregion
    
    #region Third Row Perks

    public PerkNode Defender { get; }
    public PerkNode EnergyReserves { get; }
    public PerkNode Striker { get; }
    public PerkNode StableEnchantmentsPhysicalPlus { get; }
    public PerkNode VirilePlus { get; }
    public PerkNode SeductivePlus { get; }
    public PerkNode OrgasmicLevelDrain { get; }
    public PerkNode Resistance { get; }
    public PerkNode FertilePlus { get; }
    public PerkNode StableEnchantmentsArcanePlus { get; }
    public PerkNode SpellPower { get; }
    public PerkNode AuraReserves { get; }
    public PerkNode SpellEfficiency { get; }

    #endregion
    
    #region Fourth Row Perks

    public PerkNode DefenderPlus { get; }
    public PerkNode EnergyReservesPlus { get; }
    public PerkNode StrikerPlus { get; }
    public PerkNode ArcaneSmith { get; }
    public PerkNode Seeder { get; }
    public PerkNode SeductivePlusPlus { get; }
    public PerkNode Ahegao { get; }
    public PerkNode ResistancePlus { get; }
    public PerkNode Broodmother { get; }
    public PerkNode ArcaneWeaver { get; }
    public PerkNode SpellPowerPlus { get; }
    public PerkNode AuraReservesPlus { get; }
    public PerkNode SpellEfficiencyPlus { get; }

    #endregion
    
    #region Fifth Row Perks

    public PerkNode CardioKing { get; }
    public PerkNode MartialArtist { get; }
    public PerkNode CriticalPowerPhysical { get; }
    public PerkNode HandToHand { get; }
    public PerkNode VirilePlusPlus { get; }
    public PerkNode VirilePlusx3 { get; }
    public PerkNode CriticalPowerLust { get; }
    public PerkNode FertilePlusx3 { get; }
    public PerkNode FertilePlusPlus { get; }
    public PerkNode ElementalStriker { get; }
    public PerkNode CriticalPowerArcane { get; }
    public PerkNode Chuuni { get; }
    public PerkNode ArcaneCombatant { get; }

    #endregion
    
    #region Sixth Row Perks

    public PerkNode Hypermobility { get; }
    public PerkNode SeductivePlusx3 { get; }
    public PerkNode Minx { get; }
    public PerkNode Ladykiller { get; }
    public PerkNode ArcaneAffinity { get; }

    #endregion
    
    #region Seventh Row Perks

    

    #endregion
    
    #region Eighth Row Perks

    

    #endregion
    
    #region Nineth Row Perks

    

    #endregion
    
    #region Tenth Row Perks

    

    #endregion
    
    #region Eleventh Row Perks

    

    #endregion
    
    #region Twelveth Row Perks

    

    #endregion
    
    public Perks(XElement perksNode)
    {
        NaturalFitness = new PerkNode("1", "PHYSICAL_BASE", "Natural Fitness", perksNode);
        NaturalArcanePower = new PerkNode("1", "ARCANE_BASE", "Natural Arcane Power", perksNode);
        LewdKnowledge = new PerkNode("1", "LEWD_KNOWLEDGE", "Lewd Knowledge", perksNode);
        
        PhysicallyFit = new PerkNode(NaturalFitness, "2", "PHYSIQUE_BOOST", "Physically Fit", perksNode);
        Observant = new PerkNode(NaturalFitness, "2", "OBSERVANT", "Observant", perksNode);
        StableEnchantmentsPhysical = new PerkNode(NaturalFitness, "2", "ENCHANTMENT_STABILITY", "Stable Enchantments", perksNode);
        Sterile = new PerkNode(LewdKnowledge, "2", "FIRING_BLANKS", "Sterile", perksNode);
        Virile = new PerkNode(LewdKnowledge, "2", "VIRILITY_BOOST", "Virile", perksNode);
        Seductive = new PerkNode(LewdKnowledge, "2", "SEDUCTION_BOOST", "Seductive", perksNode);
        Fertile = new PerkNode(LewdKnowledge, "2", "FERTILITY_BOOST", "Fertile", perksNode);
        Barren = new PerkNode(LewdKnowledge, "2", "BARREN", "Barren", perksNode);
        StableEnchantmentsArcane = new PerkNode(NaturalArcanePower, "2", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments", perksNode);
        ArcanePrecision = new PerkNode(NaturalArcanePower, "2", "ARCANE_CRITICALS", "Arcane Precision", perksNode);
        ArcaneTraining = new PerkNode(NaturalArcanePower, "2", "ARCANE_BOOST", "Arcane Training", perksNode);
        
        Defender = new PerkNode(PhysicallyFit, "3", "PHYSICAL_DEFENCE", "Defender", perksNode);
        EnergyReserves = new PerkNode(PhysicallyFit, "3", "ENERGY_BOOST", "Energy Reserves", perksNode);
        Striker = new PerkNode(PhysicallyFit, "3", "PHYSICAL_DAMAGE", "Striker", perksNode);
        StableEnchantmentsPhysicalPlus = new PerkNode(StableEnchantmentsPhysical, "3", "ENCHANTMENT_STABILITY", "Stable Enchantments", perksNode); //Physical
        VirilePlus = new PerkNode(Virile, "3", "VIRILITY_MAJOR_BOOST", "Virile", perksNode);
        SeductivePlus = new PerkNode(Seductive, "3", "SEDUCTION_BOOST", "Seductive", perksNode);
        OrgasmicLevelDrain = new PerkNode(Seductive, "3", "ORGASMIC_LEVEL_DRAIN", "Orgasmic Level Drain", perksNode);
        Resistance = new PerkNode(Seductive, "3", "SEDUCTION_DEFENCE_BOOST", "Resistance", perksNode);
        FertilePlus = new PerkNode(Fertile, "3", "FERTILITY_MAJOR_BOOST", "Fertile", perksNode);
        StableEnchantmentsArcanePlus = new PerkNode(StableEnchantmentsArcane, "3", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments", perksNode); //Arcane
        SpellPower = new PerkNode(ArcaneTraining, "3", "SPELL_DAMAGE", "Spell Power", perksNode);
        AuraReserves = new PerkNode(ArcaneTraining, "3", "AURA_BOOST", "Aura Reserves", perksNode);
        SpellEfficiency = new PerkNode(ArcaneTraining, "3", "SPELL_EFFICIENCY", "Spell Efficiency", perksNode);
        
        DefenderPlus = new PerkNode(Defender, "4", "PHYSICAL_DEFENCE", "Defender", perksNode);
        EnergyReservesPlus = new PerkNode(EnergyReserves, "4", "ENERGY_BOOST", "Energy Reserves", perksNode);
        StrikerPlus = new PerkNode(Striker, "4", "PHYSICAL_DAMAGE", "Striker", perksNode);
        ArcaneSmith = new PerkNode(StableEnchantmentsPhysicalPlus, "4", "WEAPON_ENCHANTER", "Arcane Smith", perksNode);
        Seeder = new PerkNode(VirilePlus, "4", "FETISH_SEEDER", "Seeder", perksNode);
        SeductivePlusPlus = new PerkNode(SeductivePlus, "4", "SEDUCTION_BOOST", "Seductive", perksNode);
        ResistancePlus = new PerkNode(Resistance, "4", "SEDUCTION_DEFENCE_BOOST", "Resistance", perksNode); // 4_8
        Ahegao = new PerkNode(SeductivePlusPlus, ResistancePlus, "4", "AHEGAO", "Ahegao", perksNode); // 4_7
        Broodmother = new PerkNode(FertilePlus, "4", "FETISH_BROODMOTHER", "Broodmother", perksNode);
        ArcaneWeaver = new PerkNode(StableEnchantmentsArcanePlus, "4", "CLOTHING_ENCHANTER", "Arcane Weaver", perksNode);
        SpellPowerPlus = new PerkNode(SpellPower, "4", "SPELL_DAMAGE", "Spell Power", perksNode);
        AuraReservesPlus = new PerkNode(AuraReserves, "4", "AURA_BOOST", "Aura Reserves", perksNode);
        SpellEfficiencyPlus = new PerkNode(SpellEfficiency, "4", "SPELL_EFFICIENCY", "Spell Efficiency", perksNode);
        
        CardioKing = new PerkNode(DefenderPlus, EnergyReservesPlus, "5", "RUNNER_2", "Cardio King", perksNode);
        HandToHand = new PerkNode(StrikerPlus, "5", "UNARMED_DAMAGE", "Hand-to-Hand", perksNode);                  // 5_4
        CriticalPowerPhysical = new PerkNode(HandToHand, "5", "CRITICAL_BOOST", "Critical Power", perksNode);      // 5_3
        MartialArtist = new PerkNode(CriticalPowerPhysical, "5", "UNARMED_TRAINING", "Martial Artist", perksNode); // 5_2
        VirilePlusPlus = new PerkNode(Seeder, "5", "VIRILITY_BOOST", "Virile", perksNode);
        VirilePlusx3 = new PerkNode(VirilePlusPlus, "5", "VIRILITY_MAJOR_BOOST", "Virile", perksNode);
        CriticalPowerLust = new PerkNode(SeductivePlusPlus, ResistancePlus, "5", "CRITICAL_BOOST_LUST", "Critical Power", perksNode);
        FertilePlusPlus = new PerkNode(Broodmother, "5", "FERTILITY_BOOST", "Fertile", perksNode);         // 5_9
        FertilePlusx3 = new PerkNode(FertilePlusPlus, "5", "FERTILITY_MAJOR_BOOST", "Fertile", perksNode); // 5_8
        ElementalStriker = new PerkNode(SpellPowerPlus, "5", "ELEMENTAL_BOOST", "Elemental Striker", perksNode);
        CriticalPowerArcane = new PerkNode(ElementalStriker, "5", "CRITICAL_BOOST_ARCANE", "Critical Power", perksNode);
        Chuuni = new PerkNode(CriticalPowerArcane, "5", "CHUUNI", "Chuuni", perksNode);
        ArcaneCombatant = new PerkNode(AuraReservesPlus, SpellEfficiencyPlus, "5", "ARCANE_COMBATANT", "Arcane Combatant", perksNode);
        
        PhysicallyFitPlus = new PerkNode(CardioKing, HandToHand, "6", "PHYSIQUE_BOOST_MAJOR", "Physically Fit", perksNode);
        Hypermobility = new PerkNode(PhysicallyFitPlus, "6", "HYPERMOBILITY", "Hypermobility", perksNode);
        SeductivePlusx3 = new PerkNode(CriticalPowerLust, "6", "SEDUCTION_BOOST_MAJOR", "Seductive", perksNode);    // 6_4
        Minx = new PerkNode(SeductivePlusx3, "6", "MALE_ATTRACTION", "Minx", perksNode);                            // 6_3
        Ladykiller = new PerkNode(SeductivePlusx3, "6", "FEMALE_ATTRACTION", "Ladykiller", perksNode);
        ArcaneAffinity = new PerkNode(ElementalStriker, ArcaneCombatant, "6", "ARCANE_BOOST_MAJOR", "Arcane Affinity", perksNode);
    }
}