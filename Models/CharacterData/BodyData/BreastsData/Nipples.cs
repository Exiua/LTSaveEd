﻿using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.BreastsData;

/// <summary>
///     Class models the nipples(Crotch) node of the character's body data. Part of the <see cref="Breasts" /> model.
/// </summary>
public class Nipples
{
    public ValueDisplayPair<string>[] AreolaeShapes { get; } =
    [
        new("Normal", "NORMAL"), new("Heart-shaped", "HEART"),
        new("Star-shaped", "STAR")
    ];

    public ValueDisplayPair<string>[] NippleShapes { get; } =
    [
        new("Normal", "NORMAL"), new("Inverted", "INVERTED"),
        new("Nipple-cunts", "VAGINA"), new("Lipples", "LIPS")
    ];

    public XmlAttribute<string> AreolaeShape { get; }
    public LabeledXmlAttribute<int> AreolaeSize { get; }
    public LabeledXmlAttribute<float> Capacity { get; }
    public LabeledXmlAttribute<int> Depth { get; }
    public LabeledXmlAttribute<int> Elasticity { get; }
    public LabeledXmlAttribute<int> NippleSize { get; }
    public LabeledXmlAttribute<int> Plasticity { get; }
    public LabeledXmlAttribute<float> StretchedCapacity { get; }
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
        AreolaeSize = new LabeledXmlAttribute<int>(nipplesNode.Attribute("areolaeSize")!, Collections.GetBodyPartSizeLabel);
        Capacity = new LabeledXmlAttribute<float>(nipplesNode.Attribute("capacity")!, Collections.GetCapacityLabel);
        Depth = new LabeledXmlAttribute<int>(nipplesNode.Attribute("depth")!, Collections.GetDepthLabel);
        Elasticity = new LabeledXmlAttribute<int>(nipplesNode.Attribute("elasticity")!, Collections.GetElasticityLabel);
        NippleSize = new LabeledXmlAttribute<int>(nipplesNode.Attribute("nippleSize")!, Collections.GetBodyPartSizeLabel);
        Plasticity = new LabeledXmlAttribute<int>(nipplesNode.Attribute("plasticity")!, Collections.GetPlasticityLabel);
        StretchedCapacity = new LabeledXmlAttribute<float>(nipplesNode.Attribute("stretchedCapacity")!, Collections.GetCapacityLabel);
        NippleShape = new XmlAttribute<string>(nipplesNode.Attribute("nippleShape")!);
        Pierced = new XmlAttribute<bool>(nipplesNode.Attribute("pierced")!);
        Virgin = new XmlAttribute<bool>(nipplesNode.Attribute("virgin")!);

        Puffy = new BodyComponentModifier(nipplesNode, "PUFFY");
        InternallyRibbed = new BodyComponentModifier(nipplesNode, "RIBBED");
        Tentacled = new BodyComponentModifier(nipplesNode, "TENTACLED");
        InternallyMuscled = new BodyComponentModifier(nipplesNode, "MUSCLE_CONTROL");

        var modifiers = nipplesNode.Elements();
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
}