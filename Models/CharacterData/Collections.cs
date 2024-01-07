using LTSaveEd.Models.CharacterData.BodyData;
using LTSaveEd.Models.CharacterData.InventoryData;
using LTSaveEd.Models.CharacterData.InventoryData.Clothes;
using LTSaveEd.Models.CharacterData.InventoryData.Items;
using LTSaveEd.Models.CharacterData.InventoryData.Weapons;

namespace LTSaveEd.Models.CharacterData;

public static class Collections
{
    public static ValueDisplayPair<string>[] HairTypes { get; } =
    [
        new ValueDisplayPair<string>("None", "ZERO_NONE"), new ValueDisplayPair<string>("Stubble", "ONE_STUBBLE"),
        new ValueDisplayPair<string>("Manicured", "TWO_MANICURED"), new ValueDisplayPair<string>("Trimmed", "THREE_TRIMMED"),
        new ValueDisplayPair<string>("Natural", "FOUR_NATURAL"), new ValueDisplayPair<string>("Unkempt", "FIVE_UNKEMPT"),
        new ValueDisplayPair<string>("Bushy", "SIX_BUSHY"), new ValueDisplayPair<string>("Wild", "SEVEN_WILD")
    ];

    public static ValueDisplayPair<string>[] BodyFluidFlavours { get; } =
    [
        new ValueDisplayPair<string>("Cum", "CUM"), new ValueDisplayPair<string>("Milk", "MILK"),
        new ValueDisplayPair<string>("Girlcum", "GIRL_CUM"), new ValueDisplayPair<string>("Bubblegum", "BUBBLEGUM"),
        new ValueDisplayPair<string>("Beer", "BEER"), new ValueDisplayPair<string>("Vanilla", "VANILLA"),
        new ValueDisplayPair<string>("Strawberry", "STRAWBERRY"), new ValueDisplayPair<string>("Chocolate", "CHOCOLATE"),
        new ValueDisplayPair<string>("Pineapple", "PINEAPPLE"), new ValueDisplayPair<string>("Honey", "HONEY"),
        new ValueDisplayPair<string>("Mint", "MINT"), new ValueDisplayPair<string>("Cherry", "CHERRY"),
        new ValueDisplayPair<string>("Coffee", "COFFEE"), new ValueDisplayPair<string>("Tea", "TEA"),
        new ValueDisplayPair<string>("Maple", "MAPLE"), new ValueDisplayPair<string>("Cinnamon", "CINNAMON"),
        new ValueDisplayPair<string>("Lemon", "LEMON"), new ValueDisplayPair<string>("Orange", "ORANGE"),
        new ValueDisplayPair<string>("Grape", "GRAPE"), new ValueDisplayPair<string>("Melon", "MELON"),
        new ValueDisplayPair<string>("Coconut", "COCONUT"), new ValueDisplayPair<string>("Blueberry", "BLUEBERRY")
    ];
    
    private static readonly ValueDisplayPair<string>[] LegConfigurationsMaster =
    [
        new ValueDisplayPair<string>("Bipedal", "BIPEDAL"), new ValueDisplayPair<string>("Quadrupedal", "QUADRUPEDAL"),
        new ValueDisplayPair<string>("Serpent-tailed", "TAIL_LONG"), new ValueDisplayPair<string>("Arachnid", "ARACHNID"),
        new ValueDisplayPair<string>("Cephalopod", "CEPHALOPOD"), new ValueDisplayPair<string>("Mer-tailed", "TAIL"),
        new ValueDisplayPair<string>("Avian", "AVIAN")
    ];
    
    private static ValueDisplayPair<string>[] _legConfigurationsBQ;
    private static ValueDisplayPair<string>[] _legConfigurationsB;
    private static ValueDisplayPair<string>[] _legConfigurationsS;
    private static ValueDisplayPair<string>[] _legConfigurationsAr;
    private static ValueDisplayPair<string>[] _legConfigurationsC;
    private static ValueDisplayPair<string>[] _legConfigurationsM;
    private static ValueDisplayPair<string>[] _legConfigurationsAv;
    private static ValueDisplayPair<string>[] _legConfigurationsBQSM;
    private static ValueDisplayPair<string>[] _legConfigurationsBAv;
    private static ValueDisplayPair<string>[] _legConfigurationsBM;
    private static ValueDisplayPair<string>[] _legConfigurationsBS;
    private static ValueDisplayPair<string>[] _legConfigurationsBAr;

    private static readonly ValueDisplayPair<string>[] FootStructuresMaster =
    [
        new ValueDisplayPair<string>("None", "NONE"), new ValueDisplayPair<string>("Plantigrade", "PLANTIGRADE"),
        new ValueDisplayPair<string>("Unguligrade", "UNGULIGRADE"), new ValueDisplayPair<string>("Digitigrade", "DIGITIGRADE"),
        new ValueDisplayPair<string>("Arachnoid", "ARACHNOID"), new ValueDisplayPair<string>("Tentacled", "TENTACLED")
    ];
    
    private static ValueDisplayPair<string>[] _footStructuresP;
    private static ValueDisplayPair<string>[] _footStructuresU;
    private static ValueDisplayPair<string>[] _footStructuresN;
    private static ValueDisplayPair<string>[] _footStructuresA;
    private static ValueDisplayPair<string>[] _footStructuresT;
    private static ValueDisplayPair<string>[] _footStructuresPD;
    private static ValueDisplayPair<string>[] _footStructuresD;

    private static readonly ValueDisplayPair<string>[] GenitalArrangementsNCR =
    [
        new ValueDisplayPair<string>("Normal", "NORMAL"), new ValueDisplayPair<string>("Cloaca", "CLOACA"),
        new ValueDisplayPair<string>("Rear-facing cloaca", "CLOACA_BEHIND")
    ];
    
    private static ValueDisplayPair<string>[]  genitalArrangementsCR;
    private static ValueDisplayPair<string>[]  genitalArrangementsN;
    private static ValueDisplayPair<string>[]  genitalArrangementsC;
    private static ValueDisplayPair<string>[]  genitalArrangementsR;
    
    public static LegTypeValueDisplayPair[] LegTypes { get; }

    public static ValueDisplayPair<string>[] FemininityValues { get; } =
    [
        new ValueDisplayPair<string>("Very Masculine", "VERY_MASCULINE"),
        new ValueDisplayPair<string>("Masculine", "MASCULINE"), new ValueDisplayPair<string>("Androgynous", "ANDROGYNOUS"),
        new ValueDisplayPair<string>("Feminine", "FEMININE"), new ValueDisplayPair<string>("Very Feminine", "VERY_FEMININE")
    ];
    
    public static ValueDisplayPair<string>[] SubspeciesOverrides { get; } =
    [
        new ValueDisplayPair<string>("Human", "HUMAN"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Elder Lilin", "ELDER_LILIN"), new ValueDisplayPair<string>("Lilin", "LILIN"),
        new ValueDisplayPair<string>("Demon", "DEMON"), new ValueDisplayPair<string>("Half Demon", "HALF_DEMON"),
        new ValueDisplayPair<string>("Imp", "IMP"), new ValueDisplayPair<string>("Imp Alpha", "IMP_ALPHA"),
        new ValueDisplayPair<string>("Cow Morph", "COW_MORPH"), new ValueDisplayPair<string>("Dog Morph", "DOG_MORPH"),
        new ValueDisplayPair<string>("Dog Morph Border Collie", "DOG_MORPH_BORDER_COLLIE"),
        new ValueDisplayPair<string>("Dog Morph Dobermann", "DOG_MORPH_DOBERMANN"),
        new ValueDisplayPair<string>("Dog Morph German Shepherd", "DOG_MORPH_GERMAN_SHEPHERD"), new ValueDisplayPair<string>("Dragon Morph", "dsg_dragon_subspecies_dragon"),
        new ValueDisplayPair<string>("Wolf Morph", "WOLF_MORPH"), new ValueDisplayPair<string>("Fox Morph", "FOX_MORPH"),
        new ValueDisplayPair<string>("Fox Morph Arctic", "FOX_MORPH_ARCTIC"),
        new ValueDisplayPair<string>("Fox Morph Fennec", "FOX_MORPH_FENNEC"),
        new ValueDisplayPair<string>("Fox Ascendant", "FOX_ASCENDANT"),
        new ValueDisplayPair<string>("Fox Ascendant Arctic", "FOX_ASCENDANT_ARCTIC"),
        new ValueDisplayPair<string>("Fox Ascendant Fennec", "FOX_ASCENDANT_FENNEC"),
        new ValueDisplayPair<string>("Cat Morph", "CAT_MORPH"),
        new ValueDisplayPair<string>("Cat Morph Lynx", "CAT_MORPH_LYNX"),
        new ValueDisplayPair<string>("Cat Morph Cheetah", "CAT_MORPH_CHEETAH"),
        new ValueDisplayPair<string>("Cat Morph Caracal", "CAT_MORPH_CARACAL"),
        new ValueDisplayPair<string>("Cat Morph Leopard Snow", "CAT_MORPH_LEOPARD_SNOW"),
        new ValueDisplayPair<string>("Cat Morph Leopard", "CAT_MORPH_LEOPARD"),
        new ValueDisplayPair<string>("Cat Morph Lion", "CAT_MORPH_LION"),
        new ValueDisplayPair<string>("Cat Morph Tiger", "CAT_MORPH_TIGER"),
        new ValueDisplayPair<string>("Horse Morph", "HORSE_MORPH"),
        new ValueDisplayPair<string>("Horse Morph Unicorn", "HORSE_MORPH_UNICORN"),
        new ValueDisplayPair<string>("Horse Morph Pegasus", "HORSE_MORPH_PEGASUS"),
        new ValueDisplayPair<string>("Horse Morph Alicorn", "HORSE_MORPH_ALICORN"),
        new ValueDisplayPair<string>("Centaur", "CENTAUR"), new ValueDisplayPair<string>("Pegataur", "PEGATAUR"),
        new ValueDisplayPair<string>("Unitaur", "UNITAUR"), new ValueDisplayPair<string>("Alitaur", "ALITAUR"),
        new ValueDisplayPair<string>("Horse Morph Zebra", "HORSE_MORPH_ZEBRA"),
        new ValueDisplayPair<string>("Reindeer Morph", "REINDEER_MORPH"),
        new ValueDisplayPair<string>("Alligator Morph", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Slime", "SLIME"),
        new ValueDisplayPair<string>("Squirrel Morph", "SQUIRREL_MORPH"),
        new ValueDisplayPair<string>("Rat Morph", "RAT_MORPH"), new ValueDisplayPair<string>("Rabbit Morph", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Rabbit Morph Lop", "RABBIT_MORPH_LOP"),
        new ValueDisplayPair<string>("Bat Morph", "BAT_MORPH"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Harpy Raven", "HARPY_RAVEN"),
        new ValueDisplayPair<string>("Harpy Bald Eagle", "HARPY_BALD_EAGLE"),
        new ValueDisplayPair<string>("Harpy Phoenix", "HARPY_PHOENIX"),
        new ValueDisplayPair<string>("Elemental Fire", "ELEMENTAL_FIRE"),
        new ValueDisplayPair<string>("Elemental Earth", "ELEMENTAL_EARTH"),
        new ValueDisplayPair<string>("Elemental Water", "ELEMENTAL_WATER"),
        new ValueDisplayPair<string>("Elemental Air", "ELEMENTAL_AIR"),
        new ValueDisplayPair<string>("Elemental Arcane", "ELEMENTAL_ARCANE"), new ValueDisplayPair<string>("Badger", "innoxia_badger_subspecies_badger")
    ]; //TODO Check if these are all subspecies in the game

    public static Dictionary<ClothingType, ClothingData[]> ClothingMap { get; } = new();
    public static Dictionary<string, ClothingType> ClothingTypeLookup { get; } = new();
    public static ClothingData[] AllClothing { get; }
    public static Dictionary<ItemType, ItemData[]> ItemsMap { get; } = new();
    public static Dictionary<string, ItemType> ItemTypeLookup { get; } = new();
    public static ItemData[] AllItems { get; }
    public static Dictionary<WeaponType, WeaponData[]> WeaponsMap { get; } = new();
    public static Dictionary<string, WeaponType> WeaponTypeLookup { get; } = new();
    public static WeaponData[] AllWeapons { get; }
    
    static Collections()
    {
        #region Leg Configuration Initialization
        
        _legConfigurationsBQ = LegConfigurationsMaster[..2];
        _legConfigurationsB = [LegConfigurationsMaster[0]];
        _legConfigurationsS = [LegConfigurationsMaster[2]];
        _legConfigurationsAr = [LegConfigurationsMaster[3]];
        _legConfigurationsC = [LegConfigurationsMaster[4]];
        _legConfigurationsM = [LegConfigurationsMaster[5]];
        _legConfigurationsAv = [LegConfigurationsMaster[6]];
        _legConfigurationsBQSM = [..LegConfigurationsMaster[..3], LegConfigurationsMaster[5]];
        _legConfigurationsBAv = [LegConfigurationsMaster[0], LegConfigurationsMaster[6]];
        _legConfigurationsBM = [LegConfigurationsMaster[0], LegConfigurationsMaster[5]];
        _legConfigurationsBS = [LegConfigurationsMaster[0], LegConfigurationsMaster[2]];
        _legConfigurationsBAr = [LegConfigurationsMaster[0], LegConfigurationsMaster[3]];
        
        _footStructuresP = [FootStructuresMaster[1]];
        _footStructuresU = [FootStructuresMaster[2]];
        _footStructuresN = [FootStructuresMaster[0]];
        _footStructuresA = [FootStructuresMaster[4]];
        _footStructuresT = [FootStructuresMaster[5]];
        _footStructuresPD = [FootStructuresMaster[1], FootStructuresMaster[3]];
        _footStructuresD = [FootStructuresMaster[3]];
        
        genitalArrangementsCR = GenitalArrangementsNCR[1..3];
        genitalArrangementsN = [GenitalArrangementsNCR[0]];
        genitalArrangementsC = [GenitalArrangementsNCR[1]];
        genitalArrangementsR = [GenitalArrangementsNCR[2]];

        LegTypes =
        [
            new LegTypeValueDisplayPair("Alligator", "ALLIGATOR_MORPH", _legConfigurationsBQ, _footStructuresP, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Angel", "ANGEL", _legConfigurationsB, _footStructuresP, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Badger", "innoxia_badger_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Bat", "BAT_MORPH", _legConfigurationsB, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Bear", "dsg_bear_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Capybara", "NoStepOnSnek_capybara_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Cat", "CAT_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Cow", "COW_MORPH", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic", "DEMON_COMMON", _legConfigurationsB, _footStructuresP, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic-hoofed", "DEMON_HOOFED", _legConfigurationsB, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic-horse", "DEMON_HORSE", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic-snake", "DEMON_SNAKE", _legConfigurationsS, _footStructuresN, genitalArrangementsCR),
            new LegTypeValueDisplayPair("Demonic-spider", "DEMON_SPIDER", _legConfigurationsAr, _footStructuresA, genitalArrangementsN),
            new LegTypeValueDisplayPair("Demonic-octopus", "DEMON_OCTOPUS", _legConfigurationsC, _footStructuresT, genitalArrangementsC),
            new LegTypeValueDisplayPair("Demonic-fish", "DEMON_FISH", _legConfigurationsM, _footStructuresN, genitalArrangementsCR),
            new LegTypeValueDisplayPair("Demonic-eagle", "DEMON_EAGLE", _legConfigurationsAv, _footStructuresD, genitalArrangementsR),
            new LegTypeValueDisplayPair("Dog", "DOG_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Dragon", "dsg_dragon_leg", _legConfigurationsBQSM, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Ferret", "dsg_ferret_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Fox", "FOX_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Goat", "innoxia_goat_leg", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Gryphon", "dsg_gryphon_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Harpy", "HARPY", _legConfigurationsBAv, _footStructuresD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Horse", "HORSE_MORPH", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Human", "HUMAN", _legConfigurationsB, _footStructuresP, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Hyena", "innoxia_hyena_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Octopus", "NoStepOnSnek_octopus_leg", _legConfigurationsC, _footStructuresT, genitalArrangementsC),
            new LegTypeValueDisplayPair("Otter", "dsg_otter_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Panther", "innoxia_panther_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Pig", "innoxia_pig_leg", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Rabbit", "RABBIT_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Racoon", "dsg_racoon_leg", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Rat", "RAT_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Reindeer", "REINDEER_MORPH", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Shark", "dsg_shark_leg", _legConfigurationsBM, _footStructuresP, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Sheep", "innoxia_sheep_leg", _legConfigurationsBQ, _footStructuresU, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Snake", "NoStepOnSnek_snake_leg", _legConfigurationsBS, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Furred Spider", "charisma_spider_legFluffy", _legConfigurationsBAr, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Spider", "charisma_spider_leg", _legConfigurationsBAr, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Squirrel", "SQUIRREL_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Wolf", "WOLF_MORPH", _legConfigurationsBQ, _footStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE")
        ];
        
        #endregion

        #region Item Dictionaries Initialization
        
        #region Clothes Initialization

        ClothingMap.Add(ClothingType.TorsoOver, [new ClothingData("bloom_wasp609_rainCoat_rain_coat", "bloom_wasp609_rainCoat_rain_coat", 1), new ClothingData("c4mg1rl_trickster_cloak", "c4mg1rl_trickster_cloak", 1), new ClothingData("dsg_eep_ptrlequipset_stpvest", "dsg_eep_ptrlequipset_stpvest", 3), new ClothingData("dsg_eep_riotarmorset_riotarmor", "dsg_eep_riotarmorset_riotarmor", 2), new ClothingData("dsg_eep_servequipset_debuggerydo_enfdjacket", "dsg_eep_servequipset_debuggerydo_enfdjacket", 1), new ClothingData("dsg_eep_servequipset_enfdjacket", "dsg_eep_servequipset_enfdjacket", 1), new ClothingData("dsg_eep_servequipset_enfdwaistcoat", "dsg_eep_servequipset_enfdwaistcoat", 1), new ClothingData("dsg_eep_servequipset_enfgreatcoat", "dsg_eep_servequipset_enfgreatcoat", 1), new ClothingData("dsg_eep_servequipset_milsweatervest_crew", "dsg_eep_servequipset_milsweatervest_crew", 1), new ClothingData("dsg_eep_servequipset_milsweatervest_crewen", "dsg_eep_servequipset_milsweatervest_crewen", 1), new ClothingData("dsg_eep_servequipset_milsweater_crew", "dsg_eep_servequipset_milsweater_crew", 3), new ClothingData("dsg_eep_servequipset_milsweater_crewen", "dsg_eep_servequipset_milsweater_crewen", 1), new ClothingData("dsg_eep_servequipset_milsweater_vee", "dsg_eep_servequipset_milsweater_vee", 3), new ClothingData("dsg_eep_tacequipset_hpltcarrier", "dsg_eep_tacequipset_hpltcarrier", 3), new ClothingData("dsg_eep_tacequipset_pltcarrier", "dsg_eep_tacequipset_pltcarrier", 3), new ClothingData("dsg_eisek_rspntunic", "dsg_eisek_rspntunic", 1), new ClothingData("dsg_hlf_equip_rbandolier", "dsg_hlf_equip_rbandolier", 2), new ClothingData("dsg_hlf_equip_rwebbing", "dsg_hlf_equip_rwebbing", 2), new ClothingData("dsg_ljacket_ljacket", "dsg_ljacket_ljacket", 1), new ClothingData("dsg_ljacket_ljacket_f", "dsg_ljacket_ljacket_f", 1), new ClothingData("dsg_m65jacket_m65jacket", "dsg_m65jacket_m65jacket", 1), new ClothingData("dsg_shadydealer_trenchcoat", "dsg_shadydealer_trenchcoat", 3), new ClothingData("dsg_sm_cboard_cbarmor", "dsg_sm_cboard_cbarmor", 1), new ClothingData("innoxia_butler_butler_jacket", "innoxia_butler_butler_jacket", 1), new ClothingData("innoxia_darkSiren_siren_cloak", "innoxia_darkSiren_siren_cloak", 1), new ClothingData("innoxia_japanese_haori", "innoxia_japanese_haori", 1), new ClothingData("innoxia_lyssiethUniform_tunic", "innoxia_lyssiethUniform_tunic", 2), new ClothingData("innoxia_scientist_lab_coat", "innoxia_scientist_lab_coat", 1), new ClothingData("innoxia_torsoOver_apron", "innoxia_torsoOver_apron", 1), new ClothingData("innoxia_torsoOver_beer_barrel", "innoxia_torsoOver_beer_barrel", 1), new ClothingData("innoxia_torsoOver_blazer", "innoxia_torsoOver_blazer", 1), new ClothingData("innoxia_torsoOver_christmas_jumper", "innoxia_torsoOver_christmas_jumper", 2), new ClothingData("innoxia_torsoOver_dress_coat", "innoxia_torsoOver_dress_coat", 3), new ClothingData("innoxia_torsoOver_feminine_blazer", "innoxia_torsoOver_feminine_blazer", 1), new ClothingData("innoxia_torsoOver_fur_cloak", "innoxia_torsoOver_fur_cloak", 1), new ClothingData("innoxia_torsoOver_himation", "innoxia_torsoOver_himation", 1), new ClothingData("innoxia_torsoOver_hooded_cloak", "innoxia_torsoOver_hooded_cloak", 2), new ClothingData("innoxia_torsoOver_hoodie", "innoxia_torsoOver_hoodie", 1), new ClothingData("innoxia_torsoOver_keyhole_jumper", "innoxia_torsoOver_keyhole_jumper", 1), new ClothingData("innoxia_torsoOver_open_front_cardigan", "innoxia_torsoOver_open_front_cardigan", 1), new ClothingData("innoxia_torsoOver_ribbed_jumper", "innoxia_torsoOver_ribbed_jumper", 1), new ClothingData("innoxia_torsoOver_suit_jacket", "innoxia_torsoOver_suit_jacket", 1), new ClothingData("innoxia_torsoOver_vending_machine", "innoxia_torsoOver_vending_machine", 1), new ClothingData("innoxia_torsoOver_womens_leather_jacket", "innoxia_torsoOver_womens_leather_jacket", 2), new ClothingData("innoxia_torsoOver_womens_winter_coat", "innoxia_torsoOver_womens_winter_coat", 1), new ClothingData("nerdlinger_builder_utility_jacket_utility_jacket", "nerdlinger_builder_utility_jacket_utility_jacket", 1), new ClothingData("NoStepOnSnek_poncho_poncho", "NoStepOnSnek_poncho_poncho", 2), new ClothingData("clothing_TonyJC_cropped_sweater", "clothing_TonyJC_cropped_sweater", 2), new ClothingData("clothing_TonyJC_shoulderless_top", "clothing_TonyJC_shoulderless_top", 1)]);
        ClothingMap.Add(ClothingType.TorsoUnder, [new ClothingData("c4mg1rl_benevolent_kyudogi", "c4mg1rl_benevolent_kyudogi", 3), new ClothingData("c4mg1rl_trickster_tunic", "c4mg1rl_trickster_tunic", 1), new ClothingData("dsg_eep_ptrlequipset_flsldshirt", "dsg_eep_ptrlequipset_flsldshirt", 3), new ClothingData("dsg_eep_ptrlequipset_fssldshirt", "dsg_eep_ptrlequipset_fssldshirt", 3), new ClothingData("dsg_eep_ptrlequipset_lsldshirt", "dsg_eep_ptrlequipset_lsldshirt", 3), new ClothingData("dsg_eep_ptrlequipset_ssldshirt", "dsg_eep_ptrlequipset_ssldshirt", 3), new ClothingData("dsg_eep_tacequipset_cbtshirt", "dsg_eep_tacequipset_cbtshirt", 2), new ClothingData("dsg_eep_tacequipset_enf_cbtshirt", "dsg_eep_tacequipset_enf_cbtshirt", 1), new ClothingData("dsg_eep_tacequipset_enf_sslcbtshirt", "dsg_eep_tacequipset_enf_sslcbtshirt", 1), new ClothingData("dsg_eep_tacequipset_sslcbtshirt", "dsg_eep_tacequipset_sslcbtshirt", 2), new ClothingData("dsg_eisek_sundshirt", "dsg_eisek_sundshirt", 1), new ClothingData("dsg_hlf_equip_rtunic", "dsg_hlf_equip_rtunic", 1), new ClothingData("innoxia_butler_butler_waistcoat_shirt", "innoxia_butler_butler_waistcoat_shirt", 3), new ClothingData("innoxia_japanese_kimono", "innoxia_japanese_kimono", 3), new ClothingData("innoxia_japanese_kimono_short", "innoxia_japanese_kimono_short", 3), new ClothingData("innoxia_japanese_mens_kimono", "innoxia_japanese_mens_kimono", 1), new ClothingData("innoxia_maid_dress", "innoxia_maid_dress", 2), new ClothingData("innoxia_torso_blouse", "innoxia_torso_blouse", 1), new ClothingData("innoxia_torso_feminine_short_sleeve_shirt", "innoxia_torso_feminine_short_sleeve_shirt", 3), new ClothingData("innoxia_torso_long_sleeved_shirt", "innoxia_torso_long_sleeved_shirt", 3), new ClothingData("innoxia_torso_peplos", "innoxia_torso_peplos", 1), new ClothingData("innoxia_torso_plunge_blouse", "innoxia_torso_plunge_blouse", 2), new ClothingData("innoxia_torso_plunge_club_dress", "innoxia_torso_plunge_club_dress", 2), new ClothingData("innoxia_torso_short_sleeved_shirt", "innoxia_torso_short_sleeved_shirt", 3), new ClothingData("innoxia_torso_tshirt", "innoxia_torso_tshirt", 1), new ClothingData("innoxia_torso_tshirt_test_item", "innoxia_torso_tshirt_test_item", 1), new ClothingData("innoxia_witch_witch_dress", "innoxia_witch_witch_dress", 2), new ClothingData("phlarx_dresses_ballgown", "phlarx_dresses_ballgown", 3), new ClothingData("phlarx_dresses_evening_gown", "phlarx_dresses_evening_gown", 1), new ClothingData("phlarx_dresses_rockabilly_dress", "phlarx_dresses_rockabilly_dress", 2), new ClothingData("phlarx_dresses_vintage_dress", "phlarx_dresses_vintage_dress", 3), new ClothingData("rfpnj_slavery_administration_shirt", "rfpnj_slavery_administration_shirt", 3), new ClothingData("sage_latex_croptop", "sage_latex_croptop", 2), new ClothingData("clothing_TonyJC_cropped_tshirt", "clothing_TonyJC_cropped_tshirt", 1), new ClothingData("clothing_TonyJC_crop_tank_top", "clothing_TonyJC_crop_tank_top", 1), new ClothingData("clothing_TonyJC_one_strap_crop_tank_top", "clothing_TonyJC_one_strap_crop_tank_top", 1), new ClothingData("clothing_TonyJC_sleeveless_shirt", "clothing_TonyJC_sleeveless_shirt", 1), new ClothingData("clothing_TonyJC_spaghetti_crop_tank_top", "clothing_TonyJC_spaghetti_crop_tank_top", 1), new ClothingData("clothing_TonyJC_tank_top", "clothing_TonyJC_tank_top", 1), new ClothingData("clothing_TonyJC_tie_up_crop_top", "clothing_TonyJC_tie_up_crop_top", 2)]);
        ClothingMap.Add(ClothingType.Hand, [new ClothingData("c4mg1rl_benevolent_mitsugake", "c4mg1rl_benevolent_mitsugake", 3), new ClothingData("dsg_ckls_ckls_gloves", "dsg_ckls_ckls_gloves", 1), new ClothingData("innoxia_butler_butler_gloves", "innoxia_butler_butler_gloves", 1), new ClothingData("innoxia_hand_elbow_length_gloves", "innoxia_hand_elbow_length_gloves", 1), new ClothingData("innoxia_hand_fingerless_gloves", "innoxia_hand_fingerless_gloves", 1), new ClothingData("innoxia_hand_fishnet_gloves", "innoxia_hand_fishnet_gloves", 1), new ClothingData("innoxia_hand_gloves", "innoxia_hand_gloves", 1), new ClothingData("innoxia_hand_striped_gloves", "innoxia_hand_striped_gloves", 2), new ClothingData("innoxia_hand_wraps", "innoxia_hand_wraps", 1), new ClothingData("innoxia_maid_sleeves", "innoxia_maid_sleeves", 2), new ClothingData("innoxia_rainbow_gloves", "innoxia_rainbow_gloves", 1), new ClothingData("sage_latex_arm_warmers", "sage_latex_arm_warmers", 2), new ClothingData("sage_latex_elbow_gloves", "sage_latex_elbow_gloves", 1)]);
        ClothingMap.Add(ClothingType.Neck, [new ClothingData("c4mg1rl_benevolent_necklace", "c4mg1rl_benevolent_necklace", 3), new ClothingData("c4mg1rl_trickster_cloak", "c4mg1rl_trickster_cloak", 1), new ClothingData("dsg_eep_riotarmorset_riotneckprotector", "dsg_eep_riotarmorset_riotneckprotector", 3), new ClothingData("dsg_foxscarf_foxscarf", "dsg_foxscarf_foxscarf", 3), new ClothingData("innoxia_bdsm_choker", "innoxia_bdsm_choker", 2), new ClothingData("innoxia_bdsm_metal_collar", "innoxia_bdsm_metal_collar", 2), new ClothingData("innoxia_cattle_cowbell_collar", "innoxia_cattle_cowbell_collar", 3), new ClothingData("innoxia_darkSiren_siren_amulet", "innoxia_darkSiren_siren_amulet", 1), new ClothingData("innoxia_darkSiren_siren_cloak", "innoxia_darkSiren_siren_cloak", 1), new ClothingData("innoxia_elemental_snowflake_necklace", "innoxia_elemental_snowflake_necklace", 2), new ClothingData("innoxia_elemental_sun_necklace", "innoxia_elemental_sun_necklace", 3), new ClothingData("innoxia_mouth_bandana", "innoxia_mouth_bandana", 1), new ClothingData("innoxia_neck_ambers_bitch_collar", "innoxia_neck_ambers_bitch_collar", 2), new ClothingData("innoxia_neck_ankh_necklace", "innoxia_neck_ankh_necklace", 3), new ClothingData("innoxia_neck_bell_collar", "innoxia_neck_bell_collar", 3), new ClothingData("innoxia_neck_breeder_collar", "innoxia_neck_breeder_collar", 3), new ClothingData("innoxia_neck_collar_bowtie", "innoxia_neck_collar_bowtie", 3), new ClothingData("innoxia_neck_cuff_choker_necklace", "innoxia_neck_cuff_choker_necklace", 1), new ClothingData("innoxia_neck_cuff_choker_necklace_triple", "innoxia_neck_cuff_choker_necklace_triple", 1), new ClothingData("innoxia_neck_demonstone_necklace", "innoxia_neck_demonstone_necklace", 2), new ClothingData("innoxia_neck_diamond_necklace", "innoxia_neck_diamond_necklace", 1), new ClothingData("innoxia_neck_filly_choker", "innoxia_neck_filly_choker", 1), new ClothingData("innoxia_neck_gemstone_necklace", "innoxia_neck_gemstone_necklace", 1), new ClothingData("innoxia_neck_heart_necklace", "innoxia_neck_heart_necklace", 2), new ClothingData("innoxia_neck_horseshoe_necklace", "innoxia_neck_horseshoe_necklace", 2), new ClothingData("innoxia_neck_key_chain", "innoxia_neck_key_chain", 1), new ClothingData("innoxia_neck_scarf", "innoxia_neck_scarf", 1), new ClothingData("innoxia_neck_tie", "innoxia_neck_tie", 1), new ClothingData("innoxia_neck_velvet_choker", "innoxia_neck_velvet_choker", 2), new ClothingData("innoxia_torsoOver_fur_cloak", "innoxia_torsoOver_fur_cloak", 1), new ClothingData("irbynx_spikedCollar_punk_neck_metal_collar_spiked", "irbynx_spikedCollar_punk_neck_metal_collar_spiked", 2)]);
        ClothingMap.Add(ClothingType.Wrist, [new ClothingData("c4mg1rl_benevolent_necklace", "c4mg1rl_benevolent_necklace", 3), new ClothingData("dsg_eep_riotarmorset_riotarmguards", "dsg_eep_riotarmorset_riotarmguards", 3), new ClothingData("dsg_eep_tacequipset_telbowpads", "dsg_eep_tacequipset_telbowpads", 3), new ClothingData("dsg_hlf_equip_rbrassard", "dsg_hlf_equip_rbrassard", 1), new ClothingData("dsg_hndcuffs_hndcuffs", "dsg_hndcuffs_hndcuffs", 1), new ClothingData("innoxia_bdsm_wrist_bracelets", "innoxia_bdsm_wrist_bracelets", 2), new ClothingData("innoxia_bdsm_wrist_restraints", "innoxia_bdsm_wrist_restraints", 2), new ClothingData("innoxia_elemental_snowflake_necklace", "innoxia_elemental_snowflake_necklace", 2), new ClothingData("innoxia_elemental_sun_necklace", "innoxia_elemental_sun_necklace", 3), new ClothingData("innoxia_neck_ankh_necklace", "innoxia_neck_ankh_necklace", 3), new ClothingData("innoxia_neck_demonstone_necklace", "innoxia_neck_demonstone_necklace", 2), new ClothingData("innoxia_neck_gemstone_necklace", "innoxia_neck_gemstone_necklace", 1), new ClothingData("innoxia_neck_heart_necklace", "innoxia_neck_heart_necklace", 2), new ClothingData("innoxia_neck_horseshoe_necklace", "innoxia_neck_horseshoe_necklace", 2), new ClothingData("innoxia_neck_key_chain", "innoxia_neck_key_chain", 1), new ClothingData("innoxia_wrist_thin_bangles", "innoxia_wrist_thin_bangles", 1), new ClothingData("nerdlinger_rollerskating_elbowpads_rollerskating_elbowpads", "nerdlinger_rollerskating_elbowpads_rollerskating_elbowpads", 1), new ClothingData("norin_hair_accessories_hair_scrunchie", "norin_hair_accessories_hair_scrunchie", 1), new ClothingData("sage_latex_arm_warmers", "sage_latex_arm_warmers", 2)]);
        ClothingMap.Add(ClothingType.Stomach, [new ClothingData("c4mg1rl_strapless_bodysuit_strapless_bodysuit", "c4mg1rl_strapless_bodysuit_strapless_bodysuit", 1), new ClothingData("innoxia_bdsm_karada", "innoxia_bdsm_karada", 1), new ClothingData("innoxia_milking_breast_pumps", "innoxia_milking_breast_pumps", 1), new ClothingData("innoxia_stomach_lowback_body", "innoxia_stomach_lowback_body", 1), new ClothingData("innoxia_stomach_overbust_corset", "innoxia_stomach_overbust_corset", 2), new ClothingData("innoxia_stomach_sarashi", "innoxia_stomach_sarashi", 1), new ClothingData("innoxia_stomach_underbust_corset", "innoxia_stomach_underbust_corset", 2), new ClothingData("sage_latex_bodysuit", "sage_latex_bodysuit", 3), new ClothingData("sage_latex_corset", "sage_latex_corset", 2)]);
        ClothingMap.Add(ClothingType.Eyes, [new ClothingData("c4mg1rl_trickster_mask", "c4mg1rl_trickster_mask", 1), new ClothingData("dsg_eep_tacequipset_bglasses", "dsg_eep_tacequipset_bglasses", 3), new ClothingData("dsg_eep_tacequipset_bgoggles", "dsg_eep_tacequipset_bgoggles", 3), new ClothingData("dsg_eep_tacequipset_nvgoggles", "dsg_eep_tacequipset_nvgoggles", 3), new ClothingData("innoxia_bdsm_blindfold", "innoxia_bdsm_blindfold", 1), new ClothingData("innoxia_darkSiren_siren_seal", "innoxia_darkSiren_siren_seal", 1), new ClothingData("innoxia_eye_aviators", "innoxia_eye_aviators", 1), new ClothingData("innoxia_eye_glasses", "innoxia_eye_glasses", 1), new ClothingData("innoxia_eye_half_moon_glasses", "innoxia_eye_half_moon_glasses", 1), new ClothingData("innoxia_eye_half_rim_glasses", "innoxia_eye_half_rim_glasses", 1), new ClothingData("innoxia_eye_patch", "innoxia_eye_patch", 1), new ClothingData("innoxia_eye_safety_glasses", "innoxia_eye_safety_glasses", 1), new ClothingData("innoxia_eye_thick_rim_glasses", "innoxia_eye_thick_rim_glasses", 1), new ClothingData("innoxia_scientist_safety_goggles", "innoxia_scientist_safety_goggles", 1), new ClothingData("nerdlinger_sports_noseguard_transparent_noseguard", "nerdlinger_sports_noseguard_transparent_noseguard", 1), new ClothingData("phlarx_sunglasses_cat_eye_sunglasses", "phlarx_sunglasses_cat_eye_sunglasses", 3), new ClothingData("phlarx_sunglasses_heart_sunglasses", "phlarx_sunglasses_heart_sunglasses", 1), new ClothingData("phlarx_sunglasses_round_sunglasses", "phlarx_sunglasses_round_sunglasses", 1)]);
        ClothingMap.Add(ClothingType.Sock, [new ClothingData("corpseBloom_toeless_stockings_toeless_stockings", "corpseBloom_toeless_stockings_toeless_stockings", 1), new ClothingData("dsg_ckls_ckls_stockings", "dsg_ckls_ckls_stockings", 1), new ClothingData("innoxia_maid_stockings", "innoxia_maid_stockings", 2), new ClothingData("innoxia_rainbow_stockings", "innoxia_rainbow_stockings", 1), new ClothingData("innoxia_sock_fishnets", "innoxia_sock_fishnets", 1), new ClothingData("innoxia_sock_kneehigh_socks", "innoxia_sock_kneehigh_socks", 1), new ClothingData("innoxia_sock_leg_warmers", "innoxia_sock_leg_warmers", 1), new ClothingData("innoxia_sock_pantyhose", "innoxia_sock_pantyhose", 1), new ClothingData("innoxia_sock_socks", "innoxia_sock_socks", 1), new ClothingData("innoxia_sock_stockings", "innoxia_sock_stockings", 1), new ClothingData("innoxia_sock_thighhigh_socks", "innoxia_sock_thighhigh_socks", 1), new ClothingData("innoxia_sock_thighhigh_socks_striped", "innoxia_sock_thighhigh_socks_striped", 2), new ClothingData("innoxia_sock_toeless_striped_stockings", "innoxia_sock_toeless_striped_stockings", 2), new ClothingData("innoxia_sock_trainer_socks", "innoxia_sock_trainer_socks", 1), new ClothingData("nerdlinger_ronin_tabi_tabi", "nerdlinger_ronin_tabi_tabi", 2), new ClothingData("sage_latex_stockings", "sage_latex_stockings", 1), new ClothingData("sage_latex_stockings_open", "sage_latex_stockings_open", 1)]);
        ClothingMap.Add(ClothingType.Head, [new ClothingData("dsg_bheadband_bheadband", "dsg_bheadband_bheadband", 2), new ClothingData("dsg_ckls_ckls_headband", "dsg_ckls_ckls_headband", 1), new ClothingData("dsg_eep_ptrlequipset_bwhat", "dsg_eep_ptrlequipset_bwhat", 1), new ClothingData("dsg_eep_ptrlequipset_pcap", "dsg_eep_ptrlequipset_pcap", 1), new ClothingData("dsg_eep_riotarmorset_riothelmet", "dsg_eep_riotarmorset_riothelmet", 3), new ClothingData("dsg_eep_servequipset_debuggerydo_enfberet", "dsg_eep_servequipset_debuggerydo_enfberet", 2), new ClothingData("dsg_eep_servequipset_enfberet", "dsg_eep_servequipset_enfberet", 2), new ClothingData("dsg_eep_tacequipset_chelmet", "dsg_eep_tacequipset_chelmet", 3), new ClothingData("dsg_hlf_equip_rbooniehat", "dsg_hlf_equip_rbooniehat", 1), new ClothingData("dsg_shadydealer_fedora", "dsg_shadydealer_fedora", 2), new ClothingData("innoxia_head_antler_headband", "innoxia_head_antler_headband", 1), new ClothingData("innoxia_head_cap", "innoxia_head_cap", 1), new ClothingData("innoxia_head_circlet", "innoxia_head_circlet", 1), new ClothingData("innoxia_head_cowboy_hat", "innoxia_head_cowboy_hat", 1), new ClothingData("innoxia_head_hard_hat", "innoxia_head_hard_hat", 1), new ClothingData("innoxia_head_headband", "innoxia_head_headband", 2), new ClothingData("innoxia_head_headband_bow", "innoxia_head_headband_bow", 3), new ClothingData("innoxia_head_jack_o_lantern", "innoxia_head_jack_o_lantern", 1), new ClothingData("innoxia_head_slime_queens_tiara", "innoxia_head_slime_queens_tiara", 3), new ClothingData("innoxia_head_sweatband", "innoxia_head_sweatband", 1), new ClothingData("innoxia_head_tiara", "innoxia_head_tiara", 1), new ClothingData("innoxia_impArcanist_arcanist_hat", "innoxia_impArcanist_arcanist_hat", 2), new ClothingData("innoxia_lyssiethUniform_hat", "innoxia_lyssiethUniform_hat", 1), new ClothingData("innoxia_maid_headpiece", "innoxia_maid_headpiece", 2), new ClothingData("innoxia_mouth_bandana", "innoxia_mouth_bandana", 1), new ClothingData("innoxia_witch_witch_hat", "innoxia_witch_witch_hat", 3), new ClothingData("innoxia_witch_witch_hat_wide", "innoxia_witch_witch_hat_wide", 3), new ClothingData("nerdlinger_rollerskating_helmet_rollerskating_helmet", "nerdlinger_rollerskating_helmet_rollerskating_helmet", 3), new ClothingData("nerdlinger_sports_biking_helmet_biking_helmet", "nerdlinger_sports_biking_helmet_biking_helmet", 3)]);
        ClothingMap.Add(ClothingType.Chest, [new ClothingData("dsg_ckls_ckls_bra", "dsg_ckls_ckls_bra", 1), new ClothingData("innoxia_chest_bikini", "innoxia_chest_bikini", 1), new ClothingData("innoxia_chest_chemise", "innoxia_chest_chemise", 1), new ClothingData("innoxia_chest_croptop_bra", "innoxia_chest_croptop_bra", 1), new ClothingData("innoxia_chest_fullcup_bra", "innoxia_chest_fullcup_bra", 1), new ClothingData("innoxia_chest_lacy_plunge_bra", "innoxia_chest_lacy_plunge_bra", 1), new ClothingData("innoxia_chest_micro_bikini", "innoxia_chest_micro_bikini", 1), new ClothingData("innoxia_chest_nursing_bra", "innoxia_chest_nursing_bra", 1), new ClothingData("innoxia_chest_open_cup_bra", "innoxia_chest_open_cup_bra", 1), new ClothingData("innoxia_chest_plunge_bra", "innoxia_chest_plunge_bra", 1), new ClothingData("innoxia_chest_sarashi", "innoxia_chest_sarashi", 1), new ClothingData("innoxia_chest_sports_bra", "innoxia_chest_sports_bra", 1), new ClothingData("innoxia_chest_strapless_bra", "innoxia_chest_strapless_bra", 1), new ClothingData("innoxia_chest_striped_bra", "innoxia_chest_striped_bra", 2), new ClothingData("innoxia_chest_swimsuit", "innoxia_chest_swimsuit", 1), new ClothingData("innoxia_chest_tube_top", "innoxia_chest_tube_top", 1), new ClothingData("innoxia_loinCloth_ragged_chest_wrap", "innoxia_loinCloth_ragged_chest_wrap", 1), new ClothingData("sage_latex_bra", "sage_latex_bra", 2)]);
        ClothingMap.Add(ClothingType.Groin, [new ClothingData("dsg_ckls_ckls_panties", "dsg_ckls_ckls_panties", 2), new ClothingData("innoxia_bdsm_chastity_belt", "innoxia_bdsm_chastity_belt", 3), new ClothingData("innoxia_bdsm_chastity_belt_full", "innoxia_bdsm_chastity_belt_full", 3), new ClothingData("innoxia_groin_backless_panties", "innoxia_groin_backless_panties", 1), new ClothingData("innoxia_groin_bikini", "innoxia_groin_bikini", 1), new ClothingData("innoxia_groin_boxers", "innoxia_groin_boxers", 1), new ClothingData("innoxia_groin_boyshorts", "innoxia_groin_boyshorts", 1), new ClothingData("innoxia_groin_briefs", "innoxia_groin_briefs", 1), new ClothingData("innoxia_groin_crotchless_briefs", "innoxia_groin_crotchless_briefs", 1), new ClothingData("innoxia_groin_crotchless_panties", "innoxia_groin_crotchless_panties", 1), new ClothingData("innoxia_groin_crotchless_thong", "innoxia_groin_crotchless_thong", 1), new ClothingData("innoxia_groin_jockstrap", "innoxia_groin_jockstrap", 2), new ClothingData("innoxia_groin_lacy_panties", "innoxia_groin_lacy_panties", 1), new ClothingData("innoxia_groin_lacy_thong", "innoxia_groin_lacy_thong", 1), new ClothingData("innoxia_groin_micro_bikini", "innoxia_groin_micro_bikini", 1), new ClothingData("innoxia_groin_panties", "innoxia_groin_panties", 1), new ClothingData("innoxia_groin_shimapan", "innoxia_groin_shimapan", 2), new ClothingData("innoxia_groin_swim_shorts", "innoxia_groin_swim_shorts", 1), new ClothingData("innoxia_groin_thong", "innoxia_groin_thong", 1), new ClothingData("innoxia_groin_vstring", "innoxia_groin_vstring", 1), new ClothingData("sage_latex_panties", "sage_latex_panties", 2)]);
        ClothingMap.Add(ClothingType.Leg, [new ClothingData("dsg_eep_ptrlequipset_enfslacks", "dsg_eep_ptrlequipset_enfslacks", 2), new ClothingData("dsg_eep_servequipset_enfdslacks", "dsg_eep_servequipset_enfdslacks", 2), new ClothingData("dsg_eep_servequipset_enfskirt", "dsg_eep_servequipset_enfskirt", 2), new ClothingData("dsg_eep_tacequipset_tpants", "dsg_eep_tacequipset_tpants", 2), new ClothingData("dsg_eisek_rspntrousers", "dsg_eisek_rspntrousers", 1), new ClothingData("dsg_hlf_equip_rtrousers", "dsg_hlf_equip_rtrousers", 2), new ClothingData("innoxia_butler_butler_trousers", "innoxia_butler_butler_trousers", 2), new ClothingData("innoxia_feral_saddle", "innoxia_feral_saddle", 2), new ClothingData("innoxia_leg_assless_chaps", "innoxia_leg_assless_chaps", 1), new ClothingData("innoxia_leg_asymmetrical_skirt", "innoxia_leg_asymmetrical_skirt", 1), new ClothingData("innoxia_leg_bike_shorts", "innoxia_leg_bike_shorts", 1), new ClothingData("innoxia_leg_cargo_trousers", "innoxia_leg_cargo_trousers", 1), new ClothingData("innoxia_leg_crotchless_chaps", "innoxia_leg_crotchless_chaps", 1), new ClothingData("innoxia_leg_distressed_jeans", "innoxia_leg_distressed_jeans", 2), new ClothingData("innoxia_leg_hotpants", "innoxia_leg_hotpants", 1), new ClothingData("innoxia_leg_jeans", "innoxia_leg_jeans", 1), new ClothingData("innoxia_leg_mens_hakama", "innoxia_leg_mens_hakama", 1), new ClothingData("innoxia_leg_micro_skirt_belted", "innoxia_leg_micro_skirt_belted", 1), new ClothingData("innoxia_leg_micro_skirt_pleated", "innoxia_leg_micro_skirt_pleated", 1), new ClothingData("innoxia_leg_mini_skirt", "innoxia_leg_mini_skirt", 1), new ClothingData("innoxia_leg_pencil_skirt", "innoxia_leg_pencil_skirt", 1), new ClothingData("innoxia_leg_shorts", "innoxia_leg_shorts", 1), new ClothingData("innoxia_leg_skirt", "innoxia_leg_skirt", 1), new ClothingData("innoxia_leg_sport_shorts", "innoxia_leg_sport_shorts", 1), new ClothingData("innoxia_leg_taur_skirt", "innoxia_leg_taur_skirt", 1), new ClothingData("innoxia_leg_taur_trousers", "innoxia_leg_taur_trousers", 1), new ClothingData("innoxia_leg_tight_jeans", "innoxia_leg_tight_jeans", 1), new ClothingData("innoxia_leg_trousers", "innoxia_leg_trousers", 1), new ClothingData("innoxia_leg_trousers_women", "innoxia_leg_trousers_women", 1), new ClothingData("innoxia_leg_yoga_pants", "innoxia_leg_yoga_pants", 1), new ClothingData("innoxia_loinCloth_loin_cloth", "innoxia_loinCloth_loin_cloth", 1), new ClothingData("innoxia_loinCloth_ragged_skirt", "innoxia_loinCloth_ragged_skirt", 1), new ClothingData("innoxia_lyssiethUniform_skirt", "innoxia_lyssiethUniform_skirt", 2), new ClothingData("nerdlinger_street_joggers_joggers", "nerdlinger_street_joggers_joggers", 1), new ClothingData("sage_latex_latexleggings", "sage_latex_latexleggings", 2), new ClothingData("clothing_TonyJC_daisy_dukes", "clothing_TonyJC_daisy_dukes", 1), new ClothingData("clothing_TonyJC_denim_overalls", "clothing_TonyJC_denim_overalls", 1)]);
        ClothingMap.Add(ClothingType.Hips, [new ClothingData("dsg_eep_ptrlequipset_utilbelt", "dsg_eep_ptrlequipset_utilbelt", 3), new ClothingData("dsg_eep_riotarmorset_riotbelt", "dsg_eep_riotarmorset_riotbelt", 3), new ClothingData("dsg_eep_servequipset_enfdbelt", "dsg_eep_servequipset_enfdbelt", 1), new ClothingData("dsg_eep_servequipset_enfstbelt", "dsg_eep_servequipset_enfstbelt", 2), new ClothingData("dsg_eep_tacequipset_battlebelt", "dsg_eep_tacequipset_battlebelt", 3), new ClothingData("dsg_eep_tacequipset_hbattlebelt", "dsg_eep_tacequipset_hbattlebelt", 3), new ClothingData("innoxia_hips_leather_belt", "innoxia_hips_leather_belt", 2)]);
        ClothingMap.Add(ClothingType.Ankle, [new ClothingData("dsg_eep_riotarmorset_riotshinguards", "dsg_eep_riotarmorset_riotshinguards", 3), new ClothingData("dsg_eep_tacequipset_tkneepads", "dsg_eep_tacequipset_tkneepads", 3), new ClothingData("innoxia_ankle_anklet", "innoxia_ankle_anklet", 2), new ClothingData("innoxia_ankle_shin_guards", "innoxia_ankle_shin_guards", 1), new ClothingData("innoxia_bdsm_spreaderbar", "innoxia_bdsm_spreaderbar", 2), new ClothingData("innoxia_bdsm_wrist_bracelets", "innoxia_bdsm_wrist_bracelets", 2), new ClothingData("innoxia_bdsm_wrist_restraints", "innoxia_bdsm_wrist_restraints", 2), new ClothingData("nerdlinger_rollerskating_kneepads_rollerskating_kneepads", "nerdlinger_rollerskating_kneepads_rollerskating_kneepads", 1)]);
        ClothingMap.Add(ClothingType.Foot, [new ClothingData("dsg_eep_servequipset_enfjackboots", "dsg_eep_servequipset_enfjackboots", 1), new ClothingData("dsg_eep_servequipset_enfpumps", "dsg_eep_servequipset_enfpumps", 2), new ClothingData("dsg_eep_tacequipset_cboots", "dsg_eep_tacequipset_cboots", 3), new ClothingData("dsg_eisek_oleathboots", "dsg_eisek_oleathboots", 1), new ClothingData("dsg_hlf_equip_vcboots", "dsg_hlf_equip_vcboots", 3), new ClothingData("innoxia_butler_butler_shoes", "innoxia_butler_butler_shoes", 3), new ClothingData("innoxia_feral_horse_shoe", "innoxia_feral_horse_shoe", 1), new ClothingData("innoxia_foot_ankle_boots", "innoxia_foot_ankle_boots", 2), new ClothingData("innoxia_foot_chelsea_boots", "innoxia_foot_chelsea_boots", 2), new ClothingData("innoxia_foot_flats", "innoxia_foot_flats", 3), new ClothingData("innoxia_foot_gladiator_sandals", "innoxia_foot_gladiator_sandals", 2), new ClothingData("innoxia_foot_goth_boots_fem", "innoxia_foot_goth_boots_fem", 3), new ClothingData("innoxia_foot_heels", "innoxia_foot_heels", 1), new ClothingData("innoxia_foot_low_top_skater_shoes", "innoxia_foot_low_top_skater_shoes", 1), new ClothingData("innoxia_foot_mens_smart_shoes", "innoxia_foot_mens_smart_shoes", 2), new ClothingData("innoxia_foot_platform_boots", "innoxia_foot_platform_boots", 2), new ClothingData("innoxia_foot_stiletto_heels", "innoxia_foot_stiletto_heels", 2), new ClothingData("innoxia_foot_strappy_sandals", "innoxia_foot_strappy_sandals", 3), new ClothingData("innoxia_foot_thigh_high_boots", "innoxia_foot_thigh_high_boots", 2), new ClothingData("innoxia_foot_trainers", "innoxia_foot_trainers", 2), new ClothingData("innoxia_foot_work_boots", "innoxia_foot_work_boots", 2), new ClothingData("innoxia_japanese_geta", "innoxia_japanese_geta", 2), new ClothingData("innoxia_japanese_mens_geta", "innoxia_japanese_mens_geta", 2), new ClothingData("innoxia_loinCloth_foot_wraps", "innoxia_loinCloth_foot_wraps", 3), new ClothingData("innoxia_lyssiethUniform_shoes", "innoxia_lyssiethUniform_shoes", 2), new ClothingData("innoxia_maid_heels", "innoxia_maid_heels", 3), new ClothingData("innoxia_witch_witch_boots", "innoxia_witch_witch_boots", 3), new ClothingData("innoxia_witch_witch_boots_thigh_high", "innoxia_witch_witch_boots_thigh_high", 3), new ClothingData("nerdlinger_street_hitop_canvas_sneakers_hi_top_canvas_sneakers", "nerdlinger_street_hitop_canvas_sneakers_hi_top_canvas_sneakers", 1)]);
        ClothingMap.Add(ClothingType.Mouth, [new ClothingData("dsg_eep_tacequipset_gmask", "dsg_eep_tacequipset_gmask", 1), new ClothingData("dsg_hlf_equip_sbandana", "dsg_hlf_equip_sbandana", 2), new ClothingData("innoxia_anus_ribbed_dildo", "innoxia_anus_ribbed_dildo", 1), new ClothingData("innoxia_bdsm_ballgag", "innoxia_bdsm_ballgag", 3), new ClothingData("innoxia_bdsm_ringgag", "innoxia_bdsm_ringgag", 3), new ClothingData("innoxia_feral_bridle", "innoxia_feral_bridle", 3), new ClothingData("innoxia_mouth_bandana", "innoxia_mouth_bandana", 1), new ClothingData("innoxia_vagina_onahole", "innoxia_vagina_onahole", 1), new ClothingData("innoxia_webbing_seal_mouth", "innoxia_webbing_seal_mouth", 1), new ClothingData("norin_dildos_realistic_dildo", "norin_dildos_realistic_dildo", 1)]);
        ClothingMap.Add(ClothingType.Finger, [new ClothingData("dsg_eisek_seawings_ring", "dsg_eisek_seawings_ring", 1), new ClothingData("innoxia_finger_gemstone_ring", "innoxia_finger_gemstone_ring", 1), new ClothingData("innoxia_finger_gemstone_ring_unisex", "innoxia_finger_gemstone_ring_unisex", 1), new ClothingData("innoxia_finger_lips_ring", "innoxia_finger_lips_ring", 1), new ClothingData("innoxia_finger_meander_ring", "innoxia_finger_meander_ring", 1), new ClothingData("innoxia_finger_ring", "innoxia_finger_ring", 1), new ClothingData("innoxia_finger_wrap_ring", "innoxia_finger_wrap_ring", 1)]);
        ClothingMap.Add(ClothingType.Anus, [new ClothingData("innoxia_anus_ribbed_dildo", "innoxia_anus_ribbed_dildo", 1), new ClothingData("innoxia_buttPlugs_butt_plug", "innoxia_buttPlugs_butt_plug", 1), new ClothingData("innoxia_buttPlugs_butt_plug_heart", "innoxia_buttPlugs_butt_plug_heart", 2), new ClothingData("innoxia_buttPlugs_butt_plug_jewel", "innoxia_buttPlugs_butt_plug_jewel", 2), new ClothingData("innoxia_buttPlugs_butt_plug_tail", "innoxia_buttPlugs_butt_plug_tail", 3), new ClothingData("innoxia_vagina_onahole", "innoxia_vagina_onahole", 1), new ClothingData("innoxia_webbing_seal_anus", "innoxia_webbing_seal_anus", 1), new ClothingData("norin_anal_beads_anal_beads", "norin_anal_beads_anal_beads", 1), new ClothingData("norin_dildos_realistic_dildo", "norin_dildos_realistic_dildo", 1)]);
        ClothingMap.Add(ClothingType.Vagina, [new ClothingData("innoxia_anus_ribbed_dildo", "innoxia_anus_ribbed_dildo", 1), new ClothingData("innoxia_milking_vagina_pump", "innoxia_milking_vagina_pump", 1), new ClothingData("innoxia_vagina_insertable_dildo", "innoxia_vagina_insertable_dildo", 1), new ClothingData("innoxia_vagina_onahole", "innoxia_vagina_onahole", 1), new ClothingData("innoxia_vagina_sticker_anal_only", "innoxia_vagina_sticker_anal_only", 1), new ClothingData("innoxia_webbing_seal_vagina", "innoxia_webbing_seal_vagina", 1), new ClothingData("norin_clover_clamps_clover_clamps", "norin_clover_clamps_clover_clamps", 1), new ClothingData("norin_dildos_realistic_dildo", "norin_dildos_realistic_dildo", 1), new ClothingData("norin_strapless_dildo_strapless_dildo", "norin_strapless_dildo_strapless_dildo", 1)]);
        ClothingMap.Add(ClothingType.Penis, [new ClothingData("innoxia_bdsm_chastity_cage", "innoxia_bdsm_chastity_cage", 1), new ClothingData("innoxia_bdsm_ornate_chastity_cage", "innoxia_bdsm_ornate_chastity_cage", 2), new ClothingData("innoxia_bdsm_penis_strapon", "innoxia_bdsm_penis_strapon", 1), new ClothingData("innoxia_milking_penis_pump", "innoxia_milking_penis_pump", 1), new ClothingData("innoxia_penis_condom", "innoxia_penis_condom", 1), new ClothingData("innoxia_penis_condom_strong", "innoxia_penis_condom_strong", 1), new ClothingData("innoxia_penis_condom_super_strong", "innoxia_penis_condom_super_strong", 1), new ClothingData("innoxia_penis_condom_webbing", "innoxia_penis_condom_webbing", 1), new ClothingData("norin_tail_ribbon_tail_ribbon", "norin_tail_ribbon_tail_ribbon", 1)]);
        ClothingMap.Add(ClothingType.PiercingEar, [new ClothingData("innoxia_cattle_piercing_ear_tag", "innoxia_cattle_piercing_ear_tag", 2), new ClothingData("innoxia_elemental_piercing_ear_snowflakes", "innoxia_elemental_piercing_ear_snowflakes", 1), new ClothingData("innoxia_elemental_piercing_ear_sun", "innoxia_elemental_piercing_ear_sun", 2), new ClothingData("innoxia_piercing_basic_barbell", "innoxia_piercing_basic_barbell", 1), new ClothingData("innoxia_piercing_basic_barbell_pair", "innoxia_piercing_basic_barbell_pair", 1), new ClothingData("innoxia_piercing_ear_ball_studs", "innoxia_piercing_ear_ball_studs", 1), new ClothingData("innoxia_piercing_ear_chain_dangle", "innoxia_piercing_ear_chain_dangle", 1), new ClothingData("innoxia_piercing_ear_cuff_chains", "innoxia_piercing_ear_cuff_chains", 1), new ClothingData("innoxia_piercing_ear_hoops", "innoxia_piercing_ear_hoops", 2), new ClothingData("innoxia_piercing_ear_pearl_studs", "innoxia_piercing_ear_pearl_studs", 2), new ClothingData("innoxia_piercing_ear_ring", "innoxia_piercing_ear_ring", 1), new ClothingData("innoxia_quest_dairy_ear_tag", "innoxia_quest_dairy_ear_tag", 1), new ClothingData("innoxia_quest_dairy_ear_tag_npc", "innoxia_quest_dairy_ear_tag_npc", 1), new ClothingData("norin_piercings_piercing_ear_bats", "norin_piercings_piercing_ear_bats", 1), new ClothingData("norin_rose_piercings_piercing_ear_rose", "norin_rose_piercings_piercing_ear_rose", 2), new ClothingData("norin_sunflower_piercings_piercing_ear_sunflower", "norin_sunflower_piercings_piercing_ear_sunflower", 2)]);
        ClothingMap.Add(ClothingType.PiercingNose, [new ClothingData("innoxia_cattle_piercing_nose_ring", "innoxia_cattle_piercing_nose_ring", 1), new ClothingData("innoxia_elemental_piercing_nose_snowflake", "innoxia_elemental_piercing_nose_snowflake", 1), new ClothingData("innoxia_elemental_piercing_nose_sun", "innoxia_elemental_piercing_nose_sun", 2), new ClothingData("innoxia_piercing_nose_ball_stud", "innoxia_piercing_nose_ball_stud", 1), new ClothingData("innoxia_piercing_nose_ring", "innoxia_piercing_nose_ring", 1), new ClothingData("norin_rose_piercings_piercing_nose_rose", "norin_rose_piercings_piercing_nose_rose", 2), new ClothingData("norin_sunflower_piercings_piercing_nose_sunflower", "norin_sunflower_piercings_piercing_nose_sunflower", 2)]);
        ClothingMap.Add(ClothingType.Tail, [new ClothingData("innoxia_feral_bandage", "innoxia_feral_bandage", 1), new ClothingData("norin_hair_accessories_hair_scrunchie", "norin_hair_accessories_hair_scrunchie", 1), new ClothingData("norin_tail_ribbon_tail_ribbon", "norin_tail_ribbon_tail_ribbon", 1)]);
        ClothingMap.Add(ClothingType.Hair, [new ClothingData("innoxia_hair_rose", "innoxia_hair_rose", 1), new ClothingData("innoxia_head_balaclava", "innoxia_head_balaclava", 1), new ClothingData("innoxia_japanese_kanzashi", "innoxia_japanese_kanzashi", 3), new ClothingData("innoxia_mouth_bandana", "innoxia_mouth_bandana", 1), new ClothingData("norin_hair_accessories_hair_bobby_pins", "norin_hair_accessories_hair_bobby_pins", 1), new ClothingData("norin_hair_accessories_hair_celtic_barrette", "norin_hair_accessories_hair_celtic_barrette", 2), new ClothingData("norin_hair_accessories_hair_dragonfly", "norin_hair_accessories_hair_dragonfly", 2), new ClothingData("norin_hair_accessories_hair_pins", "norin_hair_accessories_hair_pins", 1), new ClothingData("norin_hair_accessories_hair_scrunchie", "norin_hair_accessories_hair_scrunchie", 1), new ClothingData("norin_hair_accessories_hair_sticks", "norin_hair_accessories_hair_sticks", 1), new ClothingData("norin_tail_ribbon_tail_ribbon", "norin_tail_ribbon_tail_ribbon", 1)]);
        ClothingMap.Add(ClothingType.Horns, [new ClothingData("innoxia_horn_ring_chain", "innoxia_horn_ring_chain", 1), new ClothingData("innoxia_horn_thin_rings", "innoxia_horn_thin_rings", 1)]);
        ClothingMap.Add(ClothingType.Nipple, [new ClothingData("innoxia_milking_breast_pumps", "innoxia_milking_breast_pumps", 1), new ClothingData("innoxia_nipple_tape_crosses", "innoxia_nipple_tape_crosses", 1), new ClothingData("innoxia_webbing_seal_nipples", "innoxia_webbing_seal_nipples", 1), new ClothingData("norin_clover_clamps_clover_clamps", "norin_clover_clamps_clover_clamps", 1)]);
        ClothingMap.Add(ClothingType.PiercingTongue, [new ClothingData("innoxia_piercing_basic_barbell", "innoxia_piercing_basic_barbell", 1)]);
        ClothingMap.Add(ClothingType.PiercingNipple, [new ClothingData("innoxia_piercing_basic_barbell_pair", "innoxia_piercing_basic_barbell_pair", 1), new ClothingData("innoxia_piercing_nipple_chain", "innoxia_piercing_nipple_chain", 1), new ClothingData("norin_piercings_bat_wings_barbells", "norin_piercings_bat_wings_barbells", 1), new ClothingData("norin_piercings_heart_barbells", "norin_piercings_heart_barbells", 2), new ClothingData("norin_piercings_piercing_nipple_chain", "norin_piercings_piercing_nipple_chain", 1), new ClothingData("norin_piercings_piercing_nipple_rings", "norin_piercings_piercing_nipple_rings", 1)]);
        ClothingMap.Add(ClothingType.PiercingStomach, [new ClothingData("innoxia_piercing_gemstone_barbell", "innoxia_piercing_gemstone_barbell", 2), new ClothingData("innoxia_piercing_ringed_barbell", "innoxia_piercing_ringed_barbell", 1), new ClothingData("norin_piercings_caution_when_wet", "norin_piercings_caution_when_wet", 1), new ClothingData("norin_piercings_piercing_pentagram_navel", "norin_piercings_piercing_pentagram_navel", 1), new ClothingData("norin_rose_piercings_piercing_navel_rose", "norin_rose_piercings_piercing_navel_rose", 2), new ClothingData("norin_sunflower_piercings_piercing_sunflower_navel", "norin_sunflower_piercings_piercing_sunflower_navel", 2)]);
        ClothingMap.Add(ClothingType.PiercingVagina, [new ClothingData("innoxia_piercing_gemstone_barbell", "innoxia_piercing_gemstone_barbell", 2), new ClothingData("innoxia_piercing_ringed_barbell", "innoxia_piercing_ringed_barbell", 1), new ClothingData("norin_piercings_heart_clit", "norin_piercings_heart_clit", 1), new ClothingData("norin_piercings_piercing_vagina_sex", "norin_piercings_piercing_vagina_sex", 2), new ClothingData("norin_piercings_piercing_vertical_hood", "norin_piercings_piercing_vertical_hood", 2)]);
        ClothingMap.Add(ClothingType.PiercingLip, [new ClothingData("innoxia_piercing_lip_double_ring", "innoxia_piercing_lip_double_ring", 1), new ClothingData("norin_piercings_piercing_lip_flower", "norin_piercings_piercing_lip_flower", 2), new ClothingData("norin_rose_piercings_piercing_lip_rose", "norin_rose_piercings_piercing_lip_rose", 2), new ClothingData("norin_sunflower_piercings_piercing_lip_sunflower", "norin_sunflower_piercings_piercing_lip_sunflower", 2)]);
        ClothingMap.Add(ClothingType.PiercingPenis, [new ClothingData("innoxia_piercing_penis_ring", "innoxia_piercing_penis_ring", 1)]);

        #endregion

        #region Items Initialization

        ItemsMap.Add(ItemType.Item, [new ItemData("charisma_race_spider_chocolate_coated_cocoa_beans", "charisma_race_spider_chocolate_coated_cocoa_beans"), new ItemData("charisma_race_spider_jet_black_coffee", "charisma_race_spider_jet_black_coffee"), new ItemData("dsg_eisek_apples", "dsg_eisek_apples"), new ItemData("dsg_eisek_cartonobberries", "dsg_eisek_cartonobberries"), new ItemData("dsg_eisek_cartonosberries", "dsg_eisek_cartonosberries"), new ItemData("dsg_eisek_tangerines", "dsg_eisek_tangerines"), new ItemData("dsg_quest_awningpoles", "dsg_quest_awningpoles"), new ItemData("dsg_quest_embsign", "dsg_quest_embsign"), new ItemData("dsg_quest_fabricbolt", "dsg_quest_fabricbolt"), new ItemData("dsg_quest_hazmat_rat_card", "dsg_quest_hazmat_rat_card"), new ItemData("dsg_quest_sm_magicorb", "dsg_quest_sm_magicorb"), new ItemData("dsg_race_bear_honey_bread", "dsg_race_bear_honey_bread"), new ItemData("dsg_race_bear_vodka", "dsg_race_bear_vodka"), new ItemData("dsg_race_dragon_draft_green", "dsg_race_dragon_draft_green"), new ItemData("dsg_race_dragon_draft_orange", "dsg_race_dragon_draft_orange"), new ItemData("dsg_race_dragon_draft_pink", "dsg_race_dragon_draft_pink"), new ItemData("dsg_race_dragon_dragonfruit_pink", "dsg_race_dragon_dragonfruit_pink"), new ItemData("dsg_race_dragon_dragonfruit_red", "dsg_race_dragon_dragonfruit_red"), new ItemData("dsg_race_dragon_dragonfruit_yellow", "dsg_race_dragon_dragonfruit_yellow"), new ItemData("dsg_race_ferret_orange_juice", "dsg_race_ferret_orange_juice"), new ItemData("dsg_race_ferret_sausages", "dsg_race_ferret_sausages"), new ItemData("dsg_race_gryphon_pate_and_crackers", "dsg_race_gryphon_pate_and_crackers"), new ItemData("dsg_race_gryphon_two_tone_slushie", "dsg_race_gryphon_two_tone_slushie"), new ItemData("dsg_race_otter_berry_soda", "dsg_race_otter_berry_soda"), new ItemData("dsg_race_otter_fish_and_chips", "dsg_race_otter_fish_and_chips"), new ItemData("dsg_race_raccoon_cotton_candy_soda", "dsg_race_raccoon_cotton_candy_soda"), new ItemData("dsg_race_raccoon_popcorn", "dsg_race_raccoon_popcorn"), new ItemData("dsg_race_shark_grog", "dsg_race_shark_grog"), new ItemData("dsg_race_shark_tuna_sashimi", "dsg_race_shark_tuna_sashimi"), new ItemData("dsg_wetwipes_wetwipes", "dsg_wetwipes_wetwipes"), new ItemData("dsg_wetwipes_wetwipes_plus", "dsg_wetwipes_wetwipes_plus"), new ItemData("innoxia_cheat_inno_chans_gift", "innoxia_cheat_inno_chans_gift"), new ItemData("innoxia_cheat_unlikely_whammer", "innoxia_cheat_unlikely_whammer"), new ItemData("innoxia_food_doughnut", "innoxia_food_doughnut"), new ItemData("innoxia_food_doughnut_iced", "innoxia_food_doughnut_iced"), new ItemData("innoxia_food_doughnut_iced_sprinkles", "innoxia_food_doughnut_iced_sprinkles"), new ItemData("innoxia_pills_broodmother", "innoxia_pills_broodmother"), new ItemData("innoxia_pills_fertility", "innoxia_pills_fertility"), new ItemData("innoxia_pills_sterility", "innoxia_pills_sterility"), new ItemData("innoxia_potions_amazonian_ambrosia", "innoxia_potions_amazonian_ambrosia"), new ItemData("innoxia_potions_amazons_secret", "innoxia_potions_amazons_secret"), new ItemData("innoxia_quest_angelixx_diary", "innoxia_quest_angelixx_diary"), new ItemData("innoxia_quest_bank_card", "innoxia_quest_bank_card"), new ItemData("innoxia_quest_clothing_keys", "innoxia_quest_clothing_keys"), new ItemData("innoxia_quest_faire_ticket", "innoxia_quest_faire_ticket"), new ItemData("innoxia_quest_gym_membership_card", "innoxia_quest_gym_membership_card"), new ItemData("innoxia_quest_minotallys_pass", "innoxia_quest_minotallys_pass"), new ItemData("innoxia_quest_monica_milker", "innoxia_quest_monica_milker"), new ItemData("innoxia_quest_oglix_beer_token", "innoxia_quest_oglix_beer_token"), new ItemData("innoxia_quest_recorder", "innoxia_quest_recorder"), new ItemData("innoxia_quest_special_pass", "innoxia_quest_special_pass"), new ItemData("innoxia_quest_special_pass_elle", "innoxia_quest_special_pass_elle"), new ItemData("innoxia_race_alligator_gators_gumbo", "innoxia_race_alligator_gators_gumbo"), new ItemData("innoxia_race_alligator_swamp_water", "innoxia_race_alligator_swamp_water"), new ItemData("innoxia_race_angel_angels_tears", "innoxia_race_angel_angels_tears"), new ItemData("innoxia_race_badger_berry_trifle", "innoxia_race_badger_berry_trifle"), new ItemData("innoxia_race_badger_black_stripes_perry", "innoxia_race_badger_black_stripes_perry"), new ItemData("innoxia_race_bat_fruit_bats_juice_box", "innoxia_race_bat_fruit_bats_juice_box"), new ItemData("innoxia_race_bat_fruit_bats_salad", "innoxia_race_bat_fruit_bats_salad"), new ItemData("innoxia_race_cat_felines_fancy", "innoxia_race_cat_felines_fancy"), new ItemData("innoxia_race_cat_kittys_reward", "innoxia_race_cat_kittys_reward"), new ItemData("innoxia_race_cow_bubble_cream", "innoxia_race_cow_bubble_cream"), new ItemData("innoxia_race_cow_bubble_milk", "innoxia_race_cow_bubble_milk"), new ItemData("innoxia_race_deer_glade_springs", "innoxia_race_deer_glade_springs"), new ItemData("innoxia_race_deer_tree_shoots_salad", "innoxia_race_deer_tree_shoots_salad"), new ItemData("innoxia_race_demon_innoxias_gift", "innoxia_race_demon_innoxias_gift"), new ItemData("innoxia_race_demon_liliths_gift", "innoxia_race_demon_liliths_gift"), new ItemData("innoxia_race_dog_canine_crunch", "innoxia_race_dog_canine_crunch"), new ItemData("innoxia_race_dog_canine_crush", "innoxia_race_dog_canine_crush"), new ItemData("innoxia_race_doll_silic_oil", "innoxia_race_doll_silic_oil"), new ItemData("innoxia_race_fox_chicken_pot_pie", "innoxia_race_fox_chicken_pot_pie"), new ItemData("innoxia_race_fox_vulpines_vineyard", "innoxia_race_fox_vulpines_vineyard"), new ItemData("innoxia_race_goat_billys_best", "innoxia_race_goat_billys_best"), new ItemData("innoxia_race_goat_pans_flute", "innoxia_race_goat_pans_flute"), new ItemData("innoxia_race_harpy_bubblegum_lollipop", "innoxia_race_harpy_bubblegum_lollipop"), new ItemData("innoxia_race_harpy_harpy_perfume", "innoxia_race_harpy_harpy_perfume"), new ItemData("innoxia_race_horse_equine_cider", "innoxia_race_horse_equine_cider"), new ItemData("innoxia_race_horse_sugar_carrot_cube", "innoxia_race_horse_sugar_carrot_cube"), new ItemData("innoxia_race_human_bread_roll", "innoxia_race_human_bread_roll"), new ItemData("innoxia_race_human_vanilla_water", "innoxia_race_human_vanilla_water"), new ItemData("innoxia_race_imp_impish_brew", "innoxia_race_imp_impish_brew"), new ItemData("innoxia_race_mouse_barley_water", "innoxia_race_mouse_barley_water"), new ItemData("innoxia_race_mouse_cheese", "innoxia_race_mouse_cheese"), new ItemData("innoxia_race_none_mince_pie", "innoxia_race_none_mince_pie"), new ItemData("innoxia_race_panther_deep_roar", "innoxia_race_panther_deep_roar"), new ItemData("innoxia_race_panther_panthers_delight", "innoxia_race_panther_panthers_delight"), new ItemData("innoxia_race_pig_oinkers_fries", "innoxia_race_pig_oinkers_fries"), new ItemData("innoxia_race_pig_porcine_pop", "innoxia_race_pig_porcine_pop"), new ItemData("innoxia_race_rabbit_bunny_carrot_cake", "innoxia_race_rabbit_bunny_carrot_cake"), new ItemData("innoxia_race_rabbit_bunny_juice", "innoxia_race_rabbit_bunny_juice"), new ItemData("innoxia_race_raptor_energy_bar", "innoxia_race_raptor_energy_bar"), new ItemData("innoxia_race_raptor_energy_drink", "innoxia_race_raptor_energy_drink"), new ItemData("innoxia_race_rat_black_rats_rum", "innoxia_race_rat_black_rats_rum"), new ItemData("innoxia_race_rat_brown_rats_burger", "innoxia_race_rat_brown_rats_burger"), new ItemData("innoxia_race_reindeer_rudolphs_egg_nog", "innoxia_race_reindeer_rudolphs_egg_nog"), new ItemData("innoxia_race_reindeer_sugar_cookie", "innoxia_race_reindeer_sugar_cookie"), new ItemData("innoxia_race_sheep_ewes_brew", "innoxia_race_sheep_ewes_brew"), new ItemData("innoxia_race_sheep_woolly_goodness", "innoxia_race_sheep_woolly_goodness"), new ItemData("innoxia_race_slime_biojuice_canister", "innoxia_race_slime_biojuice_canister"), new ItemData("innoxia_race_slime_slime_quencher", "innoxia_race_slime_slime_quencher"), new ItemData("innoxia_race_squirrel_round_nuts", "innoxia_race_squirrel_round_nuts"), new ItemData("innoxia_race_squirrel_squirrel_java", "innoxia_race_squirrel_squirrel_java"), new ItemData("innoxia_race_wolf_meat_and_marrow", "innoxia_race_wolf_meat_and_marrow"), new ItemData("innoxia_race_wolf_wolf_whiskey", "innoxia_race_wolf_wolf_whiskey"), new ItemData("innoxia_slavery_freedom_certification", "innoxia_slavery_freedom_certification"), new ItemData("mintychip_race_salamander_apple_pie", "mintychip_race_salamander_apple_pie"), new ItemData("mintychip_race_salamander_hot_cocoa", "mintychip_race_salamander_hot_cocoa"), new ItemData("mintychip_race_salamander_iced_tea", "mintychip_race_salamander_iced_tea"), new ItemData("NoStepOnSnek_race_capybara_brownie", "NoStepOnSnek_race_capybara_brownie"), new ItemData("NoStepOnSnek_race_capybara_tea2go", "NoStepOnSnek_race_capybara_tea2go"), new ItemData("NoStepOnSnek_race_octopus_ink_vodka", "NoStepOnSnek_race_octopus_ink_vodka"), new ItemData("NoStepOnSnek_race_octopus_shrimp_cocktail", "NoStepOnSnek_race_octopus_shrimp_cocktail"), new ItemData("NoStepOnSnek_race_snake_eggs", "NoStepOnSnek_race_snake_eggs"), new ItemData("NoStepOnSnek_race_snake_oil", "NoStepOnSnek_race_snake_oil"), new ItemData("rfpnj_peach_peach", "rfpnj_peach_peach")]);

        #endregion

        #region Weapons Initialization

        WeaponsMap.Add(WeaponType.Ranged, [new WeaponData("c4mg1rl_bows_hama_yumi", "c4mg1rl_bows_hama_yumi"), new WeaponData("dsg_eep_cryoprism_cryoprism", "dsg_eep_cryoprism_cryoprism"), new WeaponData("dsg_eep_liqstungun_coomgun", "dsg_eep_liqstungun_coomgun"), new WeaponData("dsg_eep_liqstungun_liqstungun", "dsg_eep_liqstungun_liqstungun"), new WeaponData("dsg_eep_pbweap_pblauncher", "dsg_eep_pbweap_pblauncher"), new WeaponData("dsg_eep_pbweap_pbpistol", "dsg_eep_pbweap_pbpistol"), new WeaponData("dsg_eep_pbweap_pbrifle", "dsg_eep_pbweap_pbrifle"), new WeaponData("dsg_eep_taser_taser", "dsg_eep_taser_taser"), new WeaponData("dsg_eep_trqrifle_trqrifle", "dsg_eep_trqrifle_trqrifle"), new WeaponData("dsg_hlf_weap_gbshotgun", "dsg_hlf_weap_gbshotgun"), new WeaponData("dsg_hlf_weap_pboltrifle", "dsg_hlf_weap_pboltrifle"), new WeaponData("dsg_hlf_weap_pbomb", "dsg_hlf_weap_pbomb"), new WeaponData("dsg_hlf_weap_pbrevolver", "dsg_hlf_weap_pbrevolver"), new WeaponData("dsg_hlf_weap_pbsmg", "dsg_hlf_weap_pbsmg"), new WeaponData("innoxia_bow_pistol_crossbow", "innoxia_bow_pistol_crossbow"), new WeaponData("innoxia_bow_recurve", "innoxia_bow_recurve"), new WeaponData("innoxia_bow_shortbow", "innoxia_bow_shortbow"), new WeaponData("innoxia_cheat_doggo_whistle", "innoxia_cheat_doggo_whistle"), new WeaponData("innoxia_feather_epic", "innoxia_feather_epic"), new WeaponData("innoxia_feather_legendary", "innoxia_feather_legendary"), new WeaponData("innoxia_feather_rare", "innoxia_feather_rare"), new WeaponData("innoxia_gun_arcane_musket", "innoxia_gun_arcane_musket"), new WeaponData("innoxia_gun_br14", "innoxia_gun_br14"), new WeaponData("innoxia_gun_famase", "innoxia_gun_famase"), new WeaponData("innoxia_gun_lar1a1", "innoxia_gun_lar1a1"), new WeaponData("innoxia_gun_mkar", "innoxia_gun_mkar"), new WeaponData("innoxia_gun_revolver", "innoxia_gun_revolver"), new WeaponData("innoxia_gun_waspley_mk4_service", "innoxia_gun_waspley_mk4_service"), new WeaponData("innoxia_gun_western_ppk", "innoxia_gun_western_ppk"), new WeaponData("innoxia_lightningGlobe_lightning_globe", "innoxia_lightningGlobe_lightning_globe"), new WeaponData("innoxia_lightningGlobe_lightning_globe_ring", "innoxia_lightningGlobe_lightning_globe_ring"), new WeaponData("innoxia_thrown_tennis_ball", "innoxia_thrown_tennis_ball"), new WeaponData("innoxia_thrown_yarn", "innoxia_thrown_yarn")]);
        WeaponsMap.Add(WeaponType.Melee, [new WeaponData("c4mg1rl_swords_muramasa", "c4mg1rl_swords_muramasa"), new WeaponData("dsg_eep_enbaton_enbaton", "dsg_eep_enbaton_enbaton"), new WeaponData("dsg_eep_riotshield_riotshield", "dsg_eep_riotshield_riotshield"), new WeaponData("dsg_sm_cboard_cbsword", "dsg_sm_cboard_cbsword"), new WeaponData("innoxia_arcanistStaff_arcanist_staff", "innoxia_arcanistStaff_arcanist_staff"), new WeaponData("innoxia_axe_battle", "innoxia_axe_battle"), new WeaponData("innoxia_bat_metal", "innoxia_bat_metal"), new WeaponData("innoxia_bat_wooden", "innoxia_bat_wooden"), new WeaponData("innoxia_bat_wooden_silly", "innoxia_bat_wooden_silly"), new WeaponData("innoxia_bdsm_riding_crop", "innoxia_bdsm_riding_crop"), new WeaponData("innoxia_blunt_morning_star", "innoxia_blunt_morning_star"), new WeaponData("innoxia_blunt_sledgehammer", "innoxia_blunt_sledgehammer"), new WeaponData("innoxia_cleaning_feather_duster", "innoxia_cleaning_feather_duster"), new WeaponData("innoxia_cleaning_witch_broom", "innoxia_cleaning_witch_broom"), new WeaponData("innoxia_crystal_epic", "innoxia_crystal_epic"), new WeaponData("innoxia_crystal_legendary", "innoxia_crystal_legendary"), new WeaponData("innoxia_crystal_rare", "innoxia_crystal_rare"), new WeaponData("innoxia_dagger_dagger", "innoxia_dagger_dagger"), new WeaponData("innoxia_dagger_sword", "innoxia_dagger_sword"), new WeaponData("innoxia_europeanSwords_arming_sword", "innoxia_europeanSwords_arming_sword"), new WeaponData("innoxia_europeanSwords_xiphos", "innoxia_europeanSwords_xiphos"), new WeaponData("innoxia_europeanSwords_zweihander", "innoxia_europeanSwords_zweihander"), new WeaponData("innoxia_japaneseSwords_katana", "innoxia_japaneseSwords_katana"), new WeaponData("innoxia_japaneseSwords_wakizashi", "innoxia_japaneseSwords_wakizashi"), new WeaponData("innoxia_kerambit_kerambit", "innoxia_kerambit_kerambit"), new WeaponData("innoxia_knuckleDusters_knuckle_dusters", "innoxia_knuckleDusters_knuckle_dusters"), new WeaponData("innoxia_pipe_pipe", "innoxia_pipe_pipe"), new WeaponData("innoxia_scythe_scythe", "innoxia_scythe_scythe"), new WeaponData("innoxia_shield_buckler", "innoxia_shield_buckler"), new WeaponData("innoxia_shield_crude_wooden", "innoxia_shield_crude_wooden"), new WeaponData("innoxia_spear_dory", "innoxia_spear_dory"), new WeaponData("innoxia_utility_flashlight", "innoxia_utility_flashlight")]);

        #endregion

        #region Type Lookup Initialization
        
        foreach (var type in ClothingMap.Keys)
        {
            foreach (var item in ClothingMap[type])
            {
                ClothingTypeLookup.Add(item.Value, type);
            }
        }
        
        foreach (var type in ItemsMap.Keys)
        {
            foreach (var item in ItemsMap[type])
            {
                ItemTypeLookup.Add(item.Value, type);
            }
        }
        
        foreach (var type in WeaponsMap.Keys)
        {
            foreach (var item in WeaponsMap[type])
            {
                WeaponTypeLookup.Add(item.Value, type);
            }
        }
        
        #endregion

        #region All Items Collection Initialization

        AllClothing = ClothingMap.Keys.SelectMany(key => ClothingMap[key]).ToArray();
        AllItems = ItemsMap.Keys.SelectMany(key => ItemsMap[key]).ToArray();
        AllWeapons = WeaponsMap.Keys.SelectMany(key => WeaponsMap[key]).ToArray();

        #endregion

        #endregion
    }

    public static string GetExtremityLabel(int value)
    {
        return value switch
        {
            < 10 => "Tiny",
            >= 10 and < 22 => "Small",
            >= 22 and < 40 => "Long",
            >= 40 and < 62 => "Huge",
            >= 62 => "Massive"
        };
    }

    public static string GetCapacityLabel(float value)
    {
        return value switch
        {
            < 7 => "Very Shallow",
            >= 7 and < 15 => "Shallow",
            >= 15 and < 25 => "Average-depth",
            >= 25 and < 35 => "Spacious",
            >= 35 and < 45 => "Deep",
            >= 45 and < 55 => "Very Deep",
            >= 55 and < 80 => "Cavernous",
            >= 80 => "Fathomless",
            _ => "Invalid"
        };
    }

    public static string GetDepthLabel(int value)
    {
        return value switch
        {
            <= 0 => "Very Shallow",
            1 => "Shallow",
            2 => "Average-depth",
            3 => "Spacious",
            4 => "Deep",
            5 => "Very Deep",
            6 => "Cavernous",
            >=7 => "Fathomless"
        };
    }

    public static string GetElasticityLabel(int value)
    {
        return value switch
        {
            <= 0 => "Rigid",
            1 => "Stiff",
            2 => "Firm",
            3 => "Flexible",
            4 => "Limber",
            5 => "Stretchy",
            6 => "Supple",
            >=7 => "Elastic"
        };
    }

    public static string GetPlasticityLabel(int value)
    {
        return value switch
        {
            <= 0 => "Rubbery",
            1 => "Springy",
            2 => "Tensile",
            3 => "Resilient",
            4 => "Accommodating",
            5 => "Yielding",
            6 => "Malleable",
            >=7 => "Moldable"
        };
    }

    public static string GetWetnessLabel(int value)
    {
        return value switch
        {
            <= 0 => "Dry",
            1 => "Slightly Moist",
            2 => "Moist",
            3 => "Wet",
            4 => "Slimy",
            5 => "Sloppy",
            6 => "Sopping Wet",
            >=7 => "Drooling"
        };
    }

    public static string GetFluidRegenerationLabel(int value)
    {
        return value switch
        {
            < 300 => "Slow",
            >= 300 and < 800 => "Average",
            >= 800 and < 5000 => "Fast",
            >= 5000 and < 10000 => "Rapid",
            >= 10000 => "Very Rapid"
        };
    }

    public static string GetBodyPartSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Tiny",
            1 => "Small",
            2 => "Average-sized",
            3 => "Large",
            >= 4 => "Massive"
        };
    }

    public static string GetAppendageGirthLabel(int value)
    {
        return value switch
        {
            <= 0 => "Thin",
            1 => "Slender",
            2 => "Narrow",
            3 => "Average",
            4 => "Thick",
            5 => "Extra-thick",
            6 => "Extremely-thick",
            >= 7 => "Unbelievable-thick"
        };
    }

    public static string GetPenisClitGirthLabel(int value)
    {
        return value switch
        {
            <= 0 => "Thin",
            1 => "Slender",
            2 => "Narrow",
            3 => "Averagely-girthed",
            4 => "Girthy",
            5 => "Thick",
            6 => "Chubby",
            >= 7 => "Fat"
        };
    }
}