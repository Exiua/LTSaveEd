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