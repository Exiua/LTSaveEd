using System;
using System.Diagnostics;
using LTSaveEd.Models;
using LTSaveEd.Utility;
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
    
    public string CharacterId
    {
        get => _characterId;
        set => this.RaiseAndSetIfChanged(ref _characterId, value);
    }
    public string AndrogynousName
    {
        get => _androgynousName;
        set => this.RaiseAndSetIfChanged(ref _androgynousName, value);
    }
    public string FeminineName
    {
        get => _feminineName;
        set => this.RaiseAndSetIfChanged(ref _feminineName, value);
    }
    public string MasculineName
    {
        get => _masculineName;
        set => this.RaiseAndSetIfChanged(ref _masculineName, value);
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public int Level
    {
        get => level;
        set => this.RaiseAndSetIfChanged(ref level, value);
    }

    public int Experience
    {
        get => experience;
        set => this.RaiseAndSetIfChanged(ref experience, value);
    }

    public int Money
    {
        get => money;
        set => this.RaiseAndSetIfChanged(ref money, value);
    }

    public DateOnly Birthday
    {
        get => birthday;
        set => this.RaiseAndSetIfChanged(ref birthday, value);
    }

    public string JobHistory
    {
        get => _jobHistory;
        set => this.RaiseAndSetIfChanged(ref _jobHistory, value);
    }

    public string Orientation
    {
        get => orientation;
        set => this.RaiseAndSetIfChanged(ref orientation, value);
    }

    public double Obedience
    {
        get => obedience;
        set => this.RaiseAndSetIfChanged(ref obedience, value);
    }

    public string GenderIdentity
    {
        get => genderIdentity;
        set => this.RaiseAndSetIfChanged(ref genderIdentity, value);
    }

    public int PerkPoints
    {
        get => perkPoints;
        set => this.RaiseAndSetIfChanged(ref perkPoints, value);
    }

    public int EssenceCount
    {
        get => essenceCount;
        set => this.RaiseAndSetIfChanged(ref essenceCount, value);
    }

    public double Health
    {
        get => health;
        set => this.RaiseAndSetIfChanged(ref health, value);
    }

    public double Mana
    {
        get => mana;
        set => this.RaiseAndSetIfChanged(ref mana, value);
    }

    public bool Confident
    {
        get => confident;
        set => this.RaiseAndSetIfChanged(ref confident, value);
    }

    public bool Shy
    {
        get => shy;
        set => this.RaiseAndSetIfChanged(ref shy, value);
    }

    public bool Kind
    {
        get => kind;
        set => this.RaiseAndSetIfChanged(ref kind, value);
    }

    public bool Selfish
    {
        get => selfish;
        set => this.RaiseAndSetIfChanged(ref selfish, value);
    }

    public bool Naive
    {
        get => naive;
        set => this.RaiseAndSetIfChanged(ref naive, value);
    }

    public bool Cynical
    {
        get => cynical;
        set => this.RaiseAndSetIfChanged(ref cynical, value);
    }

    public bool Brave
    {
        get => brave;
        set => this.RaiseAndSetIfChanged(ref brave, value);
    }

    public bool Cowardly
    {
        get => _cowardly;
        set => this.RaiseAndSetIfChanged(ref _cowardly, value);
    }

    public bool Lewd
    {
        get => lewd;
        set => this.RaiseAndSetIfChanged(ref lewd, value);
    }

    public bool Innocent
    {
        get => innocent;
        set => this.RaiseAndSetIfChanged(ref innocent, value);
    }

    public bool Prude
    {
        get => prude;
        set => this.RaiseAndSetIfChanged(ref prude, value);
    }

    public bool Lisp
    {
        get => lisp;
        set => this.RaiseAndSetIfChanged(ref lisp, value);
    }

    public bool Stutter
    {
        get => stutter;
        set => this.RaiseAndSetIfChanged(ref stutter, value);
    }

    public bool Mute
    {
        get => mute;
        set => this.RaiseAndSetIfChanged(ref mute, value);
    }

    public bool Slovenly
    {
        get => _slovenly;
        set => this.RaiseAndSetIfChanged(ref _slovenly, value);
    }

    public override void PopulateTab()
    {
        PopulateCharacterComboBox();
        CharacterId = SaveFile.currentCharacter.GetDescendantByName("id").FirstAttribute?.Value ?? "NULL";
    }
    
    private void PopulateCharacterComboBox()
    {
        var npcs = SaveFile.GetNpcList();
        //npcs.Print();
        Debug.WriteLine("Populated Character ComboBox");
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