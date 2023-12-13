using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.BreastsData;

public class BreastsComponent
{
    private readonly bool _breastsCrotch;
    
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
    
    public ValueDisplayPair[] AvailableShapes => _breastsCrotch ? _breastCrotchShapes : _breastShapes;
    public ValueDisplayPair[] AvailableTypes => _breastsCrotch ? _breastsCrotchTypes : _breastsTypes;
    
    public XmlAttribute<int> MilkRegeneration { get; }
    public XmlAttribute<int> MilkStorage { get; }
    public XmlAttribute<int> NippleCountPerBreast { get; }
    public XmlAttribute<int> Rows { get; }
    public XmlAttribute<int> Size { get; }
    public XmlAttribute<float> StoredMilk { get; }
    public XmlAttribute<string> Shape { get; }
    public XmlAttribute<string> Type { get; }
    
    
    public BreastsComponent(XElement breastsNode, bool breastsCrotch)
    {
        _breastsCrotch = breastsCrotch;
        MilkRegeneration = new XmlAttribute<int>(breastsNode.Attribute("milkRegeneration")!);
        MilkStorage = new XmlAttribute<int>(breastsNode.Attribute("milkStorage")!);
        NippleCountPerBreast = new XmlAttribute<int>(breastsNode.Attribute("nippleCountPerBreast")!);
        Rows = new XmlAttribute<int>(breastsNode.Attribute("rows")!);
        Size = new XmlAttribute<int>(breastsNode.Attribute("size")!);
        StoredMilk = new XmlAttribute<float>(breastsNode.Attribute("storedMilk")!);
        Shape = new XmlAttribute<string>(breastsNode.Attribute("shape")!);
        Type = new XmlAttribute<string>(breastsNode.Attribute("type")!);
    }
}