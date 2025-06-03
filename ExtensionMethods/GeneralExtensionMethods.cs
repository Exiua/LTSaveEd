namespace LTSaveEd.ExtensionMethods;

/// <summary>
///     General extension methods
/// </summary>
public static class GeneralExtensionMethods
{
    /// <summary>
    ///     Convert an enumerable collection to a formatted string in the form of [item1, item2, item3, ...]
    /// </summary>
    /// <param name="list">Enumerable collection to format</param>
    /// <typeparam name="T">Type of the elements</typeparam>
    /// <returns>Formatted string using values from the provided collection</returns>
    public static string ToFormattedString<T>(this IEnumerable<T> list)
    {
        var output = string.Join(", ", list);
        return $"[{output}]";
    }

    public static void Pop<T>(this List<T> list)
    {
        list.RemoveAt(list.Count - 1);
    }
}