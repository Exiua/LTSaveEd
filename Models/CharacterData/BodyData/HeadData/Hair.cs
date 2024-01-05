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
        new ValueDisplayPair<string>("Natural", "NONE"), new ValueDisplayPair<string>("Messy", "MESSY"),
        new ValueDisplayPair<string>("Loose", "LOOSE"), new ValueDisplayPair<string>("Curly", "CURLY"),
        new ValueDisplayPair<string>("Straight", "STRAIGHT"), new ValueDisplayPair<string>("Slicked-back", "SLICKED_BACK"),
        new ValueDisplayPair<string>("Sidecut", "SIDECUT"), new ValueDisplayPair<string>("Mohawk", "MOHAWK"),
        new ValueDisplayPair<string>("Dreadlocks", "DREADLOCKS"), new ValueDisplayPair<string>("Afro", "AFRO"),
        new ValueDisplayPair<string>("Topknot", "TOPKNOT"), new ValueDisplayPair<string>("Pixie-cut", "PIXIE_CUT"),
        new ValueDisplayPair<string>("Bun", "BUN"), new ValueDisplayPair<string>("Bob-cut", "BOB_CUT"),
        new ValueDisplayPair<string>("Chonmage", "CHONMAGE"), new ValueDisplayPair<string>("Wavy", "WAVY"),
        new ValueDisplayPair<string>("Ponytail", "PONYTAIL"), new ValueDisplayPair<string>("Low ponytail", "LOW_PONYTAIL"),
        new ValueDisplayPair<string>("Twintails", "TWINTAILS"), new ValueDisplayPair<string>("Chignon", "CHIGNON"),
        new ValueDisplayPair<string>("Braided", "BRAIDED"), new ValueDisplayPair<string>("Twin braids", "TWIN_BRAIDS"),
        new ValueDisplayPair<string>("Crown braid", "CROWN_BRAID"), new ValueDisplayPair<string>("Drill hair", "DRILL_HAIR"),
        new ValueDisplayPair<string>("Hime-cut", "HIME_CUT"), new ValueDisplayPair<string>("Bird cage", "BIRD_CAGE")
    ];
    
    public ValueDisplayPair<string>[] HairTypes { get; } =
    [
        new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"), new ValueDisplayPair<string>("Angel", "ANGEL"),
        new ValueDisplayPair<string>("Badger", "innoxia_badger_hair"), new ValueDisplayPair<string>("Bat", "BAT_MORPH"),
        new ValueDisplayPair<string>("Bear", "dsg_bear_hair"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_hair"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"),
        new ValueDisplayPair<string>("Cat (sidefluff)", "CAT_MORPH_SIDEFLUFF"),
        new ValueDisplayPair<string>("Cow", "COW_MORPH"), new ValueDisplayPair<string>("Demonic", "DEMON"),
        new ValueDisplayPair<string>("Deer", "innoxia_deer_hair"),
        new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Dragon head feathers", "dsg_dragon_hairFeathers"),
        new ValueDisplayPair<string>("Dragon mane", "dsg_dragon_hairMane"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_hair"), new ValueDisplayPair<string>("Ferret", "dsg_ferret_hair"),
        new ValueDisplayPair<string>("Fox", "FOX_MORPH"), new ValueDisplayPair<string>("Goat", "innoxia_goat_hair"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_hair"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "HORSE_MORPH"), new ValueDisplayPair<string>("Human", "HUMAN"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_hair"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_hair"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_hair"),
        new ValueDisplayPair<string>("Panther", "innoxia_panther_hair"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_hair"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_hair"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_hair"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_hair"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_hair"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_hair"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
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