﻿namespace LTSaveEd.Models.Enums.Game;

public enum Femininity
{
    Feminine,
    Masculine,
    Androgynous,
}

public static class FemininityExtensions
{
    public static string GetValue(this Femininity femininity)
    {
        return femininity switch
        {
            Femininity.Feminine => "FEMININE",
            Femininity.Masculine => "MASCULINE",
            Femininity.Androgynous => "ANDROGYNOUS",
            _ => throw new ArgumentOutOfRangeException(nameof(femininity), femininity, null)
        };
    }

    public static Femininity FromValue(string value)
    {
        return value switch
        {
            "FEMININE" => Femininity.Feminine,
            "MASCULINE" => Femininity.Masculine,
            "ANDROGYNOUS" => Femininity.Androgynous,
            _ => Femininity.Androgynous, // Default to Androgynous if value is unknown
        };
    }
    
    /*public static List<ValueDisplayPair<string>> FemininityList { get; } =
    [
        new("Feminine", "FEMININE"),
        new("Masculine", "MASCULINE"),
        new("Androgynous", "ANDROGYNOUS"),
    ];*/
    
    public static List<ValueDisplayPair<Femininity>> FemininityList { get; } =
    [
        new("Feminine", Femininity.Feminine),
        new("Masculine", Femininity.Masculine),
        new("Androgynous", Femininity.Androgynous),
    ];
}