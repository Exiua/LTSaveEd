using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class TorsoComponent(XElement torsoNode)
{
    public ValueDisplayPair[] TorsoTypes { get; } = [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_torso"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_torso"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_torso"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Ryu", "dsg_dragon_torsoRyu"), new ValueDisplayPair("Dragon", "dsg_dragon_torso"),
        new ValueDisplayPair("Ferret", "dsg_ferret_torso"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_torso"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_torso"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_torso"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_torso"),
        new ValueDisplayPair("Otter", "dsg_otter_torso"),
        new ValueDisplayPair("Panther", "innoxia_panther_torso"),
        new ValueDisplayPair("Pig", "innoxia_pig_torso"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_torso"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_torso"),
        new ValueDisplayPair("Shark finned", "dsg_shark_torsoDorsalFin"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_torso"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_torso"),
        new ValueDisplayPair("Furred Spider", "charisma_spider_torsoFluffy"),
        new ValueDisplayPair("Spider", "charisma_spider_torso"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")];

    public XmlAttribute<string> Type { get; } = new(torsoNode.Attribute("type")!);

}