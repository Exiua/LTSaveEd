namespace LTSaveEd.Models.CharacterData.BodyData;

public class LegTypeValueDisplayPair(string displayValue, string value, ValueDisplayPair<string>[] legConfigurations, ValueDisplayPair<string>[] footStructures,
    ValueDisplayPair<string>[] genitalArrangements) : ValueDisplayPair<string>(displayValue, value)
{
    public ValueDisplayPair<string>[] LegConfigurations { get; } = legConfigurations;
    public ValueDisplayPair<string>[] FootStructures { get; } = footStructures;
    public ValueDisplayPair<string>[] GenitalArrangements { get; } = genitalArrangements;
    public ValueDisplayPair<string> DefaultLegConfiguration { get; } = legConfigurations[0];
    public ValueDisplayPair<string> DefaultFootStructure { get; } = footStructures[0];
    public ValueDisplayPair<string> DefaultGenitalArrangement { get; } = genitalArrangements[0];

    public LegTypeValueDisplayPair(string displayValue, string value, ValueDisplayPair<string>[] legConfigurations, ValueDisplayPair<string>[] footStructures, 
        ValueDisplayPair<string>[] genitalArrangements, string defaultFootStructure) : this(displayValue, value, legConfigurations, footStructures, genitalArrangements)
    {
        foreach (var footStructure in footStructures)
        {
            if (footStructure.Value != defaultFootStructure)
            {
                continue;
            }
            
            DefaultFootStructure = footStructure;
            break;
        }
    }
}