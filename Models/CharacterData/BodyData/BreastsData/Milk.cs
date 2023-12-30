using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.BreastsData;

/// <summary>
///     Class models the milk(Crotch) node of the character's body data. Part of the <see cref="Breasts" /> model.
/// </summary>
public class Milk
{
    public static ValueDisplayPair[] MilkFlavours => Collections.BodyFluidFlavours;

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
    
    public Milk(XElement milkNode)
    {
        Flavour = new XmlAttribute<string>(milkNode.Attribute("flavour")!);

        var milkModifiersNode = milkNode.Element("milkModifiers")!;
        Musky = new BodyComponentModifier(milkModifiersNode, "MUSKY");
        Viscous = new BodyComponentModifier(milkModifiersNode, "VISCOUS");
        Sticky = new BodyComponentModifier(milkModifiersNode, "STICKY");
        Slimy = new BodyComponentModifier(milkModifiersNode, "SLIMY");
        Bubbling = new BodyComponentModifier(milkModifiersNode, "BUBBLING");
        MineralOil = new BodyComponentModifier(milkModifiersNode, "MINERAL_OIL");
        Alcoholic = new BodyComponentModifier(milkModifiersNode, "ALCOHOLIC");
        Addictive = new BodyComponentModifier(milkModifiersNode, "ADDICTIVE");
        Psychoactive = new BodyComponentModifier(milkModifiersNode, "HALLUCINOGENIC");

        var modifiers = milkModifiersNode.Attributes();
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