using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.AssData;

public class Anus
{
    public static ValueDisplayPair[] AssHairTypes => Collections.HairTypes;
    
    public XmlAttribute<float> Capacity { get; }
    public XmlAttribute<int> Depth { get; }
    public XmlAttribute<int> Elasticity { get; }
    public XmlAttribute<int> Plasticity { get; }
    public XmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<int> Wetness { get; }
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
        Capacity = new XmlAttribute<float>(anusNode.Attribute("capacity")!);
        Depth = new XmlAttribute<int>(anusNode.Attribute("depth")!);
        Elasticity = new XmlAttribute<int>(anusNode.Attribute("elasticity")!);
        Plasticity = new XmlAttribute<int>(anusNode.Attribute("plasticity")!);
        StretchedCapacity = new XmlAttribute<float>(anusNode.Attribute("stretchedCapacity")!);
        Wetness = new XmlAttribute<int>(anusNode.Attribute("wetness")!);
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