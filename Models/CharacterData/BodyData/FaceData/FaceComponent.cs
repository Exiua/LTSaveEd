using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

public class FaceComponent(XElement faceNode)
{
    public ValueDisplayPair[] FacialHairTypes => Collections.HairTypes;
    
    public ValueDisplayPair[] FaceTypes =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_face"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_face"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_face"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Coatl", "dsg_dragon_faceCoatl"),
        new ValueDisplayPair("Ryu", "dsg_dragon_faceRyu"), new ValueDisplayPair("Dragon", "dsg_dragon_face"),
        new ValueDisplayPair("Ferret", "dsg_ferret_face"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_face"), new ValueDisplayPair("Gryphon", "dsg_gryphon_face"),
        new ValueDisplayPair("Harpy", "HARPY"), new ValueDisplayPair("Horse", "HORSE_MORPH"),
        new ValueDisplayPair("Human", "HUMAN"), new ValueDisplayPair("Hyena", "innoxia_hyena_face"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_face"),
        new ValueDisplayPair("Otter", "dsg_otter_face"),
        new ValueDisplayPair("Panther", "innoxia_panther_face"),
        new ValueDisplayPair("Pig", "innoxia_pig_face"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_face"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_face"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_face"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_face"),
        new ValueDisplayPair("Hooded Snake", "NoStepOnSnek_snake_face_h"),
        new ValueDisplayPair("Spider", "charisma_spider_face"),
        new ValueDisplayPair("Furred Spider", "charisma_spider_faceFluffy"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<string> FacialHair { get; } = new(faceNode.Attribute("facialHair")!);
    public XmlAttribute<bool> PiercedNose { get; } = new(faceNode.Attribute("piercedNose")!);
    public XmlAttribute<string> Type { get; } = new(faceNode.Attribute("type")!);

}