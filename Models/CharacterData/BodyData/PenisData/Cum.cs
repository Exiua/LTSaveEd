using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

/// <summary>
///     Class models the cum node of the character's body data. Part of the <see cref="Penis" /> model.
/// </summary>
public class Cum
{
    public static ValueDisplayPair[] CumFlavours => Collections.BodyFluidFlavours;
    
    public XmlAttribute<string> Flavour { get; }

    #region Modifiers

    public BodyComponentModifier Musky { get; }
    public BodyComponentModifier Viscous { get; }
    public BodyComponentModifier Sticky { get; }
    public BodyComponentModifier Slimy { get; }
    public BodyComponentModifier Bubbling { get; }
    public BodyComponentModifier MineralOil { get; }
    public BodyComponentModifier Alcoholic { get; }
    public BodyComponentModifier Addictive { get; }
    public BodyComponentModifier Psychoactive { get; }

    #endregion
    
    public Cum(XElement cumNode)
    {
        Flavour = new XmlAttribute<string>(cumNode.Attribute("flavour")!);
        
        var cumModifiersNode = cumNode.Element("cumModifiers")!;
        Musky = new BodyComponentModifier(cumModifiersNode, "MUSKY");
        Viscous = new BodyComponentModifier(cumModifiersNode, "VISCOUS");
        Sticky = new BodyComponentModifier(cumModifiersNode, "STICKY");
        Slimy = new BodyComponentModifier(cumModifiersNode, "SLIMY");
        Bubbling = new BodyComponentModifier(cumModifiersNode, "BUBBLING");
        MineralOil = new BodyComponentModifier(cumModifiersNode, "MINERAL_OIL");
        Alcoholic = new BodyComponentModifier(cumModifiersNode, "ALCOHOLIC");
        Addictive = new BodyComponentModifier(cumModifiersNode, "ADDICTIVE");
        Psychoactive = new BodyComponentModifier(cumModifiersNode, "HALLUCINOGENIC");
        
        var modifiers = cumModifiersNode.Attributes();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Name.LocalName)
            {
                case "MUSKY":
                    Musky.Initialize(modifier);
                    break;
                case "VISCOUS":
                    Viscous.Initialize(modifier);
                    break;
                case "STICKY":
                    Sticky.Initialize(modifier);
                    break;
                case "SLIMY":
                    Slimy.Initialize(modifier);
                    break;
                case "BUBBLING":
                    Bubbling.Initialize(modifier);
                    break;
                case "MINERAL_OIL":
                    MineralOil.Initialize(modifier);
                    break;
                case "ALCOHOLIC":
                    Alcoholic.Initialize(modifier);
                    break;
                case "ADDICTIVE":
                    Addictive.Initialize(modifier);
                    break;
                case "HALLUCINOGENIC":
                    Psychoactive.Initialize(modifier);
                    break;
            }
        }
    }
}