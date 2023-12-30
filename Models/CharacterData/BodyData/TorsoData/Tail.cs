using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class Tail
{
    public ValueDisplayPair<string>[] TailTypes { get; } =
    [
        new ValueDisplayPair<string>("None", "NONE"), new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_tail"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_tail"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_arm"),
        new ValueDisplayPair<string>("Feline", "CAT_MORPH"), new ValueDisplayPair<string>("Short Feline", "CAT_MORPH_SHORT"),
        new ValueDisplayPair<string>("Tufted Feline", "CAT_MORPH_TUFTED"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic spaded", "DEMON_COMMON"),
        new ValueDisplayPair<string>("Demonic hair-tipped", "DEMON_HAIR_TIP"),
        new ValueDisplayPair<string>("Demonic tapered", "DEMON_TAPERED"),
        new ValueDisplayPair<string>("Demonic horse", "DEMON_HORSE"), new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Stubby Dog", "DOG_MORPH_STUBBY"),
        new ValueDisplayPair<string>("Dragon tufted", "dsg_dragon_tailTufted"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_tail"),
        new ValueDisplayPair<string>("Dragon feathered", "dsg_dragon_tailFeathered"),
        new ValueDisplayPair<string>("Dragon spaded", "dsg_dragon_tailSpaded"),
        new ValueDisplayPair<string>("Ferret", "dsg_ferret_tail"), new ValueDisplayPair<string>("Fox", "FOX_MORPH"),
        new ValueDisplayPair<string>("Goat", "innoxia_goat_tail"),
        new ValueDisplayPair<string>("Gryphon feathered", "dsg_gryphon_tailFeathers"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_tail"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "HORSE_MORPH"), new ValueDisplayPair<string>("Zebra", "HORSE_MORPH_ZEBRA"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_tail"), new ValueDisplayPair<string>("Otter", "dsg_otter_tail"),
        new ValueDisplayPair<string>("Panther", "innoxia_panther_tail"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_tail"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_tail"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_tail"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_tail"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_tail"),
        new ValueDisplayPair<string>("Furred Spider", "charisma_spider_tailFluffy"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_tail"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
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