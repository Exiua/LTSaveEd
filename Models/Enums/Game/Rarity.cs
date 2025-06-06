namespace LTSaveEd.Models.Enums.Game;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Quest,
    Jinxed,
}

public static class RarityExtensions
{
    public static string GetValue(this Rarity rarity)
    {
        return rarity switch
        {
            Rarity.Common => "COMMON",
            Rarity.Uncommon => "UNCOMMON",
            Rarity.Rare => "RARE",
            Rarity.Epic => "EPIC",
            Rarity.Legendary => "LEGENDARY",
            Rarity.Quest => "QUEST",
            Rarity.Jinxed => "JINXED",
            _ => throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null)
        };
    }

    public static Rarity FromValue(string value)
    {
        return value switch
        {
            "COMMON" => Rarity.Common,
            "UNCOMMON" => Rarity.Uncommon,
            "RARE" => Rarity.Rare,
            "EPIC" => Rarity.Epic,
            "LEGENDARY" => Rarity.Legendary,
            "QUEST" => Rarity.Quest,
            "JINXED" => Rarity.Jinxed,
            _ => Rarity.Common // Default to Common if the value is unknown
        };
    }

    public static List<ValueDisplayPair<Rarity>> RarityList { get; } =
    [
        new("Common", Rarity.Common),
        new("Uncommon", Rarity.Uncommon),
        new("Rare", Rarity.Rare),
        new("Epic", Rarity.Epic),
        new("Legendary", Rarity.Legendary),
        new("Quest", Rarity.Quest),
        new("Jinxed", Rarity.Jinxed),
    ];
}