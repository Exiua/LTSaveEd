using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.PenisData;

/// <summary>
///     Class models the testicles node of the character's body data. Part of the <see cref="Penis" /> model.
/// </summary>
/// <param name="testiclesNode">XElement of the testicles node</param>
public class Testicles(XElement testiclesNode)
{
    public XmlAttribute<int> CumExpulsion { get; } = new(testiclesNode.Attribute("cumExpulsion")!);
    public LabeledXmlAttribute<int> CumRegeneration { get; } = new(testiclesNode.Attribute("cumRegeneration")!, Collections.GetFluidRegenerationLabel);
    public LabeledXmlAttribute<int> CumStorage { get; } = new(testiclesNode.Attribute("cumStorage")!, GetCumStorageLabel);
    public XmlAttribute<int> NumberOfTesticles { get; } = new(testiclesNode.Attribute("numberOfTesticles")!);
    public XmlAttribute<float> StoredCum { get; } = new(testiclesNode.Attribute("storedCum")!);
    public LabeledXmlAttribute<int> TesticleSize { get; } = new(testiclesNode.Attribute("testicleSize")!, GetTesticleSizeLabel);
    public XmlAttribute<bool> Internal { get; } = new(testiclesNode.Attribute("internal")!);

    /// <summary>
    ///     Get label based on the given cum storage value.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetCumStorageLabel(int value)
    {
        return value switch
        {
            <= 0 => "None",
            < 10 => "Trickle",
            < 20 => "Average",
            < 30 => "Large",
            < 100 => "Huge",
            < 1000 => "Extreme",
            >= 1000 => "Monstrous"
        };
    }

    /// <summary>
    ///     Get label based on the given testicle size value.
    /// </summary>
    /// <param name="value">Value to get the corresponding label of</param>
    /// <returns>Label corresponding to the provided value</returns>
    private static string GetTesticleSizeLabel(int value)
    {
        return value switch
        {
            <= 0 => "Vestigial",
            1 => "Tiny",
            2 => "Average-sized",
            3 => "Large",
            4 => "Huge",
            5 => "Massive",
            6 => "Gigantic",
            >= 7 => "Absurdly Enormous"
        };
    }
}