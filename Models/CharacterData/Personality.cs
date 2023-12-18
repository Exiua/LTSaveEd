using System.Xml.Linq;

namespace LTSaveEd.Models.CharacterData;

public class Personality
{
    public PersonalityTrait Confident { get; }
    public PersonalityTrait Shy { get; }
    public PersonalityTrait Kind { get; }
    public PersonalityTrait Selfish { get; }
    public PersonalityTrait Naive { get; }
    public PersonalityTrait Cynical { get; }
    public PersonalityTrait Brave { get; }
    public PersonalityTrait Cowardly { get; }
    public PersonalityTrait Lewd { get; }
    public PersonalityTrait Innocent { get; }
    public PersonalityTrait Prude { get; }
    public PersonalityTrait Lisp { get; }
    public PersonalityTrait Stutter { get; }
    public PersonalityTrait Mute { get; }
    public PersonalityTrait Slovenly { get; }

    public Personality(XElement personalityNode)
    {
        Confident = new PersonalityTrait(personalityNode, "CONFIDENT");
        Shy = new PersonalityTrait(personalityNode, "SHY");
        Shy.AddIncompatibleTraits(Confident);
        Kind= new PersonalityTrait(personalityNode, "KIND");
        Selfish = new PersonalityTrait(personalityNode, "SELFISH");
        Selfish.AddIncompatibleTraits(Kind);
        Naive = new PersonalityTrait(personalityNode, "NAIVE");
        Cynical = new PersonalityTrait(personalityNode, "CYNICAL");
        Cynical.AddIncompatibleTraits(Naive);
        Brave = new PersonalityTrait(personalityNode, "BRAVE");
        Cowardly = new PersonalityTrait(personalityNode, "COWARDLY");
        Cowardly.AddIncompatibleTraits(Brave);
        Lewd = new PersonalityTrait(personalityNode, "LEWD");
        Innocent = new PersonalityTrait(personalityNode, "INNOCENT");
        Prude = new PersonalityTrait(personalityNode, "PRUDE");
        Prude.AddIncompatibleTraits(Lewd, Innocent);
        Innocent.AddIncompatibleTraits(Lewd);
        Lisp = new PersonalityTrait(personalityNode, "LISP");
        Stutter = new PersonalityTrait(personalityNode, "STUTTER");
        Slovenly = new PersonalityTrait(personalityNode, "SLOVENLY");
        Mute = new PersonalityTrait(personalityNode, "MUTE");
        Mute.AddIncompatibleTraits(Lisp, Stutter, Slovenly);
        
        var traits = personalityNode.Elements();
        foreach (var trait in traits)
        {
            switch (trait.Value)
            {
                case "CONFIDENT":
                    Confident.Initialize(trait);
                    break;
                case "SHY":
                    Shy.Initialize(trait);
                    break;
                case "KIND":
                    Kind.Initialize(trait);
                    break;
                case "SELFISH":
                    Selfish.Initialize(trait);
                    break;
                case "NAIVE":
                    Naive.Initialize(trait);
                    break;
                case "CYNICAL":
                    Cynical.Initialize(trait);
                    break;
                case "BRAVE":
                    Brave.Initialize(trait);
                    break;
                case "COWARDLY":
                    Cowardly.Initialize(trait);
                    break;
                case "LEWD":
                    Lewd.Initialize(trait);
                    break;
                case "INNOCENT":
                    Innocent.Initialize(trait);
                    break;
                case "PRUDE":
                    Prude.Initialize(trait);
                    break;
                case "LISP":
                    Lisp.Initialize(trait);
                    break;
                case "STUTTER":
                    Stutter.Initialize(trait);
                    break;
                case "SLOVENLY":
                    Slovenly.Initialize(trait);
                    break;
                case "MUTE":
                    Mute.Initialize(trait);
                    break;
            }
        }
    }
}