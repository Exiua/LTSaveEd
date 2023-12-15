using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData;

public static class Collections
{
    public static ValueDisplayPair[] HairTypes { get; } =
    [
        new ValueDisplayPair("None", "ZERO_NONE"), new ValueDisplayPair("Stubble", "ONE_STUBBLE"),
        new ValueDisplayPair("Manicured", "TWO_MANICURED"), new ValueDisplayPair("Trimmed", "THREE_TRIMMED"),
        new ValueDisplayPair("Natural", "FOUR_NATURAL"), new ValueDisplayPair("Unkempt", "FIVE_UNKEMPT"),
        new ValueDisplayPair("Bushy", "SIX_BUSHY"), new ValueDisplayPair("Wild", "SEVEN_WILD")
    ];

    public static ValueDisplayPair[] BodyFluidFlavours { get; } =
    [
        new ValueDisplayPair("Cum", "CUM"), new ValueDisplayPair("Milk", "MILK"),
        new ValueDisplayPair("Girlcum", "GIRL_CUM"), new ValueDisplayPair("Bubblegum", "BUBBLEGUM"),
        new ValueDisplayPair("Beer", "BEER"), new ValueDisplayPair("Vanilla", "VANILLA"),
        new ValueDisplayPair("Strawberry", "STRAWBERRY"), new ValueDisplayPair("Chocolate", "CHOCOLATE"),
        new ValueDisplayPair("Pineapple", "PINEAPPLE"), new ValueDisplayPair("Honey", "HONEY"),
        new ValueDisplayPair("Mint", "MINT"), new ValueDisplayPair("Cherry", "CHERRY"),
        new ValueDisplayPair("Coffee", "COFFEE"), new ValueDisplayPair("Tea", "TEA"),
        new ValueDisplayPair("Maple", "MAPLE"), new ValueDisplayPair("Cinnamon", "CINNAMON"),
        new ValueDisplayPair("Lemon", "LEMON"), new ValueDisplayPair("Orange", "ORANGE"),
        new ValueDisplayPair("Grape", "GRAPE"), new ValueDisplayPair("Melon", "MELON"),
        new ValueDisplayPair("Coconut", "COCONUT"), new ValueDisplayPair("Blueberry", "BLUEBERRY")
    ];
    
    private static readonly ValueDisplayPair[] LegConfigurationsMaster =
    [
        new ValueDisplayPair("Bipedal", "BIPEDAL"), new ValueDisplayPair("Quadrupedal", "QUADRUPEDAL"),
        new ValueDisplayPair("Serpent-tailed", "TAIL_LONG"), new ValueDisplayPair("Arachnid", "ARACHNID"),
        new ValueDisplayPair("Cephalopod", "CEPHALOPOD"), new ValueDisplayPair("Mer-tailed", "TAIL"),
        new ValueDisplayPair("Avian", "AVIAN")
    ];
    
    private static ValueDisplayPair[] _legConfigurationsBQ;
    private static ValueDisplayPair[] _legConfigurationsB;
    private static ValueDisplayPair[] _legConfigurationsS;
    private static ValueDisplayPair[] _legConfigurationsAr;
    private static ValueDisplayPair[] _legConfigurationsC;
    private static ValueDisplayPair[] _legConfigurationsM;
    private static ValueDisplayPair[] _legConfigurationsAv;
    private static ValueDisplayPair[] _legConfigurationsBQSM;
    private static ValueDisplayPair[] _legConfigurationsBAv;
    private static ValueDisplayPair[] _legConfigurationsBM;
    private static ValueDisplayPair[] _legConfigurationsBS;
    private static ValueDisplayPair[] _legConfigurationsBAr;

    private static readonly ValueDisplayPair[] FootStructuresMaster =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Plantigrade", "PLANTIGRADE"),
        new ValueDisplayPair("Unguligrade", "UNGULIGRADE"), new ValueDisplayPair("Digitigrade", "DIGITIGRADE"),
        new ValueDisplayPair("Arachnoid", "ARACHNOID"), new ValueDisplayPair("Tentacled", "TENTACLED")
    ];
    
    private static ValueDisplayPair[] _footStructuresP;
    private static ValueDisplayPair[] _footStructuresU;
    private static ValueDisplayPair[] _footStructuresN;
    private static ValueDisplayPair[] _footStructuresA;
    private static ValueDisplayPair[] _footStructuresT;
    private static ValueDisplayPair[] _footStructuresPD;
    private static ValueDisplayPair[] _footStructuresD;

    private static readonly ValueDisplayPair[] GenitalArrangementsNCR =
    [
        new ValueDisplayPair("Normal", "NORMAL"), new ValueDisplayPair("Cloaca", "CLOACA"),
        new ValueDisplayPair("Rear-facing cloaca", "CLOACA_BEHIND")
    ];
    
    private static ValueDisplayPair[]  genitalArrangementsCR;
    private static ValueDisplayPair[]  genitalArrangementsN;
    private static ValueDisplayPair[]  genitalArrangementsC;
    private static ValueDisplayPair[]  genitalArrangementsR;
    
    public static LegTypeValueDisplayPair[] LegTypes { get; }

    public static ValueDisplayPair[] FemininityValues { get; } =
    [
        new ValueDisplayPair("Very Masculine", "VERY_MASCULINE"),
        new ValueDisplayPair("Masculine", "MASCULINE"), new ValueDisplayPair("Androgynous", "ANDROGYNOUS"),
        new ValueDisplayPair("Feminine", "FEMININE"), new ValueDisplayPair("Very Feminine", "VERY_FEMININE")
    ];
    
    public static ValueDisplayPair[] SubspeciesOverrides { get; } =
    [
        new ValueDisplayPair("Human", "HUMAN"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Elder Lilin", "ELDER_LILIN"), new ValueDisplayPair("Lilin", "LILIN"),
        new ValueDisplayPair("Demon", "DEMON"), new ValueDisplayPair("Half Demon", "HALF_DEMON"),
        new ValueDisplayPair("Imp", "IMP"), new ValueDisplayPair("Imp Alpha", "IMP_ALPHA"),
        new ValueDisplayPair("Cow Morph", "COW_MORPH"), new ValueDisplayPair("Dog Morph", "DOG_MORPH"),
        new ValueDisplayPair("Dog Morph Border Collie", "DOG_MORPH_BORDER_COLLIE"),
        new ValueDisplayPair("Dog Morph Dobermann", "DOG_MORPH_DOBERMANN"),
        new ValueDisplayPair("Dog Morph German Shepherd", "DOG_MORPH_GERMAN_SHEPHERD"), new ValueDisplayPair("Dragon Morph", "dsg_dragon_subspecies_dragon"),
        new ValueDisplayPair("Wolf Morph", "WOLF_MORPH"), new ValueDisplayPair("Fox Morph", "FOX_MORPH"),
        new ValueDisplayPair("Fox Morph Arctic", "FOX_MORPH_ARCTIC"),
        new ValueDisplayPair("Fox Morph Fennec", "FOX_MORPH_FENNEC"),
        new ValueDisplayPair("Fox Ascendant", "FOX_ASCENDANT"),
        new ValueDisplayPair("Fox Ascendant Arctic", "FOX_ASCENDANT_ARCTIC"),
        new ValueDisplayPair("Fox Ascendant Fennec", "FOX_ASCENDANT_FENNEC"),
        new ValueDisplayPair("Cat Morph", "CAT_MORPH"),
        new ValueDisplayPair("Cat Morph Lynx", "CAT_MORPH_LYNX"),
        new ValueDisplayPair("Cat Morph Cheetah", "CAT_MORPH_CHEETAH"),
        new ValueDisplayPair("Cat Morph Caracal", "CAT_MORPH_CARACAL"),
        new ValueDisplayPair("Cat Morph Leopard Snow", "CAT_MORPH_LEOPARD_SNOW"),
        new ValueDisplayPair("Cat Morph Leopard", "CAT_MORPH_LEOPARD"),
        new ValueDisplayPair("Cat Morph Lion", "CAT_MORPH_LION"),
        new ValueDisplayPair("Cat Morph Tiger", "CAT_MORPH_TIGER"),
        new ValueDisplayPair("Horse Morph", "HORSE_MORPH"),
        new ValueDisplayPair("Horse Morph Unicorn", "HORSE_MORPH_UNICORN"),
        new ValueDisplayPair("Horse Morph Pegasus", "HORSE_MORPH_PEGASUS"),
        new ValueDisplayPair("Horse Morph Alicorn", "HORSE_MORPH_ALICORN"),
        new ValueDisplayPair("Centaur", "CENTAUR"), new ValueDisplayPair("Pegataur", "PEGATAUR"),
        new ValueDisplayPair("Unitaur", "UNITAUR"), new ValueDisplayPair("Alitaur", "ALITAUR"),
        new ValueDisplayPair("Horse Morph Zebra", "HORSE_MORPH_ZEBRA"),
        new ValueDisplayPair("Reindeer Morph", "REINDEER_MORPH"),
        new ValueDisplayPair("Alligator Morph", "ALLIGATOR_MORPH"), new ValueDisplayPair("Slime", "SLIME"),
        new ValueDisplayPair("Squirrel Morph", "SQUIRREL_MORPH"),
        new ValueDisplayPair("Rat Morph", "RAT_MORPH"), new ValueDisplayPair("Rabbit Morph", "RABBIT_MORPH"),
        new ValueDisplayPair("Rabbit Morph Lop", "RABBIT_MORPH_LOP"),
        new ValueDisplayPair("Bat Morph", "BAT_MORPH"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Harpy Raven", "HARPY_RAVEN"),
        new ValueDisplayPair("Harpy Bald Eagle", "HARPY_BALD_EAGLE"),
        new ValueDisplayPair("Harpy Phoenix", "HARPY_PHOENIX"),
        new ValueDisplayPair("Elemental Fire", "ELEMENTAL_FIRE"),
        new ValueDisplayPair("Elemental Earth", "ELEMENTAL_EARTH"),
        new ValueDisplayPair("Elemental Water", "ELEMENTAL_WATER"),
        new ValueDisplayPair("Elemental Air", "ELEMENTAL_AIR"),
        new ValueDisplayPair("Elemental Arcane", "ELEMENTAL_ARCANE"), new ValueDisplayPair("Badger", "innoxia_badger_subspecies_badger")
    ]; //TODO Check if these are all subspecies in the game

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
    }
}