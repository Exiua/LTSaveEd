using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

/// <summary>
///     Class models the ear node of the character's body data. Part of the <see cref="Head" /> model.
/// </summary>
/// <param name="earNode">XElement of the ear node</param>
public class Ear(XElement earNode)
{
    public ValueDisplayPair[] EarTypes { get; } =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_ear"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_ear"), new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_ear"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Tufted Cat", "CAT_MORPH_TUFTED"),
        new ValueDisplayPair("Cow", "COW_MORPH"), new ValueDisplayPair("Demonic", "DEMON_COMMON"),
        new ValueDisplayPair("Floppy Dog", "DOG_MORPH"),
        new ValueDisplayPair("Pointed Dog", "DOG_MORPH_POINTED"),
        new ValueDisplayPair("Folded Dog", "DOG_MORPH_FOLDED"), new ValueDisplayPair("Deer", "innoxia_deer_ear"),
        new ValueDisplayPair("Dragon", "dsg_dragon_ear"),
        new ValueDisplayPair("Dragon external", "dsg_dragon_earExternal"),
        new ValueDisplayPair("Ferret", "dsg_ferret_ear"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Fennec Fox", "FOX_MORPH_BIG"), new ValueDisplayPair("Goat", "innoxia_goat_ear"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_ear"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_ear"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_ear"),
        new ValueDisplayPair("Otter", "dsg_otter_ear"),
        new ValueDisplayPair("Panther", "innoxia_panther_ear"), new ValueDisplayPair("Pig", "innoxia_pig_ear"),
        new ValueDisplayPair("Upright Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Floppy Rabbit", "RABBIT_MORPH_FLOPPY"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_ear"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_ear"),
        new ValueDisplayPair("Shark finned", "dsg_shark_earFin"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_ear"),
        new ValueDisplayPair("Pointed Snake", "NoStepOnSnek_snake_ear_1"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_ear"),
        new ValueDisplayPair("Spider", "charisma_spider_ear"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<bool> Pierced { get; } = new(earNode.Attribute("pierced")!);
    public XmlAttribute<string> Type { get; } = new(earNode.Attribute("type")!);
}