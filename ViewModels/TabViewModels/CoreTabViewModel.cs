using System;
using System.Diagnostics;
using LTSaveEd.Models;
using LTSaveEd.Models.CharacterModel.CharacterCoreModel;
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

    public int Level
    {
        get => Core.level;
        set
        {
            Core.level = value; //TODO
            this.RaisePropertyChanged();
        }
    }

    public int Experience
    {
        get => Core.experience;
        set => this.RaisePropertyChanged();
    }

    public int Money
    {
        get => Core.money;
        set => this.RaisePropertyChanged();
    }

    public DateOnly Birthday
    {
        get => Core.dateOfBirth;
        set => this.RaisePropertyChanged();
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

    public double Obedience
    {
        get => Core.obedience;
        set => this.RaisePropertyChanged();
    }

    public string GenderIdentity
    {
        get => Core.genderIdentity;
        set => this.RaisePropertyChanged();
    }

    public int PerkPoints
    {
        get => Core.perkPoints;
        set => this.RaisePropertyChanged();
    }

    public int EssenceCount
    {
        get => Core.essenceCount;
        set => this.RaisePropertyChanged();
    }

    public double Health
    {
        get => Core.health;
        set => this.RaisePropertyChanged();
    }

    public double Mana
    {
        get => Core.mana;
        set => this.RaisePropertyChanged();
    }

    public bool Confident
    {
        get => Core.Personality.Confident;
        set => this.RaisePropertyChanged();
    }

    public bool Shy
    {
        get => Core.Personality.Shy;
        set => this.RaisePropertyChanged();
    }

    public bool Kind
    {
        get => Core.Personality.Kind;
        set => this.RaisePropertyChanged();
    }

    public bool Selfish
    {
        get => Core.Personality.Selfish;
        set => this.RaisePropertyChanged();
    }

    public bool Naive
    {
        get => Core.Personality.Naive;
        set => this.RaisePropertyChanged();
    }

    public bool Cynical
    {
        get => Core.Personality.Cynical;
        set => this.RaisePropertyChanged();
    }

    public bool Brave
    {
        get => Core.Personality.Brave;
        set => this.RaisePropertyChanged();
    }

    public bool Cowardly
    {
        get => Core.Personality.Cowardly;
        set => this.RaisePropertyChanged();
    }

    public bool Lewd
    {
        get => Core.Personality.Lewd;
        set => this.RaisePropertyChanged();
    }

    public bool Innocent
    {
        get => Core.Personality.Innocent;
        set => this.RaisePropertyChanged();
    }

    public bool Prude
    {
        get => Core.Personality.Prude;
        set => this.RaisePropertyChanged();
    }

    public bool Lisp
    {
        get => Core.Personality.Lisp;
        set => this.RaisePropertyChanged();
    }

    public bool Stutter
    {
        get => Core.Personality.Stutter;
        set => this.RaisePropertyChanged();
    }

    public bool Mute
    {
        get => Core.Personality.Mute;
        set => this.RaisePropertyChanged();
    }

    public bool Slovenly
    {
        get => Core.Personality.Slovenly;
        set => this.RaisePropertyChanged();
    }

    public override void PopulateTab()
    {
        PopulateCharacterComboBox();
        this.RaisePropertyChanged(nameof(CharacterId));
        this.RaisePropertyChanged(nameof(AndrogynousName));
        this.RaisePropertyChanged(nameof(FeminineName));
        this.RaisePropertyChanged(nameof(MasculineName));
    }
    
    private void PopulateCharacterComboBox()
    {
        var npcs = SaveFileData.GetNpcList();
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