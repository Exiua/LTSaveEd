using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.VaginaData;

public class VaginaComponent
{
    public ValueDisplayPair[] VaginaTypes { get; } =
    [
        new ValueDisplayPair("None", "NONE"), new ValueDisplayPair("Alligator", "ALLIGATOR_MORPH"),
        new ValueDisplayPair("Angel", "ANGEL"), new ValueDisplayPair("Badger", "innoxia_badger_vagina"),
        new ValueDisplayPair("Bat", "BAT_MORPH"), new ValueDisplayPair("Bear", "dsg_bear_vagina"),
        new ValueDisplayPair("Capybara", "NoStepOnSnek_capybara_vagina"),
        new ValueDisplayPair("Cat", "CAT_MORPH"), new ValueDisplayPair("Cow", "COW_MORPH"),
        new ValueDisplayPair("Demonic", "DEMON_COMMON"), new ValueDisplayPair("Dog", "DOG_MORPH"),
        new ValueDisplayPair("Dragon", "dsg_dragon_vagina"),
        new ValueDisplayPair("Ferret", "dsg_ferret_vagina"), new ValueDisplayPair("Fox", "FOX_MORPH"),
        new ValueDisplayPair("Goat", "innoxia_goat_vagina"),
        new ValueDisplayPair("Gryphon", "dsg_gryphon_vagina"), new ValueDisplayPair("Harpy", "HARPY"),
        new ValueDisplayPair("Horse", "HORSE_MORPH"), new ValueDisplayPair("Human", "HUMAN"),
        new ValueDisplayPair("Hyena", "innoxia_hyena_vagina"),
        new ValueDisplayPair("Octopus", "NoStepOnSnek_octopus_vagina"),
        new ValueDisplayPair("Otter", "dsg_otter_vagina"),
        new ValueDisplayPair("Panther", "innoxia_panther_vagina"),
        new ValueDisplayPair("Pig", "innoxia_pig_vagina"), new ValueDisplayPair("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair("Racoon", "dsg_raccoon_vagina"), new ValueDisplayPair("Rat", "RAT_MORPH"),
        new ValueDisplayPair("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair("Shark", "dsg_shark_vagina"),
        new ValueDisplayPair("Sheep", "innoxia_sheep_vagina"),
        new ValueDisplayPair("Snake", "NoStepOnSnek_snake_vagina"),
        new ValueDisplayPair("Spider", "charisma_spider_vagina"),
        new ValueDisplayPair("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair("Wolf", "WOLF_MORPH")
    ];

    public XmlAttribute<float> Capacity { get; }
    public XmlAttribute<int> ClitGirth { get; }
    public XmlAttribute<int> ClitSize { get; }
    public XmlAttribute<int> Depth { get; }
    public XmlAttribute<int> Elasticity { get; }
    public XmlAttribute<int> LabiaSize { get; }
    public XmlAttribute<int> Plasticity { get; }
    public XmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<float> UrethraCapacity { get; }
    public XmlAttribute<int> UrethraDepth { get; }
    public XmlAttribute<int> UrethraElasticity { get; }
    public XmlAttribute<int> UrethraPlasticity { get; }
    public XmlAttribute<int> UrethraStretchedCapacity { get; }
    public XmlAttribute<int> Wetness { get; }
    public XmlAttribute<string> Type { get; }
    public XmlAttribute<bool> EggLayer { get; }
    public XmlAttribute<bool> Hymen { get; }
    public XmlAttribute<bool> Pierced { get; }
    public XmlAttribute<bool> Squirter { get; }
    public XmlAttribute<bool> UrethraVirgin { get; }
    public XmlAttribute<bool> Virgin { get; }

    #region Vagina Modifiers

    public BodyComponentModifier Puffy { get; }
    public BodyComponentModifier InternallyRibbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier InternallyMuscled { get; }

    #endregion

    #region Clitoris Modifiers

    public BodyComponentModifier Sheathed { get; }
    public BodyComponentModifier Ribbed { get; }
    public BodyComponentModifier ClitTentacled { get; }
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

    public BodyComponentModifier UrethraPuffy { get; }
    public BodyComponentModifier UrethraInternallyRibbed { get; }
    public BodyComponentModifier UrethraTentacled { get; }
    public BodyComponentModifier UrethraInternallyMuscled { get; }

    #endregion

    public VaginaComponent(XElement vaginaNode)
    {
        Capacity = new XmlAttribute<float>(vaginaNode.Attribute("capacity")!);
        ClitGirth = new XmlAttribute<int>(vaginaNode.Attribute("clitGirth")!);
        ClitSize = new XmlAttribute<int>(vaginaNode.Attribute("clitSize")!);
        Depth = new XmlAttribute<int>(vaginaNode.Attribute("depth")!);
        Elasticity = new XmlAttribute<int>(vaginaNode.Attribute("elasticity")!);
        LabiaSize = new XmlAttribute<int>(vaginaNode.Attribute("labiaSize")!);
        Plasticity = new XmlAttribute<int>(vaginaNode.Attribute("plasticity")!);
        StretchedCapacity = new XmlAttribute<float>(vaginaNode.Attribute("stretchedCapacity")!);
        UrethraCapacity = new XmlAttribute<float>(vaginaNode.Attribute("urethraCapacity")!);
        UrethraDepth = new XmlAttribute<int>(vaginaNode.Attribute("urethraDepth")!);
        UrethraElasticity = new XmlAttribute<int>(vaginaNode.Attribute("urethraElasticity")!);
        UrethraPlasticity = new XmlAttribute<int>(vaginaNode.Attribute("urethraPlasticity")!);
        UrethraStretchedCapacity = new XmlAttribute<int>(vaginaNode.Attribute("urethraStretchedCapacity")!);
        Wetness = new XmlAttribute<int>(vaginaNode.Attribute("wetness")!);
        Type = new XmlAttribute<string>(vaginaNode.Attribute("type")!);
        EggLayer = new XmlAttribute<bool>(vaginaNode.Attribute("eggLayer")!);
        Hymen = new XmlAttribute<bool>(vaginaNode.Attribute("hymen")!);
        Pierced = new XmlAttribute<bool>(vaginaNode.Attribute("pierced")!);
        Squirter = new XmlAttribute<bool>(vaginaNode.Attribute("squirter")!);
        UrethraVirgin = new XmlAttribute<bool>(vaginaNode.Attribute("urethraVirgin")!);
        Virgin = new XmlAttribute<bool>(vaginaNode.Attribute("virgin")!);
            
        var vaginaModifiersNode = vaginaNode.Element("vaginaModifiers")!;
        Puffy = new BodyComponentModifier(vaginaModifiersNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(vaginaModifiersNode, "RIBBED");
        Tentacled = new BodyComponentModifier(vaginaModifiersNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(vaginaModifiersNode, "MUSCLE_CONTROL");
        
        var clitModifiersNode = vaginaNode.Element("clitModifiers")!;
        Sheathed = new BodyComponentModifier(clitModifiersNode, "SHEATHED");
        Ribbed = new BodyComponentModifier(clitModifiersNode, "RIBBED");
        ClitTentacled = new BodyComponentModifier(clitModifiersNode, "TENTACLED");
        Knotted = new BodyComponentModifier(clitModifiersNode, "KNOTTED");
        Blunt = new BodyComponentModifier(clitModifiersNode, "BLUNT");
        Tapered = new BodyComponentModifier(clitModifiersNode, "TAPERED");
        Flared = new BodyComponentModifier(clitModifiersNode, "FLARED");
        Barbed = new BodyComponentModifier(clitModifiersNode, "BARBED");
        Veiny = new BodyComponentModifier(clitModifiersNode, "VEINY");
        Prehensile = new BodyComponentModifier(clitModifiersNode, "PREHENSILE");
        Ovipositor = new BodyComponentModifier(clitModifiersNode, "OVIPOSITOR");
        
        var urethraModifiersNode = vaginaNode.Element("urethraModifiers")!;
        UrethraPuffy = new BodyComponentModifier(urethraModifiersNode, "PUFFY");
        UrethraInternallyRibbed = new BodyComponentModifier(urethraModifiersNode, "RIBBED");
        UrethraTentacled = new BodyComponentModifier(urethraModifiersNode, "TENTACLED");
        UrethraInternallyMuscled = new BodyComponentModifier(urethraModifiersNode, "MUSCLE_CONTROL");
        
        var modifiers = vaginaModifiersNode.Attributes();
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
                    Tentacled.Initialize(modifier);
                    break;
                case "MUSCLE_CONTROL":
                    InternallyMuscled.Initialize(modifier);
                    break;
            }
        }
        
        modifiers = clitModifiersNode.Attributes();
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
                    ClitTentacled.Initialize(modifier);
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
                    UrethraPuffy.Initialize(modifier);
                    break;
                case "RIBBED":
                    UrethraInternallyRibbed.Initialize(modifier);
                    break;
                case "TENTACLED":
                    UrethraTentacled.Initialize(modifier);
                    break;
                case "MUSCLE_CONTROL":
                    UrethraInternallyMuscled.Initialize(modifier);
                    break;
            }
        }
    }
}