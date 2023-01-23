using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LTSaveEd.Utility;

public static class ExtensionMethods
{
    public static void Print<T>(this IEnumerable<T> array)
    {
        var output = array.Aggregate("[", (current, el) => current + $"{el}, ");
        output = string.Concat(output.AsSpan(0, output.Length - 2), "]");
        Debug.WriteLine(output);
    }
}