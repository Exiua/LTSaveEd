namespace LTSaveEd.Models.CharacterData;

public class Parent(string id, string name, string femininity, string subspecies)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Femininity { get; set; } = femininity;
    public string Subspecies { get; set; } = subspecies;
}