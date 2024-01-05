using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.AssData;

/// <summary>
///     Class models the leg node of the character's body data. Part of the <see cref="Ass" /> model.
/// </summary>
public class Leg
{
    public static LegTypeValueDisplayPair[] LegTypes => Collections.LegTypes;
    
    private LegTypeValueDisplayPair _legType = null!;

    public ValueDisplayPair<string>[] LegConfigurations => LegType.LegConfigurations;
    public ValueDisplayPair<string>[] FootStructures => LegType.FootStructures;
    public ValueDisplayPair<string>[] GenitalArrangements => LegType.GenitalArrangements;
    
    public XmlAttribute<string> Configuration { get; }
    public XmlAttribute<string> FootStructure { get; }
    //public XmlAttribute<float> TailLength { get; }  // TODO: Figure out if all saves have this attribute
    private XmlAttribute<string> Type { get; }

    public LegTypeValueDisplayPair LegType
    {
        get => _legType;
        set
        {
            var currentLegConfigurations = LegConfigurations;
            var currentFootStructures = FootStructures;
            var currentGenitalArrangements = GenitalArrangements;
            _legType = value;
            Type.Value = _legType.Value;

            // Check if leg configurations, foot structures, or genital arrangements are valid for the new leg type.
            ValueDisplayPair<string>? newLegConfiguration = null;
            ValueDisplayPair<string>? newFootStructure = null;
            ValueDisplayPair<string>? newGenitalArrangement = null;
            if (!ReferenceEquals(currentLegConfigurations, LegConfigurations))
            {
                newLegConfiguration = _legType.DefaultLegConfiguration;
            }
            if (!ReferenceEquals(currentFootStructures, FootStructures))
            {
                newFootStructure = _legType.DefaultFootStructure;
            }
            if (!ReferenceEquals(currentGenitalArrangements, GenitalArrangements))
            {
                newGenitalArrangement = _legType.DefaultGenitalArrangement;
            }
            
            OnLegTypeChanged?.Invoke(newLegConfiguration, newFootStructure, newGenitalArrangement);
        }
    }

    public event Action<ValueDisplayPair<string>?, ValueDisplayPair<string>?, ValueDisplayPair<string>?>? OnLegTypeChanged; 

    public Leg(XElement legNode)
    {
        Configuration = new XmlAttribute<string>(legNode.Attribute("configuration")!);
        FootStructure = new XmlAttribute<string>(legNode.Attribute("footStructure")!);
        //TailLength = new XmlAttribute<float>(legNode.Attribute("tailLength")!);
        Type = new XmlAttribute<string>(legNode.Attribute("type")!);

        foreach (var legType in LegTypes)
        {
            if (Type.Value != legType.Value)
            {
                continue;
            }
            
            _legType = legType;
            break;
        }
    }
}