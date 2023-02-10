using System;

namespace LTSaveEd.Models.CharacterModel;

public class Attribute
{
    public Attribute(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>
    ///     Display name of attribute
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    ///     Actual value of attribute
    /// </summary>
    public string Value { get; }

    public override string ToString()
    {
        return $"{nameof(Attribute)}{{{nameof(Name)}: {Name}, {nameof(Value)}: {Value}}}";
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

        return obj switch
        {
            Attribute attribute => Value == attribute.Value,
            string str => Value == str,
            _ => false
        };
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Value);
    }

    public static bool operator ==(Attribute attribute, string value)
    {
        return attribute.Value == value;
    }

    public static bool operator !=(Attribute attribute, string value)
    {
        return !(attribute == value);
    }

    public static bool operator ==(Attribute attribute1, Attribute attribute2)
    {
        return attribute1.Value == attribute2.Value;
    }

    public static bool operator !=(Attribute attribute1, Attribute attribute2)
    {
        return !(attribute1 == attribute2.Value);
    }
}