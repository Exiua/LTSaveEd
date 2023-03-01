using System;
using System.Diagnostics;
using System.Globalization;
using LTSaveEd.Models.CharacterModel.CharacterCoreModel;
using ReactiveUI;

namespace LTSaveEd.ViewModels;

public class CoreTabViewModel : TabViewModel
{
    private string _characterId = "";
    private string _androgynousName = "";
    private string _feminineName = "";
    private string _masculineName = "";
    private string _description = "";
    private int level = 0;
    private int experience = 0;
    private int money = 0;
    private DateOnly birthday = DateOnly.MinValue;
    private string _jobHistory = "COMBOBOX";
    private string orientation = "COMBOBOX";
    private double obedience = 0f;
    private string genderIdentity = "COMBOBOX";
    private int perkPoints = 0;
    private int essenceCount = 0;
    private double health = 0f;
    private double mana = 0f;
    private bool confident = false;
    private bool shy;
    private bool kind;
    private bool selfish;
    private bool naive;
    private bool cynical;
    private bool brave;
    private bool _cowardly;
    private bool lewd;
    private bool innocent;
    private bool prude;
    private bool lisp;
    private bool stutter;
    private bool mute;
    private bool _slovenly;

    private static CharacterCore Core => Character.core;

    public string CharacterId
    {
        get => Core.id;
        set
        {
            Core.id = value;
            this.RaisePropertyChanged();
        }
    }

    public string AndrogynousName
    {
        get => Core.name.androgynous;
        set
        {
            Core.name.androgynous = value;
            this.RaisePropertyChanged();
        }
    }

    public string FeminineName
    {
        get => Core.name.feminine;
        set
        {
            Core.name.feminine = value;
            this.RaisePropertyChanged();
        }
    }

    public string MasculineName
    {
        get => Core.name.masculine;
        set
        {
            Core.name.masculine = value;
            this.RaisePropertyChanged();
        }
    }

    public string Description
    {
        get => Core.description;
        set
        {
            Core.description = value;
            this.RaisePropertyChanged();
        }
    }

    public string Level
    {
        get => Core.level.ToString();
        set
        {
            Core.level = ValidateInt(value, Core.level);
            this.RaisePropertyChanged();
        }
    }

    public string Experience
    {
        get => Core.experience.ToString();
        set
        {
            Core.experience = ValidateInt(value, Core.experience);
            this.RaisePropertyChanged();
        }
    }

    public string Money
    {
        get => Core.money.ToString();
        set
        {
            Core.money = ValidateInt(value, Core.money);
            this.RaisePropertyChanged();
        }
    }

    public DateOnly Birthday
    {
        get => Core.dateOfBirth;
        set => this.RaisePropertyChanged();
    }

    public string dayOfBirth
    {
        get => Core.dayOfBirth.ToString();
        set
        {
            Core.dayOfBirth = ValidateDayOfMonth(value, Core.dateOfBirth);
            this.RaisePropertyChanged();
        }
    }

    public int monthOfBirth
    {
        get => Core.monthOfBirth;
        set
        {
            Core.monthOfBirth = value;
            this.RaisePropertyChanged();
        }
    }

    public string yearOfBirth
    {
        get => Core.yearOfBirth.ToString();
        set
        {
            Core.yearOfBirth = ValidateInt(value, Core.yearOfBirth);
            this.RaisePropertyChanged();
        }
    }

    public string JobHistory
    {
        get => Core.JobHistory;
        set => this.RaisePropertyChanged();
    }

    public string Orientation
    {
        get => Core.Orientation;
        set => this.RaisePropertyChanged();
    }

    public string Obedience
    {
        get => Core.obedience.ToString(CultureInfo.InvariantCulture);
        set
        {
            Core.obedience = ValidateDouble(value, Core.obedience);
            this.RaisePropertyChanged();
        }
    }

    public string GenderIdentity
    {
        get => Core.genderIdentity;
        set => this.RaisePropertyChanged();
    }

    public string PerkPoints
    {
        get => Core.perkPoints.ToString();
        set
        {
            Core.perkPoints = ValidateInt(value, Core.perkPoints);
            this.RaisePropertyChanged();
        }
    }

    public string EssenceCount
    {
        get => Core.essenceCount.ToString();
        set
        {
            Core.essenceCount = ValidateInt(value, Core.essenceCount);
            this.RaisePropertyChanged();
        }
    }

    public string Health
    {
        get => Core.health.ToString(CultureInfo.InvariantCulture);
        set
        {
            Core.health = ValidateDouble(value, Core.health);
            this.RaisePropertyChanged();
        }
    }

    public string Mana
    {
        get => Core.mana.ToString(CultureInfo.InvariantCulture);
        set
        {
            Core.mana = ValidateDouble(value, Core.mana);
            this.RaisePropertyChanged();
        }
    }

    public bool Confident
    {
        get => Core.Personality.Confident;
        set
        {
            Core.Personality.Confident = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Shy
    {
        get => Core.Personality.Shy;
        set
        {
            Core.Personality.Shy = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Kind
    {
        get => Core.Personality.Kind;
        set
        {
            Core.Personality.Kind = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Selfish
    {
        get => Core.Personality.Selfish;
        set
        {
            Core.Personality.Selfish = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Naive
    {
        get => Core.Personality.Naive;
        set
        {
            Core.Personality.Naive = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Cynical
    {
        get => Core.Personality.Cynical;
        set
        {
            Core.Personality.Cynical = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Brave
    {
        get => Core.Personality.Brave;
        set
        {
            Core.Personality.Brave = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Cowardly
    {
        get => Core.Personality.Cowardly;
        set
        {
            Core.Personality.Cowardly = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Lewd
    {
        get => Core.Personality.Lewd;
        set
        {
            Core.Personality.Lewd = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Innocent
    {
        get => Core.Personality.Innocent;
        set
        {
            Core.Personality.Innocent = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Prude
    {
        get => Core.Personality.Prude;
        set
        {
            Core.Personality.Prude = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Lisp
    {
        get => Core.Personality.Lisp;
        set
        {
            Core.Personality.Lisp = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Stutter
    {
        get => Core.Personality.Stutter;
        set
        {
            Core.Personality.Stutter = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Mute
    {
        get => Core.Personality.Mute;
        set
        {
            Core.Personality.Mute = value;
            this.RaisePropertyChanged();
        }
    }

    public bool Slovenly
    {
        get => Core.Personality.Slovenly;
        set
        {
            Core.Personality.Slovenly = value;
            this.RaisePropertyChanged();
        }
    }

    public override void PopulateTab()
    {
        PopulateCharacterComboBox();
        var propertyNames = new[]
        {
            nameof(CharacterId), nameof(AndrogynousName), nameof(FeminineName), nameof(MasculineName),
            nameof(Description), nameof(Level), nameof(Experience), nameof(Money), nameof(Birthday), nameof(JobHistory),
            nameof(Orientation), nameof(Obedience), nameof(GenderIdentity), nameof(PerkPoints), nameof(EssenceCount),
            nameof(Health), nameof(Mana), nameof(Confident), nameof(Shy), nameof(Kind), nameof(Selfish), nameof(Naive),
            nameof(Cynical), nameof(Brave), nameof(Cowardly), nameof(Lewd), nameof(Innocent), nameof(Prude),
            nameof(Lisp), nameof(Stutter), nameof(Mute), nameof(Slovenly)
        };

        foreach (var propertyName in propertyNames)
        {
            this.RaisePropertyChanged(propertyName);
        }
    }

    private void PopulateCharacterComboBox()
    {
        var npcs = SaveFileData.GetNpcList();
        //npcs.Print();
        Debug.WriteLine("Populated Character ComboBox");
    }

    private int ValidateInt(string value, int oldValue, bool allowNegative = false)
    {
        Debug.WriteLine($"New: {value}, Old: {oldValue}");
        if (allowNegative)
        {
            return int.TryParse(value, out var newValue) ? newValue : oldValue;
        }
        else
        {
            return int.TryParse(value, out var newValue) && newValue >= 0 ? newValue : oldValue;
        }
    }
    
    private int ValidateDayOfMonth(string value, DateOnly date)
    {
        var day = ValidateInt(value, date.Day);
        if (day == date.Day)
        {
            return day;
        }

        var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        if (day == 0 || day > daysInMonth)
        {
            return date.Day;
        }
        
        return day;
    }

    private double ValidateDouble(string value, double oldValue, bool allowNegative = false)
    {
        Debug.WriteLine($"New: {value}, Old: {oldValue}");
        if (allowNegative)
        {
            return double.TryParse(value, out var newValue) ? newValue : oldValue;
        }
        else
        {
            return double.TryParse(value, out var newValue) && newValue >= 0 ? newValue : oldValue;
        }
    }

    public void ToggleConfidentTrait()
    {
        if (Confident)
        {
            Shy = false;
        }
    }

    public void ToggleShyTrait()
    {
        if (Shy)
        {
            Confident = false;
        }
    }

    public void ToggleSelfishTrait()
    {
        if (Selfish)
        {
            Kind = false;
        }
    }

    public void ToggleKindTrait()
    {
        if (Kind)
        {
            Selfish = false;
        }
    }

    public void ToggleCynicalTrait()
    {
        if (Cynical)
        {
            Naive = false;
        }
    }

    public void ToggleNaiveTrait()
    {
        if (Naive)
        {
            Cynical = false;
        }
    }

    public void ToggleCowardlyTrait()
    {
        if (Cowardly)
        {
            Brave = false;
        }
    }

    public void ToggleBraveTrait()
    {
        if (Brave)
        {
            Cowardly = false;
        }
    }

    public void TogglePrudeTrait()
    {
        if (Prude)
        {
            Lewd = false;
            Innocent = false;
        }
    }

    public void ToggleLewdTrait()
    {
        if (Lewd)
        {
            Prude = false;
            Innocent = false;
        }
    }

    public void ToggleInnocentTrait()
    {
        if (Innocent)
        {
            Prude = false;
            Lewd = false;
        }
    }

    public void ToggleMuteTrait()
    {
        if (Mute)
        {
            Lisp = false;
            Stutter = false;
            Slovenly = false;
        }
    }

    public void ToggleLispTrait()
    {
        if (Lisp)
        {
            Mute = false;
        }
    }

    public void ToggleStutterTrait()
    {
        if (Stutter)
        {
            Mute = false;
        }
    }

    public void ToggleSlovenlyTrait()
    {
        if (Slovenly)
        {
            Mute = false;
        }
    }
}