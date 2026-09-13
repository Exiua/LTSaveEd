namespace LTSaveEd.Utility;

public class ErrorMessage(string message)
{
    public string Message { get; } = message;

    public override string ToString()
    {
        return Message;
    }

    public static implicit operator ErrorMessage(string message) => new(message);
}