using System;
using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.CharacterCoreModel;

public class CharacterCore
{
    private readonly string _id;
    private readonly CharacterName _name;
    private string _surname;
    private string _description;
    private int _level;
    private int _experience;
    private int _money;
    private DateOnly _dateOfBirth;
    private string _jobHistory;
    private string _orientation;
    private double _obedience;
    private string _genderIdentity;
    private int _perkPoints;
    private int _essenceCount;
    private double _health;
    private double _mana;
    private CharacterPersonality _personality;

    public string Id
    {
        get => _id;
    }

    public CharacterName Name
    {
        get => _name;
    }


    public string Surname
    {
        get => _surname;
        set => _surname = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public int Level
    {
        get => _level;
        set => _level = value;
    }

    public int Experience
    {
        get => _experience;
        set => _experience = value;
    }

    public int money
    {
        get => _money;
        set => _money = value;
    }

    public DateOnly dateOfBirth
    {
        get => _dateOfBirth;
        set => _dateOfBirth = value;
    }

    public int dayOfBirth
    {
        get => _dateOfBirth.Day;
        set => _dateOfBirth = new DateOnly(_dateOfBirth.Year, dateOfBirth.Month, value);
    }

    public int monthOfBirth
    {
        get => _dateOfBirth.Month;
        set => _dateOfBirth = new DateOnly(_dateOfBirth.Year, value, dateOfBirth.Day);
    }

    public int yearOfBirth
    {
        get => _dateOfBirth.Year;
        set => _dateOfBirth = new DateOnly(value, dateOfBirth.Month, dateOfBirth.Day);
    }
    
    public string JobHistory
    {
        get => _jobHistory;
        set => _jobHistory = value;
    }

    public string Orientation
    {
        get => _orientation;
        set => _orientation = value;
    }

    public double obedience
    {
        get => _obedience;
        set => _obedience = value;
    }

    public string genderIdentity
    {
        get => _genderIdentity;
        set => _genderIdentity = value;
    }

    public int perkPoints
    {
        get => _perkPoints;
        set => _perkPoints = value;
    }

    public int essenceCount
    {
        get => _essenceCount;
        set => _essenceCount = value;
    }

    public double health
    {
        get => _health;
        set => _health = value;
    }

    public double mana
    {
        get => _mana;
        set => _mana = value;
    }

    public CharacterPersonality Personality
    {
        get => _personality;
    }

    public bool player { get; }

    private static XElement CurrentCharacterElement => SaveFileData.savefile.currentCharacterElement;
    private XElement coreElement { get; } = null!;

    public CharacterCore()
    {
        _id = "";
        _name = new CharacterName();
        _surname = "";
        _description = "";
        _jobHistory = "";
        _orientation = "";
        _genderIdentity = "";
        _personality = new CharacterPersonality();
        player = false;
    }
    
    public CharacterCore(XElement coreElement)
    {
        if (coreElement.Name != "core")
        {
            throw new IncorrectElementException(coreElement);
        }

        this.coreElement = coreElement;
        _id = GetChildAttributeValue("id");
        player = _id == "PlayerCharacter";
        _name = new CharacterName(coreElement.GetChildByName("name"));
        _surname = GetChildAttributeValue("surname");
        _description = GetChildAttributeValue("description");
        _level = GetChildAttributeIntValue("level");
        _experience = GetChildAttributeIntValue("experience");
        _money = int.Parse(CurrentCharacterElement.GetChildBySequence("characterInventory", "money").FirstAttribute?.Value ?? "-1");
        _dateOfBirth = GetDateOfBirth();
        _jobHistory = GetChildAttributeValue("history");
        _orientation = GetChildAttributeValue("sexualOrientation");
        _obedience = GetChildAttributeDoubleValue("obedience");
        _genderIdentity = GetChildAttributeValue("genderIdentity");
        _perkPoints = GetChildAttributeIntValue("perkPoints");
        _essenceCount = int.Parse(CurrentCharacterElement.GetChildBySequence("characterInventory", "essenceCount").FirstAttribute?.Value ?? "-1");;
        _health = GetChildAttributeDoubleValue("health");
        _mana = GetChildAttributeDoubleValue("mana");
        _personality = new CharacterPersonality(coreElement.GetChildByName("personality"));
    }

    private DateOnly GetDateOfBirth()
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
        return coreElement.GetChildAttributeValue(tagName);
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