namespace LTSaveEd.Models;

public class ValueDisplayPair<T>(string displayValue, T value)
{
    public string DisplayValue { get; } = displayValue;
    public T Value { get; } = value;
    
    public override string ToString()
    {
        return DisplayValue;
    }
}