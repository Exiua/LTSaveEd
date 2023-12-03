namespace LTSaveEd.Models;

public class ValueDisplayPair(string displayValue, string value)
{
    public string DisplayValue { get; } = displayValue;
    public string Value { get; } = value;

    public override string ToString()
    {
        return DisplayValue;
    }
    
    private bool Equals(ValueDisplayPair other)
    {
        return string.Equals(Value, other.Value, StringComparison.InvariantCulture);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }
        if (ReferenceEquals(this, obj))
        {
            return true;
        }
        return obj.GetType() == GetType() && Equals((ValueDisplayPair)obj);
    }

    public override int GetHashCode()
    {
        return StringComparer.InvariantCulture.GetHashCode(Value);
    }

    public static bool operator ==(ValueDisplayPair? left, ValueDisplayPair? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueDisplayPair? left, ValueDisplayPair? right)
    {
        return !Equals(left, right);
    }
}