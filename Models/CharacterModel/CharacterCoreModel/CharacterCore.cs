using System;
using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterModel.CharacterCoreModel;

public class CharacterCore
{
    public string id { get; set; }
    public CharacterName name { get; set; }
    public string surname { get; set; }
    public string description { get; set; }
    public int level { get; set; }
    public int experience { get; set; }
    public int money { get; set; }
    public DateOnly dateOfBirth { get; set; }
    public string JobHistory { get; set; }
    public string orientnation { get; set; }
    public double obedience { get; set; }
    public string genderIdentity { get; set; }
    public int perkPoints { get; set; }
    public int essenceCount { get; set; }
    public float health  { get; set; }
    public float mana { get; set; }
    public CharacterPersonality Personality  { get; set; }

    public CharacterCore(XElement coreElement)
    {
        if (coreElement.Name != "core")
        {
            throw new Exception("Incorrect Element Supplied" + coreElement);
        }
    }
}