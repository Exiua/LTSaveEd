namespace LTSaveEd.Models.CharacterData.BodyData;

public static class Collections
{
    public static ValueDisplayPair[] HairTypes { get; } =
    [
        new ValueDisplayPair("None", "ZERO_NONE"), new ValueDisplayPair("Stubble", "ONE_STUBBLE"),
        new ValueDisplayPair("Manicured", "TWO_MANICURED"), new ValueDisplayPair("Trimmed", "THREE_TRIMMED"),
        new ValueDisplayPair("Natural", "FOUR_NATURAL"), new ValueDisplayPair("Unkempt", "FIVE_UNKEMPT"),
        new ValueDisplayPair("Bushy", "SIX_BUSHY"), new ValueDisplayPair("Wild", "SEVEN_WILD")
    ];

    public static ValueDisplayPair[] BodyFluidFlavours { get; } =
    [
        new ValueDisplayPair("Cum", "CUM"), new ValueDisplayPair("Milk", "MILK"),
        new ValueDisplayPair("Girlcum", "GIRL_CUM"), new ValueDisplayPair("Bubblegum", "BUBBLEGUM"),
        new ValueDisplayPair("Beer", "BEER"), new ValueDisplayPair("Vanilla", "VANILLA"),
        new ValueDisplayPair("Strawberry", "STRAWBERRY"), new ValueDisplayPair("Chocolate", "CHOCOLATE"),
        new ValueDisplayPair("Pineapple", "PINEAPPLE"), new ValueDisplayPair("Honey", "HONEY"),
        new ValueDisplayPair("Mint", "MINT"), new ValueDisplayPair("Cherry", "CHERRY"),
        new ValueDisplayPair("Coffee", "COFFEE"), new ValueDisplayPair("Tea", "TEA"),
        new ValueDisplayPair("Maple", "MAPLE"), new ValueDisplayPair("Cinnamon", "CINNAMON"),
        new ValueDisplayPair("Lemon", "LEMON"), new ValueDisplayPair("Orange", "ORANGE"),
        new ValueDisplayPair("Grape", "GRAPE"), new ValueDisplayPair("Melon", "MELON"),
        new ValueDisplayPair("Coconut", "COCONUT"), new ValueDisplayPair("Blueberry", "BLUEBERRY")
    ];
}