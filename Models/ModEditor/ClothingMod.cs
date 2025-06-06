using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.ModEditor.Xml;
using LTSaveEd.Models.ModEditor.Xml.EnumXml;
using LTSaveEd.Models.XmlData;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.ModEditor;

public class ClothingMod : Mod
{
    public NullableXmlCData AuthorTag { get; set; } = null!;
    public XmlElement<int> Value { get; set; } = null!;
    public XmlElement<string> Determiner { get; set; } = null!;
    public XmlCData<string> Name { get; set; } = null!;
    public XmlAttribute<bool> AppendColorName { get; set; } = null!;
    public XmlCData<string> PluralName { get; set; } = null!;
    public XmlAttribute<bool> PluralByDefault { get; set; } = null!;
    public XmlCData<string> Description { get; set; } = null!;
    public XmlElement<float> PhysicalResistance { get; set; } = null!;
    public FemininityElement Femininity { get; set; } = null!;
    public EquipSlotElements EquipSlots { get; set; } = null!;

    public RarityElement Rarity { get; set; } = null!;

    // ClothingSet
    public XmlElement<string> ImageName { get; set; } = null!;

    public ClothingMod(XDocument root) : base(root)
    {
        if (root.Root is null || root.Root.Name.LocalName != "clothing")
        {
            throw new ArgumentException("Root element must be 'clothing'.", nameof(root));
        }

        var element = root.Root;
        var coreAttributeElement = element.Element("coreAttributes");
        if (coreAttributeElement is null)
        {
            throw new ArgumentException("Root element must contain 'coreAttributes'.", nameof(root));
        }

        #region Initialize Nullable Fields

        AuthorTag = new NullableXmlCData(coreAttributeElement, "authorTag");

        #endregion

        // List of actions that may modify the XML structure after initial parsing
        // Modifying the XML structure while iterating over elements can lead to the "Collection was modified" exception.
        List<Action> deferredActions = [];
        var setFields = new Box<ClothingModField>(ClothingModField.None);
        foreach (var field in coreAttributeElement.Elements())
        {
            switch (field.Name.LocalName)
            {
                case "authorTag":
                {
                    AuthorTag.Initialize(field.GetCData());
                    break;
                }
                case "value":
                {
                    Value = new XmlElement<int>(field);
                    setFields.Value |= ClothingModField.Value;
                    break;
                }
                case "determiner":
                {
                    Determiner = new XmlElement<string>(field);
                    setFields.Value |= ClothingModField.Determiner;
                    break;
                }
                case "name":
                {
                    Name = new XmlCData<string>(field.GetCData());
                    setFields.Value |= ClothingModField.Name;
                    var appendColorName = field.Attribute("appendColourName");
                    if (appendColorName is null)
                    {
                        appendColorName = new XAttribute("appendColourName", "false");
                        field.Add(appendColorName);
                    }

                    AppendColorName = new XmlAttribute<bool>(appendColorName);
                    setFields.Value |= ClothingModField.AppendColorName;
                    break;
                }
                case "namePlural":
                {
                    PluralName = new XmlCData<string>(field.GetCData());
                    setFields.Value |= ClothingModField.PluralName;
                    var pluralByDefault = field.Attribute("pluralByDefault");
                    if (pluralByDefault is null)
                    {
                        pluralByDefault = new XAttribute("pluralByDefault", "false");
                        field.Add(pluralByDefault);
                    }

                    PluralByDefault = new XmlAttribute<bool>(pluralByDefault);
                    setFields.Value |= ClothingModField.PluralByDefault;
                    break;
                }
                case "description":
                {
                    Description = new XmlCData<string>(field.GetCData());
                    setFields.Value |= ClothingModField.Description;
                    break;
                }
                case "physicalResistance":
                {
                    PhysicalResistance = new XmlElement<float>(field);
                    setFields.Value |= ClothingModField.PhysicalResistance;
                    break;
                }
                case "femininity":
                {
                    Femininity = new FemininityElement(field);
                    setFields.Value |= ClothingModField.Femininity;
                    break;
                }
                case "equipSlots":
                {
                    EquipSlots = new EquipSlotElements(field);
                    setFields.Value |= ClothingModField.EquipSlots;
                    break;
                }
                case "slot":
                {
                    deferredActions.Add(ConvertSlotToEquipSlots);
                    break;

                    void ConvertSlotToEquipSlots()
                    {
                        ModifySlotToEquipSlots(field);
                        setFields.Value |= ClothingModField.EquipSlots;
                    }
                }
                case "rarity":
                {
                    Rarity = new RarityElement(field);
                    setFields.Value |= ClothingModField.Rarity;
                    break;
                }
                // ClothingSet
                case "imageName":
                {
                    ImageName = new XmlElement<string>(field);
                    setFields.Value |= ClothingModField.ImageName;
                    break;
                }
            }
        }
        
        foreach(var action in deferredActions)
        {
            action();
        }

        if (setFields != ClothingModField.All)
        {
            var missingFields = ClothingModField.All & ~setFields.Value;
            throw new ArgumentException(
                $"Missing fields in clothing mod: {missingFields}.", nameof(root));
        }
    }

    private void ModifySlotToEquipSlots(XElement slot)
    {
        var value = slot.Value;
        slot.Name = "equipSlots";
        var childSlot = new XElement("slot", value);
        slot.Add(childSlot);
        EquipSlots = new EquipSlotElements(slot);
    }
}

[Flags]
internal enum ClothingModField
{
    None = 0,
    Value = 1 << 0,
    Determiner = 1 << 1,
    Name = 1 << 2,
    AppendColorName = 1 << 3,
    PluralName = 1 << 4,
    PluralByDefault = 1 << 5,
    Description = 1 << 6,
    PhysicalResistance = 1 << 7,
    Femininity = 1 << 8,
    EquipSlots = 1 << 9,
    Rarity = 1 << 10,
    ImageName = 1 << 11,

    All = Value | Determiner | Name | AppendColorName | PluralName | PluralByDefault |
          Description | PhysicalResistance | Femininity | EquipSlots | Rarity | ImageName
}