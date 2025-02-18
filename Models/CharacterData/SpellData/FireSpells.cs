using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class FireSpells : ElementalSpells
{
    private SpellTier[] FireballSpellTiers { get; } =
    [
        new("Unowned", "FIREBALL_UNOWNED"), new("Base", "FIREBALL"),
        new("Lingering Flames", "FIREBALL_1"), new("Twin Comets", "FIREBALL_2"),
        new("Burning Fury", "FIREBALL_3")
    ];

    private SpellTier[] FlashSpellTiers { get; } =
    [
        new("Unowned", "FLASH_UNOWNED"), new("Base", "FLASH"),
        new("Secondary Sparks", "FLASH_1"), new("Arcing Flash", "FLASH_2"),
        new("Efficient Burn", "FLASH_3")
    ];


    private SpellTier[] CloakOfFlamesSpellTiers { get; } =
    [
        new("Unowned", "CLOAK_OF_FLAMES_UNOWNED"),
        new("Base", "CLOAK_OF_FLAMES"),
        new("Incendiary", "CLOAK_OF_FLAMES_1"),
        new("Inferno", "CLOAK_OF_FLAMES_2"),
        new("Ring of Fire", "CLOAK_OF_FLAMES_3")
    ];

    private SpellTier[] ElementalFireSpellTiers { get; } =
    [
        new("Unowned", "ELEMENTAL_FIRE_UNOWNED"),
        new("Base", "ELEMENTAL_FIRE"),
        new("Wildfire", "ELEMENTAL_FIRE_1"),
        new("Burning Desire", "ELEMENTAL_FIRE_2"),
        new("Servant of Fire", "ELEMENTAL_FIRE_3A"),
        new("Binding of Fire", "ELEMENTAL_FIRE_3B")
    ];
    
    public Spell Fireball { get; }
    public Spell Flash { get; }
    public Spell CloakOfFlames { get; }
    public Spell FireElemental { get; }
    
    public FireSpells(XElement knownSpellsNode, XElement spellUpgradesNode, XElement spellUpgradePointsNode) : base(knownSpellsNode, spellUpgradesNode)
    {
        Fireball = new Spell(FireballSpellTiers, knownSpellsNode, spellUpgradesNode);
        Flash = new Spell(FlashSpellTiers, knownSpellsNode, spellUpgradesNode);
        CloakOfFlames = new Spell(CloakOfFlamesSpellTiers, knownSpellsNode, spellUpgradesNode);
        FireElemental = new Spell(ElementalFireSpellTiers, knownSpellsNode, spellUpgradesNode);
        UpgradePoints = GetUpgradePointNode(spellUpgradePointsNode, "FIRE");
    }
}