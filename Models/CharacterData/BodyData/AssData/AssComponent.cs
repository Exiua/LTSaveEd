using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.AssData;

public class AssComponent
{
    public ValueDisplayPair[] AssTypes { get; } =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_ass"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_ass"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_ass"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_ass"), new ValueDisplayPair("Ferret", "dsg_ferret_ass"),
        new ValueDisplayPair("Fox", "FOX_MORPH"), new ValueDisplayPair("Goat", "innoxia_goat_ass"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_ass"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_ass"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_ass"),
        new ValueDisplayPair("Otter", "dsg_otter_ass"), new ValueDisplayPair("Panther", "innoxia_panther_ass"),
        new ValueDisplayPair("Pig", "innoxia_pig_ass"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_ass"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_ass"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_ass"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_ass"),
        new ValueDisplayPair("Spider", "charisma_spider_ass"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<int> AssSize { get; }
    public XmlAttribute<int> HipSize { get; }
    public XmlAttribute<string> Type { get; }
    
    public AssComponent(XElement assNode)
    {
        AssSize = new XmlAttribute<int>(assNode.Attribute("assSize")!);
        HipSize = new XmlAttribute<int>(assNode.Attribute("hipSize")!);
        Type = new XmlAttribute<string>(assNode.Attribute("type")!);
    }
}