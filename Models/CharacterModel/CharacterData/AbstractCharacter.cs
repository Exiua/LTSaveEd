namespace LTSaveEd.Models.CharacterModel.CharacterData;

public abstract class AbstractCharacter
{
    public string id { get; set; }

    public readonly string[] names = new string[3];

    protected int _femininity;
}