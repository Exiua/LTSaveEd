using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Core(XContainer coreNode)
{
    public ValueDisplayPair<string>[] PlayerJobHistories { get; } =
    [
        new ValueDisplayPair<string>("Unemployed", "UNEMPLOYED"),
        new ValueDisplayPair<string>("Office Worker", "OFFICE_WORKER"), new ValueDisplayPair<string>("Student", "STUDENT"),
        new ValueDisplayPair<string>("Musician", "MUSICIAN"), new ValueDisplayPair<string>("Teacher", "TEACHER"),
        new ValueDisplayPair<string>("Writer", "WRITER"), new ValueDisplayPair<string>("Chef", "CHEF"),
        new ValueDisplayPair<string>("Construction Worker", "CONSTRUCTION_WORKER"),
        new ValueDisplayPair<string>("Soldier", "SOLDIER"), new ValueDisplayPair<string>("Athlete", "ATHLETE"),
        new ValueDisplayPair<string>("Aristocrat", "ARISTOCRAT"), new ValueDisplayPair<string>("Butler", "BUTLER"),
        new ValueDisplayPair<string>("Tourist", "TOURIST")
    ];

    public ValueDisplayPair<string>[] NpcJobHistories { get; } =
    [
        new ValueDisplayPair<string>("Unemployed", "NPC_UNEMPLOYED"),
        new ValueDisplayPair<string>("Beautician", "NPC_BEAUTICIAN"),
        new ValueDisplayPair<string>("Enforcer Sword Constable", "NPC_ENFORCER_SWORD_CONSTABLE"),
        new ValueDisplayPair<string>("Enforcer Sword Inspector", "NPC_ENFORCER_SWORD_INSPECTOR"),
        new ValueDisplayPair<string>("Enforcer Sword Chief Inspector", "NPC_ENFORCER_SWORD_CHIEF_INSPECTOR"),
        new ValueDisplayPair<string>("Enforcer Sword Sergeant", "NPC_ENFORCER_SWORD_SERGEANT"),
        new ValueDisplayPair<string>("Enforcer Sword Super", "NPC_ENFORCER_SWORD_SUPER"),
        new ValueDisplayPair<string>("Enforcer Patrol Constable", "NPC_ENFORCER_PATROL_CONSTABLE"),
        new ValueDisplayPair<string>("Enforcer Patrol Inspector", "NPC_ENFORCER_PATROL_INSPECTOR"),
        new ValueDisplayPair<string>("Enforcer Patrol Sergeant", "NPC_ENFORCER_PATROL_SERGEANT"),
        new ValueDisplayPair<string>("Slime Queen Guard", "NPC_SLIME_QUEEN_GUARD"),
        new ValueDisplayPair<string>("Slime Queen", "NPC_SLIME_QUEEN"),
        new ValueDisplayPair<string>("Elis Mayor", "NPC_ELIS_MAYOR"),
        new ValueDisplayPair<string>("Stable Mistress", "NPC_STABLE_MISTRESS"),
        new ValueDisplayPair<string>("Epona", "NPC_EPONA"),
        new ValueDisplayPair<string>("Business Owner", "NPC_BUSINESS_OWNER"),
        new ValueDisplayPair<string>("Casino Owner", "NPC_CASINO_OWNER"),
        new ValueDisplayPair<string>("Clothing Store Owner", "NPC_CLOTHING_STORE_OWNER"),
        new ValueDisplayPair<string>("Gym Owner", "NPC_GYM_OWNER"),
        new ValueDisplayPair<string>("Nightclub Owner", "NPC_NIGHTCLUB_OWNER"),
        new ValueDisplayPair<string>("Store Owner", "NPC_STORE_OWNER"),
        new ValueDisplayPair<string>("Tavern Owner", "NPC_TAVERN_OWNER"),
        new ValueDisplayPair<string>("Assistant", "NPC_ASSISTANT"),
        new ValueDisplayPair<string>("Arcane Researcher", "NPC_ARCANE_RESEARCHER"),
        new ValueDisplayPair<string>("Bar Tender", "NPC_BAR_TENDER"),
        new ValueDisplayPair<string>("Bouncer", "NPC_BOUNCER"),
        new ValueDisplayPair<string>("Prostitute", "NPC_PROSTITUTE"),
        new ValueDisplayPair<string>("Lyssieth Guard", "NPC_LYSSIETH_GUARD"),
        new ValueDisplayPair<string>("Slave", "NPC_SLAVE"),
        new ValueDisplayPair<string>("Slaver Admin", "NPC_SLAVER_ADMIN"),
        new ValueDisplayPair<string>("Harpy Flock Member", "NPC_HARPY_FLOCK_MEMBER"),
        new ValueDisplayPair<string>("Harpy Matriarch", "NPC_HARPY_MATRIARCH"),
        new ValueDisplayPair<string>("Construction Worker Arcane", "NPC_CONSTRUCTION_WORKER_ARCANE"),
        new ValueDisplayPair<string>("Bounty Hunter", "NPC_BOUNTY_HUNTER"),
        new ValueDisplayPair<string>("Taur Transport", "NPC_TAUR_TRANSPORT"),
        new ValueDisplayPair<string>("Elemental", "ELEMENTAL"), new ValueDisplayPair<string>("Mugger", "NPC_MUGGER"),
        new ValueDisplayPair<string>("Gang Member", "NPC_GANG_MEMBER"),
        new ValueDisplayPair<string>("Gang Body Guard", "NPC_GANG_BODY_GUARD"),
        new ValueDisplayPair<string>("Gang Leader", "NPC_GANG_LEADER"),
        new ValueDisplayPair<string>("Office Worker", "NPC_OFFICE_WORKER"),
        new ValueDisplayPair<string>("Maid", "NPC_MAID"),
        new ValueDisplayPair<string>("Elder Lilin", "NPC_ELDER_LILIN")
    ];

    public ValueDisplayPair<string>[] SexualOrientations { get; } =
    [
        new ValueDisplayPair<string>("Androphilic", "ANDROPHILIC"), new ValueDisplayPair<string>("Ambiphilic", "AMBIPHILIC"),
        new ValueDisplayPair<string>("Gynephilic", "GYNEPHILIC")
    ];

    public ValueDisplayPair<string>[] GenderIdentities { get; } =
    [
        new ValueDisplayPair<string>("M_P_V_B_HERMAPHRODITE", "M_P_V_B_HERMAPHRODITE"),
        new ValueDisplayPair<string>("M_P_V_HERMAPHRODITE", "M_P_V_HERMAPHRODITE"),
        new ValueDisplayPair<string>("M_P_B_BUSTYBOY", "M_P_B_BUSTYBOY"), new ValueDisplayPair<string>("M_P_MALE", "M_P_MALE"),
        new ValueDisplayPair<string>("M_V_B_BUTCH", "M_V_B_BUTCH"), new ValueDisplayPair<string>("M_V_CUNTBOY", "M_V_CUNTBOY"),
        new ValueDisplayPair<string>("M_B_MANNEQUIN", "M_B_MANNEQUIN"),
        new ValueDisplayPair<string>("M_MANNEQUIN", "M_MANNEQUIN"),
        new ValueDisplayPair<string>("F_P_V_B_FUTANARI", "F_P_V_B_FUTANARI"),
        new ValueDisplayPair<string>("F_P_V_FUTANARI", "F_P_V_FUTANARI"),
        new ValueDisplayPair<string>("F_P_B_SHEMALE", "F_P_B_SHEMALE"),
        new ValueDisplayPair<string>("F_P_TRAP", "F_P_TRAP"),
        new ValueDisplayPair<string>("F_V_B_FEMALE", "F_V_B_FEMALE"), new ValueDisplayPair<string>("F_V_FEMALE", "F_V_FEMALE"),
        new ValueDisplayPair<string>("F_B_DOLL", "F_B_DOLL"), new ValueDisplayPair<string>("F_DOLL", "F_DOLL"),
        new ValueDisplayPair<string>("N_P_V_B_HERMAPHRODITE", "N_P_V_B_HERMAPHRODITE"),
        new ValueDisplayPair<string>("N_P_V_HERMAPHRODITE", "N_P_V_HERMAPHRODITE"),
        new ValueDisplayPair<string>("N_P_B_SHEMALE", "N_P_B_SHEMALE"), new ValueDisplayPair<string>("N_P_TRAP", "N_P_TRAP"),
        new ValueDisplayPair<string>("N_V_B_TOMBOY", "N_V_B_TOMBOY"), new ValueDisplayPair<string>("N_V_TOMBOY", "N_V_TOMBOY"),
        new ValueDisplayPair<string>("N_B_DOLL", "N_B_DOLL"), new ValueDisplayPair<string>("N_NEUTER", "N_NEUTER")
    ];
    
    public XmlAttribute<string> Id { get; } = new(coreNode.GetChildsAttributeNode("id"));
    public Name Name { get; } = new(coreNode.Element("name")!, coreNode.Element("surname")!);
    public XmlAttribute<string> Description { get; } = new(coreNode.GetChildsAttributeNode("description"));
    public XmlAttribute<int> Level { get; } = new(coreNode.GetChildsAttributeNode("level"));
    public XmlAttribute<int> Experience { get; } = new(coreNode.GetChildsAttributeNode("experience"));
    public XmlDate DateOfBirth { get; } = new(coreNode);
    public XmlAttribute<string> JobHistory { get; } = new(coreNode.GetChildsAttributeNode("history"));
    public XmlAttribute<string> SexualOrientation { get; } = new(coreNode.GetChildsAttributeNode("sexualOrientation"));
    public XmlAttribute<float> Obedience { get; } = new(coreNode.GetChildsAttributeNode("obedience"));
    public XmlAttribute<string> GenderIdentity { get; } = new(coreNode.GetChildsAttributeNode("genderIdentity"));
    public XmlAttribute<int> PerkPoints { get; } = new(coreNode.GetChildsAttributeNode("perkPoints"));
    public XmlAttribute<float> Health { get; } = new(coreNode.GetChildsAttributeNode("health"));
    public XmlAttribute<float> Mana { get; } = new(coreNode.GetChildsAttributeNode("mana"));

    public Personality Personality { get; } = new(coreNode.Element("personality")!);
}