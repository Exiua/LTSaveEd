using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

/// <summary>
///     Class models the ear node of the character's body data. Part of the <see cref="Head" /> model.
/// </summary>
/// <param name="earNode">XElement of the ear node</param>
public class Ear(XElement earNode)
{
    public ValueDisplayPair<string>[] EarTypes { get; } =
    [
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_ear"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_ear"), new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_ear"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Tufted Cat", "CAT_MORPH_TUFTED"),
        new ValueDisplayPair<string>("Cow", "COW_MORPH"), new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"),
        new ValueDisplayPair<string>("Floppy Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Pointed Dog", "DOG_MORPH_POINTED"),
        new ValueDisplayPair<string>("Folded Dog", "DOG_MORPH_FOLDED"), new ValueDisplayPair<string>("Deer", "innoxia_deer_ear"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_ear"),
        new ValueDisplayPair<string>("Dragon external", "dsg_dragon_earExternal"),
        new ValueDisplayPair<string>("Ferret", "dsg_ferret_ear"), new ValueDisplayPair<string>("Fox", "FOX_MORPH"),
        new ValueDisplayPair<string>("Fennec Fox", "FOX_MORPH_BIG"), new ValueDisplayPair<string>("Goat", "innoxia_goat_ear"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_ear"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "HORSE_MORPH"), new ValueDisplayPair<string>("Human", "HUMAN"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_ear"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_ear"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_ear"),
        new ValueDisplayPair<string>("Panther", "innoxia_panther_ear"), new ValueDisplayPair<string>("Pig", "innoxia_pig_ear"),
        new ValueDisplayPair<string>("Upright Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Floppy Rabbit", "RABBIT_MORPH_FLOPPY"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_ear"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_ear"),
        new ValueDisplayPair<string>("Shark finned", "dsg_shark_earFin"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_ear"),
        new ValueDisplayPair<string>("Pointed Snake", "NoStepOnSnek_snake_ear_1"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_ear"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_ear"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<bool> Pierced { get; } = new(earNode.Attribute("pierced")!);
    public XmlAttribute<string> Type { get; } = new(earNode.Attribute("type")!);
}