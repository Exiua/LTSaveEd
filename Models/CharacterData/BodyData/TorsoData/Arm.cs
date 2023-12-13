using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Arm
{
    public ValueDisplayPair[] ArmTypes { get; } =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_arm"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_arm"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_arm"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_arm"),
        new ValueDisplayPair("Dragon winged", "dsg_dragon_armWings"),
        new ValueDisplayPair("Ferret", "dsg_ferret_arm"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_arm"), new ValueDisplayPair("Gryphon", "dsg_gryphon_arm"),
        new ValueDisplayPair("Harpy", "HARPY"), new ValueDisplayPair("Horse", "HORSE_MORPH"),
        new ValueDisplayPair("Human", "HUMAN"), new ValueDisplayPair("Hyena", "innoxia_hyena_arm"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_arm"),
        new ValueDisplayPair("Otter", "dsg_otter_arm"), new ValueDisplayPair("Panther", "innoxia_panther_arm"),
        new ValueDisplayPair("Pig", "innoxia_pig_arm"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_arm"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_arm"),
        new ValueDisplayPair("Shark finned", "dsg_shark_armFin"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_arm"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_arm"),
        new ValueDisplayPair("Spider", "charisma_spider_arm"),
        new ValueDisplayPair("Furred Spider", "charisma_spider_armFluffy"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public ValueDisplayPair[] UnderArmHairTypes { get; } = Collections.HairTypes;

    public XmlAttribute<int> Rows { get; }
    public XmlAttribute<string> Type { get; }
    public XmlAttribute<string> UnderarmHair { get; }

    public Arm(XElement armNode)
    {
        Rows = new XmlAttribute<int>(armNode.Attribute("rows")!);
        Type = new XmlAttribute<string>(armNode.Attribute("type")!);
        UnderarmHair = new XmlAttribute<string>(armNode.Attribute("underarmHair")!);
    }
}