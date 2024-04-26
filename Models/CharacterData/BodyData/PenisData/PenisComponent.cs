using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

/// <summary>
///     Class models the penis node of the character's body data. Part of the <see cref="Penis" /> model.
/// </summary>
public class PenisComponent
{
    public ValueDisplayPair<string>[] PenisTypes { get; } =
    [
        new ValueDisplayPair<string>("None", "NONE"), new ValueDisplayPair<string>("Alligator", "ALLIGATOR_MORPH"),
        new ValueDisplayPair<string>("Angel", "ANGEL"), new ValueDisplayPair<string>("Badger", "innoxia_badger_penis"),
        new ValueDisplayPair<string>("Bat", "BAT_MORPH"), new ValueDisplayPair<string>("Bear", "dsg_bear_penis"),
        new ValueDisplayPair<string>("Capybara", "NoStepOnSnek_capybara_penis"),
        new ValueDisplayPair<string>("Cat", "CAT_MORPH"), new ValueDisplayPair<string>("Cow", "COW_MORPH"),
        new ValueDisplayPair<string>("Demonic", "DEMON_COMMON"), new ValueDisplayPair<string>("Dog", "DOG_MORPH"),
        new ValueDisplayPair<string>("Dragon", "dsg_dragon_penis"), new ValueDisplayPair<string>("Ferret", "dsg_ferret_penis"),
        new ValueDisplayPair<string>("Fox", "FOX_MORPH"), new ValueDisplayPair<string>("Goat", "innoxia_goat_penis"),
        new ValueDisplayPair<string>("Gryphon", "dsg_gryphon_penis"), new ValueDisplayPair<string>("Harpy", "HARPY"),
        new ValueDisplayPair<string>("Horse", "EQUINE"), new ValueDisplayPair<string>("Human", "HUMAN"),
        new ValueDisplayPair<string>("Hyena", "innoxia_hyena_penis"),
        new ValueDisplayPair<string>("Octopus", "NoStepOnSnek_octopus_penis"),
        new ValueDisplayPair<string>("Otter", "dsg_otter_penis"),
        new ValueDisplayPair<string>("Panther", "innoxia_panther_penis"),
        new ValueDisplayPair<string>("Pig", "innoxia_pig_penis"), new ValueDisplayPair<string>("Rabbit", "RABBIT_MORPH"),
        new ValueDisplayPair<string>("Racoon", "dsg_raccoon_penis"), new ValueDisplayPair<string>("Rat", "RAT_MORPH"),
        new ValueDisplayPair<string>("Reindeer", "REINDEER_MORPH"), new ValueDisplayPair<string>("Shark", "dsg_shark_penis"),
        new ValueDisplayPair<string>("Sheep", "innoxia_sheep_penis"),
        new ValueDisplayPair<string>("Snake", "NoStepOnSnek_snake_penis"),
        new ValueDisplayPair<string>("Spider", "charisma_spider_penis"),
        new ValueDisplayPair<string>("Squirrel", "SQUIRREL_MORPH"), new ValueDisplayPair<string>("Wolf", "WOLF_MORPH")
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
        
        Sheathed = new BodyComponentModifier(penisNode, "SHEATHED");
        Ribbed = new BodyComponentModifier(penisNode, "RIBBED");
        Tentacled = new BodyComponentModifier(penisNode, "TENTACLED");
        Knotted = new BodyComponentModifier(penisNode, "KNOTTED");
        Blunt = new BodyComponentModifier(penisNode, "BLUNT");
        Tapered = new BodyComponentModifier(penisNode, "TAPERED");
        Flared = new BodyComponentModifier(penisNode, "FLARED");
        Barbed = new BodyComponentModifier(penisNode, "BARBED");
        Veiny = new BodyComponentModifier(penisNode, "VEINY");
        Prehensile = new BodyComponentModifier(penisNode, "PREHENSILE");
        Ovipositor = new BodyComponentModifier(penisNode, "OVIPOSITOR");

        Puffy = new BodyComponentModifier(penisNode, "PUFFY", "modUrethra");
        InternallyRibbed = new BodyComponentModifier(penisNode, "RIBBED", "modUrethra");
        UrethraTentacled = new BodyComponentModifier(penisNode, "TENTACLED", "modUrethra");
        InternallyMuscled = new BodyComponentModifier(penisNode, "MUSCLE_CONTROL", "modUrethra");
        
        var modifiers = penisNode.Attributes();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Value)
            {
                case "SHEATHED":
                    Sheathed.Initialize(modifier);
                    break;
                case "RIBBED":
                    if(modifier.Name.LocalName == "mod")
                    {
                        Ribbed.Initialize(modifier);
                    }
                    else
                    {
                        InternallyRibbed.Initialize(modifier);
                    }
                    break;
                case "TENTACLED":
                    if (modifier.Name.LocalName == "mod")
                    {
                        Tentacled.Initialize(modifier);
                    }
                    else
                    {
                        UrethraTentacled.Initialize(modifier);
                    }
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
                case "PUFFY":
                    Puffy.Initialize(modifier);
                    break;
                case "MUSCLE_CONTROL":
                    InternallyMuscled.Initialize(modifier);
                    break;
            }
        }
    }

    /// <summary>
    ///     Get the penis size label corresponding to the provided value.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
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