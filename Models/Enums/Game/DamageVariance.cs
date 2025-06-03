namespace LTSaveEd.Models.Enums.Game;

public enum DamageVariance
{
    None,
    Low,
    Medium,
    High,
}

public static class DamageVarianceExtensions
{
    public static string GetValue(this DamageVariance variance)
    {
        return variance switch
        {
            DamageVariance.None => "NONE",
            DamageVariance.Low => "LOW",
            DamageVariance.Medium => "MEDIUM",
            DamageVariance.High => "HIGH",
            _ => throw new ArgumentOutOfRangeException(nameof(variance), variance, null)
        };
    }

    public static DamageVariance FromValue(string value)
    {
        return value switch
        {
            "NONE" => DamageVariance.None,
            "LOW" => DamageVariance.Low,
            "MEDIUM" => DamageVariance.Medium,
            "HIGH" => DamageVariance.High,
            _ => DamageVariance.None // Default case, can be adjusted as needed
        };
    }
}