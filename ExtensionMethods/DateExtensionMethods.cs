namespace LTSaveEd.ExtensionMethods;

/// <summary>
///     Extension methods for <see cref="DateTime" /> related functionality.
/// </summary>
public static class DateExtensionMethods
{
    /// <summary>
    ///     Converts a month's numerical value to its full-uppercase string representation.
    /// </summary>
    /// <param name="value">Numerical value of the month</param>
    /// <returns>String name of the corresponding month</returns>
    /// <exception cref="Exception">Thrown when value is out of the range [1, 12]</exception>
    public static string ToMonthString(this int value)
    {
        return value switch
        {
            1 => "JANUARY",
            2 => "FEBRUARY",
            3 => "MARCH",
            4 => "APRIL",
            5 => "MAY",
            6 => "JUNE",
            7 => "JULY",
            8 => "AUGUST",
            9 => "SEPTEMBER",
            10 => "OCTOBER",
            11 => "NOVEMBER",
            12 => "DECEMBER",
            _ => throw new Exception($"Invalid month number: {value}")
        };
    }

    /// <summary>
    ///     Converts a month's full-uppercase string representation to its numerical value.
    /// </summary>
    /// <param name="value">String name of the month</param>
    /// <returns>Numerical value of the corresponding month</returns>
    /// <exception cref="Exception">Thrown when an invalid (or improperly formatted) month name is provided</exception>
    public static int ToMonthInt(this string value)
    {
        return value switch
        {
            "JANUARY" => 1,
            "FEBRUARY" => 2,
            "MARCH" => 3,
            "APRIL" => 4,
            "MAY" => 5,
            "JUNE" => 6,
            "JULY" => 7,
            "AUGUST" => 8,
            "SEPTEMBER" => 9,
            "OCTOBER" => 10,
            "NOVEMBER" => 11,
            "DECEMBER" => 12,
            _ => throw new Exception($"Invalid month: {value}")
        };
    }
}