using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

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

        var modifiersNode = mouthNode.Element("mouthModifiers")!;
        Puffy = new BodyComponentModifier(modifiersNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(modifiersNode, "RIBBED");
        Tentacled = new BodyComponentModifier(modifiersNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(modifiersNode, "MUSCLE_CONTROL");
        
        var modifiers = modifiersNode.Attributes();
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
    }

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