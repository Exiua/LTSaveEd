using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.TorsoData;

public class TorsoComponent(XElement torsoNode)
{
    public ValueDisplayPair<string>[] TorsoTypes { get; } = [
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_torso"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_torso"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_torso"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"), new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Ryu", "dsg_dragon_torsoRyu"), new ValueDisplayPair<string>("Dragon", "dsg_dragon_torso"),
        new ValueDisplayPair<string>("Ferret", "dsg_ferret_torso"), new ValueDisplayPair<string>("Fox", "FOX_MORPH"),
        new ValueDisplayPair<string>("Goat", "innoxia_goat_torso"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_torso"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "HORSE_MORPH"), new ValueDisplayPair<string>("Human", "HUMAN"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_torso"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_torso"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_torso"),
        new ValueDisplayPair<string>("Panther", "innoxia_panther_torso"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_torso"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_torso"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_torso"),
        new ValueDisplayPair<string>("Shark finned", "dsg_shark_torsoDorsalFin"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_torso"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_torso"),
        new ValueDisplayPair<string>("Furred Spider", "charisma_spider_torsoFluffy"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_torso"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")];

    public XmlAttribute<string> Type { get; } = new(torsoNode.Attribute("type")!);

}