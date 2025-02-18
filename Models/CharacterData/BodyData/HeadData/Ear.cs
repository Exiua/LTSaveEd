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
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_ear"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_ear"), new("Capybara", "NoStepOnSnek_capybara_ear"),
        new("Cat", "CAT_MORPH"), new("Tufted Cat", "CAT_MORPH_TUFTED"),
        new("Cow", "COW_MORPH"), new("Demonic", "DEMON_COMMON"),
        new("Floppy Dog", "DOG_MORPH"),
        new("Pointed Dog", "DOG_MORPH_POINTED"),
        new("Folded Dog", "DOG_MORPH_FOLDED"), new("Deer", "innoxia_deer_ear"),
        new("Dragon", "dsg_dragon_ear"),
        new("Dragon external", "dsg_dragon_earExternal"),
        new("Ferret", "dsg_ferret_ear"), new("Fox", "FOX_MORPH"),
        new("Fennec Fox", "FOX_MORPH_BIG"), new("Goat", "innoxia_goat_ear"),
        new("Gryphon", "dsg_gryphon_ear"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Human", "HUMAN"),
        new("Hyena", "innoxia_hyena_ear"),
        new("Octopus", "NoStepOnSnek_octopus_ear"),
        new("Otter", "dsg_otter_ear"),
        new("Panther", "innoxia_panther_ear"), new("Pig", "innoxia_pig_ear"),
        new("Upright Rabbit", "RABBIT_MORPH"),
        new("Floppy Rabbit", "RABBIT_MORPH_FLOPPY"),
        new("Racoon", "dsg_raccoon_ear"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_ear"),
        new("Shark finned", "dsg_shark_earFin"),
        new("Sheep", "innoxia_sheep_ear"),
        new("Pointed Snake", "NoStepOnSnek_snake_ear_1"),
        new("Snake", "NoStepOnSnek_snake_ear"),
        new("Spider", "charisma_spider_ear"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<bool> Pierced { get; } = new(earNode.Attribute("pierced")!);
    public XmlAttribute<string> Type { get; } = new(earNode.Attribute("type")!);
}