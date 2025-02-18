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
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_face"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_face"),
        new("Capybara", "NoStepOnSnek_capybara_face"),
        new("Cat", "CAT_MORPH"), new("Cow", "COW_MORPH"),
        new("Demonic", "DEMON_COMMON"), new("Dog", "DOG_MORPH"),
        new("Coatl", "dsg_dragon_faceCoatl"),
        new("Ryu", "dsg_dragon_faceRyu"), new("Dragon", "dsg_dragon_face"),
        new("Ferret", "dsg_ferret_face"), new("Fox", "FOX_MORPH"),
        new("Goat", "innoxia_goat_face"), new("Gryphon", "dsg_gryphon_face"),
        new("Harpy", "HARPY"), new("Horse", "HORSE_MORPH"),
        new("Human", "HUMAN"), new("Hyena", "innoxia_hyena_face"),
        new("Octopus", "NoStepOnSnek_octopus_face"),
        new("Otter", "dsg_otter_face"),
        new("Panther", "innoxia_panther_face"),
        new("Pig", "innoxia_pig_face"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_face"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_face"),
        new("Sheep", "innoxia_sheep_face"),
        new("Snake", "NoStepOnSnek_snake_face"),
        new("Hooded Snake", "NoStepOnSnek_snake_face_h"),
        new("Spider", "charisma_spider_face"),
        new("Furred Spider", "charisma_spider_faceFluffy"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<string> FacialHair { get; } = new(faceNode.Attribute("facialHair")!);
    public XmlAttribute<bool> PiercedNose { get; } = new(faceNode.Attribute("piercedNose")!);
    public XmlAttribute<string> Type { get; } = new(faceNode.Attribute("type")!);
}