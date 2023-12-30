using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

/// <summary>
///     Class models the eye node of the character's body data. Part of the <see cref="Face" /> model.
/// </summary>
public class Eye
{
    public ValueDisplayPair[] IrisShapes { get; } =
    [
        new ValueDisplayPair("Round", "ROUND"), new ValueDisplayPair("Horizontal", "HORIZONTAL"),
        new ValueDisplayPair("Vertical", "VERTICAL"), new ValueDisplayPair("Heart-shaped", "HEART"),
        new ValueDisplayPair("Star-shaped", "STAR")
    ];

    public ValueDisplayPair[] PupilShapes { get; }

    public ValueDisplayPair[] EyeTypes { get; } =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_eye"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_eye"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_eye"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Deer", "innoxia_deer_eye"),
        new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_eye"), new ValueDisplayPair("Ferret", "dsg_ferret_eye"),
        new ValueDisplayPair("Fox", "FOX_MORPH"), new ValueDisplayPair("Goat", "innoxia_goat_eye"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_eye"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_eye"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_eye"),
        new ValueDisplayPair("Otter", "dsg_otter_eye"), new ValueDisplayPair("Panther", "innoxia_panther_eye"),
        new ValueDisplayPair("Pig", "innoxia_pig_eye"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_eye"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_eye"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_eye"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_eye"),
        new ValueDisplayPair("Spider", "charisma_spider_eye"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
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