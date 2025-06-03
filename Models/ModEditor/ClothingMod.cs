using System.Xml.Linq;
using LTSaveEd.Models.ModEditor.Xml;
using LTSaveEd.Models.ModEditor.Xml.EnumXml;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor;

public class ClothingMod : Mod
{
    public XmlElement<int> Value { get; set; } = null!;
    public XmlElement<string> Determiner { get; set; } = null!;
    public XmlCData<string> Name { get; set; } = null!;
    public XmlAttribute<bool> AppendColorName { get; set; } = null!;
    public XmlCData<string> PluralName { get; set; } = null!;
    public XmlAttribute<bool> PluralByDefault { get; set; } = null!;
    public XmlCData<string> Description { get; set; } = null!;
    public XmlElement<int> PhysicalResistance { get; set; } = null!;
    public FemininityElement Femininity { get; set; } = null!;
    public EquipSlotElements EquipSlots { get; set; } = null!;
    public RarityElement Rarity { get; set; } = null!;
    // ClothingSet
    public XmlElement<string> ImageName { get; set; } = null!;
    
    // Internal use only, do not use this constructor.
    public ClothingMod()
    {
    }
    
    protected override XDocument CreateNewModDocument()
    {
        throw new NotImplementedException();
    }
}