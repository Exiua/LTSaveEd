using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

/// <summary>
///     Class models the mouth node of the character's body data. Part of the <see cref="Face" /> model.
/// </summary>
public class Mouth
{
    public LabeledXmlAttribute<float> Capacity { get; }
    public LabeledXmlAttribute<int> Depth { get; }
    public LabeledXmlAttribute<int> Elasticity { get; }
    public LabeledXmlAttribute<int> LipSize { get; }
    public XmlAttribute<bool> PiercedLip { get; }
    public LabeledXmlAttribute<int> Plasticity { get; }
    public LabeledXmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<bool> Virgin { get; }
    public LabeledXmlAttribute<int> Wetness { get; }
    
    #region Modifiers
    
    public BodyComponentModifier Puffy { get; }
    public BodyComponentModifier InternallyRibbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier InternallyMuscled { get; }
    
    #endregion
    
    public Mouth(XElement mouthNode)
    {
        Capacity = new LabeledXmlAttribute<float>(mouthNode.Attribute("capacity")!, Collections.GetCapacityLabel);
        Depth = new LabeledXmlAttribute<int>(mouthNode.Attribute("depth")!, Collections.GetDepthLabel);
        Elasticity = new LabeledXmlAttribute<int>(mouthNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
        LipSize = new LabeledXmlAttribute<int>(mouthNode.Attribute("lipSize")!, GetLipSizeLabel);
        PiercedLip = new XmlAttribute<bool>(mouthNode.Attribute("piercedLip")!);
        Plasticity = new LabeledXmlAttribute<int>(mouthNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
        StretchedCapacity = new LabeledXmlAttribute<float>(mouthNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
        Virgin = new XmlAttribute<bool>(mouthNode.Attribute("virgin")!);
        Wetness = new LabeledXmlAttribute<int>(mouthNode.Attribute("wetness")!, Collections.GetWetnessLabel);

        Puffy = new BodyComponentModifier(mouthNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(mouthNode, "RIBBED");
        Tentacled = new BodyComponentModifier(mouthNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(mouthNode, "MUSCLE_CONTROL");

        var modifiers = mouthNode.Elements();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Value)
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
    }

    /// <summary>
    ///     Returns the label for the lip size attribute.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetLipSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Thin",
            1 => "Average-sized",
            2 => "Full",
            3 => "Plump",
            4 => "Huge",
            5 => "Massive",
            6 => "Gigantic",
            >= 7 => "Absurdly Colossal",
        };
    }
}