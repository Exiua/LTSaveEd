using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.VaginaData;

public class GirlCum
{
    public static ValueDisplayPair<string>[] GirlCumFlavours => Collections.BodyFluidFlavours;
    
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
    
    public GirlCum(XElement girlCumNode)
    {
        Flavour = new XmlAttribute<string>(girlCumNode.Attribute("flavour")!);
        
        Musky = new BodyComponentModifier(girlCumNode, "MUSKY");
        Viscous = new BodyComponentModifier(girlCumNode, "VISCOUS");
        Sticky = new BodyComponentModifier(girlCumNode, "STICKY");
        Slimy = new BodyComponentModifier(girlCumNode, "SLIMY");
        Bubbling = new BodyComponentModifier(girlCumNode, "BUBBLING");
        MineralOil = new BodyComponentModifier(girlCumNode, "MINERAL_OIL");
        Alcoholic = new BodyComponentModifier(girlCumNode, "ALCOHOLIC");
        Addictive = new BodyComponentModifier(girlCumNode, "ADDICTIVE");
        Psychoactive = new BodyComponentModifier(girlCumNode, "HALLUCINOGENIC");
        
        var modifiers = girlCumNode.Attributes();
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