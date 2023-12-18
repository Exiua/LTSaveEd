using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData.SpellData;

public class FireSpells : ElementalSpells
{
    private SpellTier[] FireballSpellTiers { get; } =
    [
        new SpellTier("Unowned", "FIREBALL_UNOWNED"), new SpellTier("Base", "FIREBALL"),
        new SpellTier("Lingering Flames", "FIREBALL_1"), new SpellTier("Twin Comets", "FIREBALL_2"),
        new SpellTier("Burning Fury", "FIREBALL_3")
    ];

    private SpellTier[] FlashSpellTiers { get; } =
    [
        new SpellTier("Unowned", "FLASH_UNOWNED"), new SpellTier("Base", "FLASH"),
        new SpellTier("Secondary Sparks", "FLASH_1"), new SpellTier("Arcing Flash", "FLASH_2"),
        new SpellTier("Efficient Burn", "FLASH_3")
    ];


    private SpellTier[] CloakOfFlamesSpellTiers { get; } =
    [
        new SpellTier("Unowned", "CLOAK_OF_FLAMES_UNOWNED"),
        new SpellTier("Base", "CLOAK_OF_FLAMES"),
        new SpellTier("Incendiary", "CLOAK_OF_FLAMES_1"),
        new SpellTier("Inferno", "CLOAK_OF_FLAMES_2"),
        new SpellTier("Ring of Fire", "CLOAK_OF_FLAMES_3")
    ];

    private SpellTier[] ElementalFireSpellTiers { get; } =
    [
        new SpellTier("Unowned", "ELEMENTAL_FIRE_UNOWNED"),
        new SpellTier("Base", "ELEMENTAL_FIRE"),
        new SpellTier("Wildfire", "ELEMENTAL_FIRE_1"),
        new SpellTier("Burning Desire", "ELEMENTAL_FIRE_2"),
        new SpellTier("Servant of Fire", "ELEMENTAL_FIRE_3A"),
        new SpellTier("Binding of Fire", "ELEMENTAL_FIRE_3B")
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