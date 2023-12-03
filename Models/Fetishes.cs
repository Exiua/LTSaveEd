using System.Xml.Linq;

namespace LTSaveEd.Models;

public class Fetishes
{
    public Fetish Dominant { get; } = null!;
    public Fetish Submissive { get; } = null!;
    public Fetish Vaginal { get; } = null!;
    public Fetish PussySlut { get; } = null!;
    public Fetish CockStud { get; } = null!;
    public Fetish CockAddict { get; } = null!;
    public Fetish Anal { get; } = null!;
    public Fetish Buttslut { get; } = null!;
    public Fetish BreastLover { get; } = null!;
    public Fetish Breasts { get; } = null!;
    public Fetish MilkLover { get; } = null!;
    public Fetish Lactation { get; } = null!;
    public Fetish Oral { get; } = null!;
    public Fetish OralPerformer { get; } = null!;
    public Fetish LegLover { get; } = null!;
    public Fetish Strutter { get; } = null!;
    public Fetish DominantFoot { get; } = null!;
    public Fetish SubmissiveFoot { get; } = null!;
    public Fetish ArmpitLover { get; } = null!;
    public Fetish ArmpitSlut { get; } = null!;
    public Fetish CumStud { get; } = null!;
    public Fetish CumAddict { get; } = null!;
    public Fetish Deflowering { get; } = null!;
    public Fetish VaginalVirginity { get; } = null!;
    public Fetish Impregnation { get; } = null!;
    public Fetish Pregnancy { get; } = null!;
    public Fetish Transformer { get; } = null!;
    public Fetish TestSubject { get; } = null!;
    public Fetish KinkAdvocate { get; } = null!;
    public Fetish KinkCurious { get; } = null!;
    public Fetish Sadist { get; } = null!;
    public Fetish Masochist { get; } = null!;
    public Fetish NonConsent { get; } = null!;
    public Fetish UnwillingFuckToy { get; } = null!;
    public Fetish BondageApplier { get; } = null!;
    public Fetish BondageBitch { get; } = null!;
    public Fetish OrgasmDenier { get; } = null!;
    public Fetish SelfDenial { get; } = null!;
    public Fetish Voyeurist { get; } = null!;
    public Fetish Exhibitionist { get; } = null!;
    public Fetish Bimbo { get; } = null!;
    public Fetish CrossDressing { get; } = null!;
    public Fetish Masturbation { get; } = null!;
    public Fetish Incest { get; } = null!;
    public Fetish SizeQueen { get; } = null!;
    public Fetish Switch { get; } = null!;
    public Fetish Breeder { get; } = null!;
    public Fetish Sadomasochist { get; } = null!;
    public Fetish LustyMaiden { get; } = null!;

    public Fetishes(XElement fetishesNode)
    {
        var fetishes = fetishesNode.Elements();
        var fetishTypes = FetishType.None;
        
        #region Match Existing Fetishes
        
        foreach (var fetish in fetishes)
        {
            
            switch (fetish.Value)
            {
                case "FETISH_DOMINANT":
                    fetishTypes |= FetishType.Dominant;
                    Dominant = new Fetish(fetish);
                    break;
                case "FETISH_SUBMISSIVE":
                    fetishTypes |= FetishType.Submissive;
                    Submissive = new Fetish(fetish);
                    break;
                case "FETISH_VAGINAL_GIVING":
                    fetishTypes |= FetishType.Vaginal;
                    Vaginal = new Fetish(fetish);
                    break;
                case "FETISH_VAGINAL_RECEIVING":
                    fetishTypes |= FetishType.PussySlut;
                    PussySlut = new Fetish(fetish);
                    break;
                case "FETISH_PENIS_GIVING":
                    fetishTypes |= FetishType.CockStud;
                    CockStud = new Fetish(fetish);
                    break;
                case "FETISH_PENIS_RECEIVING":
                    fetishTypes |= FetishType.CockAddict;
                    CockAddict = new Fetish(fetish);
                    break;
                case "FETISH_ANAL_GIVING":
                    fetishTypes |= FetishType.Anal;
                    Anal = new Fetish(fetish);
                    break;
                case "FETISH_ANAL_RECEIVING":
                    fetishTypes |= FetishType.Buttslut;
                    Buttslut = new Fetish(fetish);
                    break;
                case "FETISH_BREASTS_OTHERS":
                    fetishTypes |= FetishType.BreastLover;
                    BreastLover = new Fetish(fetish);
                    break;
                case "FETISH_BREASTS_SELF":
                    fetishTypes |= FetishType.Breasts;
                    Breasts = new Fetish(fetish);
                    break;
                case "FETISH_LACTATION_OTHERS":
                    fetishTypes |= FetishType.MilkLover;
                    MilkLover = new Fetish(fetish);
                    break;
                case "FETISH_LACTATION_SELF":
                    fetishTypes |= FetishType.Lactation;
                    Lactation = new Fetish(fetish);
                    break;
                case "FETISH_ORAL_RECEIVING":
                    fetishTypes |= FetishType.Oral;
                    Oral = new Fetish(fetish);
                    break;
                case "FETISH_ORAL_GIVING":
                    fetishTypes |= FetishType.OralPerformer;
                    OralPerformer = new Fetish(fetish);
                    break;
                case "FETISH_LEG_LOVER":
                    fetishTypes |= FetishType.LegLover;
                    LegLover = new Fetish(fetish);
                    break;
                case "FETISH_STRUTTER":
                    fetishTypes |= FetishType.Strutter;
                    Strutter = new Fetish(fetish);
                    break;
                case "FETISH_FOOT_GIVING":
                    fetishTypes |= FetishType.DominantFoot;
                    DominantFoot = new Fetish(fetish);
                    break;
                case "FETISH_FOOT_RECEIVING":
                    fetishTypes |= FetishType.SubmissiveFoot;
                    SubmissiveFoot = new Fetish(fetish);
                    break;
                case "FETISH_ARMPIT_GIVING":
                    fetishTypes |= FetishType.ArmpitLover;
                    ArmpitLover = new Fetish(fetish);
                    break;
                case "FETISH_ARMPIT_RECEIVING":
                    fetishTypes |= FetishType.ArmpitSlut;
                    ArmpitSlut = new Fetish(fetish);
                    break;
                case "FETISH_CUM_STUD":
                    fetishTypes |= FetishType.CumStud;
                    CumStud = new Fetish(fetish);
                    break;
                case "FETISH_CUM_ADDICT":
                    fetishTypes |= FetishType.CumAddict;
                    CumAddict = new Fetish(fetish);
                    break;
                case "FETISH_DEFLOWERING":
                    fetishTypes |= FetishType.Deflowering;
                    Deflowering = new Fetish(fetish);
                    break;
                case "FETISH_PURE_VIRGIN":
                    fetishTypes |= FetishType.VaginalVirginity;
                    VaginalVirginity = new Fetish(fetish);
                    break;
                case "FETISH_IMPREGNATION":
                    fetishTypes |= FetishType.Impregnation;
                    Impregnation = new Fetish(fetish);
                    break;
                case "FETISH_PREGNANCY":
                    fetishTypes |= FetishType.Pregnancy;
                    Pregnancy = new Fetish(fetish);
                    break;
                case "FETISH_TRANSFORMATION_GIVING":
                    fetishTypes |= FetishType.Transformer;
                    Transformer = new Fetish(fetish);
                    break;
                case "FETISH_TRANSFORMATION_RECEIVING":
                    fetishTypes |= FetishType.TestSubject;
                    TestSubject = new Fetish(fetish);
                    break;
                case "FETISH_KINK_GIVING":
                    fetishTypes |= FetishType.KinkAdvocate;
                    KinkAdvocate = new Fetish(fetish);
                    break;
                case "FETISH_KINK_RECEIVING":
                    fetishTypes |= FetishType.KinkCurious;
                    KinkCurious = new Fetish(fetish);
                    break;
                case "FETISH_SADIST":
                    fetishTypes |= FetishType.Sadist;
                    Sadist = new Fetish(fetish);
                    break;
                case "FETISH_MASOCHIST":
                    fetishTypes |= FetishType.Masochist;
                    Masochist = new Fetish(fetish);
                    break;
                case "FETISH_NON_CON_DOM":
                    fetishTypes |= FetishType.NonConsent;
                    NonConsent = new Fetish(fetish);
                    break;
                case "FETISH_NON_CON_SUB":
                    fetishTypes |= FetishType.UnwillingFuckToy;
                    UnwillingFuckToy = new Fetish(fetish);
                    break;
                case "FETISH_BONDAGE_APPLIER":
                    fetishTypes |= FetishType.BondageApplier;
                    BondageApplier = new Fetish(fetish);
                    break;
                case "FETISH_BONDAGE_VICTIM":
                    fetishTypes |= FetishType.BondageBitch;
                    BondageBitch = new Fetish(fetish);
                    break;
                case "FETISH_DENIAL":
                    fetishTypes |= FetishType.OrgasmDenier;
                    OrgasmDenier = new Fetish(fetish);
                    break;
                case "FETISH_DENIAL_SELF":
                    fetishTypes |= FetishType.SelfDenial;
                    SelfDenial = new Fetish(fetish);
                    break;
                case "FETISH_VOYEURIST":
                    fetishTypes |= FetishType.Voyeurist;
                    Voyeurist = new Fetish(fetish);
                    break;
                case "FETISH_EXHIBITIONIST":
                    fetishTypes |= FetishType.Exhibitionist;
                    Exhibitionist = new Fetish(fetish);
                    break;
                case "FETISH_BIMBO":
                    fetishTypes |= FetishType.Bimbo;
                    Bimbo = new Fetish(fetish);
                    break;
                case "FETISH_CROSS_DRESSER":
                    fetishTypes |= FetishType.CrossDressing;
                    CrossDressing = new Fetish(fetish);
                    break;
                case "FETISH_MASTURBATION":
                    fetishTypes |= FetishType.Masturbation;
                    Masturbation = new Fetish(fetish);
                    break;
                case "FETISH_INCEST":
                    fetishTypes |= FetishType.Incest;
                    Incest = new Fetish(fetish);
                    break;
                case "FETISH_SIZE_QUEEN":
                    fetishTypes |= FetishType.SizeQueen;
                    SizeQueen = new Fetish(fetish);
                    break;
                case "FETISH_SWITCH":
                    fetishTypes |= FetishType.Switch;
                    Switch = new Fetish(fetish, true);
                    break;
                case "FETISH_BREEDER":
                    fetishTypes |= FetishType.Breeder;
                    Breeder = new Fetish(fetish, true);
                    break;
                case "FETISH_SADOMASOCHIST":
                    fetishTypes |= FetishType.Sadomasochist;
                    Sadomasochist = new Fetish(fetish, true);
                    break;
                case "FETISH_LUSTY_MAIDEN":
                    fetishTypes |= FetishType.LustyMaiden;
                    LustyMaiden = new Fetish(fetish, true);
                    break;
                default:
                    Console.WriteLine($"Unknown Fetish: {fetish.Value}");
                    break;
            }
        }
        
        #endregion

        #region Create Missing Fetishes
        
        if ((fetishTypes & FetishType.Dominant) == 0)
        {
            Dominant = CreateFetish("FETISH_DOMINANT", fetishesNode);
        }
        if ((fetishTypes & FetishType.Submissive) == 0)
        {
            Submissive = CreateFetish("FETISH_SUBMISSIVE", fetishesNode);
        }
        if ((fetishTypes & FetishType.Vaginal) == 0)
        {
            Vaginal = CreateFetish("FETISH_VAGINAL_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.PussySlut) == 0)
        {
            PussySlut = CreateFetish("FETISH_VAGINAL_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.CockStud) == 0)
        {
            CockStud = CreateFetish("FETISH_PENIS_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.CockAddict) == 0)
        {
            CockAddict = CreateFetish("FETISH_PENIS_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.Anal) == 0)
        {
            Anal = CreateFetish("FETISH_ANAL_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.Buttslut) == 0)
        {
            Buttslut = CreateFetish("FETISH_ANAL_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.BreastLover) == 0)
        {
            BreastLover = CreateFetish("FETISH_BREASTS_OTHERS", fetishesNode);
        }
        if ((fetishTypes & FetishType.Breasts) == 0)
        {
            Breasts = CreateFetish("FETISH_BREASTS_SELF", fetishesNode);
        }
        if ((fetishTypes & FetishType.MilkLover) == 0)
        {
            MilkLover = CreateFetish("FETISH_LACTATION_OTHERS", fetishesNode);
        }
        if ((fetishTypes & FetishType.Lactation) == 0)
        {
            Lactation = CreateFetish("FETISH_LACTATION_SELF", fetishesNode);
        }
        if ((fetishTypes & FetishType.Oral) == 0)
        {
            Oral = CreateFetish("FETISH_ORAL_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.OralPerformer) == 0)
        {
            OralPerformer = CreateFetish("FETISH_ORAL_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.LegLover) == 0)
        {
            LegLover = CreateFetish("FETISH_LEG_LOVER", fetishesNode);
        }
        if ((fetishTypes & FetishType.Strutter) == 0)
        {
            Strutter = CreateFetish("FETISH_STRUTTER", fetishesNode);
        }
        if ((fetishTypes & FetishType.DominantFoot) == 0)
        {
            DominantFoot = CreateFetish("FETISH_FOOT_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.SubmissiveFoot) == 0)
        {
            SubmissiveFoot = CreateFetish("FETISH_FOOT_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.ArmpitLover) == 0)
        {
            ArmpitLover = CreateFetish("FETISH_ARMPIT_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.ArmpitSlut) == 0)
        {
            ArmpitSlut = CreateFetish("FETISH_ARMPIT_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.CumStud) == 0)
        {
            CumStud = CreateFetish("FETISH_CUM_STUD", fetishesNode);
        }
        if ((fetishTypes & FetishType.CumAddict) == 0)
        {
            CumAddict = CreateFetish("FETISH_CUM_ADDICT", fetishesNode);
        }
        if ((fetishTypes & FetishType.Deflowering) == 0)
        {
            Deflowering = CreateFetish("FETISH_DEFLOWERING", fetishesNode);
        }
        if ((fetishTypes & FetishType.VaginalVirginity) == 0)
        {
            VaginalVirginity = CreateFetish("FETISH_PURE_VIRGIN", fetishesNode);
        }
        if ((fetishTypes & FetishType.Impregnation) == 0)
        {
            Impregnation = CreateFetish("FETISH_IMPREGNATION", fetishesNode);
        }
        if ((fetishTypes & FetishType.Pregnancy) == 0)
        {
            Pregnancy = CreateFetish("FETISH_PREGNANCY", fetishesNode);
        }
        if ((fetishTypes & FetishType.Transformer) == 0)
        {
            Transformer = CreateFetish("FETISH_TRANSFORMATION_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.TestSubject) == 0)
        {
            TestSubject = CreateFetish("FETISH_TRANSFORMATION_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.KinkAdvocate) == 0)
        {
            KinkAdvocate = CreateFetish("FETISH_KINK_GIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.KinkCurious) == 0)
        {
            KinkCurious = CreateFetish("FETISH_KINK_RECEIVING", fetishesNode);
        }
        if ((fetishTypes & FetishType.Sadist) == 0)
        {
            Sadist = CreateFetish("FETISH_SADIST", fetishesNode);
        }
        if ((fetishTypes & FetishType.Masochist) == 0)
        {
            Masochist = CreateFetish("FETISH_MASOCHIST", fetishesNode);
        }
        if ((fetishTypes & FetishType.NonConsent) == 0)
        {
            NonConsent = CreateFetish("FETISH_NON_CON_DOM", fetishesNode);
        }
        if ((fetishTypes & FetishType.UnwillingFuckToy) == 0)
        {
            UnwillingFuckToy = CreateFetish("FETISH_NON_CON_SUB", fetishesNode);
        }
        if ((fetishTypes & FetishType.BondageApplier) == 0)
        {
            BondageApplier = CreateFetish("FETISH_BONDAGE_APPLIER", fetishesNode);
        }
        if ((fetishTypes & FetishType.BondageBitch) == 0)
        {
            BondageBitch = CreateFetish("FETISH_BONDAGE_VICTIM", fetishesNode);
        }
        if ((fetishTypes & FetishType.OrgasmDenier) == 0)
        {
            OrgasmDenier = CreateFetish("FETISH_DENIAL", fetishesNode);
        }
        if ((fetishTypes & FetishType.SelfDenial) == 0)
        {
            SelfDenial = CreateFetish("FETISH_DENIAL_SELF", fetishesNode);
        }
        if ((fetishTypes & FetishType.Voyeurist) == 0)
        {
            Voyeurist = CreateFetish("FETISH_VOYEURIST", fetishesNode);
        }
        if ((fetishTypes & FetishType.Exhibitionist) == 0)
        {
            Exhibitionist = CreateFetish("FETISH_EXHIBITIONIST", fetishesNode);
        }
        if ((fetishTypes & FetishType.Bimbo) == 0)
        {
            Bimbo = CreateFetish("FETISH_BIMBO", fetishesNode);
        }
        if ((fetishTypes & FetishType.CrossDressing) == 0)
        {
            CrossDressing = CreateFetish("FETISH_CROSS_DRESSER", fetishesNode);
        }
        if ((fetishTypes & FetishType.Masturbation) == 0)
        {
            Masturbation = CreateFetish("FETISH_MASTURBATION", fetishesNode);
        }
        if ((fetishTypes & FetishType.Incest) == 0)
        {
            Incest = CreateFetish("FETISH_INCEST", fetishesNode);
        }
        if ((fetishTypes & FetishType.SizeQueen) == 0)
        {
            SizeQueen = CreateFetish("FETISH_SIZE_QUEEN", fetishesNode);
        }
        if ((fetishTypes & FetishType.Switch) == 0)
        {
            SizeQueen = CreateFetish("FETISH_SWITCH", fetishesNode);
        }
        if ((fetishTypes & FetishType.Breeder) == 0)
        {
            SizeQueen = CreateFetish("FETISH_BREEDER", fetishesNode);
        }
        if ((fetishTypes & FetishType.Sadomasochist) == 0)
        {
            SizeQueen = CreateFetish("FETISH_SADOMASOCHIST", fetishesNode);
        }
        if ((fetishTypes & FetishType.LustyMaiden) == 0)
        {
            SizeQueen = CreateFetish("FETISH_LUSTY_MAIDEN", fetishesNode);
        }
        
        #endregion
    }

    private static Fetish CreateFetish(string fetishName, XElement fetishesNode, bool suppressDesire = false)
    {
        var fetishNode = new XElement("f", new XAttribute("desire", 2), new XAttribute("o", false), new XAttribute("xp", 0))
        {
            Value = fetishName
        };
        fetishesNode.Add(fetishNode);
        var fetish = new Fetish(fetishesNode, suppressDesire);
        return fetish;
    }
}

[Flags]
internal enum FetishType : ulong
{
    None = 0,
    Dominant = 1L << 0,
    Submissive = 1L << 1,
    Vaginal = 1L << 2,
    PussySlut = 1L << 3,
    CockStud = 1L << 4,
    CockAddict = 1L << 5,
    Anal = 1L << 6,
    Buttslut = 1L << 7,
    BreastLover = 1L << 8,
    Breasts = 1L << 9,
    MilkLover = 1L << 10,
    Lactation = 1L << 11,
    Oral = 1L << 12,
    OralPerformer = 1L << 13,
    LegLover = 1L << 14,
    Strutter = 1L << 15,
    DominantFoot = 1L << 16,
    SubmissiveFoot = 1L << 17,
    ArmpitLover = 1L << 18,
    ArmpitSlut = 1L << 19,
    CumStud = 1L << 20,
    CumAddict = 1L << 21,
    Deflowering = 1L << 22,
    VaginalVirginity = 1L << 23,
    Impregnation = 1L << 24,
    Pregnancy = 1L << 25,
    Transformer = 1L << 26,
    TestSubject = 1L << 27,
    KinkAdvocate = 1L << 28,
    KinkCurious = 1L << 29,
    Sadist = 1L << 30,
    Masochist = 1L << 31,
    NonConsent = 1L << 32,
    UnwillingFuckToy = 1L << 33,
    BondageApplier = 1L << 34,
    BondageBitch = 1L << 35,
    OrgasmDenier = 1L << 36,
    SelfDenial = 1L << 37,
    Voyeurist = 1L << 38,
    Exhibitionist = 1L << 39,
    Bimbo = 1L << 40,
    CrossDressing = 1L << 41,
    Masturbation = 1L << 42,
    Incest = 1L << 43,
    SizeQueen = 1L << 44,
    Switch = 1L << 45,
    Breeder = 1L << 46,
    Sadomasochist = 1L << 47,
    LustyMaiden = 1L << 48
}