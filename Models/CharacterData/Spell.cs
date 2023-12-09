namespace LTSaveEd.Models.CharacterData;

public class Spell
{
    public SpellTier[] Tiers { get; }
    
    public int CurrentTier { get; set; }

    public Spell(SpellTier[] tiers)
    {
        Tiers = tiers;
    }
}