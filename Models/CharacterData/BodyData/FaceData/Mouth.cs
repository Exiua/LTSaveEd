using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

public class Mouth
{
    public XmlAttribute<float> Capacity { get; }
    public XmlAttribute<int> Depth { get; }
    public XmlAttribute<int> Elasticity { get; }
    public XmlAttribute<int> LipSize { get; }
    public XmlAttribute<bool> PiercedLip { get; }
    public XmlAttribute<int> Plasticity { get; }
    public XmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<bool> Virgin { get; }
    public XmlAttribute<int> Wetness { get; }
    
    #region Modifiers
    
    public BodyComponentModifier Puffy { get; }
    public BodyComponentModifier InternallyRibbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier InternallyMuscled { get; }
    
    #endregion
    
    public Mouth(XElement mouthNode)
    {
        Capacity = new XmlAttribute<float>(mouthNode.Attribute("capacity")!);
        Depth = new XmlAttribute<int>(mouthNode.Attribute("depth")!);
        Elasticity = new XmlAttribute<int>(mouthNode.Attribute("elasticity")!);
        LipSize = new XmlAttribute<int>(mouthNode.Attribute("lipSize")!);
        PiercedLip = new XmlAttribute<bool>(mouthNode.Attribute("piercedLip")!);
        Plasticity = new XmlAttribute<int>(mouthNode.Attribute("plasticity")!);
        StretchedCapacity = new XmlAttribute<float>(mouthNode.Attribute("stretchedCapacity")!);
        Virgin = new XmlAttribute<bool>(mouthNode.Attribute("virgin")!);
        Wetness = new XmlAttribute<int>(mouthNode.Attribute("wetness")!);

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
}