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

        var modifiersNode = tongueNode.Element("tongueModifiers")!;
        Ribbed = new BodyComponentModifier(modifiersNode, "RIBBED");
        Tentacled = new BodyComponentModifier(modifiersNode, "TENTACLED");
        Bifurcated = new BodyComponentModifier(modifiersNode, "BIFURCATED");
        Wide = new BodyComponentModifier(modifiersNode, "WIDE");
        Flat = new BodyComponentModifier(modifiersNode, "FLAT");
        Strong = new BodyComponentModifier(modifiersNode, "STRONG");
        Tapered = new BodyComponentModifier(modifiersNode, "TAPERED");

        var modifiers = modifiersNode.Attributes();
        foreach (var modifier in modifiers)
        {
            switch (modifier.Name.LocalName)
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
            >= 7 and < 15 => "Long",
            >= 15 and < 25 => "Very Long",
            >= 25 and < 45 => "Extremely Long",
            >= 45 => "Absurdly Long"
        };
    }
}