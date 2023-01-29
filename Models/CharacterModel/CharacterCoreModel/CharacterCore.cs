using System;
using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Utility;

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

    private static XElement CurrentCharacterElement => SaveFile.savefile.currentCharacterElement;
    
    public CharacterCore(XElement coreElement)
    {
        if (coreElement.Name != "core")
        {
            throw new IncorrectElementException(coreElement);
        }

        id = GetChildAttributeValue("id");
        name = new CharacterName(CurrentCharacterElement.GetChildByName("name"));
        surname = GetChildAttributeValue("surname");
        description = GetChildAttributeValue("description");
        level = GetChildAttributeIntValue("level");
        experience = GetChildAttributeIntValue("experience");
        money = int.Parse(CurrentCharacterElement.GetChildBySequence("characterInventory", "money").FirstAttribute?.Value ?? "-1");
        dateOfBirth = GetDateOfBirth(coreElement);
        JobHistory = GetChildAttributeValue("history");
        orientnation = GetChildAttributeValue("sexualOrientation");
        obedience = GetChildAttributeDoubleValue("obedience");
        genderIdentity = GetChildAttributeValue("genderIdentity");
        perkPoints = GetChildAttributeIntValue("perkPoints");
        essenceCount = int.Parse(CurrentCharacterElement.GetChildBySequence("characterInventory", "essenceCount").FirstAttribute?.Value ?? "-1");;
        health = GetChildAttributeDoubleValue("health");
        mana = GetChildAttributeDoubleValue("mana");
        Personality = new CharacterPersonality(CurrentCharacterElement.GetChildByName("personality"));
    }

    private DateOnly GetDateOfBirth(XElement coreElement)
    {
        var year = int.Parse(coreElement.GetChildAttributeByName("yearOfBirth").Value);
        var monthString = coreElement.GetChildAttributeByName("monthOfBirth").Value;
        var month = MonthStringToInt(monthString);
        var day = int.Parse(coreElement.GetChildAttributeByName("dayOfBirth").Value);
        var dob = new DateOnly(year, month, day);
        return dob;
    }

    private int MonthStringToInt(string monthName) =>
        monthName switch
        {
            "JANUARY" => 1,
            "FEBRUARY" => 2,
            "MARCH" => 3,
            "APRIL" => 4,
            "MAY" => 5,
            "JUNE" => 6,
            "JULY" => 7,
            "AUGUST" => 8,
            "SEPTEMBER" => 9,
            "OCTOBER" => 10,
            "NOVEMBER" => 11,
            "DECEMBER" => 12,
            _ => throw new Exception($"Invalid Month: {monthName}")
        };

    private string GetChildAttributeValue(string tagName)
    {
        return CurrentCharacterElement.GetChildAttributeValue(tagName);
    }

    private int GetChildAttributeIntValue(string tagName)
    {
        var value = GetChildAttributeValue(tagName);
        if (value == "NULL")
        {
            throw new ValueNotFoundException(tagName);
        }

        return int.Parse(value);
    }
    
    private float GetChildAttributeDoubleValue(string tagName)
    {
        var value = GetChildAttributeValue(tagName);
        if (value == "NULL")
        {
            throw new ValueNotFoundException(tagName);
        }

        return float.Parse(value);
    }
    
    private bool GetChildAttributeBoolValue(string tagName)
    {
        var value = GetChildAttributeValue(tagName);
        if (value == "NULL")
        {
            throw new ValueNotFoundException(tagName);
        }

        return bool.Parse(value);
    }
}