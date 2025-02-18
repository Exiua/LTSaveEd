using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

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
        SirensCall = new NullableSpell(knownSpellsNode, "DARK_SIREN_SIRENS_CALL", nodeName: "spell");
        LightningDischarge = new NullableSpell(knownSpellsNode, "LIGHTNING_SPHERE_DISCHARGE", nodeName: "spell");
        LightningOvercharge = new NullableSpell(knownSpellsNode, "LIGHTNING_SPHERE_OVERCHARGE", nodeName: "spell"); 
        ChainLightning = new NullableSpell(knownSpellsNode, "ARCANE_CHAIN_LIGHTNING", nodeName: "spell");
        LightningSuperbolt = new NullableSpell(knownSpellsNode, "ARCANE_LIGHTNING_SUPERBOLT", nodeName: "spell");

        var spells = knownSpellsNode.Elements();
        foreach (var spell in spells)
        {
            var spellType = spell.GetAttributeValue<string>("type");
            switch (spellType)
            {
                case "WITCH_SEAL":
                    WitchsSeal.Initialize(spell);
                    break;
                case "WITCH_CHARM":
                    WitchsCharm.Initialize(spell);
                    break;
                case "DARK_SIREN_SIRENS_CALL":
                    SirensCall.Initialize(spell);
                    break;
                case "LIGHTNING_SPHERE_DISCHARGE":
                    LightningDischarge.Initialize(spell);
                    break;
                case "LIGHTNING_SPHERE_OVERCHARGE":
                    LightningOvercharge.Initialize(spell);
                    break;
                case "ARCANE_CHAIN_LIGHTNING":
                    ChainLightning.Initialize(spell);
                    break;
                case "ARCANE_LIGHTNING_SUPERBOLT":
                    LightningSuperbolt.Initialize(spell);
                    break;
                default:
                    Console.WriteLine($"Unknown Misc Spell Encountered: {spellType}");
                    break;
            }
        }
    }
}