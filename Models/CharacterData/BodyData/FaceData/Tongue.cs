using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.FaceData;

/// <summary>
///     Class models the tongue node of the character's body data. Part of the <see cref="Face" /> model.
/// </summary>
public class Tongue
{
    public XmlAttribute<bool> PiercedTongue { get; }
    public LabeledXmlAttribute<int> Length { get; }

    #region Modifiers

    public BodyComponentModifier Ribbed { get; }
    public BodyComponentModifier Tentacled { get; }
    public BodyComponentModifier Bifurcated { get; }
    public BodyComponentModifier Wide { get; }
    public BodyComponentModifier Flat { get; }
    public BodyComponentModifier Strong { get; }
    public BodyComponentModifier Tapered { get; }

    #endregion
    
    public Tongue(XElement tongueNode)
    {
        PiercedTongue = new XmlAttribute<bool>(tongueNode.Attribute("piercedTongue")!);
        Length = new LabeledXmlAttribute<int>(tongueNode.Attribute("tongueLength")!, GetTongueLengthLabel);

        Ribbed = new BodyComponentModifier(tongueNode, "RIBBED");
        Tentacled = new BodyComponentModifier(tongueNode, "TENTACLED");
        Bifurcated = new BodyComponentModifier(tongueNode, "BIFURCATED");
        Wide = new BodyComponentModifier(tongueNode, "WIDE");
        Flat = new BodyComponentModifier(tongueNode, "FLAT");
        Strong = new BodyComponentModifier(tongueNode, "STRONG");
        Tapered = new BodyComponentModifier(tongueNode, "TAPERED");

        var modifiers = tongueNode.Elements();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Value)
            {
                case "RIBBED":
                    Ribbed.Initialize(modifier);
                    break;
                case "TENTACLED":
                    Tentacled.Initialize(modifier);
                    break;
                case "BIFURCATED":
                    Bifurcated.Initialize(modifier);
                    break;
                case "WIDE":
                    Wide.Initialize(modifier);
                    break;
                case "FLAT":
                    Flat.Initialize(modifier);
                    break;
                case "STRONG":
                    Strong.Initialize(modifier);
                    break;
                case "TAPERED":
                    Tapered.Initialize(modifier);
                    break;
            }
        }
    }

    /// <summary>
    ///     Returns the tongue length label based on the tongue length value.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetTongueLengthLabel(int value)
    {
        return value switch
        {
            < 7 => "Normal-sized",
            < 15 => "Long",
            < 25 => "Very Long",
            < 45 => "Extremely Long",
            >= 45 => "Absurdly Long"
        };
    }
}