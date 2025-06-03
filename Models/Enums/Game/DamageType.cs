namespace LTSaveEd.Models.Enums.Game;

public enum DamageType
{
    Health,
    Physical,
    Ice,
    Fire,
    Poison,
    Unarmed,
    Lust,
    Misc
}

public static class DamageTypeExtensions
{
    public static string GetValue(this DamageType type)
    {
        return type switch
        {
            DamageType.Health => "HEALTH",
            DamageType.Physical => "PHYSICAL",
            DamageType.Ice => "ICE",
            DamageType.Fire => "FIRE",
            DamageType.Poison => "POISON",
            DamageType.Unarmed => "UNARMED",
            DamageType.Lust => "LUST",
            DamageType.Misc => "MISC",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
    
    public static DamageType FromValue(string value)
    {
        return value switch
        {
            "HEALTH" => DamageType.Health,
            "PHYSICAL" => DamageType.Physical,
            "ICE" => DamageType.Ice,
            "FIRE" => DamageType.Fire,
            "POISON" => DamageType.Poison,
            "UNARMED" => DamageType.Unarmed,
            "LUST" => DamageType.Lust,
            "MISC" => DamageType.Misc,
            _ => DamageType.Health // Default case, can be adjusted as needed
        };
    }
}