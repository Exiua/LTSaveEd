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

    public PerkNode PhysicallyFitPlus { get;}
    public PerkNode Hypermobility { get; }
    public PerkNode Minx { get; }
    public PerkNode SeductivePlusx3 { get; }
    public PerkNode Ladykiller { get; }
    public PerkNode ArcaneAffinity { get; }

    #endregion
    
    #region Seventh Row Perks

    public PerkNode StrikerPlusPlus { get; }
    public PerkNode HandToHandPlus { get; }
    public PerkNode AuraShielding { get; }
    public PerkNode EnergyReservesPlusPlus { get; }
    public PerkNode SeductiveLeftBranch { get; }
    public PerkNode SeductiveMiddleBranch { get; }
    public PerkNode ResistancePlusPlus { get; }
    public PerkNode AuraReservesPlusPlus { get; }
    public PerkNode SpellEfficiencyPlusPlus { get; }
    public PerkNode SpellPowerPlusPlus { get; }

    #endregion
    
    #region Eighth Row Perks

    public PerkNode StrikerPlusx3  { get; }
    public PerkNode MeleeWeaponsExpert  { get; }
    public PerkNode DefenderPlusPlus  { get; }
    public PerkNode EnergyReservesPlusx3  { get; }
    public PerkNode SeductivePlusLeftBranch  { get; }
    public PerkNode IrresistibleAppeals  { get; }
    public PerkNode SeductivePlusMiddleBranch  { get; }
    public PerkNode ObjectOfDesire  { get; }
    public PerkNode ResistancePlusx3  { get; }
    public PerkNode AuraReservesPlusx3  { get; }
    public PerkNode SpellEfficiencyPlusx3  { get; }
    public PerkNode SpellPowerPlusx3  { get; }

    #endregion
    
    #region Nineth Row Perks

    public PerkNode StrikerPlusx4  { get; }
    public PerkNode SharpShooter  { get; }
    public PerkNode DefenderPlusx3  { get; }
    public PerkNode EnergyReservesPlusx4  { get; }
    public PerkNode SeductivePlusPlusLeftBranch  { get; }
    public PerkNode SeductivePlusPlusMiddleBranch  { get; }
    public PerkNode ResistancePlusx4  { get; }
    public PerkNode AuraReservesPlusx4  { get; }
    public PerkNode SpellEfficiencyPlusx4  { get; }
    public PerkNode SpellMastery  { get; }

    #endregion
    
    #region Tenth Row Perks

    public PerkNode FerociousWarrior  { get; }
    public PerkNode Berserk  { get; }
    public PerkNode CombatRegeneration  { get; }
    public PerkNode Lustpyre  { get; }
    public PerkNode Nymphomaniac  { get; }
    public PerkNode PureThoughts  { get; }
    public PerkNode SacrificialShielding  { get; }
    public PerkNode SpellEfficiencyPlusx5  { get; }
    public PerkNode ArcaneVampyrism  { get; }

    #endregion
    
    #region Eleventh Row Perks

    public PerkNode MeleeWeaponsExpertPlus  { get; }
    public PerkNode PhysicallyFitPlusPlus  { get; }
    public PerkNode SharpShooterPlus  { get; }
    public PerkNode SeductivePlusx4  { get; }
    public PerkNode ElementalDefender  { get; }
    public PerkNode ArcaneAffinityPlus  { get; }
    public PerkNode ElementalStrikerPlus  { get; }

    #endregion
    
    #region Twelveth Row Perks

    public PerkNode ElementalStrikerPhysical  { get; }
    public PerkNode ElementalStrikerSeductive  { get; }
    public PerkNode ElementalStrikerArcane  { get; }

    #endregion

    private Dictionary<string, PerkNode[]> LookupCache { get; }
    
    public Perks(XElement perksNode)
    {
        #region Property Fields Intialization
        
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
        
        StrikerPlusPlus = new PerkNode(PhysicallyFitPlus, "7", "PHYSICAL_DAMAGE", "Striker", perksNode);
        HandToHandPlus = new PerkNode(StrikerPlusPlus, "7", "UNARMED_DAMAGE", "Hand-to-Hand", perksNode);
        EnergyReservesPlusPlus = new PerkNode(PhysicallyFitPlus, "7", "ENERGY_BOOST", "Energy Reserves", perksNode);         // 7_4
        AuraShielding = new PerkNode(EnergyReservesPlusPlus, "7", "ENERGY_BOOST_DRAIN_DAMAGE", "Aura Shielding", perksNode); // 7_3
        SeductiveLeftBranch = new PerkNode(SeductivePlusx3, "7", "SEDUCTION_BOOST", "Seductive", perksNode);                 // Left Branch
        SeductiveMiddleBranch = new PerkNode(SeductivePlusx3, "7", "SEDUCTION_BOOST_ALT", "Seductive", perksNode);           // Middle Branch
        ResistancePlusPlus = new PerkNode(SeductivePlusx3, "7", "SEDUCTION_DEFENCE_BOOST", "Resistance", perksNode);
        AuraReservesPlusPlus = new PerkNode(ArcaneAffinity, "7", "AURA_BOOST", "Aura Reserves", perksNode);
        SpellEfficiencyPlusPlus = new PerkNode(ArcaneAffinity, "7", "SPELL_EFFICIENCY", "Spell Efficiency", perksNode);
        SpellPowerPlusPlus = new PerkNode(SpellEfficiencyPlusPlus, "7", "SPELL_DAMAGE", "Spell Power", perksNode);
        
        StrikerPlusx3 = new PerkNode(StrikerPlusPlus, "8", "PHYSICAL_DAMAGE", "Striker", perksNode);
        MeleeWeaponsExpert = new PerkNode(StrikerPlusx3, "8", "MELEE_DAMAGE", "Melee Weapons Expert", perksNode);
        DefenderPlusPlus = new PerkNode(EnergyReservesPlusPlus, "8", "PHYSICAL_DEFENCE", "Defender", perksNode);
        EnergyReservesPlusx3 = new PerkNode(EnergyReservesPlusPlus, "8", "ENERGY_BOOST", "Energy Reserves", perksNode);
        SeductivePlusLeftBranch = new PerkNode(SeductiveLeftBranch, "8", "SEDUCTION_BOOST", "Seductive", perksNode);
        SeductivePlusMiddleBranch = new PerkNode(SeductiveMiddleBranch, "8", "SEDUCTION_BOOST_MAJOR", "Seductive", perksNode);        // 8_7
        IrresistibleAppeals = new PerkNode(SeductivePlusMiddleBranch, "8", "CONVINCING_REQUESTS", "Irresistible Appeals", perksNode); // 8_6
        ObjectOfDesire = new PerkNode(SeductivePlusMiddleBranch, "8", "OBJECT_OF_DESIRE", "Object of Desire", perksNode);
        ResistancePlusx3 = new PerkNode(ResistancePlusPlus, "8", "SEDUCTION_DEFENCE_BOOST", "Resistance", perksNode);
        AuraReservesPlusx3 = new PerkNode(AuraReservesPlusPlus, "8", "AURA_BOOST", "Aura Reserves", perksNode);
        SpellEfficiencyPlusx3 = new PerkNode(SpellEfficiencyPlusPlus, "8", "SPELL_EFFICIENCY", "Spell Efficiency", perksNode);
        SpellPowerPlusx3 = new PerkNode(SpellPowerPlusPlus, "8", "SPELL_DAMAGE", "Spell Power", perksNode);
        
        StrikerPlusx4 = new PerkNode(StrikerPlusx3, "9", "PHYSICAL_DAMAGE", "Striker", perksNode);
        SharpShooter = new PerkNode(StrikerPlusx4, "9", "RANGED_DAMAGE", "Sharp-shooter", perksNode);
        DefenderPlusx3 = new PerkNode(DefenderPlusPlus, "9", "PHYSICAL_DEFENCE", "Defender", perksNode);
        EnergyReservesPlusx4 = new PerkNode(EnergyReservesPlusx3, "9", "ENERGY_BOOST", "Energy Reserves", perksNode);
        SeductivePlusPlusLeftBranch = new PerkNode(SeductivePlusLeftBranch, "9", "SEDUCTION_BOOST", "Seductive", perksNode);         //Left Branch
        SeductivePlusPlusMiddleBranch = new PerkNode(SeductivePlusMiddleBranch, "9", "SEDUCTION_BOOST_ALT", "Seductive", perksNode); //Middle Branch
        ResistancePlusx4 = new PerkNode(ResistancePlusx3, "9", "SEDUCTION_DEFENCE_BOOST", "Resistance", perksNode);
        SpellEfficiencyPlusx4 = new PerkNode(SpellEfficiencyPlusx3, "9", "SPELL_EFFICIENCY", "Spell Efficiency", perksNode); // 9_9
        AuraReservesPlusx4 = new PerkNode(SpellEfficiencyPlusx4, "9", "AURA_BOOST", "Aura Reserves", perksNode);             // 9_8
        SpellMastery = new PerkNode(SpellPowerPlusx3, "9", "SPELL_DAMAGE_MAJOR", "Spell Mastery", perksNode);
        
        FerociousWarrior = new PerkNode(StrikerPlusx4, "10", "FEROCIOUS_WARRIOR", "Ferocious Warrior", perksNode);
        Berserk = new PerkNode(FerociousWarrior, "10", "BESERK", "Berserk", perksNode);
        CombatRegeneration = new PerkNode(DefenderPlusx3, EnergyReservesPlusx4, "10", "COMBAT_REGENERATION", "Combat Regeneration", perksNode);
        Lustpyre = new PerkNode(SeductivePlusPlusLeftBranch, "10", "LUSTPYRE", "Lustpyre", perksNode);
        Nymphomaniac = new PerkNode(SeductivePlusPlusMiddleBranch, "10", "NYMPHOMANIAC", "Nymphomaniac", perksNode);
        PureThoughts = new PerkNode(ResistancePlusx4, "10", "PURE_MIND", "Pure Thoughts", perksNode);
        SacrificialShielding = new PerkNode(AuraReservesPlusx4, "10", "SACRIFICIAL_SHIELDING", "Sacrificial Shielding", perksNode);
        SpellEfficiencyPlusx5 = new PerkNode(SpellEfficiencyPlusx4, "10", "SPELL_EFFICIENCY", "Spell Efficiency", perksNode);
        ArcaneVampyrism = new PerkNode(SpellMastery, "10", "ARCANE_VAMPYRISM", "Arcane Vampyrism", perksNode);
        
        PhysicallyFitPlusPlus = new PerkNode(FerociousWarrior, CombatRegeneration, "11", "PHYSIQUE_BOOST_MAJOR", "Physically Fit", perksNode); // 11_2
        MeleeWeaponsExpertPlus = new PerkNode(PhysicallyFitPlusPlus, "11", "MELEE_DAMAGE", "Melee Weapons Expert", perksNode);                                  // 11_1
        SharpShooterPlus = new PerkNode(PhysicallyFitPlusPlus, "11", "RANGED_DAMAGE", "Sharp-shooter", perksNode);
        SeductivePlusx4 = new PerkNode(Lustpyre, PureThoughts, "11", "SEDUCTION_BOOST_MAJOR", "Seductive", perksNode);
        ArcaneAffinityPlus = new PerkNode(SpellEfficiencyPlusx5, "11", "ARCANE_BOOST_MAJOR", "Arcane Affinity", perksNode);     // 11_6
        ElementalDefender = new PerkNode(ArcaneAffinityPlus, "11", "ELEMENTAL_DEFENCE_BOOST", "Elemental Defender", perksNode); // 11_5
        ElementalStrikerPlus = new PerkNode(ArcaneAffinityPlus, "11", "ELEMENTAL_BOOST", "Elemental Striker", perksNode);
        
        ElementalStrikerPhysical = new PerkNode(PhysicallyFitPlusPlus, "12", "ELEMENTAL_BOOST", "Elemental Striker", perksNode);  //Physical
        ElementalStrikerSeductive = new PerkNode(SeductivePlusx4, "12", "ELEMENTAL_BOOST_ALT", "Elemental Striker", perksNode);   //Seductive
        ElementalStrikerArcane = new PerkNode(ArcaneAffinityPlus, "12", "ELEMENTAL_BOOST_ALT_2", "Elemental Striker", perksNode); // Arcane
        
        #endregion

        LookupCache = new Dictionary<string, PerkNode[]>
        {
            {
                "1", new[]
                {
                    NaturalFitness, LewdKnowledge, NaturalArcanePower
                }
            },
            {
                "2", new[]
                {
                    PhysicallyFit, Observant, StableEnchantmentsPhysical, Sterile, Virile, Seductive, Fertile, Barren, StableEnchantmentsArcane, ArcanePrecision, ArcaneTraining
                }
            },
            {
                "3", new[]
                {
                    Defender, EnergyReserves, Striker, StableEnchantmentsPhysicalPlus, VirilePlus, SeductivePlus, OrgasmicLevelDrain, Resistance, FertilePlus, StableEnchantmentsArcanePlus,
                    SpellPower, AuraReserves, SpellEfficiency
                }
            },
            {
                "4", new[]
                {
                    DefenderPlus, EnergyReservesPlus, StrikerPlus, ArcaneSmith, Seeder, SeductivePlusPlus, Ahegao, ResistancePlus, Broodmother, ArcaneWeaver, SpellPowerPlus, AuraReservesPlus,
                    SpellEfficiencyPlus
                }
            },
            {
                "5", new[]
                {
                    CardioKing, MartialArtist, CriticalPowerPhysical, HandToHand, VirilePlusPlus, VirilePlusx3, CriticalPowerLust, FertilePlusx3, FertilePlusPlus, ElementalStriker,
                    CriticalPowerArcane, Chuuni, ArcaneCombatant
                }
            },
            {
                "6", new[]
                {
                    PhysicallyFitPlus, Hypermobility, SeductivePlusx3, Minx, Ladykiller, ArcaneAffinity
                }
            },
            {
                "7", new[]
                {
                    StrikerPlusPlus, HandToHandPlus, AuraShielding, EnergyReservesPlusPlus, SeductiveLeftBranch, SeductiveMiddleBranch, ResistancePlusPlus, AuraReservesPlusPlus,
                    SpellEfficiencyPlusPlus, SpellPowerPlusPlus
                }
            },
            {
                "8", new[]
                {
                    StrikerPlusx3, MeleeWeaponsExpert, DefenderPlusPlus, EnergyReservesPlusx3, SeductivePlusLeftBranch, IrresistibleAppeals, SeductivePlusMiddleBranch, ObjectOfDesire,
                    ResistancePlusx3, AuraReservesPlusx3, SpellEfficiencyPlusx3, SpellPowerPlusx3
                }
            },
            {
                "9", new[]
                {
                    StrikerPlusx4, SharpShooter, DefenderPlusx3, EnergyReservesPlusx4, SeductivePlusPlusLeftBranch, SeductivePlusPlusMiddleBranch, ResistancePlusx4, AuraReservesPlusx4,
                    SpellEfficiencyPlusx4, SpellMastery
                }
            },
            {
                "10", new[]
                {
                    FerociousWarrior, Berserk, CombatRegeneration, Lustpyre, Nymphomaniac, PureThoughts, SacrificialShielding, SpellEfficiencyPlusx5, ArcaneVampyrism
                }
            },
            {
                "11", new[]
                {
                    MeleeWeaponsExpertPlus, PhysicallyFitPlusPlus, SharpShooterPlus, SeductivePlusx4, ElementalDefender, ArcaneAffinityPlus, ElementalStrikerPlus
                }
            },
            {
                "12", new[]
                {
                    ElementalStrikerPhysical, ElementalStrikerSeductive, ElementalStrikerArcane
                }
            }
        };

        var perks = perksNode.Elements();
        foreach (var perk in perks)
        {
            var row = perk.Attribute("row")!.Value;
            var type = perk.Attribute("type")!.Value;
            foreach (var perkNode in LookupCache[row])
            {
                if (perkNode.Type != type)
                {
                    continue;
                }
                
                perkNode.InitializeNode(perk);
                break;
            }
        }
    }
}