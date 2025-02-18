using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

/// <summary>
///     Class models the eye node of the character's body data. Part of the <see cref="Face" /> model.
/// </summary>
public class Eye
{
    public ValueDisplayPair<string>[] IrisShapes { get; } =
    [
        new("Round", "ROUND"), new("Horizontal", "HORIZONTAL"),
        new("Vertical", "VERTICAL"), new("Heart-shaped", "HEART"),
        new("Star-shaped", "STAR")
    ];

    public ValueDisplayPair<string>[] PupilShapes { get; }

    public ValueDisplayPair<string>[] EyeTypes { get; } =
    [
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_eye"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_eye"),
        new("Capybara", "NoStepOnSnek_capybara_eye"),
        new("Cat", "CAT_MORPH"), new("Cow", "COW_MORPH"),
        new("Demonic", "DEMON_COMMON"), new("Deer", "innoxia_deer_eye"),
        new("Dog", "DOG_MORPH"),
        new("Dragon", "dsg_dragon_eye"), new("Ferret", "dsg_ferret_eye"),
        new("Fox", "FOX_MORPH"), new("Goat", "innoxia_goat_eye"),
        new("Gryphon", "dsg_gryphon_eye"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Human", "HUMAN"),
        new("Hyena", "innoxia_hyena_eye"),
        new("Octopus", "NoStepOnSnek_octopus_eye"),
        new("Otter", "dsg_otter_eye"), new("Panther", "innoxia_panther_eye"),
        new("Pig", "innoxia_pig_eye"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_eye"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_eye"),
        new("Sheep", "innoxia_sheep_eye"),
        new("Snake", "NoStepOnSnek_snake_eye"),
        new("Spider", "charisma_spider_eye"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<int> EyePairs { get; }
    public XmlAttribute<string> IrisShape { get; }
    public XmlAttribute<string> PupilShape { get; }
    public XmlAttribute<string> Type { get; }
    
    public Eye(XElement eyeNode)
    {
        EyePairs = new XmlAttribute<int>(eyeNode.Attribute("eyePairs")!);
        IrisShape = new XmlAttribute<string>(eyeNode.Attribute("irisShape")!);
        PupilShape = new XmlAttribute<string>(eyeNode.Attribute("pupilShape")!);
        Type = new XmlAttribute<string>(eyeNode.Attribute("type")!);

        PupilShapes = IrisShapes;
    }
}