namespace LTSaveEd;

public static class ExtensionMethods
{
    public static string ToFormattedString<T>(this IEnumerable<T> list)
    {
        var output = string.Join(", ", list);
        return $"[{output}]";
    }
}