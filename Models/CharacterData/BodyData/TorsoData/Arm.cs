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
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_arm"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_arm"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_arm"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"), new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_arm"),
        new ValueDisplayPair<string>("Dragon winged", "dsg_dragon_armWings"),
        new ValueDisplayPair<string>("Ferret", "dsg_ferret_arm"), new ValueDisplayPair<string>("Fox", "FOX_MORPH"),
        new ValueDisplayPair<string>("Goat", "innoxia_goat_arm"), new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_arm"),
        new ValueDisplayPair<string>("Harpy", "HARPY"), new ValueDisplayPair<string>("Horse", "HORSE_MORPH"),
        new ValueDisplayPair<string>("Human", "HUMAN"), new ValueDisplayPair<string>("Hyena", "innoxia_hyena_arm"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_arm"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_arm"), new ValueDisplayPair<string>("Panther", "innoxia_panther_arm"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_arm"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_arm"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_arm"),
        new ValueDisplayPair<string>("Shark finned", "dsg_shark_armFin"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_arm"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_arm"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_arm"),
        new ValueDisplayPair<string>("Furred Spider", "charisma_spider_armFluffy"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
    ];

    public static ValueDisplayPair<string>[] UnderArmHairTypes => Collections.HairTypes;

    public XmlAttribute<int> Rows { get; } = new(armNode.Attribute("rows")!);
    public XmlAttribute<string> Type { get; } = new(armNode.Attribute("type")!);
    public XmlAttribute<string> UnderarmHair { get; } = new(armNode.Attribute("underarmHair")!);
}