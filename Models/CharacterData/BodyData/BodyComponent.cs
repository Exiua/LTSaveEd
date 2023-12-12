namespace LTSaveEd.Models.CharacterData.BodyData;

public abstract class BodyComponent(Body body)
{
    protected Body Body { get; } = body;
}