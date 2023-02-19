using System.Collections.Generic;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.Attributes;

public static class LegTypeAttributeInitializer
{
    static LegTypeAttributeInitializer()
    {
        #region Leg Configuration Initialization

        LegConfigurationBQ = LegConfigurationMaster.GetRange(..2);
        LegConfigurationsB = LegConfigurationMaster.GetRange(..0);
        LegConfigurationsS = LegConfigurationMaster.GetRange(2..2);
        LegConfigurationsAr = LegConfigurationMaster.GetRange(3..3);
        LegConfigurationsC = LegConfigurationMaster.GetRange(4..4);
        LegConfigurationsM = LegConfigurationMaster.GetRange(5..5);
        LegConfigurationsAv = LegConfigurationMaster.GetRange(6..6);
        LegConfigurationBQSM = LegConfigurationMaster.GetRange(..3);
        LegConfigurationBQSM = LegConfigurationMaster.GetRange(5..5);
        LegConfigurationsBAv = LegConfigurationMaster.GetRange(..0);
        LegConfigurationsBAv = LegConfigurationMaster.GetRange(6..6);
        LegConfigurationsBM = LegConfigurationMaster.GetRange(..0);
        LegConfigurationsBM = LegConfigurationMaster.GetRange(5..5);
        LegConfigurationsBS = LegConfigurationMaster.GetRange(..0);
        LegConfigurationsBS = LegConfigurationMaster.GetRange(2..2);
        LegConfigurationsBAr = LegConfigurationMaster.GetRange(..0);
        LegConfigurationsBAr = LegConfigurationMaster.GetRange(3..3);

        #endregion


        #region Foot Structure Initialization

        FootStructuresP = FootStructuresMaster.GetRange(1..1);
        FootStructuresU = FootStructuresMaster.GetRange(2..2);
        FootStructuresN = FootStructuresMaster.GetRange(..0);
        FootStructuresA = FootStructuresMaster.GetRange(4..4);
        FootStructuresT = FootStructuresMaster.GetRange(5..5);
        FootStructuresPD = FootStructuresMaster.GetRange(1..1);
        FootStructuresPD = FootStructuresMaster.GetRange(3..3);
        FootStructuresD = FootStructuresMaster.GetRange(3..3);

        #endregion

        #region Genital Arrangement Initialization

        GenitalArrangementsCR = GenitalArrangementsNCR.GetRange(1..3);
        GenitalArrangementsN = GenitalArrangementsNCR.GetRange(..0);
        GenitalArrangementsC = GenitalArrangementsNCR.GetRange(1..1);
        GenitalArrangementsR = GenitalArrangementsNCR.GetRange(2..2);

        #endregion
    }

    public static List<LegTypeAttribute> LegTypes
    {
        get
        {
            var types = InitializeLegTypes();
            return types;
        }
    }

    private static List<LegTypeAttribute> InitializeLegTypes()
    {
        return new List<LegTypeAttribute>
        {
            new LegTypeAttribute("Alligator", "ALLIGATOR_MORPH", LegConfigurationBQ, FootStructuresP, GenitalArrangementsNCR),
            new LegTypeAttribute("Angel", "ANGEL", LegConfigurationsB, FootStructuresP, GenitalArrangementsNCR),
            new LegTypeAttribute("Badger", "innoxia_badger_leg", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Bat", "BAT_MORPH", LegConfigurationsB, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Bear", "dsg_bear_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Capybara", "NoStepOnSnek_capybara_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Cat", "CAT_MORPH", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Cow", "COW_MORPH", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Demonic", "DEMON_COMMON", LegConfigurationsB, FootStructuresP, GenitalArrangementsNCR),
            new LegTypeAttribute("Demonic-hoofed", "DEMON_HOOFED", LegConfigurationsB, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Demonic-horse", "DEMON_HORSE", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Demonic-snake", "DEMON_SNAKE", LegConfigurationsS, FootStructuresN, GenitalArrangementsCR),
            new LegTypeAttribute("Demonic-spider", "DEMON_SPIDER", LegConfigurationsAr, FootStructuresA, GenitalArrangementsN),
            new LegTypeAttribute("Demonic-octopus", "DEMON_OCTOPUS", LegConfigurationsC, FootStructuresT, GenitalArrangementsC),
            new LegTypeAttribute("Demonic-fish", "DEMON_FISH", LegConfigurationsM, FootStructuresN, GenitalArrangementsCR),
            new LegTypeAttribute("Demonic-eagle", "DEMON_EAGLE", LegConfigurationsAv, FootStructuresD, GenitalArrangementsR),
            new LegTypeAttribute("Dog", "DOG_MORPH", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Dragon", "dsg_dragon_leg", LegConfigurationBQSM, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Ferret", "dsg_ferret_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Fox", "FOX_MORPH", LegConfigurationBQ, LegConfigurationBQ, FootStructuresPD, "DIGITIGRADE"),
            new LegTypeAttribute("Goat", "innoxia_goat_leg", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Gryphon", "dsg_gryphon_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Harpy", "HARPY", LegConfigurationsBAv, FootStructuresD, GenitalArrangementsNCR),
            new LegTypeAttribute("Horse", "HORSE_MORPH", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Human", "HUMAN", LegConfigurationsB, FootStructuresP, GenitalArrangementsNCR),
            new LegTypeAttribute("Hyena", "innoxia_hyena_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Octopus", "NoStepOnSnek_octopus_leg", LegConfigurationsC, FootStructuresT, GenitalArrangementsC),
            new LegTypeAttribute("Otter", "dsg_otter_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Panther", "innoxia_panther_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE"),
            new LegTypeAttribute("Pig", "innoxia_pig_leg", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Rabbit", "RABBIT_MORPH", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Racoon", "dsg_racoon_leg", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Rat", "RAT_MORPH", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Reindeer", "REINDEER_MORPH", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Shark", "dsg_shark_leg", LegConfigurationsBM, FootStructuresP, GenitalArrangementsNCR),
            new LegTypeAttribute("Sheep", "innoxia_sheep_leg", LegConfigurationBQ, FootStructuresU, GenitalArrangementsNCR),
            new LegTypeAttribute("Snake", "NoStepOnSnek_snake_leg", LegConfigurationsBS, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Furred Spider", "charisma_spider_legFluffy", LegConfigurationsBAr, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Spider", "charisma_spider_leg", LegConfigurationsBAr, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Squirrel", "SQUIRREL_MORPH", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR),
            new LegTypeAttribute("Wolf", "WOLF_MORPH", LegConfigurationBQ, FootStructuresPD, GenitalArrangementsNCR, "DIGITIGRADE")
        };
    }

    #region Leg Configurations

    /**
     * List of all leg configurations in the game
     */
    private static readonly List<Attribute> LegConfigurationMaster = new List<Attribute>
    {
        new Attribute("Bipedal", "BIPEDAL"), new Attribute("Quadrupedal", "QUADRUPEDAL"),
        new Attribute("Serpent-tailed", "TAIL_LONG"), new Attribute("Arachnid", "ARACHNID"),
        new Attribute("Cephalopod", "CEPHALOPOD"), new Attribute("Mer-tailed", "TAIL"),
        new Attribute("Avian", "AVIAN")
    };

    /**
     * List of bipedal and quadrupedal leg configurations
     */
    private static readonly List<Attribute> LegConfigurationBQ;

    /**
     * List of bipedal leg configuration
     */
    private static readonly List<Attribute> LegConfigurationsB;

    /**
     * List of serpent-tailed leg configurations
     */
    private static readonly List<Attribute> LegConfigurationsS;

    /**
     * List of arachnid leg configuration
     */
    private static readonly List<Attribute> LegConfigurationsAr;

    /**
     * List of cephalopod leg configuration
     */
    private static readonly List<Attribute> LegConfigurationsC;

    /**
     * List of mer-tailed leg configuration
     */
    private static readonly List<Attribute> LegConfigurationsM;

    /**
     * List of avian leg configuration
     */
    private static readonly List<Attribute> LegConfigurationsAv;

    /**
     * List of bipedal, quadrupedal, serpent-tailed, and mer-tailed leg configurations
     */
    private static readonly List<Attribute> LegConfigurationBQSM;

    /**
     * List of bipedal and avian leg configurations
     */
    private static readonly List<Attribute> LegConfigurationsBAv;

    /**
     * List of bipedal and mer-tailed leg configurations
     */
    private static readonly List<Attribute> LegConfigurationsBM;

    /**
     * List of bipedal and serpent-tailed leg configurations
     */
    private static readonly List<Attribute> LegConfigurationsBS;

    /**
     * List of bipedal and arachnid leg configurations
     */
    private static readonly List<Attribute> LegConfigurationsBAr;

    #endregion

    #region Foot Structures

    /**
     * List of all foot structures in the game
     */
    private static readonly List<Attribute> FootStructuresMaster = new List<Attribute>
    {
        new Attribute("None", "NONE"), new Attribute("Plantigrade", "PLANTIGRADE"),
        new Attribute("Unguligrade", "UNGULIGRADE"), new Attribute("Digitigrade", "DIGITIGRADE"),
        new Attribute("Arachnoid", "ARACHNOID"), new Attribute("Tentacled", "TENTACLED")
    };

    /**
     * List of plantigrade foot structure
     */
    private static readonly List<Attribute> FootStructuresP;

    /**
     * List of unguligrade foot structure
     */
    private static readonly List<Attribute> FootStructuresU;

    /**
     * List of none foot structure (for tailed leg configs)
     */
    private static readonly List<Attribute> FootStructuresN;

    /**
     * List of arachnoid foot structure
     */
    private static readonly List<Attribute> FootStructuresA;

    /**
     * List of tentacled foot structure
     */
    private static readonly List<Attribute> FootStructuresT;

    /**
     * List of plantigrade and digitigrade foot structures
     */
    private static readonly List<Attribute> FootStructuresPD;

    /**
     * List of digitigrade foot structure
     */
    private static readonly List<Attribute> FootStructuresD;

    #endregion

    #region Genital Arrangements

    /**
     * List of all genital arrangements in the game
     */
    private static readonly List<Attribute> GenitalArrangementsNCR = new List<Attribute>
    {
        new Attribute("Normal", "NORMAL"), new Attribute("Cloaca", "CLOACA"),
        new Attribute("Rear-facing cloaca", "CLOACA_BEHIND")
    };

    /**
     * List of cloaca and rear-facing cloaca genital arrangements
     */
    private static readonly List<Attribute> GenitalArrangementsCR;

    /**
     * List of normal genital arrangement
     */
    private static readonly List<Attribute> GenitalArrangementsN;

    /**
     * List of cloaca genital arrangement
     */
    private static readonly List<Attribute> GenitalArrangementsC;

    /**
     * List of rear-facing cloaca genital arrangement
     */
    private static readonly List<Attribute> GenitalArrangementsR;

    #endregion
}