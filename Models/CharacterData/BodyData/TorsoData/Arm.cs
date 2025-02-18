using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

/// <summary>
///     Class models the arm node of the character's body data. Part of the <see cref="Torso" /> model.
/// </summary>
/// <param name="armNode">XElement of the arm node</param>
public class Arm(XElement armNode)
{
    public ValueDisplayPair<string>[] ArmTypes { get; } =
    [
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_arm"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_arm"),
        new("Capybara", "NoStepOnSnek_capybara_arm"),
        new("Cat", "CAT_MORPH"), new("Cow", "COW_MORPH"),
        new("Demonic", "DEMON_COMMON"), new("Dog", "DOG_MORPH"),
        new("Dragon", "dsg_dragon_arm"),
        new("Dragon winged", "dsg_dragon_armWings"),
        new("Ferret", "dsg_ferret_arm"), new("Fox", "FOX_MORPH"),
        new("Goat", "innoxia_goat_arm"), new("Gryphon", "dsg_gryphon_arm"),
        new("Harpy", "HARPY"), new("Horse", "HORSE_MORPH"),
        new("Human", "HUMAN"), new("Hyena", "innoxia_hyena_arm"),
        new("Octopus", "NoStepOnSnek_octopus_arm"),
        new("Otter", "dsg_otter_arm"), new("Panther", "innoxia_panther_arm"),
        new("Pig", "innoxia_pig_arm"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_arm"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_arm"),
        new("Shark finned", "dsg_shark_armFin"),
        new("Sheep", "innoxia_sheep_arm"),
        new("Snake", "NoStepOnSnek_snake_arm"),
        new("Spider", "charisma_spider_arm"),
        new("Furred Spider", "charisma_spider_armFluffy"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public static ValueDisplayPair<string>[] UnderArmHairTypes => Collections.HairTypes;

    public XmlAttribute<int> Rows { get; } = new(armNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(armNode.Attribute("type")!);
    public XmlAttribute<string> UnderarmHair { get; } = new(armNode.Attribute("underarmHair")!);
}