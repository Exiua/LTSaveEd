using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Core(XContainer coreNode)
{
    public ValueDisplayPair<string>[] PlayerJobHistories { get; } =
    [
        new("Unemployed", "UNEMPLOYED"),
        new("Office Worker", "OFFICE_WORKER"), new("Student", "STUDENT"),
        new("Musician", "MUSICIAN"), new("Teacher", "TEACHER"),
        new("Writer", "WRITER"), new("Chef", "CHEF"),
        new("Construction Worker", "CONSTRUCTION_WORKER"),
        new("Soldier", "SOLDIER"), new("Athlete", "ATHLETE"),
        new("Aristocrat", "ARISTOCRAT"), new("Butler", "BUTLER"),
        new("Tourist", "TOURIST")
    ];

    public ValueDisplayPair<string>[] NpcJobHistories { get; } =
    [
        new("Unemployed", "NPC_UNEMPLOYED"),
        new("Beautician", "NPC_BEAUTICIAN"),
        new("Enforcer Sword Constable", "NPC_ENFORCER_SWORD_CONSTABLE"),
        new("Enforcer Sword Inspector", "NPC_ENFORCER_SWORD_INSPECTOR"),
        new("Enforcer Sword Chief Inspector", "NPC_ENFORCER_SWORD_CHIEF_INSPECTOR"),
        new("Enforcer Sword Sergeant", "NPC_ENFORCER_SWORD_SERGEANT"),
        new("Enforcer Sword Super", "NPC_ENFORCER_SWORD_SUPER"),
        new("Enforcer Patrol Constable", "NPC_ENFORCER_PATROL_CONSTABLE"),
        new("Enforcer Patrol Inspector", "NPC_ENFORCER_PATROL_INSPECTOR"),
        new("Enforcer Patrol Sergeant", "NPC_ENFORCER_PATROL_SERGEANT"),
        new("Slime Queen Guard", "NPC_SLIME_QUEEN_GUARD"),
        new("Slime Queen", "NPC_SLIME_QUEEN"),
        new("Elis Mayor", "NPC_ELIS_MAYOR"),
        new("Stable Mistress", "NPC_STABLE_MISTRESS"),
        new("Epona", "NPC_EPONA"),
        new("Business Owner", "NPC_BUSINESS_OWNER"),
        new("Casino Owner", "NPC_CASINO_OWNER"),
        new("Clothing Store Owner", "NPC_CLOTHING_STORE_OWNER"),
        new("Gym Owner", "NPC_GYM_OWNER"),
        new("Nightclub Owner", "NPC_NIGHTCLUB_OWNER"),
        new("Store Owner", "NPC_STORE_OWNER"),
        new("Tavern Owner", "NPC_TAVERN_OWNER"),
        new("Assistant", "NPC_ASSISTANT"),
        new("Arcane Researcher", "NPC_ARCANE_RESEARCHER"),
        new("Bar Tender", "NPC_BAR_TENDER"),
        new("Bouncer", "NPC_BOUNCER"),
        new("Prostitute", "NPC_PROSTITUTE"),
        new("Lyssieth Guard", "NPC_LYSSIETH_GUARD"),
        new("Slave", "NPC_SLAVE"),
        new("Slaver Admin", "NPC_SLAVER_ADMIN"),
        new("Harpy Flock Member", "NPC_HARPY_FLOCK_MEMBER"),
        new("Harpy Matriarch", "NPC_HARPY_MATRIARCH"),
        new("Construction Worker Arcane", "NPC_CONSTRUCTION_WORKER_ARCANE"),
        new("Bounty Hunter", "NPC_BOUNTY_HUNTER"),
        new("Taur Transport", "NPC_TAUR_TRANSPORT"),
        new("Elemental", "ELEMENTAL"), new("Mugger", "NPC_MUGGER"),
        new("Gang Member", "NPC_GANG_MEMBER"),
        new("Gang Body Guard", "NPC_GANG_BODY_GUARD"),
        new("Gang Leader", "NPC_GANG_LEADER"),
        new("Office Worker", "NPC_OFFICE_WORKER"),
        new("Maid", "NPC_MAID"),
        new("Elder Lilin", "NPC_ELDER_LILIN")
    ];

    public ValueDisplayPair<string>[] SexualOrientations { get; } =
    [
        new("Androphilic", "ANDROPHILIC"), new("Ambiphilic", "AMBIPHILIC"),
        new("Gynephilic", "GYNEPHILIC")
    ];

    public ValueDisplayPair<string>[] GenderIdentities { get; } =
    [
        new("M_P_V_B_HERMAPHRODITE", "M_P_V_B_HERMAPHRODITE"),
        new("M_P_V_HERMAPHRODITE", "M_P_V_HERMAPHRODITE"),
        new("M_P_B_BUSTYBOY", "M_P_B_BUSTYBOY"), new("M_P_MALE", "M_P_MALE"),
        new("M_V_B_BUTCH", "M_V_B_BUTCH"), new("M_V_CUNTBOY", "M_V_CUNTBOY"),
        new("M_B_MANNEQUIN", "M_B_MANNEQUIN"),
        new("M_MANNEQUIN", "M_MANNEQUIN"),
        new("F_P_V_B_FUTANARI", "F_P_V_B_FUTANARI"),
        new("F_P_V_FUTANARI", "F_P_V_FUTANARI"),
        new("F_P_B_SHEMALE", "F_P_B_SHEMALE"),
        new("F_P_TRAP", "F_P_TRAP"),
        new("F_V_B_FEMALE", "F_V_B_FEMALE"), new("F_V_FEMALE", "F_V_FEMALE"),
        new("F_B_DOLL", "F_B_DOLL"), new("F_DOLL", "F_DOLL"),
        new("N_P_V_B_HERMAPHRODITE", "N_P_V_B_HERMAPHRODITE"),
        new("N_P_V_HERMAPHRODITE", "N_P_V_HERMAPHRODITE"),
        new("N_P_B_SHEMALE", "N_P_B_SHEMALE"), new("N_P_TRAP", "N_P_TRAP"),
        new("N_V_B_TOMBOY", "N_V_B_TOMBOY"), new("N_V_TOMBOY", "N_V_TOMBOY"),
        new("N_B_DOLL", "N_B_DOLL"), new("N_NEUTER", "N_NEUTER")
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