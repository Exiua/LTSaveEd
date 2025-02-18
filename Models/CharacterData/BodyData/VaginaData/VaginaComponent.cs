using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.VaginaData;

public class VaginaComponent
{
    public ValueDisplayPair<string>[] VaginaTypes { get; } =
    [
        new("None", "NONE"), new("Alligator", "ALLIGATOR_MORPH"),
        new("Angel", "ANGEL"), new("Badger", "innoxia_badger_vagina"),
        new("Bat", "BAT_MORPH"), new("Bear", "dsg_bear_vagina"),
        new("Capybara", "NoStepOnSnek_capybara_vagina"),
        new("Cat", "CAT_MORPH"), new("Cow", "COW_MORPH"),
        new("Demonic", "DEMON_COMMON"), new("Dog", "DOG_MORPH"),
        new("Dragon", "dsg_dragon_vagina"),
        new("Ferret", "dsg_ferret_vagina"), new("Fox", "FOX_MORPH"),
        new("Goat", "innoxia_goat_vagina"),
        new("Gryphon", "dsg_gryphon_vagina"), new("Harpy", "HARPY"),
        new("Horse", "HORSE_MORPH"), new("Human", "HUMAN"),
        new("Hyena", "innoxia_hyena_vagina"),
        new("Octopus", "NoStepOnSnek_octopus_vagina"),
        new("Otter", "dsg_otter_vagina"),
        new("Panther", "innoxia_panther_vagina"),
        new("Pig", "innoxia_pig_vagina"), new("Rabbit", "RABBIT_MORPH"),
        new("Racoon", "dsg_raccoon_vagina"), new("Rat", "RAT_MORPH"),
        new("Reindeer", "REINDEER_MORPH"), new("Shark", "dsg_shark_vagina"),
        new("Sheep", "innoxia_sheep_vagina"),
        new("Snake", "NoStepOnSnek_snake_vagina"),
        new("Spider", "charisma_spider_vagina"),
        new("Squirrel", "SQUIRREL_MORPH"), new("Wolf", "WOLF_MORPH")
    ];

    public LabeledXmlAttribute<float> Capacity { get; }
    public LabeledXmlAttribute<int> ClitGirth { get; }
    public LabeledXmlAttribute<int> ClitSize { get; }
    public LabeledXmlAttribute<int> Depth { get; }
    public LabeledXmlAttribute<int> Elasticity { get; }
    public LabeledXmlAttribute<int> LabiaSize { get; }
    public LabeledXmlAttribute<int> Plasticity { get; }
    public LabeledXmlAttribute<float> StretchedCapacity { get; }
    public LabeledXmlAttribute<float> UrethraCapacity { get; }
    public LabeledXmlAttribute<int> UrethraDepth { get; }
    public LabeledXmlAttribute<int> UrethraElasticity { get; }
    public LabeledXmlAttribute<int> UrethraPlasticity { get; }
    public LabeledXmlAttribute<float> UrethraStretchedCapacity { get; }
    public LabeledXmlAttribute<int> Wetness { get; }
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
        Capacity = new LabeledXmlAttribute<float>(vaginaNode.Attribute("capacity")!, Collections.GetCapacityLabel);
        ClitGirth = new LabeledXmlAttribute<int>(vaginaNode.Attribute("clitGirth")!, Collections.GetPenisClitGirthLabel);
        ClitSize = new LabeledXmlAttribute<int>(vaginaNode.Attribute("clitSize")!, GetClitSizeLabel);
        Depth = new LabeledXmlAttribute<int>(vaginaNode.Attribute("depth")!, Collections.GetDepthLabel);
        Elasticity = new LabeledXmlAttribute<int>(vaginaNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
        LabiaSize = new LabeledXmlAttribute<int>(vaginaNode.Attribute("labiaSize")!, Collections.GetBodyPartSizeLabel);
        Plasticity = new LabeledXmlAttribute<int>(vaginaNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
        StretchedCapacity = new LabeledXmlAttribute<float>(vaginaNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
        UrethraCapacity = new LabeledXmlAttribute<float>(vaginaNode.Attribute("urethraCapacity")!, Collections.GetCapacityLabel);
        UrethraDepth = new LabeledXmlAttribute<int>(vaginaNode.Attribute("urethraDepth")!, Collections.GetDepthLabel);
        UrethraElasticity = new LabeledXmlAttribute<int>(vaginaNode.Attribute("urethraElasticity")!, Collections.GetElasticityLabel);
        UrethraPlasticity = new LabeledXmlAttribute<int>(vaginaNode.Attribute("urethraPlasticity")!, Collections.GetPlasticityLabel);
        UrethraStretchedCapacity = new LabeledXmlAttribute<float>(vaginaNode.Attribute("urethraStretchedCapacity")!, Collections.GetCapacityLabel);
        Wetness = new LabeledXmlAttribute<int>(vaginaNode.Attribute("wetness")!, Collections.GetWetnessLabel);
        Type = new XmlAttribute<string>(vaginaNode.Attribute("type")!);
        EggLayer = new XmlAttribute<bool>(vaginaNode.Attribute("eggLayer")!);
        Hymen = new XmlAttribute<bool>(vaginaNode.Attribute("hymen")!);
        Pierced = new XmlAttribute<bool>(vaginaNode.Attribute("pierced")!);
        Squirter = new XmlAttribute<bool>(vaginaNode.Attribute("squirter")!);
        UrethraVirgin = new XmlAttribute<bool>(vaginaNode.Attribute("urethraVirgin")!);
        Virgin = new XmlAttribute<bool>(vaginaNode.Attribute("virgin")!);
            
        Puffy = new BodyComponentModifier(vaginaNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(vaginaNode, "RIBBED");
        Tentacled = new BodyComponentModifier(vaginaNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(vaginaNode, "MUSCLE_CONTROL");
        
        Sheathed = new BodyComponentModifier(vaginaNode, "SHEATHED", "modClit");
        Ribbed = new BodyComponentModifier(vaginaNode, "RIBBED", "modClit");
        ClitTentacled = new BodyComponentModifier(vaginaNode, "TENTACLED", "modClit");
        Knotted = new BodyComponentModifier(vaginaNode, "KNOTTED", "modClit");
        Blunt = new BodyComponentModifier(vaginaNode, "BLUNT", "modClit");
        Tapered = new BodyComponentModifier(vaginaNode, "TAPERED", "modClit");
        Flared = new BodyComponentModifier(vaginaNode, "FLARED", "modClit");
        Barbed = new BodyComponentModifier(vaginaNode, "BARBED", "modClit");
        Veiny = new BodyComponentModifier(vaginaNode, "VEINY", "modClit");
        Prehensile = new BodyComponentModifier(vaginaNode, "PREHENSILE", "modClit");
        Ovipositor = new BodyComponentModifier(vaginaNode, "OVIPOSITOR", "modClit");
        
        UrethraPuffy = new BodyComponentModifier(vaginaNode, "PUFFY", "modUrethra");
        UrethraInternallyRibbed = new BodyComponentModifier(vaginaNode, "RIBBED", "modUrethra");
        UrethraTentacled = new BodyComponentModifier(vaginaNode, "TENTACLED", "modUrethra");
        UrethraInternallyMuscled = new BodyComponentModifier(vaginaNode, "MUSCLE_CONTROL", "modUrethra");
        
        var modifiers = vaginaNode.Elements();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Value)
            {
                case "PUFFY":
                    if(modifier.Name.LocalName == "mod")
                    {
                        Puffy.Initialize(modifier);
                    }
                    else
                    {
                        UrethraPuffy.Initialize(modifier);
                    }
                    break;
                case "RIBBED":
                    switch (modifier.Name.LocalName)
                    {
                        case "mod":
                            InternallyRibbed.Initialize(modifier);
                            break;
                        case "modClit":
                            Ribbed.Initialize(modifier);
                            break;
                        default:
                            UrethraInternallyRibbed.Initialize(modifier);
                            break;
                    }
                    break;
                case "TENTACLED":
                    switch (modifier.Name.LocalName)
                    {
                        case "mod":
                            Tentacled.Initialize(modifier);
                            break;
                        case "modClit":
                            ClitTentacled.Initialize(modifier);
                            break;
                        default:
                            UrethraTentacled.Initialize(modifier);
                            break;
                    }
                    break;
                case "MUSCLE_CONTROL":
                    if(modifier.Name.LocalName == "mod")
                    {
                        InternallyMuscled.Initialize(modifier);
                    }
                    else
                    {
                        UrethraInternallyMuscled.Initialize(modifier);
                    }
                    break;
                case "SHEATHED":
                    Sheathed.Initialize(modifier);
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
                default:
                    Console.Error.WriteLine($"Unknown modifier: {modifier.Name.LocalName} : {modifier.Value}");
                    break;
            }
        }
    }

    private static string GetClitSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Small",
            < 5 => "Big",
            < 10 => "Large",
            < 25 => "Huge",
            < 40 => "Massive",
            < 50 => "Enormous",
            < 60 => "Gigantic",
            >= 60 => "Absurdly Colossal"
        };
    }
}