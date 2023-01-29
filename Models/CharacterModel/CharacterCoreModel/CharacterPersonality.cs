using System.Diagnostics;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Models.CharacterModel.CharacterCoreModel;

public class CharacterPersonality
{
    private bool _confident;
    private bool _shy;
    private bool _kind;
    private bool _selfish;
    private bool _naive;
    private bool _cynical;
    private bool _brave;
    private bool _cowardly;
    private bool _lewd;
    private bool _innocent;
    private bool _prude;
    private bool _lisp;
    private bool _stutter;
    private bool _mute;
    private bool _slovenly;

    public bool Confident
    {
        get => _confident;
        set
        {
            _confident = value;
            _shy = false;
        }
    }

    public bool Shy
    {
        get => _shy;
        set
        {
            _shy = value;
            _confident = false;
        }
    }

    public bool Kind
    {
        get => _kind;
        set
        {
            _kind = value;
            _selfish = false;
        }
    }

    public bool Selfish
    {
        get => _selfish;
        set
        {
            _selfish = value;
            _kind = false;
        }
    }

    public bool Naive
    {
        get => _naive;
        set
        {
            _naive = value;
            _cynical = false;
        }
    }

    public bool Cynical
    {
        get => _cynical;
        set
        {
            _cynical = value;
            _naive = false;
        }
    }

    public bool Brave
    {
        get => _brave;
        set
        {
            _brave = value;
            _cowardly = false;
        }
    }

    public bool Cowardly
    {
        get => _cowardly;
        set
        {
            _cowardly = value;
            _brave = false;
        }
    }

    public bool Lewd
    {
        get => _lewd;
        set
        {
            _lewd = value;
            _prude = false;
            _innocent = false;
        }
    }

    public bool Innocent
    {
        get => _innocent;
        set
        {
            _innocent = value;
            _prude = false;
            _lewd = false;
        }
    }

    public bool Prude
    {
        get => _prude;
        set
        {
            _prude = value;
            _lewd = false;
            _innocent = false;
        }
    }

    public bool Lisp
    {
        get => _lisp;
        set
        {
            _lisp = value;
            _mute = false;
        }
    }

    public bool Stutter
    {
        get => _stutter;
        set
        {
            _stutter = value;
            _mute = false;
        }
    }

    public bool Mute
    {
        get => _mute;
        set
        {
            _mute = value;
            _lisp = false;
            _stutter = false;
            _slovenly = false;
        }
    }

    public bool Slovenly
    {
        get => _slovenly;
        set
        {
            _slovenly = value;
            _mute = false;
        }
    }

    public CharacterPersonality(XElement personalityElement)
    {
        if (personalityElement.Name != "personality")
        {
            throw new IncorrectElementException(personalityElement);
        }
        
        var traits = personalityElement.Elements();
        foreach (var trait in traits)
        {
            switch (trait.Value)
            {
                case "CONFIDENT":
                    _confident = true;
                    break;
                case "SHY":
                    _shy = true;
                    break;
                case "KIND":
                    _kind = true;
                    break;
                case "SELFISH":
                    _selfish = true;
                    break;
                case "NAIVE":
                    _naive = true;
                    break;
                case "CYNICAL":
                    _cynical = true;
                    break;
                case "BRAVE":
                    _brave = true;
                    break;
                case "COWARDLY":
                    _cowardly = true;
                    break;
                case "LEWD":
                    _lewd = true;
                    break;
                case "INNOCENT":
                    _innocent = true;
                    break;
                case "PRUDE":
                    _prude = true;
                    break;
                case "LISP":
                    _lisp = true;
                    break;
                case "STUTTER":
                    _stutter = true;
                    break;
                case "SLOVENLY":
                    _slovenly = true;
                    break;
                case "MUTE":
                    _mute = true;
                    break;
                default:
                    Debug.WriteLine($"Unknown Value Encountered: {trait.Value}");
                    break;
            }
        }
    }
}