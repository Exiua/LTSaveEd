using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

/// <summary>
///     Class models the cum node of the character's body data. Part of the <see cref="Penis" /> model.
/// </summary>
public class Cum
{
    public static ValueDisplayPair<string>[] CumFlavours => Collections.BodyFluidFlavours;
    
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
        
        Musky = new BodyComponentModifier(cumNode, "MUSKY");
        Viscous = new BodyComponentModifier(cumNode, "VISCOUS");
        Sticky = new BodyComponentModifier(cumNode, "STICKY");
        Slimy = new BodyComponentModifier(cumNode, "SLIMY");
        Bubbling = new BodyComponentModifier(cumNode, "BUBBLING");
        MineralOil = new BodyComponentModifier(cumNode, "MINERAL_OIL");
        Alcoholic = new BodyComponentModifier(cumNode, "ALCOHOLIC");
        Addictive = new BodyComponentModifier(cumNode, "ADDICTIVE");
        Psychoactive = new BodyComponentModifier(cumNode, "HALLUCINOGENIC");
        
        var modifiers = cumNode.Elements();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Value)
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