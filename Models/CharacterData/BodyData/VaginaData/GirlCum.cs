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
        
        var girlCumModifiersNode = girlCumNode.Element("girlcumModifiers")!;
        Musky = new BodyComponentModifier(girlCumModifiersNode, "MUSKY");
        Viscous = new BodyComponentModifier(girlCumModifiersNode, "VISCOUS");
        Sticky = new BodyComponentModifier(girlCumModifiersNode, "STICKY");
        Slimy = new BodyComponentModifier(girlCumModifiersNode, "SLIMY");
        Bubbling = new BodyComponentModifier(girlCumModifiersNode, "BUBBLING");
        MineralOil = new BodyComponentModifier(girlCumModifiersNode, "MINERAL_OIL");
        Alcoholic = new BodyComponentModifier(girlCumModifiersNode, "ALCOHOLIC");
        Addictive = new BodyComponentModifier(girlCumModifiersNode, "ADDICTIVE");
        Psychoactive = new BodyComponentModifier(girlCumModifiersNode, "HALLUCINOGENIC");
        
        var modifiers = girlCumModifiersNode.Attributes();
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