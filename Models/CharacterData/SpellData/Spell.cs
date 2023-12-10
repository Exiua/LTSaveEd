using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class Spell
{
    private SpellTier _currentSpellTier;
    private XElement KnownSpellsNode { get; }
    private XElement SpellUpgradesNode { get; }
        
    public SpellTier[] Tiers { get; }

    public int CurrentTier => _currentSpellTier.Tier;

    public SpellTier CurrentSpellTier
    {
        get => _currentSpellTier;
        set
        {
            if (value.Tier == _currentSpellTier.Tier)
            {
                return;
            }

            _currentSpellTier = value;
            switch (_currentSpellTier.Tier)
            {
                case -1: // Unowned Spell
                    RemoveSpellNode(_currentSpellTier);
                    RemoveHigherTierSpells(_currentSpellTier, false);
                    break;
                case 0: // Base Spell
                    CreateSpellNode(_currentSpellTier);
                    RemoveHigherTierSpells(_currentSpellTier, true);
                    break;
                case 1 or 2: // Upgrades 1 and 2
                    CreateSpellNode(_currentSpellTier);
                    RemoveHigherTierSpells(_currentSpellTier, true);
                    AddLowerTierSpells(_currentSpellTier);
                    break;
                case 3: // Upgrade 3 (branching in the case of Elemental spell or 3A in the case of Steal spell)
                    CreateSpellNode(_currentSpellTier);
                    if (_currentSpellTier.Type == "STEAL")
                    {
                        RemoveHigherTierSpells(_currentSpellTier, true);
                    }
                    AddLowerTierSpells(_currentSpellTier);
                    ChangeWithinTierSpells(_currentSpellTier);
                    break;
                case 4: // Upgrade 3B only used by Steal spell
                    CreateSpellNode(_currentSpellTier);
                    AddLowerTierSpells(_currentSpellTier);
                    break;
            }
        }
    }

    public Spell(SpellTier[] tiers, XElement knownSpellsNode, XElement spellUpgradesNode)
    {
        Tiers = tiers;
        KnownSpellsNode = knownSpellsNode;
        SpellUpgradesNode = spellUpgradesNode;
        _currentSpellTier = tiers[0];
        var knownSpellNodes = knownSpellsNode.Elements();
        var spellKnown = false;
        if (knownSpellNodes.Any(knownSpell => knownSpell.GetAttributeValue<string>("type") == tiers[0].Type))
        {
            spellKnown = true;
            _currentSpellTier = tiers[1];
        }

        if (!spellKnown)
        {
            return;
        }
        
        var spellUpgrade = spellUpgradesNode.Elements();
        var highestTier = 0;
        foreach (var spell in spellUpgrade)
        {
            var spellType = spell.GetAttributeValue<string>("type");
            if (!spellType.StartsWith(_currentSpellTier.Type))
            {
                continue;
            }

            var tierFragment = spellType.Split("_")[^1];
            switch (tierFragment[^1])
            {
                case 'A':
                    highestTier = 3;
                    _currentSpellTier = tiers[4];
                    break;
                case 'B':
                    highestTier = 4;
                    _currentSpellTier = tiers[5];
                    break;
                default:
                {
                    var tier = (int)char.GetNumericValue(tierFragment[0]);
                    if (tier < highestTier)
                    {
                        continue;
                    }

                    tier = highestTier;
                    _currentSpellTier = tiers[tier + 1];
                    break;
                }
            }
        }
    }

    private void RemoveSpellNode(SpellTier spellTier)
    {
        var knownSpells = KnownSpellsNode.Elements();
        foreach (var spell in knownSpells)
        {
            if (spell.GetAttributeValue<string>("type") != spellTier.Type)
            {
                continue;
            }
            
            spell.Remove();
            return;
        }
    }
    
    private void CreateSpellNode(SpellTier spellTier)
    {
        var knownSpells = KnownSpellsNode.Elements();
        if (knownSpells.Any(spell => spell.GetAttributeValue<string>("type") == spellTier.Type))
        {
            return; // Spell exists
        }
        
        var spellNode = new XElement("spell", new XAttribute("type", spellTier.Type));
        KnownSpellsNode.Add(spellNode);
    }
    
    private void RemoveHigherTierSpells(SpellTier tier, bool owned) {
        var spellUpgrades = SpellUpgradesNode.Elements();
        foreach (var spellUpgrade in spellUpgrades)
        {
            var spellType = spellUpgrade.GetAttributeValue<string>("type");
            if (!spellType.StartsWith(tier.Type))
            {
                continue;
            }
            
            var upgradeTier = SpellTier.ReadTier(spellType);
            if (tier.Tier >= upgradeTier)
            {
                continue;
            }
                
            if (owned && !spellType.EndsWith("CLEAN"))
            {
                spellUpgrade.Remove();
            }
            else if(!owned)
            {
                spellUpgrade.Remove();
            }
        }
    }
    
    private void AddLowerTierSpells(SpellTier tier) {
        var spellUpgrades = SpellUpgradesNode.Elements();
        var count = spellUpgrades.Select(spell => spell.GetAttributeValue<string>("type")).Where(spellType => spellType.StartsWith(tier.Type)).Count(spellType => !spellType.EndsWith("CLEAN"));
        while (count < tier.Tier) {
            count++;
            var spellUpgrade = new XElement("upgrade");
            string value;
            if (tier.Type == "STEAL")
            {
                value = count switch
                {
                    3 => "STEAL_3A",
                    4 => "STEAL_3B",
                    _ => $"{tier.Type}_{count}"
                };
            }
            else if (count == tier.Tier) {
                value = tier.Value;
            }
            else
            {
                value = $"{tier.Type}_{count}";
            }
            var typeAttribute = new XAttribute("type", value);
            spellUpgrade.Add(typeAttribute);
            SpellUpgradesNode.Add(spellUpgrade);
        }
    }
    
    private void ChangeWithinTierSpells(SpellTier spellTier)
    {
        if (spellTier.Type == "STEAL")
        {
            return;
        }
        
        var spellUpgrades = SpellUpgradesNode.Elements();
        var complementTier = GetComplementTier(spellTier);
        foreach (var spell in spellUpgrades)
        {
            if (spell.GetAttributeValue<string>("type") != complementTier)
            {
                continue;
            }
                
            spell.Remove();
            var complementSpell = new XElement("upgrade", new XAttribute("type", spellTier.Value));
            SpellUpgradesNode.Add(complementSpell);
            break;
        }
    }
    
    private static string GetComplementTier(SpellTier spellTier) {
        if (spellTier.Value.EndsWith("_3A")) {
            return spellTier.Type + "_3B";
        }
        return spellTier.Type + "_3A";
    }
}