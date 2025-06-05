using System.Xml.Linq;
using LTSaveEd.Models.ModEditor.Xml;
using LTSaveEd.Models.ModEditor.Xml.EnumXml;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor;

public class CombatMoveMod : Mod
{
    public CombatMoveCategoryElement Category { get; set; } = null!;
    public CombatMoveTypeElement Type { get; set; } = null!;
    public XmlElement<int> EquipWeighting { get; set; } = null!;
    public XmlCData<string> Name { get; set; } = null!;
    public XmlCData<string> Description { get; set; } = null!;
    public DamageTypeElement DamageType { get; set; } = null!;
    public XmlCData<string> BaseDamage { get; set; } = null!;
    public DamageVarianceElement DamageVariance { get; set; } = null!;
    public XmlCData<int> BlockAmount { get; set; } = null!;
    public XmlCData<int> Cooldown { get; set; } = null!;
    public XmlCData<int> ApCost { get; set; } = null!;
    public XmlElement<bool> CanTargetEnemies { get; set; } = null!;
    public XmlElement<bool> CanTargetAllies { get; set; } = null!;
    public XmlElement<bool> CanTargetSelf { get; set; } = null!;
    public XmlElement<string> ImageName { get; set; } = null!;
    public PresetColorElement PrimaryColor { get; set; } = null!;
    public PresetColorElement SecondaryColor { get; set; } = null!;
    public PresetColorElement TertiaryColor { get; set; } = null!;
    // Status Effects
    public XmlCData<string> AvailabilityCondition { get; set; } = null!;
    public XmlCData<string> AvailabilityDescription { get; set; } = null!;
    public XmlCData<string> Weighting { get; set; } = null!;
    public XmlCData<string> CriticalCondition { get; set; } = null!;
    public XmlCData<string> CriticalDescription { get; set; } = null!;
    public XmlCData<string> MovePredictionDescriptionWithTarget { get; set; } = null!;
    public XmlCData<string> MovePredictionDescriptionNoTarget { get; set; } = null!;
    // Perform move
    
    public CombatMoveMod()
    {
        
    }
    
    private CombatMoveMod(XDocument root) : base(root)
    {
        if (root.Root is null || root.Root.Name.LocalName != "combatMove")
        {
            throw new InvalidOperationException("Invalid XML structure: Root element must be 'combatMove'.");
        }
        
        var element = root.Root;
    }
}