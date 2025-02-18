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
        new("None", "ZERO_NONE"), new("Stubble", "ONE_STUBBLE"),
        new("Manicured", "TWO_MANICURED"),
        new("Trimmed", "THREE_TRIMMED"),
        new("Natural", "FOUR_NATURAL"),
        new("Unkempt", "FIVE_UNKEMPT"),
        new("Bushy", "SIX_BUSHY"), new("Wild", "SEVEN_WILD")
    ];

    public static ValueDisplayPair<string>[] BodyFluidFlavours { get; } =
    [
        new("Cum", "CUM"), new("Milk", "MILK"),
        new("Girlcum", "GIRL_CUM"), new("Bubblegum", "BUBBLEGUM"),
        new("Beer", "BEER"), new("Vanilla", "VANILLA"),
        new("Strawberry", "STRAWBERRY"),
        new("Chocolate", "CHOCOLATE"),
        new("Pineapple", "PINEAPPLE"), new("Honey", "HONEY"),
        new("Mint", "MINT"), new("Cherry", "CHERRY"),
        new("Coffee", "COFFEE"), new("Tea", "TEA"),
        new("Maple", "MAPLE"), new("Cinnamon", "CINNAMON"),
        new("Lemon", "LEMON"), new("Orange", "ORANGE"),
        new("Grape", "GRAPE"), new("Melon", "MELON"),
        new("Coconut", "COCONUT"), new("Blueberry", "BLUEBERRY")
    ];

    private static readonly ValueDisplayPair<string>[] LegConfigurationsMaster =
    [
        new("Bipedal", "BIPEDAL"), new("Quadrupedal", "QUADRUPEDAL"),
        new("Serpent-tailed", "TAIL_LONG"),
        new("Arachnid", "ARACHNID"),
        new("Cephalopod", "CEPHALOPOD"), new("Mer-tailed", "TAIL"),
        new("Avian", "AVIAN")
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
        new("None", "NONE"), new("Plantigrade", "PLANTIGRADE"),
        new("Unguligrade", "UNGULIGRADE"),
        new("Digitigrade", "DIGITIGRADE"),
        new("Arachnoid", "ARACHNOID"), new("Tentacled", "TENTACLED")
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
        new("Normal", "NORMAL"), new("Cloaca", "CLOACA"),
        new("Rear-facing cloaca", "CLOACA_BEHIND")
    ];

    private static ValueDisplayPair<string>[] genitalArrangementsCR;
    private static ValueDisplayPair<string>[] genitalArrangementsN;
    private static ValueDisplayPair<string>[] genitalArrangementsC;
    private static ValueDisplayPair<string>[] genitalArrangementsR;

    public static LegTypeValueDisplayPair[] LegTypes { get; }

    public static ValueDisplayPair<string>[] FemininityValues { get; } =
    [
        new("Very Masculine", "VERY_MASCULINE"),
        new("Masculine", "MASCULINE"),
        new("Androgynous", "ANDROGYNOUS"),
        new("Feminine", "FEMININE"),
        new("Very Feminine", "VERY_FEMININE")
    ];

    public static ValueDisplayPair<string>[] SubspeciesOverrides { get; } =
    [
        new("Human", "HUMAN"), new("Angel", "ANGEL"),
        new("Elder Lilin", "ELDER_LILIN"), new("Lilin", "LILIN"),
        new("Demon", "DEMON"), new("Half Demon", "HALF_DEMON"),
        new("Imp", "IMP"), new("Imp Alpha", "IMP_ALPHA"),
        new("Cow Morph", "COW_MORPH"), new("Dog Morph", "DOG_MORPH"),
        new("Dog Morph Border Collie", "DOG_MORPH_BORDER_COLLIE"),
        new("Dog Morph Dobermann", "DOG_MORPH_DOBERMANN"),
        new("Dog Morph German Shepherd", "DOG_MORPH_GERMAN_SHEPHERD"),
        new("Dragon Morph", "dsg_dragon_subspecies_dragon"),
        new("Wolf Morph", "WOLF_MORPH"),
        new("Fox Morph", "FOX_MORPH"),
        new("Fox Morph Arctic", "FOX_MORPH_ARCTIC"),
        new("Fox Morph Fennec", "FOX_MORPH_FENNEC"),
        new("Fox Ascendant", "FOX_ASCENDANT"),
        new("Fox Ascendant Arctic", "FOX_ASCENDANT_ARCTIC"),
        new("Fox Ascendant Fennec", "FOX_ASCENDANT_FENNEC"),
        new("Cat Morph", "CAT_MORPH"),
        new("Cat Morph Lynx", "CAT_MORPH_LYNX"),
        new("Cat Morph Cheetah", "CAT_MORPH_CHEETAH"),
        new("Cat Morph Caracal", "CAT_MORPH_CARACAL"),
        new("Cat Morph Leopard Snow", "CAT_MORPH_LEOPARD_SNOW"),
        new("Cat Morph Leopard", "CAT_MORPH_LEOPARD"),
        new("Cat Morph Lion", "CAT_MORPH_LION"),
        new("Cat Morph Tiger", "CAT_MORPH_TIGER"),
        new("Horse Morph", "HORSE_MORPH"),
        new("Horse Morph Unicorn", "HORSE_MORPH_UNICORN"),
        new("Horse Morph Pegasus", "HORSE_MORPH_PEGASUS"),
        new("Horse Morph Alicorn", "HORSE_MORPH_ALICORN"),
        new("Centaur", "CENTAUR"), new("Pegataur", "PEGATAUR"),
        new("Unitaur", "UNITAUR"), new("Alitaur", "ALITAUR"),
        new("Horse Morph Zebra", "HORSE_MORPH_ZEBRA"),
        new("Reindeer Morph", "REINDEER_MORPH"),
        new("Alligator Morph", "ALLIGATOR_MORPH"),
        new("Slime", "SLIME"),
        new("Squirrel Morph", "SQUIRREL_MORPH"),
        new("Rat Morph", "RAT_MORPH"),
        new("Rabbit Morph", "RABBIT_MORPH"),
        new("Rabbit Morph Lop", "RABBIT_MORPH_LOP"),
        new("Bat Morph", "BAT_MORPH"), new("Harpy", "HARPY"),
        new("Harpy Raven", "HARPY_RAVEN"),
        new("Harpy Bald Eagle", "HARPY_BALD_EAGLE"),
        new("Harpy Phoenix", "HARPY_PHOENIX"),
        new("Elemental Fire", "ELEMENTAL_FIRE"),
        new("Elemental Earth", "ELEMENTAL_EARTH"),
        new("Elemental Water", "ELEMENTAL_WATER"),
        new("Elemental Air", "ELEMENTAL_AIR"),
        new("Elemental Arcane", "ELEMENTAL_ARCANE"),
        new("Badger", "innoxia_badger_subspecies_badger")
    ]; //TODO Check if these are all subspecies in the game

    public static Dictionary<ClothingType, ClothingData[]> ClothingMap { get; } = new();
    public static Dictionary<ItemType, ItemData[]> ItemsMap { get; } = new();
    public static Dictionary<WeaponType, WeaponData[]> WeaponsMap { get; } = new();
    
    public static ValueDisplayPair<ClothingType>[] ClothingTypes { get; } =
    [
        new("Head", ClothingType.Head),
        new("Eyes", ClothingType.Eyes),
        new("Hair", ClothingType.Hair),
        new("Mouth", ClothingType.Mouth),
        new("Neck", ClothingType.Neck),
        new("Over-torso", ClothingType.TorsoOver),
        new("Torso", ClothingType.TorsoUnder),
        new("Chest", ClothingType.Chest),
        new("Nipple", ClothingType.Nipple),
        new("Stomach", ClothingType.Stomach),
        new("Hand", ClothingType.Hand),
        new("Wrist", ClothingType.Wrist),
        new("Finger", ClothingType.Finger),
        new("Hips", ClothingType.Hips),
        new("Anus", ClothingType.Anus),
        new("Leg", ClothingType.Leg),
        new("Groin", ClothingType.Groin),
        new("Foot", ClothingType.Foot),
        new("Sock", ClothingType.Sock),
        new("Ankle", ClothingType.Ankle),
        new("Horns", ClothingType.Horns),
        new("Wings", ClothingType.Wings),
        new("Tail", ClothingType.Tail),
        new("Penis", ClothingType.Penis),
        new("Vagina", ClothingType.Vagina),
        new("Ear Piercing", ClothingType.PiercingEar),
        new("Nose Piercing", ClothingType.PiercingNose),
        new("Tongue Piercing", ClothingType.PiercingTongue),
        new("Lip Piercing", ClothingType.PiercingLip),
        new("Stomach Piercing", ClothingType.PiercingStomach),
        new("Nipple Piercing", ClothingType.PiercingNipple),
        new("Vagina Piercing", ClothingType.PiercingVagina),
        new("Penis Piercing", ClothingType.PiercingPenis)
    ];

    public static ValueDisplayPair<ItemType>[] ItemTypes { get; } =
    [
        new("Item", ItemType.Item),
        /*new("Essence", ItemType.Essence),
        new("Book", ItemType.Book),
        new("Spell", ItemType.Spell)*/ // TODO: Implement
    ];
    
    public static ValueDisplayPair<WeaponType>[] WeaponTypes { get; } =
    [
        new("Melee", WeaponType.Melee),
        new("Ranged", WeaponType.Ranged)
    ];


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
            new LegTypeValueDisplayPair("Alligator", "ALLIGATOR_MORPH", _legConfigurationsBQ, _footStructuresP,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Angel", "ANGEL", _legConfigurationsB, _footStructuresP,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Badger", "innoxia_badger_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Bat", "BAT_MORPH", _legConfigurationsB, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Bear", "dsg_bear_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Capybara", "NoStepOnSnek_capybara_leg", _legConfigurationsBQ,
                _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Cat", "CAT_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Cow", "COW_MORPH", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic", "DEMON_COMMON", _legConfigurationsB, _footStructuresP,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic-hoofed", "DEMON_HOOFED", _legConfigurationsB, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic-horse", "DEMON_HORSE", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Demonic-snake", "DEMON_SNAKE", _legConfigurationsS, _footStructuresN,
                genitalArrangementsCR),
            new LegTypeValueDisplayPair("Demonic-spider", "DEMON_SPIDER", _legConfigurationsAr, _footStructuresA,
                genitalArrangementsN),
            new LegTypeValueDisplayPair("Demonic-octopus", "DEMON_OCTOPUS", _legConfigurationsC, _footStructuresT,
                genitalArrangementsC),
            new LegTypeValueDisplayPair("Demonic-fish", "DEMON_FISH", _legConfigurationsM, _footStructuresN,
                genitalArrangementsCR),
            new LegTypeValueDisplayPair("Demonic-eagle", "DEMON_EAGLE", _legConfigurationsAv, _footStructuresD,
                genitalArrangementsR),
            new LegTypeValueDisplayPair("Dog", "DOG_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Dragon", "dsg_dragon_leg", _legConfigurationsBQSM, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Ferret", "dsg_ferret_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Fox", "FOX_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Goat", "innoxia_goat_leg", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Gryphon", "dsg_gryphon_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Harpy", "HARPY", _legConfigurationsBAv, _footStructuresD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Horse", "HORSE_MORPH", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Human", "HUMAN", _legConfigurationsB, _footStructuresP,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Hyena", "innoxia_hyena_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Octopus", "NoStepOnSnek_octopus_leg", _legConfigurationsC, _footStructuresT,
                genitalArrangementsC),
            new LegTypeValueDisplayPair("Otter", "dsg_otter_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Panther", "innoxia_panther_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeValueDisplayPair("Pig", "innoxia_pig_leg", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Rabbit", "RABBIT_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Racoon", "dsg_racoon_leg", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Rat", "RAT_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Reindeer", "REINDEER_MORPH", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Shark", "dsg_shark_leg", _legConfigurationsBM, _footStructuresP,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Sheep", "innoxia_sheep_leg", _legConfigurationsBQ, _footStructuresU,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Snake", "NoStepOnSnek_snake_leg", _legConfigurationsBS, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Furred Spider", "charisma_spider_legFluffy", _legConfigurationsBAr,
                _footStructuresPD, GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Spider", "charisma_spider_leg", _legConfigurationsBAr, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Squirrel", "SQUIRREL_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR),
            new LegTypeValueDisplayPair("Wolf", "WOLF_MORPH", _legConfigurationsBQ, _footStructuresPD,
                GenitalArrangementsNCR, "DIGITIGRADE")
        ];

        #endregion

        #region Item Dictionaries Initialization

        // The maps were autogenerated via python script

        #region Clothes Initialization

        ClothingMap.Add(ClothingType.TorsoOver,
        [
            new ClothingData("Raincoat", "bloom_wasp609_rainCoat_rain_coat", 3),
            new ClothingData("Trickster's Cloak", "c4mg1rl_trickster_cloak", 3),
            new ClothingData("Stabproof Vest", "dsg_eep_ptrlequipset_stpvest", 3),
            new ClothingData("Enforcer's Riot Armour", "dsg_eep_riotarmorset_riotarmor", 3),
            new ClothingData("Test Coat", "dsg_eep_servequipset_debuggerydo_enfdjacket", 3),
            new ClothingData("Coat", "dsg_eep_servequipset_enfdjacket", 3),
            new ClothingData("Waistcoat", "dsg_eep_servequipset_enfdwaistcoat", 3),
            new ClothingData("Enforcer's Greatcoat", "dsg_eep_servequipset_enfgreatcoat", 3),
            new ClothingData("Commando Sweater Vest", "dsg_eep_servequipset_milsweatervest_crew", 3),
            new ClothingData("Enforcer's Commando Sweater Vest", "dsg_eep_servequipset_milsweatervest_crewen", 3),
            new ClothingData("Commando Sweater", "dsg_eep_servequipset_milsweater_crew", 3),
            new ClothingData("Enforcer's Commando Sweater", "dsg_eep_servequipset_milsweater_crewen", 3),
            new ClothingData("V-Necked Commando Sweater", "dsg_eep_servequipset_milsweater_vee", 3),
            new ClothingData("Heavy Plate Carrier", "dsg_eep_tacequipset_hpltcarrier", 3),
            new ClothingData("Plate Carrier", "dsg_eep_tacequipset_pltcarrier", 3),
            new ClothingData("Roughspun Tunic", "dsg_eisek_rspntunic", 3),
            new ClothingData("Canvas Bandolier", "dsg_hlf_equip_rbandolier", 2),
            new ClothingData("Canvas Webbing", "dsg_hlf_equip_rwebbing", 2),
            new ClothingData("Men's Leather Jacket", "dsg_ljacket_ljacket", 3),
            new ClothingData("Women's Leather Jacket", "dsg_ljacket_ljacket_f", 3),
            new ClothingData("Vintage Field Jacket", "dsg_m65jacket_m65jacket", 2),
            new ClothingData("Trenchcoat", "dsg_shadydealer_trenchcoat", 3),
            new ClothingData("Cardboard Cuirass", "dsg_sm_cboard_cbarmor", 3),
            new ClothingData("Butler's Jacket", "innoxia_butler_butler_jacket", 1),
            new ClothingData("Dark Siren's Cloak", "innoxia_darkSiren_siren_cloak", 3),
            new ClothingData("Men's Haori", "innoxia_japanese_haori", 1),
            new ClothingData("Service Dress Tunic", "innoxia_lyssiethUniform_tunic", 3),
            new ClothingData("Lab Coat", "innoxia_scientist_lab_coat", 1),
            new ClothingData("Feminine Apron", "innoxia_torsoOver_apron", 2),
            new ClothingData("Beer Barrel", "innoxia_torsoOver_beer_barrel", 3),
            new ClothingData("Blazer", "innoxia_torsoOver_blazer", 1),
            new ClothingData("Festive Jumper", "innoxia_torsoOver_christmas_jumper", 2),
            new ClothingData("Dress Coat", "innoxia_torsoOver_dress_coat", 3),
            new ClothingData("Feminine Blazer", "innoxia_torsoOver_feminine_blazer", 2),
            new ClothingData("Fur Cloak", "innoxia_torsoOver_fur_cloak", 3),
            new ClothingData("Himation", "innoxia_torsoOver_himation", 1),
            new ClothingData("Hooded Cloak", "innoxia_torsoOver_hooded_cloak", 2),
            new ClothingData("Hoodie", "innoxia_torsoOver_hoodie", 1),
            new ClothingData("Keyhole Jumper", "innoxia_torsoOver_keyhole_jumper", 1),
            new ClothingData("Open-Front Cardigan", "innoxia_torsoOver_open_front_cardigan", 1),
            new ClothingData("Ribbed Jumper", "innoxia_torsoOver_ribbed_jumper", 1),
            new ClothingData("Suit Jacket", "innoxia_torsoOver_suit_jacket", 3),
            new ClothingData("Hazmat Rat Vending Machine", "innoxia_torsoOver_vending_machine", 1),
            new ClothingData("Women's Fashionable Leather Jacket", "innoxia_torsoOver_womens_leather_jacket", 3),
            new ClothingData("Women's Winter Coat", "innoxia_torsoOver_womens_winter_coat", 2),
            new ClothingData("Utility Jacket", "nerdlinger_builder_utility_jacket_utility_jacket", 2),
            new ClothingData("Poncho", "NoStepOnSnek_poncho_poncho", 2),
            new ClothingData("Cropped Sweater", "TonyJC_cropped_sweater", 2),
            new ClothingData("Shoulderless Sweater", "TonyJC_shoulderless_top", 2)
        ]);
        ClothingMap.Add(ClothingType.TorsoUnder,
        [
            new ClothingData("Kyudogi", "c4mg1rl_benevolent_kyudogi", 3),
            new ClothingData("Trickster's Tunic", "c4mg1rl_trickster_tunic", 3),
            new ClothingData("Enforcer's Long-Sleeved Blouse", "dsg_eep_ptrlequipset_flsldshirt", 3),
            new ClothingData("Enforcer's Short-Sleeved Blouse", "dsg_eep_ptrlequipset_fssldshirt", 3),
            new ClothingData("Enforcer's Long-Sleeved Shirt", "dsg_eep_ptrlequipset_lsldshirt", 3),
            new ClothingData("Enforcer's Short-Sleeved Shirt", "dsg_eep_ptrlequipset_ssldshirt", 3),
            new ClothingData("Combat Shirt", "dsg_eep_tacequipset_cbtshirt", 2),
            new ClothingData("Enforcer's Combat Shirt", "dsg_eep_tacequipset_enf_cbtshirt", 2),
            new ClothingData("Enforcer's Short-Sleeved Combat Shirt", "dsg_eep_tacequipset_enf_sslcbtshirt", 2),
            new ClothingData("Short-Sleeved Combat Shirt", "dsg_eep_tacequipset_sslcbtshirt", 2),
            new ClothingData("Linen Shirt", "dsg_eisek_sundshirt", 1),
            new ClothingData("Vintage Fatigue Tunic", "dsg_hlf_equip_rtunic", 3),
            new ClothingData("Butler's Waistcoat", "innoxia_butler_butler_waistcoat_shirt", 3),
            new ClothingData("Kimono", "innoxia_japanese_kimono", 3),
            new ClothingData("Short Kimono", "innoxia_japanese_kimono_short", 3),
            new ClothingData("Men's Kimono", "innoxia_japanese_mens_kimono", 3),
            new ClothingData("Maid's Dress", "innoxia_maid_dress", 2),
            new ClothingData("Blouse", "innoxia_torso_blouse", 1),
            new ClothingData("Feminine Short-Sleeved Shirt", "innoxia_torso_feminine_short_sleeve_shirt", 3),
            new ClothingData("Long-Sleeved Shirt", "innoxia_torso_long_sleeved_shirt", 3),
            new ClothingData("Peplos", "innoxia_torso_peplos", 2),
            new ClothingData("Plunge Blouse", "innoxia_torso_plunge_blouse", 2),
            new ClothingData("Plunge-Neck Clubbing Dress", "innoxia_torso_plunge_club_dress", 2),
            new ClothingData("Short-Sleeved Shirt", "innoxia_torso_short_sleeved_shirt", 3),
            new ClothingData("T-Shirt", "innoxia_torso_tshirt", 1),
            new ClothingData("Colour Test T-Shirt", "innoxia_torso_tshirt_test_item", 1),
            new ClothingData("Witch's Dress", "innoxia_witch_witch_dress", 2),
            new ClothingData("Ballgown", "phlarx_dresses_ballgown", 3),
            new ClothingData("Evening Gown", "phlarx_dresses_evening_gown", 1),
            new ClothingData("Rockabilly Dress", "phlarx_dresses_rockabilly_dress", 2),
            new ClothingData("Vintage Dress", "phlarx_dresses_vintage_dress", 3),
            new ClothingData("Slavery Administration Shirt", "rfpnj_slavery_administration_shirt", 3),
            new ClothingData("Latex Crop Top", "sage_latex_croptop", 2),
            new ClothingData("Cropped T-Shirt", "TonyJC_cropped_tshirt", 2),
            new ClothingData("Cropped Tank-Top", "TonyJC_crop_tank_top", 2),
            new ClothingData("One-Strap Crop Top", "TonyJC_one_strap_crop_tank_top", 1),
            new ClothingData("Sleeveless Shirt", "TonyJC_sleeveless_shirt", 2),
            new ClothingData("Spaghetti Crop Tank-Top", "TonyJC_spaghetti_crop_tank_top", 3),
            new ClothingData("Tank-Top", "TonyJC_tank_top", 2),
            new ClothingData("Tied-Up Croptop", "TonyJC_tie_up_crop_top", 2)
        ]);
        ClothingMap.Add(ClothingType.Hand,
        [
            new ClothingData("Mitsugake", "c4mg1rl_benevolent_mitsugake", 3),
            new ClothingData("Kitty Gloves", "dsg_ckls_ckls_gloves", 2),
            new ClothingData("Butler's Glove", "innoxia_butler_butler_gloves", 1),
            new ClothingData("Elbow-Length Glove", "innoxia_hand_elbow_length_gloves", 1),
            new ClothingData("Fingerless Glove", "innoxia_hand_fingerless_gloves", 1),
            new ClothingData("Fishnet Glove", "innoxia_hand_fishnet_gloves", 1),
            new ClothingData("Glove", "innoxia_hand_gloves", 1),
            new ClothingData("Striped Gloves", "innoxia_hand_striped_gloves", 2),
            new ClothingData("Arm Wrap", "innoxia_hand_wraps", 1),
            new ClothingData("Maid's Sleeve", "innoxia_maid_sleeves", 2),
            new ClothingData("Rainbow Glove", "innoxia_rainbow_gloves", 1),
            new ClothingData("Latex Arm Warmers", "sage_latex_arm_warmers", 2),
            new ClothingData("Latex Elbow-Length Glove", "sage_latex_elbow_gloves", 1)
        ]);
        ClothingMap.Add(ClothingType.Neck,
        [
            new ClothingData("Benevolent Necklace", "c4mg1rl_benevolent_necklace", 3),
            new ClothingData("Trickster's Cloak", "c4mg1rl_trickster_cloak", 3),
            new ClothingData("Enforcer's Riot Neck Protector", "dsg_eep_riotarmorset_riotneckprotector", 3),
            new ClothingData("Fox-Patterned Scarf", "dsg_foxscarf_foxscarf", 3),
            new ClothingData("Tagged Choker", "innoxia_bdsm_choker", 2),
            new ClothingData("Metal Collar", "innoxia_bdsm_metal_collar", 3),
            new ClothingData("Cowbell Collar", "innoxia_cattle_cowbell_collar", 3),
            new ClothingData("Dark Siren's Amulet", "innoxia_darkSiren_siren_amulet", 3),
            new ClothingData("Dark Siren's Cloak", "innoxia_darkSiren_siren_cloak", 3),
            new ClothingData("Snowflake Necklace", "innoxia_elemental_snowflake_necklace", 2),
            new ClothingData("Sun Necklace", "innoxia_elemental_sun_necklace", 3),
            new ClothingData("Bandana", "innoxia_mouth_bandana", 1),
            new ClothingData("'Amber's Bitch' Collar", "innoxia_neck_ambers_bitch_collar", 2),
            new ClothingData("Ankh Necklace", "innoxia_neck_ankh_necklace", 3),
            new ClothingData("Bell Collar", "innoxia_neck_bell_collar", 3),
            new ClothingData("Breeder Collar", "innoxia_neck_breeder_collar", 3),
            new ClothingData("Collar Bowtie", "innoxia_neck_collar_bowtie", 3),
            new ClothingData("Cuff Choker Necklace", "innoxia_neck_cuff_choker_necklace", 1),
            new ClothingData("Triple Cuff Choker Necklace", "innoxia_neck_cuff_choker_necklace_triple", 1),
            new ClothingData("Demonstone Necklace", "innoxia_neck_demonstone_necklace", 2),
            new ClothingData("Diamond Necklace", "innoxia_neck_diamond_necklace", 2),
            new ClothingData("'Filly' Choker", "innoxia_neck_filly_choker", 3),
            new ClothingData("Gemstone Necklace", "innoxia_neck_gemstone_necklace", 2),
            new ClothingData("Heart Necklace", "innoxia_neck_heart_necklace", 2),
            new ClothingData("Horseshoe Necklace", "innoxia_neck_horseshoe_necklace", 2),
            new ClothingData("Key-Chain Necklace", "innoxia_neck_key_chain", 3),
            new ClothingData("Scarf", "innoxia_neck_scarf", 1), new ClothingData("Tie", "innoxia_neck_tie", 1),
            new ClothingData("Velvet Choker", "innoxia_neck_velvet_choker", 2),
            new ClothingData("Fur Cloak", "innoxia_torsoOver_fur_cloak", 3),
            new ClothingData("Spiked Collar", "irbynx_spikedCollar_punk_neck_metal_collar_spiked", 2)
        ]);
        ClothingMap.Add(ClothingType.Wrist,
        [
            new ClothingData("Benevolent Necklace", "c4mg1rl_benevolent_necklace", 3),
            new ClothingData("Enforcer's Riot Arm Guards", "dsg_eep_riotarmorset_riotarmguards", 3),
            new ClothingData("Enforcer's Tactical Elbow Pads", "dsg_eep_tacequipset_telbowpads", 3),
            new ClothingData("Canvas Brassard", "dsg_hlf_equip_rbrassard", 3),
            new ClothingData("Handcuffs", "dsg_hndcuffs_hndcuffs", 1),
            new ClothingData("Leather Bracelet", "innoxia_bdsm_wrist_bracelets", 2),
            new ClothingData("Wrist Restraint", "innoxia_bdsm_wrist_restraints", 2),
            new ClothingData("Snowflake Necklace", "innoxia_elemental_snowflake_necklace", 2),
            new ClothingData("Sun Necklace", "innoxia_elemental_sun_necklace", 3),
            new ClothingData("Ankh Necklace", "innoxia_neck_ankh_necklace", 3),
            new ClothingData("Demonstone Necklace", "innoxia_neck_demonstone_necklace", 2),
            new ClothingData("Gemstone Necklace", "innoxia_neck_gemstone_necklace", 2),
            new ClothingData("Heart Necklace", "innoxia_neck_heart_necklace", 2),
            new ClothingData("Horseshoe Necklace", "innoxia_neck_horseshoe_necklace", 2),
            new ClothingData("Key-Chain Necklace", "innoxia_neck_key_chain", 3),
            new ClothingData("Thin Bangle", "innoxia_wrist_thin_bangles", 1),
            new ClothingData("Roller Skating Elbow Pad", "nerdlinger_rollerskating_elbowpads_rollerskating_elbowpads",
                3),
            new ClothingData("Scrunchie", "norin_hair_accessories_hair_scrunchie", 1),
            new ClothingData("Latex Arm Warmers", "sage_latex_arm_warmers", 2)
        ]);
        ClothingMap.Add(ClothingType.Stomach,
        [
            new ClothingData("Strapless Bodysuit", "c4mg1rl_strapless_bodysuit_strapless_bodysuit", 2),
            new ClothingData("Arcane Karada", "innoxia_bdsm_karada", 1),
            new ClothingData("Breast Pump", "innoxia_milking_breast_pumps", 2),
            new ClothingData("Lowback Bodysuit", "innoxia_stomach_lowback_body", 1),
            new ClothingData("Overbust Corset", "innoxia_stomach_overbust_corset", 2),
            new ClothingData("Stomach Sarashi", "innoxia_stomach_sarashi", 1),
            new ClothingData("Underbust Corset", "innoxia_stomach_underbust_corset", 2),
            new ClothingData("Latex Bodysuit", "sage_latex_bodysuit", 3),
            new ClothingData("Latex Corset", "sage_latex_corset", 2)
        ]);
        ClothingMap.Add(ClothingType.Eyes,
        [
            new ClothingData("Trickster's Mask", "c4mg1rl_trickster_mask", 3),
            new ClothingData("Ballistic Glasses", "dsg_eep_tacequipset_bglasses", 3),
            new ClothingData("Enforcer's Ballistic Goggles", "dsg_eep_tacequipset_bgoggles", 3),
            new ClothingData("Enforcer's Night Vision Goggles", "dsg_eep_tacequipset_nvgoggles", 3),
            new ClothingData("Blindfold", "innoxia_bdsm_blindfold", 2),
            new ClothingData("Dark Siren's Seal", "innoxia_darkSiren_siren_seal", 2),
            new ClothingData("Aviators", "innoxia_eye_aviators", 2),
            new ClothingData("Glasses", "innoxia_eye_glasses", 3),
            new ClothingData("Half-Moon Reading Glasses", "innoxia_eye_half_moon_glasses", 3),
            new ClothingData("Half-Rim Glasses", "innoxia_eye_half_rim_glasses", 3),
            new ClothingData("Eye-Patch", "innoxia_eye_patch", 2),
            new ClothingData("Safety Glasses", "innoxia_eye_safety_glasses", 3),
            new ClothingData("Thick-Rimmed Glasses", "innoxia_eye_thick_rim_glasses", 2),
            new ClothingData("Safety Goggles", "innoxia_scientist_safety_goggles", 2),
            new ClothingData("Nose Guard", "nerdlinger_sports_noseguard_transparent_noseguard", 1),
            new ClothingData("Cat-Eye Sunglasses", "phlarx_sunglasses_cat_eye_sunglasses", 3),
            new ClothingData("Heart Sunglasses", "phlarx_sunglasses_heart_sunglasses", 3),
            new ClothingData("Round Sunglasses", "phlarx_sunglasses_round_sunglasses", 3)
        ]);
        ClothingMap.Add(ClothingType.Sock,
        [
            new ClothingData("Toeless Stocking", "corpseBloom_toeless_stockings_toeless_stockings", 1),
            new ClothingData("Kitty Stockings", "dsg_ckls_ckls_stockings", 3),
            new ClothingData("Maid's Stocking", "innoxia_maid_stockings", 2),
            new ClothingData("Rainbow Stocking", "innoxia_rainbow_stockings", 1),
            new ClothingData("Fishnet Stocking", "innoxia_sock_fishnets", 1),
            new ClothingData("Knee-High Sock", "innoxia_sock_kneehigh_socks", 1),
            new ClothingData("Leg Warmer", "innoxia_sock_leg_warmers", 1),
            new ClothingData("Pantyhose", "innoxia_sock_pantyhose", 1),
            new ClothingData("Sock", "innoxia_sock_socks", 1),
            new ClothingData("Stocking", "innoxia_sock_stockings", 1),
            new ClothingData("Thigh-High Sock", "innoxia_sock_thighhigh_socks", 1),
            new ClothingData("Striped Thigh-High Sock", "innoxia_sock_thighhigh_socks_striped", 2),
            new ClothingData("Toeless Striped Stocking", "innoxia_sock_toeless_striped_stockings", 2),
            new ClothingData("Trainer Sock", "innoxia_sock_trainer_socks", 1),
            new ClothingData("Tabi Sock", "nerdlinger_ronin_tabi_tabi", 2),
            new ClothingData("Latex Thigh-High Stockings", "sage_latex_stockings", 1),
            new ClothingData("Latex Open Thigh-High Stockings", "sage_latex_stockings_open", 1)
        ]);
        ClothingMap.Add(ClothingType.Head,
        [
            new ClothingData("Bunny Headband", "dsg_bheadband_bheadband", 2),
            new ClothingData("Kitty Headband", "dsg_ckls_ckls_headband", 3),
            new ClothingData("Bowler Hat", "dsg_eep_ptrlequipset_bwhat", 2),
            new ClothingData("Cap", "dsg_eep_ptrlequipset_pcap", 3),
            new ClothingData("Enforcer's Riot Helmet", "dsg_eep_riotarmorset_riothelmet", 3),
            new ClothingData("Test Beret", "dsg_eep_servequipset_debuggerydo_enfberet", 2),
            new ClothingData("Beret", "dsg_eep_servequipset_enfberet", 2),
            new ClothingData("Enforcer's Combat Helmet", "dsg_eep_tacequipset_chelmet", 3),
            new ClothingData("Boonie Hat", "dsg_hlf_equip_rbooniehat", 2),
            new ClothingData("Fedora", "dsg_shadydealer_fedora", 2),
            new ClothingData("Antler Headband", "innoxia_head_antler_headband", 2),
            new ClothingData("Cap", "innoxia_head_cap", 1), new ClothingData("Circlet", "innoxia_head_circlet", 1),
            new ClothingData("Cowboy Hat", "innoxia_head_cowboy_hat", 1),
            new ClothingData("Hard Hat", "innoxia_head_hard_hat", 2),
            new ClothingData("Headband", "innoxia_head_headband", 2),
            new ClothingData("Bow Headband", "innoxia_head_headband_bow", 3),
            new ClothingData("Jack-O'-Lantern", "innoxia_head_jack_o_lantern", 3),
            new ClothingData("Slime Queen's Tiara", "innoxia_head_slime_queens_tiara", 3),
            new ClothingData("Sweatband", "innoxia_head_sweatband", 1),
            new ClothingData("Tiara", "innoxia_head_tiara", 1),
            new ClothingData("Imp Arcanist's Hat", "innoxia_impArcanist_arcanist_hat", 3),
            new ClothingData("Service Dress Hat", "innoxia_lyssiethUniform_hat", 2),
            new ClothingData("Maid's Headpiece", "innoxia_maid_headpiece", 2),
            new ClothingData("Bandana", "innoxia_mouth_bandana", 1),
            new ClothingData("Witch's Hat", "innoxia_witch_witch_hat", 3),
            new ClothingData("Wide-Brimmed Witch's Hat", "innoxia_witch_witch_hat_wide", 3),
            new ClothingData("Roller Skating Helmet", "nerdlinger_rollerskating_helmet_rollerskating_helmet", 3),
            new ClothingData("Bike Racing Helmet", "nerdlinger_sports_biking_helmet_biking_helmet", 3)
        ]);
        ClothingMap.Add(ClothingType.Chest,
        [
            new ClothingData("Kitty Bra", "dsg_ckls_ckls_bra", 2),
            new ClothingData("Bikini Top", "innoxia_chest_bikini", 1),
            new ClothingData("Chemise", "innoxia_chest_chemise", 1),
            new ClothingData("Croptop Bra", "innoxia_chest_croptop_bra", 1),
            new ClothingData("Fullcup Bra", "innoxia_chest_fullcup_bra", 1),
            new ClothingData("Lacy Plunge Bra", "innoxia_chest_lacy_plunge_bra", 1),
            new ClothingData("Micro Bikini Top", "innoxia_chest_micro_bikini", 1),
            new ClothingData("Nursing Bra", "innoxia_chest_nursing_bra", 1),
            new ClothingData("Open Cup Bra", "innoxia_chest_open_cup_bra", 1),
            new ClothingData("Plunge Bra", "innoxia_chest_plunge_bra", 1),
            new ClothingData("Chest Sarashi", "innoxia_chest_sarashi", 1),
            new ClothingData("Sports Bra", "innoxia_chest_sports_bra", 1),
            new ClothingData("Strapless Bra", "innoxia_chest_strapless_bra", 1),
            new ClothingData("Striped Bra", "innoxia_chest_striped_bra", 2),
            new ClothingData("One-Piece Swimsuit", "innoxia_chest_swimsuit", 1),
            new ClothingData("Tube Top", "innoxia_chest_tube_top", 1),
            new ClothingData("Ragged Chest Wrap", "innoxia_loinCloth_ragged_chest_wrap", 1),
            new ClothingData("Latex Zip Bra", "sage_latex_bra", 2)
        ]);
        ClothingMap.Add(ClothingType.Groin,
        [
            new ClothingData("Kitty Panties", "dsg_ckls_ckls_panties", 3),
            new ClothingData("Chastity Belt", "innoxia_bdsm_chastity_belt", 3),
            new ClothingData("Full Chastity Belt", "innoxia_bdsm_chastity_belt_full", 3),
            new ClothingData("Backless Panties", "innoxia_groin_backless_panties", 1),
            new ClothingData("Bikini Bottoms", "innoxia_groin_bikini", 1),
            new ClothingData("Boxer Shorts", "innoxia_groin_boxers", 1),
            new ClothingData("Boyshorts", "innoxia_groin_boyshorts", 1),
            new ClothingData("Briefs", "innoxia_groin_briefs", 1),
            new ClothingData("Crotchless Briefs", "innoxia_groin_crotchless_briefs", 1),
            new ClothingData("Crotchless Panties", "innoxia_groin_crotchless_panties", 1),
            new ClothingData("Crotchless Thong", "innoxia_groin_crotchless_thong", 1),
            new ClothingData("Jockstrap", "innoxia_groin_jockstrap", 2),
            new ClothingData("Lacy Panties", "innoxia_groin_lacy_panties", 1),
            new ClothingData("Lacy Thong", "innoxia_groin_lacy_thong", 1),
            new ClothingData("Micro Bikini Bottoms", "innoxia_groin_micro_bikini", 1),
            new ClothingData("Panties", "innoxia_groin_panties", 1),
            new ClothingData("Striped Panties", "innoxia_groin_shimapan", 2),
            new ClothingData("Swimming Shorts", "innoxia_groin_swim_shorts", 2),
            new ClothingData("Thong", "innoxia_groin_thong", 1),
            new ClothingData("V-String Panties", "innoxia_groin_vstring", 1),
            new ClothingData("Latex Panties", "sage_latex_panties", 2)
        ]);
        ClothingMap.Add(ClothingType.Leg,
        [
            new ClothingData("Enforcer's Slacks", "dsg_eep_ptrlequipset_enfslacks", 2),
            new ClothingData("Enforcer's Dress Slacks", "dsg_eep_servequipset_enfdslacks", 3),
            new ClothingData("Enforcer's Uniform Skirt", "dsg_eep_servequipset_enfskirt", 2),
            new ClothingData("Enforcer's Tactical Trousers", "dsg_eep_tacequipset_tpants", 2),
            new ClothingData("Roughspun Trousers", "dsg_eisek_rspntrousers", 2),
            new ClothingData("Vintage Fatigue Trousers", "dsg_hlf_equip_rtrousers", 3),
            new ClothingData("Butler's Trousers", "innoxia_butler_butler_trousers", 2),
            new ClothingData("Saddle", "innoxia_feral_saddle", 3),
            new ClothingData("Assless Chaps", "innoxia_leg_assless_chaps", 1),
            new ClothingData("Asymmetrical Skirt", "innoxia_leg_asymmetrical_skirt", 1),
            new ClothingData("Bike Shorts", "innoxia_leg_bike_shorts", 2),
            new ClothingData("Cargo Trousers", "innoxia_leg_cargo_trousers", 2),
            new ClothingData("Crotchless Chaps", "innoxia_leg_crotchless_chaps", 1),
            new ClothingData("Distressed Jeans", "innoxia_leg_distressed_jeans", 3),
            new ClothingData("Hot Pants", "innoxia_leg_hotpants", 1), new ClothingData("Jeans", "innoxia_leg_jeans", 2),
            new ClothingData("Hakama", "innoxia_leg_mens_hakama", 1),
            new ClothingData("Belted Microskirt", "innoxia_leg_micro_skirt_belted", 2),
            new ClothingData("Pleated Microskirt", "innoxia_leg_micro_skirt_pleated", 2),
            new ClothingData("Miniskirt", "innoxia_leg_mini_skirt", 1),
            new ClothingData("Pencil Skirt", "innoxia_leg_pencil_skirt", 1),
            new ClothingData("Shorts", "innoxia_leg_shorts", 2), new ClothingData("Skirt", "innoxia_leg_skirt", 1),
            new ClothingData("Sport Shorts", "innoxia_leg_sport_shorts", 2),
            new ClothingData("Taur-Skirt", "innoxia_leg_taur_skirt", 1),
            new ClothingData("Taur-Trousers", "innoxia_leg_taur_trousers", 1),
            new ClothingData("Tight Jeans", "innoxia_leg_tight_jeans", 2),
            new ClothingData("Trousers", "innoxia_leg_trousers", 2),
            new ClothingData("Women's Trousers", "innoxia_leg_trousers_women", 2),
            new ClothingData("Yoga Pants", "innoxia_leg_yoga_pants", 1),
            new ClothingData("Ragged Loincloth", "innoxia_loinCloth_loin_cloth", 1),
            new ClothingData("Ragged Skirt", "innoxia_loinCloth_ragged_skirt", 1),
            new ClothingData("Service Dress Skirt", "innoxia_lyssiethUniform_skirt", 2),
            new ClothingData("Joggers", "nerdlinger_street_joggers_joggers", 2),
            new ClothingData("Tight Latex Leggings", "sage_latex_latexleggings", 2),
            new ClothingData("Daisy Dukes", "TonyJC_daisy_dukes", 3),
            new ClothingData("Denim Overalls", "TonyJC_denim_overalls", 2)
        ]);
        ClothingMap.Add(ClothingType.Hips,
        [
            new ClothingData("Enforcer's Utility Belt", "dsg_eep_ptrlequipset_utilbelt", 3),
            new ClothingData("Enforcer's Riot Belt", "dsg_eep_riotarmorset_riotbelt", 3),
            new ClothingData("Enforcer's Dress Belt", "dsg_eep_servequipset_enfdbelt", 3),
            new ClothingData("Enforcer's Stable Belt", "dsg_eep_servequipset_enfstbelt", 2),
            new ClothingData("Enforcer's Battle Belt", "dsg_eep_tacequipset_battlebelt", 3),
            new ClothingData("Enforcer's Heavy Battle Belt", "dsg_eep_tacequipset_hbattlebelt", 3),
            new ClothingData("Leather Belt", "innoxia_hips_leather_belt", 2)
        ]);
        ClothingMap.Add(ClothingType.Ankle,
        [
            new ClothingData("Enforcer's Riot Shin Guards", "dsg_eep_riotarmorset_riotshinguards", 3),
            new ClothingData("Enforcer's Tactical Kneepads", "dsg_eep_tacequipset_tkneepads", 3),
            new ClothingData("Anklet", "innoxia_ankle_anklet", 2),
            new ClothingData("Shin Guard", "innoxia_ankle_shin_guards", 2),
            new ClothingData("Spreader Bar", "innoxia_bdsm_spreaderbar", 2),
            new ClothingData("Leather Bracelet", "innoxia_bdsm_wrist_bracelets", 2),
            new ClothingData("Wrist Restraint", "innoxia_bdsm_wrist_restraints", 2),
            new ClothingData("Roller Skating Knee Pad", "nerdlinger_rollerskating_kneepads_rollerskating_kneepads", 3)
        ]);
        ClothingMap.Add(ClothingType.Foot,
        [
            new ClothingData("Enforcer's Jackboots", "dsg_eep_servequipset_enfjackboots", 1),
            new ClothingData("Enforcer's Pumps", "dsg_eep_servequipset_enfpumps", 3),
            new ClothingData("Tactical Combat Boots", "dsg_eep_tacequipset_cboots", 3),
            new ClothingData("Leather Boot", "dsg_eisek_oleathboots", 3),
            new ClothingData("Vintage Combat Boots", "dsg_hlf_equip_vcboots", 3),
            new ClothingData("Butler's Shoe", "innoxia_butler_butler_shoes", 3),
            new ClothingData("Horseshoe", "innoxia_feral_horse_shoe", 1),
            new ClothingData("Ankle Boot", "innoxia_foot_ankle_boots", 3),
            new ClothingData("Chelsea Boot", "innoxia_foot_chelsea_boots", 2),
            new ClothingData("Flat", "innoxia_foot_flats", 3),
            new ClothingData("Sandals", "innoxia_foot_gladiator_sandals", 2),
            new ClothingData("Gothic Boot", "innoxia_foot_goth_boots_fem", 3),
            new ClothingData("Heel", "innoxia_foot_heels", 3),
            new ClothingData("Low-Top Skater Shoe", "innoxia_foot_low_top_skater_shoes", 3),
            new ClothingData("Men's Shoe", "innoxia_foot_mens_smart_shoes", 3),
            new ClothingData("Platform Boot", "innoxia_foot_platform_boots", 3),
            new ClothingData("Stiletto Heel", "innoxia_foot_stiletto_heels", 3),
            new ClothingData("Strappy Stiletto Sandal", "innoxia_foot_strappy_sandals", 3),
            new ClothingData("Thigh High Boot", "innoxia_foot_thigh_high_boots", 2),
            new ClothingData("Trainer", "innoxia_foot_trainers", 3),
            new ClothingData("Work Boot", "innoxia_foot_work_boots", 3),
            new ClothingData("Geta", "innoxia_japanese_geta", 2),
            new ClothingData("Men's Geta", "innoxia_japanese_mens_geta", 2),
            new ClothingData("Crude Foot Wrap", "innoxia_loinCloth_foot_wraps", 3),
            new ClothingData("Service Dress Shoe", "innoxia_lyssiethUniform_shoes", 3),
            new ClothingData("Maid's High Heel", "innoxia_maid_heels", 3),
            new ClothingData("Witch's Boot", "innoxia_witch_witch_boots", 3),
            new ClothingData("Witch's Thigh-High Boot", "innoxia_witch_witch_boots_thigh_high", 3),
            new ClothingData("High-Top Skater Shoes", "nerdlinger_street_hitop_canvas_sneakers_hi_top_canvas_sneakers",
                3)
        ]);
        ClothingMap.Add(ClothingType.Mouth,
        [
            new ClothingData("Enforcer's Gas Mask", "dsg_eep_tacequipset_gmask", 3),
            new ClothingData("Skull-Patterned Bandana", "dsg_hlf_equip_sbandana", 2),
            new ClothingData("Ribbed Dildo", "innoxia_anus_ribbed_dildo", 1),
            new ClothingData("Ball Gag", "innoxia_bdsm_ballgag", 3),
            new ClothingData("Ring Gag", "innoxia_bdsm_ringgag", 3),
            new ClothingData("Bridle", "innoxia_feral_bridle", 3),
            new ClothingData("Bandana", "innoxia_mouth_bandana", 1),
            new ClothingData("Insertable Onahole", "innoxia_vagina_onahole", 2),
            new ClothingData("Mouth Web-Seal", "innoxia_webbing_seal_mouth", 1),
            new ClothingData("Realistic Dildo", "norin_dildos_realistic_dildo", 2)
        ]);
        ClothingMap.Add(ClothingType.Finger,
        [
            new ClothingData("Eisek's Ring", "dsg_eisek_seawings_ring", 3),
            new ClothingData("Gemstone Ring", "innoxia_finger_gemstone_ring", 2),
            new ClothingData("Heavy Gemstone Ring", "innoxia_finger_gemstone_ring_unisex", 2),
            new ClothingData("Lips Ring", "innoxia_finger_lips_ring", 2),
            new ClothingData("Meander Ring", "innoxia_finger_meander_ring", 1),
            new ClothingData("Ring", "innoxia_finger_ring", 1),
            new ClothingData("Wrap Ring", "innoxia_finger_wrap_ring", 1)
        ]);
        ClothingMap.Add(ClothingType.Anus,
        [
            new ClothingData("Ribbed Dildo", "innoxia_anus_ribbed_dildo", 1),
            new ClothingData("Butt Plug", "innoxia_buttPlugs_butt_plug", 1),
            new ClothingData("Jewelled-Heart Butt Plug", "innoxia_buttPlugs_butt_plug_heart", 2),
            new ClothingData("Jewelled Butt Plug", "innoxia_buttPlugs_butt_plug_jewel", 2),
            new ClothingData("Tail Butt Plug", "innoxia_buttPlugs_butt_plug_tail", 3),
            new ClothingData("Insertable Onahole", "innoxia_vagina_onahole", 2),
            new ClothingData("Asshole Web-Seal", "innoxia_webbing_seal_anus", 1),
            new ClothingData("Anal Beads", "norin_anal_beads_anal_beads", 1),
            new ClothingData("Realistic Dildo", "norin_dildos_realistic_dildo", 2)
        ]);
        ClothingMap.Add(ClothingType.Vagina,
        [
            new ClothingData("Ribbed Dildo", "innoxia_anus_ribbed_dildo", 1),
            new ClothingData("Pussy Pump", "innoxia_milking_vagina_pump", 3),
            new ClothingData("Insertable Dildo", "innoxia_vagina_insertable_dildo", 1),
            new ClothingData("Insertable Onahole", "innoxia_vagina_onahole", 2),
            new ClothingData("Anal-Only Pastie", "innoxia_vagina_sticker_anal_only", 3),
            new ClothingData("Pussy Web-Seal", "innoxia_webbing_seal_vagina", 1),
            new ClothingData("Clover Clamps", "norin_clover_clamps_clover_clamps", 1),
            new ClothingData("Realistic Dildo", "norin_dildos_realistic_dildo", 2),
            new ClothingData("Strapless Strap-On", "norin_strapless_dildo_strapless_dildo", 1)
        ]);
        ClothingMap.Add(ClothingType.Penis,
        [
            new ClothingData("Chastity Cage", "innoxia_bdsm_chastity_cage", 3),
            new ClothingData("Ornate Chastity Cage", "innoxia_bdsm_ornate_chastity_cage", 3),
            new ClothingData("Strap-On", "innoxia_bdsm_penis_strapon", 3),
            new ClothingData("Cock Pump", "innoxia_milking_penis_pump", 2),
            new ClothingData("Condom", "innoxia_penis_condom", 1),
            new ClothingData("Stallion-Branded Condom", "innoxia_penis_condom_strong", 2),
            new ClothingData("Dragon-Branded Condom", "innoxia_penis_condom_super_strong", 2),
            new ClothingData("Condom-Webbing", "innoxia_penis_condom_webbing", 1),
            new ClothingData("Ribbon", "norin_tail_ribbon_tail_ribbon", 1)
        ]);
        ClothingMap.Add(ClothingType.PiercingEar,
        [
            new ClothingData("Ear Tag", "innoxia_cattle_piercing_ear_tag", 2),
            new ClothingData("Snowflake Earring", "innoxia_elemental_piercing_ear_snowflakes", 1),
            new ClothingData("Sun Earring", "innoxia_elemental_piercing_ear_sun", 2),
            new ClothingData("Basic Barbell", "innoxia_piercing_basic_barbell", 1),
            new ClothingData("Basic Barbell", "innoxia_piercing_basic_barbell_pair", 1),
            new ClothingData("Ball Stud Earring", "innoxia_piercing_ear_ball_studs", 2),
            new ClothingData("Dangle Chain Earrings", "innoxia_piercing_ear_chain_dangle", 1),
            new ClothingData("Ear Cuff Chain Studs", "innoxia_piercing_ear_cuff_chains", 2),
            new ClothingData("Hoop Earring", "innoxia_piercing_ear_hoops", 2),
            new ClothingData("Pearl Stud Earring", "innoxia_piercing_ear_pearl_studs", 2),
            new ClothingData("Earring", "innoxia_piercing_ear_ring", 2),
            new ClothingData("Evelyx's Dairy Ear Tag", "innoxia_quest_dairy_ear_tag", 2),
            new ClothingData("Evelyx's Dairy Ear Tag", "innoxia_quest_dairy_ear_tag_npc", 2),
            new ClothingData("Bat Earring", "norin_piercings_piercing_ear_bats", 3),
            new ClothingData("Rose Earring", "norin_rose_piercings_piercing_ear_rose", 2),
            new ClothingData("Sunflower Earring", "norin_sunflower_piercings_piercing_ear_sunflower", 3)
        ]);
        ClothingMap.Add(ClothingType.PiercingNose,
        [
            new ClothingData("Large Nose Ring", "innoxia_cattle_piercing_nose_ring", 1),
            new ClothingData("Snowflake Nose Stud", "innoxia_elemental_piercing_nose_snowflake", 1),
            new ClothingData("Sun Nose Stud", "innoxia_elemental_piercing_nose_sun", 2),
            new ClothingData("Nose Ball Stud", "innoxia_piercing_nose_ball_stud", 2),
            new ClothingData("Nose Ring", "innoxia_piercing_nose_ring", 1),
            new ClothingData("Rose Nose Piercing", "norin_rose_piercings_piercing_nose_rose", 2),
            new ClothingData("Sunflower Nose Piercing", "norin_sunflower_piercings_piercing_nose_sunflower", 3)
        ]);
        ClothingMap.Add(ClothingType.Tail,
        [
            new ClothingData("Tail Bandage", "innoxia_feral_bandage", 1),
            new ClothingData("Scrunchie", "norin_hair_accessories_hair_scrunchie", 1),
            new ClothingData("Ribbon", "norin_tail_ribbon_tail_ribbon", 1)
        ]);
        ClothingMap.Add(ClothingType.Hair,
        [
            new ClothingData("Rose", "innoxia_hair_rose", 2),
            new ClothingData("Balaclava", "innoxia_head_balaclava", 1),
            new ClothingData("Kanzashi", "innoxia_japanese_kanzashi", 3),
            new ClothingData("Bandana", "innoxia_mouth_bandana", 1),
            new ClothingData("Bobby Pin", "norin_hair_accessories_hair_bobby_pins", 1),
            new ClothingData("Celtic Barrette", "norin_hair_accessories_hair_celtic_barrette", 2),
            new ClothingData("Dragonfly Bobby Pin", "norin_hair_accessories_hair_dragonfly", 2),
            new ClothingData("Hair Pin", "norin_hair_accessories_hair_pins", 1),
            new ClothingData("Scrunchie", "norin_hair_accessories_hair_scrunchie", 1),
            new ClothingData("Hair Stick", "norin_hair_accessories_hair_sticks", 1),
            new ClothingData("Ribbon", "norin_tail_ribbon_tail_ribbon", 1)
        ]);
        ClothingMap.Add(ClothingType.Horns,
        [
            new ClothingData("Horn Chains", "innoxia_horn_ring_chain", 1),
            new ClothingData("Thin Horn Rings", "innoxia_horn_thin_rings", 1)
        ]);
        ClothingMap.Add(ClothingType.Nipple,
        [
            new ClothingData("Breast Pump", "innoxia_milking_breast_pumps", 2),
            new ClothingData("Tape Cross", "innoxia_nipple_tape_crosses", 1),
            new ClothingData("Nipple Web-Seal", "innoxia_webbing_seal_nipples", 1),
            new ClothingData("Clover Clamps", "norin_clover_clamps_clover_clamps", 1)
        ]);
        ClothingMap.Add(ClothingType.PiercingTongue,
            [new ClothingData("Basic Barbell", "innoxia_piercing_basic_barbell", 1)]);
        ClothingMap.Add(ClothingType.PiercingNipple,
        [
            new ClothingData("Basic Barbell", "innoxia_piercing_basic_barbell_pair", 1),
            new ClothingData("Nipple Chain", "innoxia_piercing_nipple_chain", 1),
            new ClothingData("Bat Wing Barbells", "norin_piercings_bat_wings_barbells", 2),
            new ClothingData("Heart-Shaped Barbells", "norin_piercings_heart_barbells", 2),
            new ClothingData("Chained Nipple Ring", "norin_piercings_piercing_nipple_chain", 1),
            new ClothingData("Nipple Ring", "norin_piercings_piercing_nipple_rings", 1)
        ]);
        ClothingMap.Add(ClothingType.PiercingStomach,
        [
            new ClothingData("Gemstone Barbell", "innoxia_piercing_gemstone_barbell", 2),
            new ClothingData("Ringed Barbell", "innoxia_piercing_ringed_barbell", 1),
            new ClothingData("Caution-When-Wet Piercing", "norin_piercings_caution_when_wet", 3),
            new ClothingData("Pentagram Piercing", "norin_piercings_piercing_pentagram_navel", 2),
            new ClothingData("Rose Piercing", "norin_rose_piercings_piercing_navel_rose", 2),
            new ClothingData("Sunflower Piercing", "norin_sunflower_piercings_piercing_sunflower_navel", 3)
        ]);
        ClothingMap.Add(ClothingType.PiercingVagina,
        [
            new ClothingData("Gemstone Barbell", "innoxia_piercing_gemstone_barbell", 2),
            new ClothingData("Ringed Barbell", "innoxia_piercing_ringed_barbell", 1),
            new ClothingData("Heart-Shaped Barbell", "norin_piercings_heart_clit", 1),
            new ClothingData("\"SEX\" Barbell", "norin_piercings_piercing_vagina_sex", 2),
            new ClothingData("Vertical Hood Piercing", "norin_piercings_piercing_vertical_hood", 2)
        ]);
        ClothingMap.Add(ClothingType.PiercingLip,
        [
            new ClothingData("Lip Ring", "innoxia_piercing_lip_double_ring", 1),
            new ClothingData("Flower Lip Piercing", "norin_piercings_piercing_lip_flower", 2),
            new ClothingData("Rose Lip Piercing", "norin_rose_piercings_piercing_lip_rose", 2),
            new ClothingData("Sunflower Lip Piercing", "norin_sunflower_piercings_piercing_lip_sunflower", 3)
        ]);
        ClothingMap.Add(ClothingType.PiercingPenis,
            [new ClothingData("Piercing Ring", "innoxia_piercing_penis_ring", 1)]);

        #endregion

        #region Items Initialization

        ItemsMap.Add(ItemType.Item,
        [
            new ItemData("Chocolate Coated Coffee Bean", "charisma_race_spider_chocolate_coated_cocoa_beans"),
            new ItemData("Jet Black Coffee", "charisma_race_spider_jet_black_coffee"),
            new ItemData("Apples", "dsg_eisek_apples"),
            new ItemData("Carton of Blueberries", "dsg_eisek_cartonobberries"),
            new ItemData("Carton of Strawberries", "dsg_eisek_cartonosberries"),
            new ItemData("Tangerines", "dsg_eisek_tangerines"),
            new ItemData("Foldable Awning Poles", "dsg_quest_awningpoles"),
            new ItemData("Embroidered Sign", "dsg_quest_embsign"),
            new ItemData("Bolt of Green Cloth", "dsg_quest_fabricbolt"),
            new ItemData("HappyRat Gold+ Discount Card", "dsg_quest_hazmat_rat_card"),
            new ItemData("Mystical Orb of Fate", "dsg_quest_sm_magicorb"),
            new ItemData("Honey Bread", "dsg_race_bear_honey_bread"), new ItemData("Vodka", "dsg_race_bear_vodka"),
            new ItemData("Green Dragon Draft", "dsg_race_dragon_draft_green"),
            new ItemData("Orange Dragon Draft", "dsg_race_dragon_draft_orange"),
            new ItemData("Pink Dragon Draft", "dsg_race_dragon_draft_pink"),
            new ItemData("Pink Dragonfruit", "dsg_race_dragon_dragonfruit_pink"),
            new ItemData("Red Dragonfruit", "dsg_race_dragon_dragonfruit_red"),
            new ItemData("Yellow Dragonfruit", "dsg_race_dragon_dragonfruit_yellow"),
            new ItemData("Fizzy Orange Juice", "dsg_race_ferret_orange_juice"),
            new ItemData("Sausages", "dsg_race_ferret_sausages"),
            new ItemData("P�t� and Crackers", "dsg_race_gryphon_pate_and_crackers"),
            new ItemData("Two-Tone Slushie", "dsg_race_gryphon_two_tone_slushie"),
            new ItemData("Berry Soda", "dsg_race_otter_berry_soda"),
            new ItemData("Fish and Chips", "dsg_race_otter_fish_and_chips"),
            new ItemData("Cotton Candy Soda", "dsg_race_raccoon_cotton_candy_soda"),
            new ItemData("Popcorn", "dsg_race_raccoon_popcorn"), new ItemData("Grog", "dsg_race_shark_grog"),
            new ItemData("Tuna Sashimi", "dsg_race_shark_tuna_sashimi"),
            new ItemData("Wet Wipe", "dsg_wetwipes_wetwipes"),
            new ItemData("Arcane Wet Wipe", "dsg_wetwipes_wetwipes_plus"),
            new ItemData("Inno-Chan's Gift", "innoxia_cheat_inno_chans_gift"),
            new ItemData("Improbable-Whammer", "innoxia_cheat_unlikely_whammer"),
            new ItemData("Doughnut", "innoxia_food_doughnut"),
            new ItemData("Iced Doughnut", "innoxia_food_doughnut_iced"),
            new ItemData("Iced Doughnut With Sprinkles", "innoxia_food_doughnut_iced_sprinkles"),
            new ItemData("Broodmother Pill", "innoxia_pills_broodmother"),
            new ItemData("Breeder Pill", "innoxia_pills_fertility"),
            new ItemData("Sterility Pill", "innoxia_pills_sterility"),
            new ItemData("Amazonian Ambrosia", "innoxia_potions_amazonian_ambrosia"),
            new ItemData("Amazon's Secret", "innoxia_potions_amazons_secret"),
            new ItemData("Angelixx's Diary", "innoxia_quest_angelixx_diary"),
            new ItemData("Platinum Bank of Dominion Card", "innoxia_quest_bank_card"),
            new ItemData("Clothing Keys", "innoxia_quest_clothing_keys"),
            new ItemData("Faire Ticket", "innoxia_quest_faire_ticket"),
            new ItemData("'Pix's Playground' Membership Card", "innoxia_quest_gym_membership_card"),
            new ItemData("Elis Town Hall Pass", "innoxia_quest_minotallys_pass"),
            new ItemData("Monica's Moo Milker", "innoxia_quest_monica_milker"),
            new ItemData("Beer-Bitch Token", "innoxia_quest_oglix_beer_token"),
            new ItemData("Arcane Recorder", "innoxia_quest_recorder"),
            new ItemData("Wes's Contractor Pass", "innoxia_quest_special_pass"),
            new ItemData("Elle's Contractor Pass", "innoxia_quest_special_pass_elle"),
            new ItemData("Gator's Gumbo", "innoxia_race_alligator_gators_gumbo"),
            new ItemData("Swamp Water", "innoxia_race_alligator_swamp_water"),
            new ItemData("Angel's Tears", "innoxia_race_angel_angels_tears"),
            new ItemData("Berry Trifle", "innoxia_race_badger_berry_trifle"),
            new ItemData("Black Stripes Perry", "innoxia_race_badger_black_stripes_perry"),
            new ItemData("Fruit Bat's Juice Box", "innoxia_race_bat_fruit_bats_juice_box"),
            new ItemData("Fruit Bat's Salad", "innoxia_race_bat_fruit_bats_salad"),
            new ItemData("Feline's Fancy", "innoxia_race_cat_felines_fancy"),
            new ItemData("Kitty's Reward", "innoxia_race_cat_kittys_reward"),
            new ItemData("Bubble Cream", "innoxia_race_cow_bubble_cream"),
            new ItemData("Bubble Milk", "innoxia_race_cow_bubble_milk"),
            new ItemData("Glade Springs", "innoxia_race_deer_glade_springs"),
            new ItemData("Tree Shoots Salad", "innoxia_race_deer_tree_shoots_salad"),
            new ItemData("Innoxia's Gift", "innoxia_race_demon_innoxias_gift"),
            new ItemData("Lilith's Gift", "innoxia_race_demon_liliths_gift"),
            new ItemData("Canine Crunch", "innoxia_race_dog_canine_crunch"),
            new ItemData("Canine Crush", "innoxia_race_dog_canine_crush"),
            new ItemData("Silic Oil", "innoxia_race_doll_silic_oil"),
            new ItemData("Chicken Pot Pie", "innoxia_race_fox_chicken_pot_pie"),
            new ItemData("Vulpine's Vineyard", "innoxia_race_fox_vulpines_vineyard"),
            new ItemData("Billy's Best", "innoxia_race_goat_billys_best"),
            new ItemData("Pan's Flute", "innoxia_race_goat_pans_flute"),
            new ItemData("Bubblegum Lollipop", "innoxia_race_harpy_bubblegum_lollipop"),
            new ItemData("Harpy Perfume", "innoxia_race_harpy_harpy_perfume"),
            new ItemData("Equine Cider", "innoxia_race_horse_equine_cider"),
            new ItemData("Sugar Carrot Cube", "innoxia_race_horse_sugar_carrot_cube"),
            new ItemData("Bread Roll", "innoxia_race_human_bread_roll"),
            new ItemData("Vanilla Water", "innoxia_race_human_vanilla_water"),
            new ItemData("Impish Brew", "innoxia_race_imp_impish_brew"),
            new ItemData("Harvest Mouse's Barley Water", "innoxia_race_mouse_barley_water"),
            new ItemData("Harvest Mouse's Cheese", "innoxia_race_mouse_cheese"),
            new ItemData("Mince Pie", "innoxia_race_none_mince_pie"),
            new ItemData("Deep Roar", "innoxia_race_panther_deep_roar"),
            new ItemData("Panther's Delight", "innoxia_race_panther_panthers_delight"),
            new ItemData("Oinkers Fries", "innoxia_race_pig_oinkers_fries"),
            new ItemData("Porcine Pop", "innoxia_race_pig_porcine_pop"),
            new ItemData("Bunny Carrot-Cake", "innoxia_race_rabbit_bunny_carrot_cake"),
            new ItemData("Bunny Juice", "innoxia_race_rabbit_bunny_juice"),
            new ItemData("Raptor Energy Bar", "innoxia_race_raptor_energy_bar"),
            new ItemData("Raptor Energy Drink", "innoxia_race_raptor_energy_drink"),
            new ItemData("Black Rat's Rum", "innoxia_race_rat_black_rats_rum"),
            new ItemData("Brown Rat's Burger", "innoxia_race_rat_brown_rats_burger"),
            new ItemData("Rudolph's Egg Nog", "innoxia_race_reindeer_rudolphs_egg_nog"),
            new ItemData("Sugar Cookie", "innoxia_race_reindeer_sugar_cookie"),
            new ItemData("Ewe's Brew", "innoxia_race_sheep_ewes_brew"),
            new ItemData("Woolly Goodness", "innoxia_race_sheep_woolly_goodness"),
            new ItemData("Biojuice Canister", "innoxia_race_slime_biojuice_canister"),
            new ItemData("Slime Quencher", "innoxia_race_slime_slime_quencher"),
            new ItemData("Round Nuts", "innoxia_race_squirrel_round_nuts"),
            new ItemData("Squirrel Java", "innoxia_race_squirrel_squirrel_java"),
            new ItemData("Meat and Marrow", "innoxia_race_wolf_meat_and_marrow"),
            new ItemData("Wolf Whiskey", "innoxia_race_wolf_wolf_whiskey"),
            new ItemData("Freedom Certification", "innoxia_slavery_freedom_certification"),
            new ItemData("Apple Pie � La Mode", "mintychip_race_salamander_apple_pie"),
            new ItemData("Hot Chocolate", "mintychip_race_salamander_hot_cocoa"),
            new ItemData("Iced Tea", "mintychip_race_salamander_iced_tea"),
            new ItemData("Chocolate Brownie", "NoStepOnSnek_race_capybara_brownie"),
            new ItemData("Chamomile Tea", "NoStepOnSnek_race_capybara_tea2go"),
            new ItemData("Ink Vodka", "NoStepOnSnek_race_octopus_ink_vodka"),
            new ItemData("Shrimp Cocktail", "NoStepOnSnek_race_octopus_shrimp_cocktail"),
            new ItemData("Boiled Eggs", "NoStepOnSnek_race_snake_eggs"),
            new ItemData("Snake Oil", "NoStepOnSnek_race_snake_oil"), new ItemData("Peach", "rfpnj_peach_peach")
        ]);

        #endregion

        #region Weapons Initialization

        WeaponsMap.Add(WeaponType.Ranged,
        [
            new WeaponData("Hama Yumi", "c4mg1rl_bows_hama_yumi", 2, "CRITICAL_DAMAGE", "ICE"),
            new WeaponData("Cryoprism Gun", "dsg_eep_cryoprism_cryoprism", 2, "null", "ICE"),
            new WeaponData("LSG-9000 Coom Gun", "dsg_eep_liqstungun_coomgun", 2, "DAMAGE_LUST", "LUST"),
            new WeaponData("Arcane Liquid Stun Gun", "dsg_eep_liqstungun_liqstungun", 2, "DAMAGE_LUST", "LUST"),
            new WeaponData("Pepper Grenade Launcher", "dsg_eep_pbweap_pblauncher", 2, "null", "FIRE"),
            new WeaponData("Pepperball Pistol", "dsg_eep_pbweap_pbpistol", 2, "null", "FIRE"),
            new WeaponData("Pepperball Rifle", "dsg_eep_pbweap_pbrifle", 2, "null", "FIRE"),
            new WeaponData("Arcane Taser", "dsg_eep_taser_taser", 2, "DAMAGE_LUST", "LUST"),
            new WeaponData("Revolving Tranquiliser Rifle", "dsg_eep_trqrifle_trqrifle", 2, "null", "POISON"),
            new WeaponData("Teargas Shotgun", "dsg_hlf_weap_gbshotgun", 2, "null", "POISON"),
            new WeaponData("Pepperball Bolt-Action Rifle", "dsg_hlf_weap_pboltrifle", 2, "null", "FIRE"),
            new WeaponData("Arcane Firebomb", "dsg_hlf_weap_pbomb", 1, "null", "FIRE"),
            new WeaponData("Pepperball Revolver", "dsg_hlf_weap_pbrevolver", 2, "null", "FIRE"),
            new WeaponData("Pepperball Submachine Gun", "dsg_hlf_weap_pbsmg", 2, "null", "FIRE"),
            new WeaponData("Pistol Crossbow", "innoxia_bow_pistol_crossbow", 2, "DAMAGE_RANGED_WEAPON", "PHYSICAL"),
            new WeaponData("Arcane Recurve Bow", "innoxia_bow_recurve", 2, "DAMAGE_RANGED_WEAPON", "PHYSICAL"),
            new WeaponData("Arcane Shortbow", "innoxia_bow_shortbow", 2, "CRITICAL_DAMAGE", "PHYSICAL"),
            new WeaponData("Suspicious Dog Whistle", "innoxia_cheat_doggo_whistle", 2, "null", "PHYSICAL"),
            new WeaponData("Arcane Feather", "innoxia_feather_epic", 1, "RESISTANCE_PHYSICAL", "PHYSICAL"),
            new WeaponData("Pristine Arcane Feather", "innoxia_feather_legendary", 1, "RESISTANCE_PHYSICAL",
                "PHYSICAL"),
            new WeaponData("Rough Arcane Feather", "innoxia_feather_rare", 1, "RESISTANCE_PHYSICAL", "PHYSICAL"),
            new WeaponData("Arcane Musket", "innoxia_gun_arcane_musket", 1, "null", "PHYSICAL"),
            new WeaponData("Br14", "innoxia_gun_br14", 1, "null", "PHYSICAL"),
            new WeaponData("Fauxmas", "innoxia_gun_famase", 1, "null", "PHYSICAL"),
            new WeaponData("Lar1a1", "innoxia_gun_lar1a1", 1, "null", "PHYSICAL"),
            new WeaponData("Mkar", "innoxia_gun_mkar", 2, "null", "PHYSICAL"),
            new WeaponData("Arcane Revolver", "innoxia_gun_revolver", 2, "null", "PHYSICAL"),
            new WeaponData("Waspley Mk IV .38/200 Service Revolver", "innoxia_gun_waspley_mk4_service", 2, "null",
                "PHYSICAL"),
            new WeaponData("Western PPK", "innoxia_gun_western_ppk", 2, "null", "PHYSICAL"),
            new WeaponData("Arcane Lightning Globe", "innoxia_lightningGlobe_lightning_globe", 1, "DAMAGE_LUST",
                "LUST"),
            new WeaponData("Arcane Lightning Ring", "innoxia_lightningGlobe_lightning_globe_ring", 2, "DAMAGE_LUST",
                "LUST"),
            new WeaponData("Tennis Ball", "innoxia_thrown_tennis_ball", 2, "null", "PHYSICAL"),
            new WeaponData("Ball of Yarn", "innoxia_thrown_yarn", 1, "null", "PHYSICAL")
        ]);
        WeaponsMap.Add(WeaponType.Melee,
        [
            new WeaponData("Muramasa", "c4mg1rl_swords_muramasa", 2, "DAMAGE_LUST", "LUST"),
            new WeaponData("Enforcer's Baton", "dsg_eep_enbaton_enbaton", 2, "null", "PHYSICAL"),
            new WeaponData("Enforcer's Riot Shield", "dsg_eep_riotshield_riotshield", 2, "null", "PHYSICAL"),
            new WeaponData("Cardboard Sword", "dsg_sm_cboard_cbsword", 2, "null", "PHYSICAL"),
            new WeaponData("Imp Arcanist's Staff", "innoxia_arcanistStaff_arcanist_staff", 1, "DAMAGE_MELEE_WEAPON",
                "PHYSICAL"),
            new WeaponData("Battle Axe", "innoxia_axe_battle", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Metal Bat", "innoxia_bat_metal", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Wooden Bat", "innoxia_bat_wooden", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Wooden 'BONK!' Bat", "innoxia_bat_wooden_silly", 2, "null", "PHYSICAL"),
            new WeaponData("Riding Crop", "innoxia_bdsm_riding_crop", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Morning Star", "innoxia_blunt_morning_star", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Arcane Sledgehammer", "innoxia_blunt_sledgehammer", 1, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Feather Duster", "innoxia_cleaning_feather_duster", 2, "null", "PHYSICAL"),
            new WeaponData("Witch's Broom", "innoxia_cleaning_witch_broom", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Misty Demonstone", "innoxia_crystal_epic", 1, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Clear Demonstone", "innoxia_crystal_legendary", 1, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Opaque Demonstone", "innoxia_crystal_rare", 1, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Demon's Dagger", "innoxia_dagger_dagger", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("SWORD Dagger", "innoxia_dagger_sword", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Arming Sword", "innoxia_europeanSwords_arming_sword", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Xiphos", "innoxia_europeanSwords_xiphos", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Zweih&auml;nder", "innoxia_europeanSwords_zweihander", 2, "DAMAGE_MELEE_WEAPON",
                "PHYSICAL"),
            new WeaponData("Katana", "innoxia_japaneseSwords_katana", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Wakizashi", "innoxia_japaneseSwords_wakizashi", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Kerambit", "innoxia_kerambit_kerambit", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Knuckle Duster", "innoxia_knuckleDusters_knuckle_dusters", 1, "DAMAGE_MELEE_WEAPON",
                "PHYSICAL"),
            new WeaponData("Metal Pipe", "innoxia_pipe_pipe", 1, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Dark Siren's Scythe", "innoxia_scythe_scythe", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Buckler", "innoxia_shield_buckler", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Crude Shield", "innoxia_shield_crude_wooden", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Dory", "innoxia_spear_dory", 2, "DAMAGE_MELEE_WEAPON", "PHYSICAL"),
            new WeaponData("Flashlight", "innoxia_utility_flashlight", 2, "null", "PHYSICAL")
        ]);

        #endregion

        #endregion
    }

    public static string GetExtremityLabel(int value)
    {
        return value switch
        {
            < 10 => "Tiny",
            < 22 => "Small",
            < 40 => "Long",
            < 62 => "Huge",
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
            >= 7 => "Fathomless"
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
            >= 7 => "Elastic"
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
            >= 7 => "Moldable"
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
            >= 7 => "Drooling"
        };
    }

    public static string GetFluidRegenerationLabel(int value)
    {
        return value switch
        {
            < 300 => "Slow",
            < 800 => "Average",
            < 5000 => "Fast",
            < 10000 => "Rapid",
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