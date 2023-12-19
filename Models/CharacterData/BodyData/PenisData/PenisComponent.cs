using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

public class PenisComponent
{
    public ValueDisplayPair[] PenisTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"),
        new ValueDisplayPair("Angel", "ANGEL"), new ValueDisplayPair("Badger", "innoxia_badger_penis"),
        new ValueDisplayPair("Bat", "BAT_MORPH"), new ValueDisplayPair("Bear", "dsg_bear_penis"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_penis"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_penis"), new ValueDisplayPair("Ferret", "dsg_ferret_penis"),
        new ValueDisplayPair("Fox", "FOX_MORPH"), new ValueDisplayPair("Goat", "innoxia_goat_penis"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_penis"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "EQUINE"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_penis"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_penis"),
        new ValueDisplayPair("Otter", "dsg_otter_penis"),
        new ValueDisplayPair("Panther", "innoxia_panther_penis"),
        new ValueDisplayPair("Pig", "innoxia_pig_penis"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_penis"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_penis"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_penis"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_penis"),
        new ValueDisplayPair("Spider", "charisma_spider_penis"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public LabeledXmlAttribute<float> Capacity { get; }
    public LabeledXmlAttribute<int> Depth { get; }
    public LabeledXmlAttribute<int> Elasticity { get; }
    public LabeledXmlAttribute<int> Girth { get; }
    public LabeledXmlAttribute<int> Plasticity { get; }
    public LabeledXmlAttribute<int> Size { get; }
    public LabeledXmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<string> Type { get; }
    public XmlAttribute<bool> Pierced { get; }
    public XmlAttribute<bool> UrethraVirgin { get; }
    public XmlAttribute<bool> Virgin { get; }

    #region Penis Modifiers

    public BodyComponentModifier Sheathed { get; }
    public BodyComponentModifier Ribbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier Knotted { get; }
    public BodyComponentModifier Blunt { get; }
    private BodyComponentModifier Tapered { get; }
    private BodyComponentModifier Flared { get; }
    public BodyComponentModifier Barbed { get; }
    public BodyComponentModifier Veiny { get; }
    public BodyComponentModifier Prehensile { get; }
    public BodyComponentModifier Ovipositor { get; }

    public bool IsFlared
    {
        get => Flared.Exists;
        set
        {
            if (value)
            {
                Tapered.Exists = false;
            }
            Flared.Exists = value;
        }
    }

    public bool IsTapered
    {
        get => Tapered.Exists;
        set
        {
            if (value)
            {
                Flared.Exists = false;
            }
            Tapered.Exists = value;
        }
    }
    
    #endregion

    #region Urethra Modifiers

    public BodyComponentModifier Puffy { get; }
    public BodyComponentModifier InternallyRibbed { get; }
    public BodyComponentModifier UrethraTentacled { get; }
    public BodyComponentModifier InternallyMuscled { get; }

    #endregion
    
    public PenisComponent(XElement penisNode)
    {
        Capacity = new LabeledXmlAttribute<float>(penisNode.Attribute("capacity")!, Collections.GetCapacityLabel);
        Depth = new LabeledXmlAttribute<int>(penisNode.Attribute("depth")!, Collections.GetDepthLabel);
        Elasticity = new LabeledXmlAttribute<int>(penisNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
        Girth = new LabeledXmlAttribute<int>(penisNode.Attribute("girth")!, Collections.GetPenisClitGirthLabel);
        Plasticity = new LabeledXmlAttribute<int>(penisNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
        Size = new LabeledXmlAttribute<int>(penisNode.Attribute("size")!, GetPenisSizeLabel);
        StretchedCapacity = new LabeledXmlAttribute<float>(penisNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
        Type = new XmlAttribute<string>(penisNode.Attribute("type")!);
        Pierced = new XmlAttribute<bool>(penisNode.Attribute("pierced")!);
        UrethraVirgin = new XmlAttribute<bool>(penisNode.Attribute("urethraVirgin")!);
        Virgin = new XmlAttribute<bool>(penisNode.Attribute("virgin")!);
        
        var penisModifiersNode = penisNode.Element("penisModifiers")!;
        Sheathed = new BodyComponentModifier(penisModifiersNode, "SHEATHED");
        Ribbed = new BodyComponentModifier(penisModifiersNode, "RIBBED");
        Tentacled = new BodyComponentModifier(penisModifiersNode, "TENTACLED");
        Knotted = new BodyComponentModifier(penisModifiersNode, "KNOTTED");
        Blunt = new BodyComponentModifier(penisModifiersNode, "BLUNT");
        Tapered = new BodyComponentModifier(penisModifiersNode, "TAPERED");
        Flared = new BodyComponentModifier(penisModifiersNode, "FLARED");
        Barbed = new BodyComponentModifier(penisModifiersNode, "BARBED");
        Veiny = new BodyComponentModifier(penisModifiersNode, "VEINY");
        Prehensile = new BodyComponentModifier(penisModifiersNode, "PREHENSILE");
        Ovipositor = new BodyComponentModifier(penisModifiersNode, "OVIPOSITOR");

        var urethraModifiersNode = penisNode.Element("urethraModifiers")!;
        Puffy = new BodyComponentModifier(urethraModifiersNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(urethraModifiersNode, "RIBBED");
        UrethraTentacled = new BodyComponentModifier(urethraModifiersNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(urethraModifiersNode, "MUSCLE_CONTROL");
        
        var modifiers = penisModifiersNode.Attributes();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Name.LocalName)
            {
                case "SHEATHED":
                    Sheathed.Initialize(modifier);
                    break;
                case "RIBBED":
                    Ribbed.Initialize(modifier);
                    break;
                case "TENTACLED":
                    Tentacled.Initialize(modifier);
                    break;
                case "KNOTTED":
                    Knotted.Initialize(modifier);
                    break;
                case "BLUNT":
                    Blunt.Initialize(modifier);
                    break;
                case "TAPERED":
                    Tapered.Initialize(modifier);
                    break;
                case "FLARED":
                    Flared.Initialize(modifier);
                    break;
                case "BARBED":
                    Barbed.Initialize(modifier);
                    break;
                case "VEINY":
                    Veiny.Initialize(modifier);
                    break;
                case "PREHENSILE":
                    Prehensile.Initialize(modifier);
                    break;
                case "OVIPOSITOR":
                    Ovipositor.Initialize(modifier);
                    break;
            }
        }
        
        modifiers = urethraModifiersNode.Attributes();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Name.LocalName)
            {
                case "PUFFY":
                    Puffy.Initialize(modifier);
                    break;
                case "RIBBED":
                    InternallyRibbed.Initialize(modifier);
                    break;
                case "TENTACLED":
                    UrethraTentacled.Initialize(modifier);
                    break;
                case "MUSCLE_CONTROL":
                    InternallyMuscled.Initialize(modifier);
                    break;
            }
        }
    }

    private static string GetPenisSizeLabel(int value)
    {
        return value switch
        {
            < 5 => "Tiny",
            >= 5 and < 10 => "Small",
            >= 10 and < 20 => "Average-sized",
            >= 20 and < 30 => "Large",
            >= 30 and < 40 => "Huge",
            >= 40 and < 50 => "Enormous",
            >= 50 and < 60 => "Gigantic",
            >= 60 => "Stallion-sized"
        };
    }
}