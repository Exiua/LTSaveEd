using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class MiscSpells : ElementalSpells
{
    public NullableSpell WitchsSeal { get; }
    public NullableSpell WitchsCharm { get; }
    public NullableSpell SirensCall { get; }
    public NullableSpell LightningDischarge { get; }
    public NullableSpell LightningOvercharge { get; }
    public NullableSpell ChainLightning { get; }
    public NullableSpell LightningSuperbolt { get; }
    
    public MiscSpells(XElement knownSpellsNode, XElement spellUpgradesNode) : base(knownSpellsNode, spellUpgradesNode)
    {
        WitchsSeal = new NullableSpell(knownSpellsNode, "WITCH_SEAL", nodeName: "spell");
        WitchsCharm = new NullableSpell(knownSpellsNode, "WITCH_CHARM", nodeName: "spell");
        SirensCall = new NullableSpell(knownSpellsNode, "SIRENS_CALL", nodeName: "spell");
        LightningDischarge = new NullableSpell(knownSpellsNode, "LIGHTNING_SPHERE_DISCHARGE", nodeName: "spell");
        LightningOvercharge = new NullableSpell(knownSpellsNode, "LIGHTNING_SPHERE_OVERCHARGE", nodeName: "spell"); 
        ChainLightning = new NullableSpell(knownSpellsNode, "CHAIN_LIGHTNING", nodeName: "spell");
        LightningSuperbolt = new NullableSpell(knownSpellsNode, "LIGHTNING_SUPERBOLT", nodeName: "spell");
    }
}