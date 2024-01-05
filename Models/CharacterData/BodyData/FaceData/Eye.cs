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
        new ValueDisplayPair<string>("Round", "ROUND"), new ValueDisplayPair<string>("Horizontal", "HORIZONTAL"),
        new ValueDisplayPair<string>("Vertical", "VERTICAL"), new ValueDisplayPair<string>("Heart-shaped", "HEART"),
        new ValueDisplayPair<string>("Star-shaped", "STAR")
    ];

    public ValueDisplayPair<string>[] PupilShapes { get; }

    public ValueDisplayPair<string>[] EyeTypes { get; } =
    [
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_eye"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_eye"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_eye"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"), new ValueDisplayPair<string>("Deer", "innoxia_deer_eye"),
        new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_eye"), new ValueDisplayPair<string>("Ferret", "dsg_ferret_eye"),
        new ValueDisplayPair<string>("Fox", "FOX_MORPH"), new ValueDisplayPair<string>("Goat", "innoxia_goat_eye"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_eye"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "HORSE_MORPH"), new ValueDisplayPair<string>("Human", "HUMAN"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_eye"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_eye"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_eye"), new ValueDisplayPair<string>("Panther", "innoxia_panther_eye"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_eye"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_eye"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_eye"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_eye"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_eye"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_eye"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
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