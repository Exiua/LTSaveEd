using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.BreastsData;

/// <summary>
///     Class models the breasts(Crotch) node of the character's body data. Part of the <see cref="Breasts" /> model.
/// </summary>
/// <param name="breastsNode">XElement of the breasts(Crotch) node</param>
/// <param name="breastsCrotch">Whether the breasts are crotch breasts or not</param>
public class BreastsComponent(XElement breastsNode, bool breastsCrotch)
{
    private readonly ValueDisplayPair[] _breastShapes =
    [
        new ValueDisplayPair("Round", "ROUND"), new ValueDisplayPair("Pointy", "POINTY"),
        new ValueDisplayPair("Perky", "PERKY"), new ValueDisplayPair("Side-set", "SIDE_SET"),
        new ValueDisplayPair("Wide", "WIDE"), new ValueDisplayPair("Narrow", "NARROW")
    ];

    private readonly ValueDisplayPair[] _breastCrotchShapes =
    [
        new ValueDisplayPair("Udders", "UDDERS"), new ValueDisplayPair("Round", "ROUND"),
        new ValueDisplayPair("Pointy", "POINTY"), new ValueDisplayPair("Perky", "PERKY"),
        new ValueDisplayPair("Side-set", "SIDE_SET"), new ValueDisplayPair("Wide", "WIDE"),
        new ValueDisplayPair("Narrow", "NARROW")
    ];

    private readonly ValueDisplayPair[] _breastsTypes =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_breast"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_breast"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_breast"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_breast"),
        new ValueDisplayPair("Ferret", "dsg_ferret_breast"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_breast"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_breast"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_breast"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_breast"),
        new ValueDisplayPair("Otter", "dsg_otter_breast"),
        new ValueDisplayPair("Panther", "innoxia_panther_breast"),
        new ValueDisplayPair("Pig", "innoxia_pig_breast"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_breast"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_breast"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_breast"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_breast"),
        new ValueDisplayPair("Spider", "charisma_spider_breast"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    private readonly ValueDisplayPair[] _breastsCrotchTypes =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"),
        new ValueDisplayPair("Angel", "ANGEL"), new ValueDisplayPair("Badger", "innoxia_badger_breast"),
        new ValueDisplayPair("Bat", "BAT_MORPH"), new ValueDisplayPair("Bear", "dsg_bear_breast"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_breast"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_breast"),
        new ValueDisplayPair("Ferret", "dsg_ferret_breast"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_breast"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_breast"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_breast"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_breast"),
        new ValueDisplayPair("Otter", "dsg_otter_breast"),
        new ValueDisplayPair("Panther", "innoxia_panther_breast"),
        new ValueDisplayPair("Pig", "innoxia_pig_breast"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_breast"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_breast"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_breast"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_breast"),
        new ValueDisplayPair("Spider", "charisma_spider_breast"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];
    
    public ValueDisplayPair[] AvailableShapes => breastsCrotch ? _breastCrotchShapes : _breastShapes;
    public ValueDisplayPair[] AvailableTypes => breastsCrotch ? _breastsCrotchTypes : _breastsTypes;
    
    public LabeledXmlAttribute<int> MilkRegeneration { get; } = new(breastsNode.Attribute("milkRegeneration")!, Collections.GetFluidRegenerationLabel);
    public LabeledXmlAttribute<int> MilkStorage { get; } = new(breastsNode.Attribute("milkStorage")!, GetMilkStorageLabel);
    public XmlAttribute<int> NippleCountPerBreast { get; } = new(breastsNode.Attribute("nippleCountPerBreast")!);
    public XmlAttribute<int> Rows { get; } = new(breastsNode.Attribute("rows")!);
    public LabeledXmlAttribute<int> Size { get; } = new(breastsNode.Attribute("size")!, GetBreastsSizeLabel);
    public XmlAttribute<float> StoredMilk { get; } = new(breastsNode.Attribute("storedMilk")!);
    public XmlAttribute<string> Shape { get; } = new(breastsNode.Attribute("shape")!);
    public XmlAttribute<string> Type { get; } = new(breastsNode.Attribute("type")!);


    /// <summary>
    ///     Get the label for the milk storage attribute based on the given value.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetMilkStorageLabel(int value)
    {
        return value switch
        {
            <= 0 => "None",
            > 0 and < 30 => "Trickle",
            >= 30 and < 100 => "Small",
            >= 100 and < 600 => "Decent",
            >= 600 and < 1000 => "Large",
            >= 1000 and < 2000 => "Huge",
            >= 2000 and < 10000 => "Extreme",
            >= 10000 => "Monstrous",
        };
    }

    /// <summary>
    ///     Get the label for the breasts size attribute based on the given value.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetBreastsSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Flat",
            1 => "Training-AAA-cup",
            2 => "Training-AA-cup",
            3 => "Training-A-cup",
            4 => "AA-cup",
            5 => "A-cup",
            6 => "B-cup",
            7 => "C-cup",
            8 => "D-cup",
            9 => "DD-cup",
            10 => "E-cup",
            11 => "F-cup",
            12 => "FF-cup",
            13 => "G-cup",
            14 => "GG-cup",
            15 => "H-cup",
            16 => "HH-cup",
            17 => "J-cup",
            18 => "JJ-cup",
            19 => "K-cup",
            20 => "KK-cup",
            21 => "L-cup",
            22 => "LL-cup",
            23 => "M-cup",
            24 => "MM-cup",
            25 => "N-cup",
            26 => "X-AA-cup",
            27 => "X-A-cup",
            28 => "X-B-cup",
            29 => "X-C-cup",
            30 => "X-D-cup",
            31 => "X-DD-cup",
            32 => "X-E-cup",
            33 => "X-F-cup",
            34 => "X-FF-cup",
            35 => "X-G-cup",
            36 => "X-GG-cup",
            37 => "X-H-cup",
            38 => "X-HH-cup",
            39 => "X-J-cup",
            40 => "X-JJ-cup",
            41 => "X-K-cup",
            42 => "X-KK-cup",
            43 => "X-L-cup",
            44 => "X-LL-cup",
            45 => "X-M-cup",
            46 => "X-MM-cup",
            47 => "X-N-cup",
            48 => "XX-AA-cup",
            49 => "XX-A-cup",
            50 => "XX-B-cup",
            51 => "XX-C-cup",
            52 => "XX-D-cup",
            53 => "XX-DD-cup",
            54 => "XX-E-cup",
            55 => "XX-F-cup",
            56 => "XX-FF-cup",
            57 => "XX-G-cup",
            58 => "XX-GG-cup",
            59 => "XX-H-cup",
            60 => "XX-HH-cup",
            61 => "XX-J-cup",
            62 => "XX-JJ-cup",
            63 => "XX-K-cup",
            64 => "XX-KK-cup",
            65 => "XX-L-cup",
            66 => "XX-LL-cup",
            67 => "XX-M-cup",
            68 => "XX-MM-cup",
            69 => "XX-N-cup",
            70 => "XXX-AA-cup",
            71 => "XXX-A-cup",
            72 => "XXX-B-cup",
            73 => "XXX-C-cup",
            74 => "XXX-D-cup",
            75 => "XXX-DD-cup",
            76 => "XXX-E-cup",
            77 => "XXX-F-cup",
            78 => "XXX-FF-cup",
            79 => "XXX-G-cup",
            80 => "XXX-GG-cup",
            81 => "XXX-H-cup",
            82 => "XXX-HH-cup",
            83 => "XXX-J-cup",
            84 => "XXX-JJ-cup",
            85 => "XXX-K-cup",
            86 => "XXX-KK-cup",
            87 => "XXX-L-cup",
            88 => "XXX-LL-cup",
            89 => "XXX-M-cup",
            90 => "XXX-MM-cup",
            >= 91 => "XXX-N-cup"
        };
    }
}