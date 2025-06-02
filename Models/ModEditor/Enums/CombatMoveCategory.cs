namespace LTSaveEd.Models.ModEditor.Enums;

public enum CombatMoveCategory
{
    /** Moves available to everyone by default. */
    Basic,

    /** Spells. */
    Spell,
	
    /** Any move derived from body parts, weapons, fetishes, etc. */
    Special,
}

public static class CombatMoveCategoryExtensions
{
    public static string GetValue(this CombatMoveCategory category)
    {
        return category switch
        {
            CombatMoveCategory.Basic => "BASIC",
            CombatMoveCategory.Spell => "SPELL",
            CombatMoveCategory.Special => "SPECIAL",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
    
    public static CombatMoveCategory FromValue(string value)
    {
        return value switch
        {
            "BASIC" => CombatMoveCategory.Basic,
            "SPELL" => CombatMoveCategory.Spell,
            "SPECIAL" => CombatMoveCategory.Special,
            _ => CombatMoveCategory.Basic, // Default to Basic if the value is unknown
        };
    }
}