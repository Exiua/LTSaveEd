using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.HeadData;

public class Hair
{
    private readonly ValueDisplayPair<string>[] _availableHairStyles = [];
    private readonly bool _initialized;
    
    private ValueDisplayPair<string>[] HairStylesB { get;}
    private ValueDisplayPair<string>[] HairStylesVS { get;}
    private ValueDisplayPair<string>[] HairStylesS { get; }
    private ValueDisplayPair<string>[] HairStylesSL { get;}
    private ValueDisplayPair<string>[] HairStylesL { get;}

    private ValueDisplayPair<string>[] HairStylesFL { get; } =
    [
        new("Natural", "NONE"), new("Messy", "MESSY"),
        new("Loose", "LOOSE"), new("Curly", "CURLY"),
        new("Straight", "STRAIGHT"), new("Slicked-back", "SLICKED_BACK"),
        new("Sidecut", "SIDECUT"), new("Mohawk", "MOHAWK"),
        new("Dreadlocks", "DREADLOCKS"), new("Afro", "AFRO"),
        new("Topknot", "TOPKNOT"), new("Pixie-cut", "PIXIE_CUT"),
        new("Bun", "BUN"), new("Bob-cut", "BOB_CUT"),
        new("Chonmage", "CHONMAGE"), new("Wavy", "WAVY"),
        new("Ponytail", "PONYTAIL"), new("Low ponytail", "LOW_PONYTAIL"),
        new("Twintails", "TWINTAILS"), new("Chignon", "CHIGNON"),
        new("Braided", "BRAIDED"), new("Twin braids", "TWIN_BRAIDS"),
        new("Crown braid", "CROWN_BRAID"), new("Drill hair", "DRILL_HAIR"),
        new("Hime-cut", "HIME_CUT"), new("Bird cage", "BIRD_CAGE")
    ];
    
    public ValueDisplayPair<string>[] HairTypes { get; } =
    [
        new("Alligator", "ALLIGATOR_MORPH"), new("Angel", "ANGEL"),
        new("Badger", "innoxia_badger_hair"), new("Bat", "BAT_MORPH"),
        new("Bear", "dsg_bear_hair"),
        new("Capybara", "NoStepOnSnek_capybara_hair"),
        new("Cat", "CAT_MORPH"),
        new("Cat (sidefluff)", "CAT_MORPH_SIDEFLUFF"),
        new("Cow", "COW_MORPH"), new("Demonic", "DEMON"),
        new("Deer", "innoxia_deer_hair"),
        new("Dog", "DOG_MORPH"),
        new("Dragon head feathers", "dsg_dragon_hairFeathers"),
        new("Dragon mane", "dsg_dragon_hairMane"),
        new("Dragon", "dsg_dragon_hair"), new("Ferret", "dsg_ferret_hair"),
        new("Fox", "FOX_MORPH"), new("Goat", "innoxia_goat_hair"),
        new("Gryphon", "dsg_gryphon_hair"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Human", "HUMAN"),
        new("Hyena", "innoxia_hyena_hair"),
        new("Octopus", "NoStepOnSnek_octopus_hair"),
        new("Otter", "dsg_otter_hair"),
        new("Panther", "innoxia_panther_hair"),
        new("Pig", "innoxia_pig_hair"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_hair"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_hair"),
        new("Sheep", "innoxia_sheep_hair"),
        new("Snake", "NoStepOnSnek_snake_hair"),
        new("Spider", "charisma_spider_hair"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<string> HairStyle { get; }
    public LabeledXmlAttribute<int> Length { get; }
    public XmlAttribute<string> Type { get; }
    public XmlAttribute<bool> NeckFluff { get; }

    public ValueDisplayPair<string>[] AvailableHairStyles
    {
        get
        {
            if (!_initialized)
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
        _initialized = true;
    }

    /// <summary>
    ///     Returns the label for the hair length.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetHairLengthLabel(int value)
    {
        return value switch
        {
            < 4 => "Bald",
            < 11 => "Very Short",
            < 22 => "Short",
            < 45 => "Shoulder-length",
            < 80 => "Long",
            < 140 => "Very Long",
            < 265 => "Incredibly Long",
            >= 265 => "Floor-length"
        };
    }
}