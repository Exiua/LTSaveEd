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
}