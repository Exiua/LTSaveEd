using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

public class Hair
{
    private ValueDisplayPair[] _availableHairStyles = [];
    private bool _initalized;
    
    private ValueDisplayPair[] HairStylesB { get;}
    private ValueDisplayPair[] HairStylesVS { get;}
    private ValueDisplayPair[] HairStylesS { get; }
    private ValueDisplayPair[] HairStylesSL { get;}
    private ValueDisplayPair[] HairStylesL { get;}

    private ValueDisplayPair[] HairStylesFL { get; } =
    [
        new ValueDisplayPair("Natural", "NONE"), new ValueDisplayPair("Messy", "MESSY"),
        new ValueDisplayPair("Loose", "LOOSE"), new ValueDisplayPair("Curly", "CURLY"),
        new ValueDisplayPair("Straight", "STRAIGHT"), new ValueDisplayPair("Slicked-back", "SLICKED_BACK"),
        new ValueDisplayPair("Sidecut", "SIDECUT"), new ValueDisplayPair("Mohawk", "MOHAWK"),
        new ValueDisplayPair("Dreadlocks", "DREADLOCKS"), new ValueDisplayPair("Afro", "AFRO"),
        new ValueDisplayPair("Topknot", "TOPKNOT"), new ValueDisplayPair("Pixie-cut", "PIXIE_CUT"),
        new ValueDisplayPair("Bun", "BUN"), new ValueDisplayPair("Bob-cut", "BOB_CUT"),
        new ValueDisplayPair("Chonmage", "CHONMAGE"), new ValueDisplayPair("Wavy", "WAVY"),
        new ValueDisplayPair("Ponytail", "PONYTAIL"), new ValueDisplayPair("Low ponytail", "LOW_PONYTAIL"),
        new ValueDisplayPair("Twintails", "TWINTAILS"), new ValueDisplayPair("Chignon", "CHIGNON"),
        new ValueDisplayPair("Braided", "BRAIDED"), new ValueDisplayPair("Twin braids", "TWIN_BRAIDS"),
        new ValueDisplayPair("Crown braid", "CROWN_BRAID"), new ValueDisplayPair("Drill hair", "DRILL_HAIR"),
        new ValueDisplayPair("Hime-cut", "HIME_CUT"), new ValueDisplayPair("Bird cage", "BIRD_CAGE")
    ];
    
    public ValueDisplayPair[] HairTypes { get; } =
    [
        new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair("Angel", "ANGEL"),
        new ValueDisplayPair("Badger", "innoxia_badger_hair"), new ValueDisplayPair("Bat", "BAT_MORPH"),
        new ValueDisplayPair("Bear", "dsg_bear_hair"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_hair"),
        new ValueDisplayPair("Cat", "CAT_MORPH"),
        new ValueDisplayPair("Cat (sidefluff)", "CAT_MORPH_SIDEFLUFF"),
        new ValueDisplayPair("Cow", "COW_MORPH"), new ValueDisplayPair("Demonic", "DEMON"),
        new ValueDisplayPair("Deer", "innoxia_deer_hair"),
        new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon head feathers", "dsg_dragon_hairFeathers"),
        new ValueDisplayPair("Dragon mane", "dsg_dragon_hairMane"),
        new ValueDisplayPair("Dragon", "dsg_dragon_hair"), new ValueDisplayPair("Ferret", "dsg_ferret_hair"),
        new ValueDisplayPair("Fox", "FOX_MORPH"), new ValueDisplayPair("Goat", "innoxia_goat_hair"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_hair"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_hair"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_hair"),
        new ValueDisplayPair("Otter", "dsg_otter_hair"),
        new ValueDisplayPair("Panther", "innoxia_panther_hair"),
        new ValueDisplayPair("Pig", "innoxia_pig_hair"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_hair"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_hair"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_hair"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_hair"),
        new ValueDisplayPair("Spider", "charisma_spider_hair"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<string> HairStyle { get; }
    public LabeledXmlAttribute<int> Length { get; }
    public XmlAttribute<string> Type { get; }
    public XmlAttribute<bool> NeckFluff { get; }

    public ValueDisplayPair[] AvailableHairStyles
    {
        get
        {
            if (!_initalized)
            {
                return _availableHairStyles;
            }
            
            return Length.Value switch
            {
                < 4 => HairStylesB,
                < 11 => HairStylesVS,
                < 22 => HairStylesS,
                < 45 => HairStylesSL,
                < 265 => HairStylesL,
                _ => HairStylesFL
            };
        }
    }
    
    
    public Hair(XElement hairNode)
    {
        HairStyle = new XmlAttribute<string>(hairNode.Attribute("hairStyle")!);
        Length = new LabeledXmlAttribute<int>(hairNode.Attribute("length")!, GetHairLengthLabel);
        Type = new XmlAttribute<string>(hairNode.Attribute("type")!);
        NeckFluff = new XmlAttribute<bool>(hairNode.Attribute("neckFluff")!);
        HairStylesL = HairStylesFL[..25];
        HairStylesSL = HairStylesFL[..19];
        HairStylesS = HairStylesFL.Take(10).Concat(HairStylesFL.Skip(11).Take(1)).ToArray(); // 0-9 and 11
        HairStylesVS = HairStylesFL.Take(6).Concat(HairStylesFL.Skip(9).Take(1)).ToArray(); // 0-6 and 9
        HairStylesB = HairStylesFL[..1];
        _initalized = true;
    }

    private static string GetHairLengthLabel(int value)
    {
        return value switch
        {
            < 4 => "Bald",
            >= 4 and < 11 => "Very Short",
            >= 11 and < 22 => "Short",
            >= 22 and < 45 => "Shoulder-length",
            >= 45 and < 80 => "Long",
            >= 80 and < 140 => "Very Long",
            >= 140 and < 265 => "Incredibly Long",
            >= 265 => "Floor-length"
        };
    }
}