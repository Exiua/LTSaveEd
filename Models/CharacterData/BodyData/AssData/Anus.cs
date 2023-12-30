using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.AssData;

/// <summary>
///     Class models the anus node of the character's body data. Part of the <see cref="Ass" /> model.
/// </summary>
public class Anus
{
    public static ValueDisplayPair<string>[] AssHairTypes => Collections.HairTypes;
    
    public LabeledXmlAttribute<float> Capacity { get; }
    public LabeledXmlAttribute<int> Depth { get; }
    public LabeledXmlAttribute<int> Elasticity { get; }
    public LabeledXmlAttribute<int> Plasticity { get; }
    public LabeledXmlAttribute<float> StretchedCapacity { get; }
    public LabeledXmlAttribute<int> Wetness { get; }
    public XmlAttribute<string> AssHair { get; }
    public XmlAttribute<bool> Bleached { get; }
    public XmlAttribute<bool> Virgin { get; }

    #region Modifiers

    public BodyComponentModifier Puffy { get; }
    public BodyComponentModifier InternallyRibbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier InternallyMuscled { get; }

    #endregion
    
    public Anus(XElement anusNode)
    {
        Capacity = new LabeledXmlAttribute<float>(anusNode.Attribute("capacity")!, Collections.GetCapacityLabel);
        Depth = new LabeledXmlAttribute<int>(anusNode.Attribute("depth")!, Collections.GetDepthLabel);
        Elasticity = new LabeledXmlAttribute<int>(anusNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
        Plasticity = new LabeledXmlAttribute<int>(anusNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
        StretchedCapacity = new LabeledXmlAttribute<float>(anusNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
        Wetness = new LabeledXmlAttribute<int>(anusNode.Attribute("wetness")!, Collections.GetWetnessLabel);
        AssHair = new XmlAttribute<string>(anusNode.Attribute("assHair")!);
        Bleached = new XmlAttribute<bool>(anusNode.Attribute("bleached")!);
        Virgin = new XmlAttribute<bool>(anusNode.Attribute("virgin")!);
        
        var anusModifiersNode = anusNode.Element("anusModifiers")!;
        Puffy = new BodyComponentModifier(anusModifiersNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(anusModifiersNode, "RIBBED");
        Tentacled = new BodyComponentModifier(anusModifiersNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(anusModifiersNode, "MUSCLE_CONTROL");
        
        var modifiers = anusModifiersNode.Attributes();
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