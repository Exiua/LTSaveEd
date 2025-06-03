using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class PersonalityTrait : NullableXmlObject
{
    private readonly string _value;
    private readonly List<PersonalityTrait> _incompatibleTraits;
    
    public PersonalityTrait(XElement personalityNode, string trait) : base(personalityNode)
    {
        _value = trait;
        _incompatibleTraits = [];
    }

    public void AddIncompatibleTraits(params PersonalityTrait[] personalityTraits)
    {
        foreach (var personalityTrait in personalityTraits)
        {
            if (_incompatibleTraits.Contains(personalityTrait))
            {
                continue;
            }

            _incompatibleTraits.Add(personalityTrait);
            personalityTrait.AddIncompatibleTraits(this);
        }
    }

    private void CheckIncompatibleTraits()
    {
        foreach (var trait in _incompatibleTraits)
        {
            trait.Exists = false;
        }
    }

    protected override XElement CreateNode()
    {
        var trait = new XElement("trait")
        {
            Value = _value
        };
        Parent.Add(trait);
        CheckIncompatibleTraits();
        return trait;
    }
}