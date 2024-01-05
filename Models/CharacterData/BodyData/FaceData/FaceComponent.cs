using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

/// <summary>
///     Class models the face node of the character's body data. Part of the <see cref="Face" /> model.
/// </summary>
/// <param name="faceNode">XElement of the face node</param>
public class FaceComponent(XElement faceNode)
{
    public static ValueDisplayPair<string>[] FacialHairTypes => Collections.HairTypes;

    public ValueDisplayPair<string>[] FaceTypes { get; } =
    [
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_face"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_face"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_face"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"), new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Coatl", "dsg_dragon_faceCoatl"),
        new ValueDisplayPair<string>("Ryu", "dsg_dragon_faceRyu"), new ValueDisplayPair<string>("Dragon", "dsg_dragon_face"),
        new ValueDisplayPair<string>("Ferret", "dsg_ferret_face"), new ValueDisplayPair<string>("Fox", "FOX_MORPH"),
        new ValueDisplayPair<string>("Goat", "innoxia_goat_face"), new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_face"),
        new ValueDisplayPair<string>("Harpy", "HARPY"), new ValueDisplayPair<string>("Horse", "HORSE_MORPH"),
        new ValueDisplayPair<string>("Human", "HUMAN"), new ValueDisplayPair<string>("Hyena", "innoxia_hyena_face"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_face"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_face"),
        new ValueDisplayPair<string>("Panther", "innoxia_panther_face"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_face"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_face"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_face"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_face"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_face"),
        new ValueDisplayPair<string>("Hooded Snake", "NoStepOnSnek_snake_face_h"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_face"),
        new ValueDisplayPair<string>("Furred Spider", "charisma_spider_faceFluffy"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<string> FacialHair { get; } = new(faceNode.Attribute("facialHair")!);
    public XmlAttribute<bool> PiercedNose { get; } = new(faceNode.Attribute("piercedNose")!);
    public XmlAttribute<string> Type { get; } = new(faceNode.Attribute("type")!);
}