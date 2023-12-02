namespace LTSaveEd.ExtensionMethods;

public static class GeneralExtensionMethods
{
    public static string ToFormattedString<T>(this IEnumerable<T> list)
    {
        var output = string.Join(", ", list);
        return $"[{output}]";
    }
}