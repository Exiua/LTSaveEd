using System.Globalization;

namespace LTSaveEd.Utility;

public static class TypeHelper
{
    public static int ParseInt(string s)
    {
        return int.Parse(s);
    }
    
    public static float ParseFloat(string s)
    {
        return float.Parse(s, CultureInfo.InvariantCulture);
    }

    public static double ParseDouble(string s)
    {
        return double.Parse(s, CultureInfo.InvariantCulture);
    }
    
    public static bool ParseBool(string s)
    {
        return bool.Parse(s);
    }
}