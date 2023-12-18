using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData.BodyData.AssData;

public class Leg
{
    public static LegTypeValueDisplayPair[] LegTypes => Collections.LegTypes;
    
    private LegTypeValueDisplayPair _legType = null!;

    public ValueDisplayPair[] LegConfigurations => LegType.LegConfigurations;
    public ValueDisplayPair[] FootStructures => LegType.FootStructures;
    public ValueDisplayPair[] GenitalArrangements => LegType.GenitalArrangements;
    
    public XmlAttribute<string> Configuration { get; }
    public XmlAttribute<string> FootStructure { get; }
    //public XmlAttribute<float> TailLength { get; }
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

            ValueDisplayPair? newLegConfiguration = null;
            ValueDisplayPair? newFootStructure = null;
            ValueDisplayPair? newGenitalArrangement = null;
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

    public event Action<ValueDisplayPair?, ValueDisplayPair?, ValueDisplayPair?>? OnLegTypeChanged; 

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