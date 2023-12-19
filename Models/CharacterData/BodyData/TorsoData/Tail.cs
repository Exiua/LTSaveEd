using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Tail
{
    public ValueDisplayPair[] TailTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"),
        new ValueDisplayPair("Badger", "innoxia_badger_tail"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_tail"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_arm"),
        new ValueDisplayPair("Feline", "CAT_MORPH"), new ValueDisplayPair("Short Feline", "CAT_MORPH_SHORT"),
        new ValueDisplayPair("Tufted Feline", "CAT_MORPH_TUFTED"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic spaded", "DEMON_COMMON"),
        new ValueDisplayPair("Demonic hair-tipped", "DEMON_HAIR_TIP"),
        new ValueDisplayPair("Demonic tapered", "DEMON_TAPERED"),
        new ValueDisplayPair("Demonic horse", "DEMON_HORSE"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Stubby Dog", "DOG_MORPH_STUBBY"),
        new ValueDisplayPair("Dragon tufted", "dsg_dragon_tailTufted"),
        new ValueDisplayPair("Dragon", "dsg_dragon_tail"),
        new ValueDisplayPair("Dragon feathered", "dsg_dragon_tailFeathered"),
        new ValueDisplayPair("Dragon spaded", "dsg_dragon_tailSpaded"),
        new ValueDisplayPair("Ferret", "dsg_ferret_tail"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_tail"),
        new ValueDisplayPair("Gryphon feathered", "dsg_gryphon_tailFeathers"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_tail"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Zebra", "HORSE_MORPH_ZEBRA"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_tail"), new ValueDisplayPair("Otter", "dsg_otter_tail"),
        new ValueDisplayPair("Panther", "innoxia_panther_tail"),
        new ValueDisplayPair("Pig", "innoxia_pig_tail"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_tail"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_tail"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_tail"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_tail"),
        new ValueDisplayPair("Furred Spider", "charisma_spider_tailFluffy"),
        new ValueDisplayPair("Spider", "charisma_spider_tail"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
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