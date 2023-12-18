using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class Core(XContainer coreNode)
{
    public ValueDisplayPair[] PlayerJobHistories { get; } =
    [
        new ValueDisplayPair("Unemployed", "UNEMPLOYED"),
        new ValueDisplayPair("Office Worker", "OFFICE_WORKER"), new ValueDisplayPair("Student", "STUDENT"),
        new ValueDisplayPair("Musician", "MUSICIAN"), new ValueDisplayPair("Teacher", "TEACHER"),
        new ValueDisplayPair("Writer", "WRITER"), new ValueDisplayPair("Chef", "CHEF"),
        new ValueDisplayPair("Construction Worker", "CONSTRUCTION_WORKER"),
        new ValueDisplayPair("Soldier", "SOLDIER"), new ValueDisplayPair("Athlete", "ATHLETE"),
        new ValueDisplayPair("Aristocrat", "ARISTOCRAT"), new ValueDisplayPair("Butler", "BUTLER"),
        new ValueDisplayPair("Tourist", "TOURIST")
    ];

    public ValueDisplayPair[] NpcJobHistories { get; } =
    [
        new ValueDisplayPair("Unemployed", "NPC_UNEMPLOYED"),
        new ValueDisplayPair("Beautician", "NPC_BEAUTICIAN"),
        new ValueDisplayPair("Enforcer Sword Constable", "NPC_ENFORCER_SWORD_CONSTABLE"),
        new ValueDisplayPair("Enforcer Sword Inspector", "NPC_ENFORCER_SWORD_INSPECTOR"),
        new ValueDisplayPair("Enforcer Sword Chief Inspector", "NPC_ENFORCER_SWORD_CHIEF_INSPECTOR"),
        new ValueDisplayPair("Enforcer Sword Sergeant", "NPC_ENFORCER_SWORD_SERGEANT"),
        new ValueDisplayPair("Enforcer Sword Super", "NPC_ENFORCER_SWORD_SUPER"),
        new ValueDisplayPair("Enforcer Patrol Constable", "NPC_ENFORCER_PATROL_CONSTABLE"),
        new ValueDisplayPair("Enforcer Patrol Inspector", "NPC_ENFORCER_PATROL_INSPECTOR"),
        new ValueDisplayPair("Enforcer Patrol Sergeant", "NPC_ENFORCER_PATROL_SERGEANT"),
        new ValueDisplayPair("Slime Queen Guard", "NPC_SLIME_QUEEN_GUARD"),
        new ValueDisplayPair("Slime Queen", "NPC_SLIME_QUEEN"),
        new ValueDisplayPair("Elis Mayor", "NPC_ELIS_MAYOR"),
        new ValueDisplayPair("Stable Mistress", "NPC_STABLE_MISTRESS"),
        new ValueDisplayPair("Epona", "NPC_EPONA"),
        new ValueDisplayPair("Business Owner", "NPC_BUSINESS_OWNER"),
        new ValueDisplayPair("Casino Owner", "NPC_CASINO_OWNER"),
        new ValueDisplayPair("Clothing Store Owner", "NPC_CLOTHING_STORE_OWNER"),
        new ValueDisplayPair("Gym Owner", "NPC_GYM_OWNER"),
        new ValueDisplayPair("Nightclub Owner", "NPC_NIGHTCLUB_OWNER"),
        new ValueDisplayPair("Store Owner", "NPC_STORE_OWNER"),
        new ValueDisplayPair("Tavern Owner", "NPC_TAVERN_OWNER"),
        new ValueDisplayPair("Assistant", "NPC_ASSISTANT"),
        new ValueDisplayPair("Arcane Researcher", "NPC_ARCANE_RESEARCHER"),
        new ValueDisplayPair("Bar Tender", "NPC_BAR_TENDER"),
        new ValueDisplayPair("Bouncer", "NPC_BOUNCER"),
        new ValueDisplayPair("Prostitute", "NPC_PROSTITUTE"),
        new ValueDisplayPair("Lyssieth Guard", "NPC_LYSSIETH_GUARD"),
        new ValueDisplayPair("Slave", "NPC_SLAVE"),
        new ValueDisplayPair("Slaver Admin", "NPC_SLAVER_ADMIN"),
        new ValueDisplayPair("Harpy Flock Member", "NPC_HARPY_FLOCK_MEMBER"),
        new ValueDisplayPair("Harpy Matriarch", "NPC_HARPY_MATRIARCH"),
        new ValueDisplayPair("Construction Worker Arcane", "NPC_CONSTRUCTION_WORKER_ARCANE"),
        new ValueDisplayPair("Bounty Hunter", "NPC_BOUNTY_HUNTER"),
        new ValueDisplayPair("Taur Transport", "NPC_TAUR_TRANSPORT"),
        new ValueDisplayPair("Elemental", "ELEMENTAL"), new ValueDisplayPair("Mugger", "NPC_MUGGER"),
        new ValueDisplayPair("Gang Member", "NPC_GANG_MEMBER"),
        new ValueDisplayPair("Gang Body Guard", "NPC_GANG_BODY_GUARD"),
        new ValueDisplayPair("Gang Leader", "NPC_GANG_LEADER"),
        new ValueDisplayPair("Office Worker", "NPC_OFFICE_WORKER"),
        new ValueDisplayPair("Maid", "NPC_MAID"),
        new ValueDisplayPair("Elder Lilin", "NPC_ELDER_LILIN")
    ];

    public ValueDisplayPair[] SexualOrientations { get; } =
    [
        new ValueDisplayPair("Androphilic", "ANDROPHILIC"), new ValueDisplayPair("Ambiphilic", "AMBIPHILIC"),
        new ValueDisplayPair("Gynephilic", "GYNEPHILIC")
    ];

    public ValueDisplayPair[] GenderIdentities { get; } =
    [
        new ValueDisplayPair("M_P_V_B_HERMAPHRODITE", "M_P_V_B_HERMAPHRODITE"),
        new ValueDisplayPair("M_P_V_HERMAPHRODITE", "M_P_V_HERMAPHRODITE"),
        new ValueDisplayPair("M_P_B_BUSTYBOY", "M_P_B_BUSTYBOY"), new ValueDisplayPair("M_P_MALE", "M_P_MALE"),
        new ValueDisplayPair("M_V_B_BUTCH", "M_V_B_BUTCH"), new ValueDisplayPair("M_V_CUNTBOY", "M_V_CUNTBOY"),
        new ValueDisplayPair("M_B_MANNEQUIN", "M_B_MANNEQUIN"),
        new ValueDisplayPair("M_MANNEQUIN", "M_MANNEQUIN"),
        new ValueDisplayPair("F_P_V_B_FUTANARI", "F_P_V_B_FUTANARI"),
        new ValueDisplayPair("F_P_V_FUTANARI", "F_P_V_FUTANARI"),
        new ValueDisplayPair("F_P_B_SHEMALE", "F_P_B_SHEMALE"),
        new ValueDisplayPair("F_P_TRAP", "F_P_TRAP"),
        new ValueDisplayPair("F_V_B_FEMALE", "F_V_B_FEMALE"), new ValueDisplayPair("F_V_FEMALE", "F_V_FEMALE"),
        new ValueDisplayPair("F_B_DOLL", "F_B_DOLL"), new ValueDisplayPair("F_DOLL", "F_DOLL"),
        new ValueDisplayPair("N_P_V_B_HERMAPHRODITE", "N_P_V_B_HERMAPHRODITE"),
        new ValueDisplayPair("N_P_V_HERMAPHRODITE", "N_P_V_HERMAPHRODITE"),
        new ValueDisplayPair("N_P_B_SHEMALE", "N_P_B_SHEMALE"), new ValueDisplayPair("N_P_TRAP", "N_P_TRAP"),
        new ValueDisplayPair("N_V_B_TOMBOY", "N_V_B_TOMBOY"), new ValueDisplayPair("N_V_TOMBOY", "N_V_TOMBOY"),
        new ValueDisplayPair("N_B_DOLL", "N_B_DOLL"), new ValueDisplayPair("N_NEUTER", "N_NEUTER")
    ];
    
    public XmlAttribute<string> Id { get; } = new(coreNode.GetChildsAttributeNode("id"));
    public Name Name { get; } = new(coreNode.Element("name")!, coreNode.Element("surname")!);
    public XmlAttribute<string> Description { get; } = new(coreNode.GetChildsAttributeNode("description"));
    public XmlAttribute<int> Level { get; } = new(coreNode.GetChildsAttributeNode("level"));
    public XmlAttribute<int> Experience { get; } = new(coreNode.GetChildsAttributeNode("experience"));
    // public int Money { get; set; } // Part of Character Inventory
    public XmlDate DateOfBirth { get; } = new(coreNode);
    public XmlAttribute<string> JobHistory { get; } = new(coreNode.GetChildsAttributeNode("history"));
    public XmlAttribute<string> SexualOrientation { get; } = new(coreNode.GetChildsAttributeNode("sexualOrientation"));
    public XmlAttribute<float> Obedience { get; } = new(coreNode.GetChildsAttributeNode("obedience"));

    public XmlAttribute<string> GenderIdentity { get; } = new(coreNode.GetChildsAttributeNode("genderIdentity"));
    public XmlAttribute<int> PerkPoints { get; } = new(coreNode.GetChildsAttributeNode("perkPoints"));
    public XmlAttribute<float> Health { get; } = new(coreNode.GetChildsAttributeNode("health"));
    public XmlAttribute<float> Mana { get; } = new(coreNode.GetChildsAttributeNode("mana"));
}