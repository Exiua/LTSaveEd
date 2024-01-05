using LTSaveEd.Models.CharacterData.BodyData;

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