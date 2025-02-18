using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class TorsoComponent(XElement torsoNode)
{
    public ValueDisplayPair<string>[] TorsoTypes { get; } = [
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_torso"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_torso"),
        new("Capybara", "NoStepOnSnek_capybara_torso"),
        new("Cat", "CAT_MORPH"), new("Cow", "COW_MORPH"),
        new("Demonic", "DEMON_COMMON"), new("Dog", "DOG_MORPH"),
        new("Ryu", "dsg_dragon_torsoRyu"), new("Dragon", "dsg_dragon_torso"),
        new("Ferret", "dsg_ferret_torso"), new("Fox", "FOX_MORPH"),
        new("Goat", "innoxia_goat_torso"),
        new("Gryphon", "dsg_gryphon_torso"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Human", "HUMAN"),
        new("Hyena", "innoxia_hyena_torso"),
        new("Octopus", "NoStepOnSnek_octopus_torso"),
        new("Otter", "dsg_otter_torso"),
        new("Panther", "innoxia_panther_torso"),
        new("Pig", "innoxia_pig_torso"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_torso"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_torso"),
        new("Shark finned", "dsg_shark_torsoDorsalFin"),
        new("Sheep", "innoxia_sheep_torso"),
        new("Snake", "NoStepOnSnek_snake_torso"),
        new("Furred Spider", "charisma_spider_torsoFluffy"),
        new("Spider", "charisma_spider_torso"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")];

    public XmlAttribute<string> Type { get; } = new(torsoNode.Attribute("type")!);

}