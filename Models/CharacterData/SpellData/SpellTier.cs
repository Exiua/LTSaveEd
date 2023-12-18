namespace LTSaveEd.Models.CharacterData.SpellData;

public class SpellTier(string name, string value) : ValueDisplayPair(name, value)
{
    private static string[] Endings { get; } = ["_UNOWNED", "_3A", "_3B", "_3", "_2", "_1"];

    public string Type { get; } = ReadType(value);
    public int Tier { get; } = ReadTier(value);

    private static char GetLastNum(string str){
        var num = str[^1];
        if(num is 'A' or 'B'){
            num = '3';
        }
        return num;
    }
    
    public static string ReadType(string str){
        return Endings.Aggregate(str, (current, replacement) => current.Replace(replacement, ""));
    }
    
    public static int ReadTier(string value)
    {
        var valueType = ReadType(value);
        if(value.EndsWith("UNOWNED")){
            return -1;
        }
        
        if(value == valueType){
            return 0;
        }

        if (valueType != "STEAL")
        {
            return (int)char.GetNumericValue(GetLastNum(value));
        }
        
        if(value.EndsWith("3A")){
            return 3;
        }
            
        if(value.EndsWith("3B")){
            return 4;
        }
            
        return (int)char.GetNumericValue(GetLastNum(value));
    }
}