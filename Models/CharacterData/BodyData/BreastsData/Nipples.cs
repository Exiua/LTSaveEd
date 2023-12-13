using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.BreastsData;

public class Nipples
{
    public ValueDisplayPair[] AreolaeShapes { get; } =
    [
        new ValueDisplayPair("Normal", "NORMAL"), new ValueDisplayPair("Heart-shaped", "HEART"),
        new ValueDisplayPair("Star-shaped", "STAR")
    ];

    public ValueDisplayPair[] nippleShapes { get; } =
    [
        new ValueDisplayPair("Normal", "NORMAL"), new ValueDisplayPair("Inverted", "INVERTED"),
        new ValueDisplayPair("Nipple-cunts", "VAGINA"), new ValueDisplayPair("Lipples", "LIPS")
    ];

    public XmlAttribute<string> AreolaeShape { get; }
    public XmlAttribute<int> AreolaeSize { get; }
    public XmlAttribute<float> Capacity { get; }
    public XmlAttribute<int> Depth { get; }
    public XmlAttribute<int> Elasticity { get; }
    public XmlAttribute<int> NippleSize { get; }
    public XmlAttribute<int> Plasticity { get; }
    public XmlAttribute<float> StretchedCapacity { get; }
    public XmlAttribute<string> NippleShape { get; }
    public XmlAttribute<bool> Pierced { get; }
    public XmlAttribute<bool> Virgin { get; }

    #region Modifiers

    public BodyComponentModifier Puffy { get; }
    public BodyComponentModifier InternallyRibbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier InternallyMuscled { get; }

    #endregion
    
    public Nipples(XElement nipplesNode)
    {
        AreolaeShape = new XmlAttribute<string>(nipplesNode.Attribute("areolaeShape")!);
        AreolaeSize = new XmlAttribute<int>(nipplesNode.Attribute("areolaeSize")!);
        Capacity = new XmlAttribute<float>(nipplesNode.Attribute("capacity")!);
        Depth = new XmlAttribute<int>(nipplesNode.Attribute("depth")!);
        Elasticity = new XmlAttribute<int>(nipplesNode.Attribute("elasticity")!);
        NippleSize = new XmlAttribute<int>(nipplesNode.Attribute("nippleSize")!);
        Plasticity = new XmlAttribute<int>(nipplesNode.Attribute("plasticity")!);
        StretchedCapacity = new XmlAttribute<float>(nipplesNode.Attribute("stretchedCapacity")!);
        NippleShape = new XmlAttribute<string>(nipplesNode.Attribute("nippleShape")!);
        Pierced = new XmlAttribute<bool>(nipplesNode.Attribute("pierced")!);
        Virgin = new XmlAttribute<bool>(nipplesNode.Attribute("virgin")!);

        var nippleModifiersNode = nipplesNode.Element("nippleModifiers")!;
        Puffy = new BodyComponentModifier(nippleModifiersNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(nippleModifiersNode, "RIBBED");
        Tentacled = new BodyComponentModifier(nippleModifiersNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(nippleModifiersNode, "MUSCLE_CONTROL");

        var modifiers = nippleModifiersNode.Attributes();
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