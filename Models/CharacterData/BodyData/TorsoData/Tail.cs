using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Tail
{
    public ValueDisplayPair<string>[] TailTypes { get; } =
    [
        new("None", "NONE"), new("Alligator", "ALLIGATOR_MORPH"),
        new("Badger", "innoxia_badger_tail"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_tail"),
        new("Capybara", "NoStepOnSnek_capybara_arm"),
        new("Feline", "CAT_MORPH"), new("Short Feline", "CAT_MORPH_SHORT"),
        new("Tufted Feline", "CAT_MORPH_TUFTED"), new("Cow", "COW_MORPH"),
        new("Demonic spaded", "DEMON_COMMON"),
        new("Demonic hair-tipped", "DEMON_HAIR_TIP"),
        new("Demonic tapered", "DEMON_TAPERED"),
        new("Demonic horse", "DEMON_HORSE"), new("Dog", "DOG_MORPH"),
        new("Stubby Dog", "DOG_MORPH_STUBBY"),
        new("Dragon tufted", "dsg_dragon_tailTufted"),
        new("Dragon", "dsg_dragon_tail"),
        new("Dragon feathered", "dsg_dragon_tailFeathered"),
        new("Dragon spaded", "dsg_dragon_tailSpaded"),
        new("Ferret", "dsg_ferret_tail"), new("Fox", "FOX_MORPH"),
        new("Goat", "innoxia_goat_tail"),
        new("Gryphon feathered", "dsg_gryphon_tailFeathers"),
        new("Gryphon", "dsg_gryphon_tail"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Zebra", "HORSE_MORPH_ZEBRA"),
        new("Hyena", "innoxia_hyena_tail"), new("Otter", "dsg_otter_tail"),
        new("Panther", "innoxia_panther_tail"),
        new("Pig", "innoxia_pig_tail"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_tail"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_tail"),
        new("Sheep", "innoxia_sheep_tail"),
        new("Snake", "NoStepOnSnek_snake_tail"),
        new("Furred Spider", "charisma_spider_tailFluffy"),
        new("Spider", "charisma_spider_tail"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<int> Count { get; }
    public LabeledXmlAttribute<int> Girth { get; }
    public XmlAttribute<float> Length { get; }
    public XmlAttribute<string> Type { get; }

    public Tail(XElement tailNode)
    {
        Count = new XmlAttribute<int>(tailNode.Attribute("count")!);
        Girth = new LabeledXmlAttribute<int>(tailNode.Attribute("girth")!, Collections.GetAppendageGirthLabel);
        Length = new XmlAttribute<float>(tailNode.Attribute("length")!);
        Type = new XmlAttribute<string>(tailNode.Attribute("type")!);
    }
}