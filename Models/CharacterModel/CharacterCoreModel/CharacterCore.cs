using System;
using System.Xml.Linq;
using LTSaveEd.Exceptions;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.CharacterCoreModel;

public class CharacterCore
{
    private string _id;
    private CharacterName _name;
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
    private float _health;
    private float _mana;
    private CharacterPersonality _personality;

    public string id
    {
        get => _id;
        set => _id = value;
    }

    public CharacterName name
    {
        get => _name;
        set => _name = value;
    }

    public string surname
    {
        get => _surname;
        set => _surname = value;
    }

    public string description
    {
        get => _description;
        set => _description = value;
    }

    public int level
    {
        get => _level;
        set => _level = value;
    }

    public int experience
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

    public float health
    {
        get => _health;
        set => _health = value;
    }

    public float mana
    {
        get => _mana;
        set => _mana = value;
    }

    public CharacterPersonality Personality
    {
        get => _personality;
        set => _personality = value;
    }

    private static XElement CurrentCharacterElement => SaveFileData.savefile.currentCharacterElement;
    private XElement coreElement { get; set; } = null!;

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
    }
    
    public CharacterCore(XElement coreElement)
    {
        if (coreElement.Name != "core")
        {
            throw new IncorrectElementException(coreElement);
        }

        this.coreElement = coreElement;
        _id = GetChildAttributeValue("id");
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