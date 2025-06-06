namespace LTSaveEd.Utility;

public class Box<T>(T value)
    where T : struct
{
    public T Value { get; set; } = value;
    
    public static implicit operator T(Box<T> box) => box.Value;
}