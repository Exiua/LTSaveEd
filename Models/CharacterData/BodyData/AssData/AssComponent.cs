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
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_ass"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_ass"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_ass"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"), new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_ass"), new ValueDisplayPair<string>("Ferret", "dsg_ferret_ass"),
        new ValueDisplayPair<string>("Fox", "FOX_MORPH"), new ValueDisplayPair<string>("Goat", "innoxia_goat_ass"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_ass"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "HORSE_MORPH"), new ValueDisplayPair<string>("Human", "HUMAN"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_ass"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_ass"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_ass"), new ValueDisplayPair<string>("Panther", "innoxia_panther_ass"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_ass"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_ass"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_ass"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_ass"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_ass"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_ass"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
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