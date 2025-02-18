using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.AssData;

/// <summary>
///     Class models the ass node of the character's body data. Part of the <see cref="Ass" /> model.
/// </summary>
public class AssComponent
{
    public ValueDisplayPair<string>[] AssTypes { get; } =
    [
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_ass"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_ass"),
        new("Capybara", "NoStepOnSnek_capybara_ass"),
        new("Cat", "CAT_MORPH"), new("Cow", "COW_MORPH"),
        new("Demonic", "DEMON_COMMON"), new("Dog", "DOG_MORPH"),
        new("Dragon", "dsg_dragon_ass"), new("Ferret", "dsg_ferret_ass"),
        new("Fox", "FOX_MORPH"), new("Goat", "innoxia_goat_ass"),
        new("Gryphon", "dsg_gryphon_ass"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Human", "HUMAN"),
        new("Hyena", "innoxia_hyena_ass"),
        new("Octopus", "NoStepOnSnek_octopus_ass"),
        new("Otter", "dsg_otter_ass"), new("Panther", "innoxia_panther_ass"),
        new("Pig", "innoxia_pig_ass"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_ass"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_ass"),
        new("Sheep", "innoxia_sheep_ass"),
        new("Snake", "NoStepOnSnek_snake_ass"),
        new("Spider", "charisma_spider_ass"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public LabeledXmlAttribute<int> AssSize { get; }
    public LabeledXmlAttribute<int> HipSize { get; }
    public XmlAttribute<string> Type { get; }
    
    public AssComponent(XElement assNode)
    {
        AssSize = new LabeledXmlAttribute<int>(assNode.Attribute("assSize")!, GetAssSizeLabel);
        HipSize = new LabeledXmlAttribute<int>(assNode.Attribute("hipSize")!, GetHipSizeLabel);
        Type = new XmlAttribute<string>(assNode.Attribute("type")!);
    }

    private static string GetAssSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Flat",
            1 => "Tiny",
            2 => "Small",
            3 => "Round",
            4 => "Large",
            5 => "Huge",
            6 => "Massive",
            >= 7 => "Gigantic"
        };
    }

    private static string GetHipSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Completely Straight",
            1 => "Very Narrow",
            2 => "Narrow",
            3 => "Girly",
            4 => "Womanly",
            5 => "Very Wide",
            6 => "Extremely Wide",
            >= 7 => "Absurdly Wide"
        };
    }
}