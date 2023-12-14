namespace LTSaveEd.Models.CharacterData.BodyData;

public class LegTypeValueDisplayPair(string displayValue, string value, ValueDisplayPair[] legConfigurations, ValueDisplayPair[] footStructures,
    ValueDisplayPair[] genitalArrangements) : ValueDisplayPair(displayValue, value)
{
    public ValueDisplayPair[] LegConfigurations { get; } = legConfigurations;
    public ValueDisplayPair[] FootStructures { get; } = footStructures;
    public ValueDisplayPair[] GenitalArrangements { get; } = genitalArrangements;
    public ValueDisplayPair DefaultLegConfiguration { get; } = legConfigurations[0];
    public ValueDisplayPair DefaultFootStructure { get; } = footStructures[0];
    public ValueDisplayPair DefaultGenitalArrangement { get; } = genitalArrangements[0];

    public LegTypeValueDisplayPair(string displayValue, string value, ValueDisplayPair[] legConfigurations, ValueDisplayPair[] footStructures, 
        ValueDisplayPair[] genitalArrangements, string defaultFootStructure) : this(displayValue, value, legConfigurations, footStructures, genitalArrangements)
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