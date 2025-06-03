namespace LTSaveEd.Models.Enums.Game;

public enum CombatMoveType
{
    Attack,
    Defend,
    Tease,
    Spell,
    Power, 
    //Skill,
    AttackDefend,
}

public static class CombatMoveTypeExtensions
{
    public static string GetValue(this CombatMoveType type)
    {
        return type switch
        {
            CombatMoveType.Attack => "ATTACK",
            CombatMoveType.Defend => "DEFEND",
            CombatMoveType.Tease => "TEASE",
            CombatMoveType.Spell => "SPELL",
            CombatMoveType.Power => "POWER",
            //CombatMoveType.SKILL => "SKILL",
            CombatMoveType.AttackDefend => "ATTACK_DEFEND",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    public static CombatMoveType FromValue(string value)
    {
        return value switch
        {
            "ATTACK" => CombatMoveType.Attack,
            "DEFEND" => CombatMoveType.Defend,
            "TEASE" => CombatMoveType.Tease,
            "SPELL" => CombatMoveType.Spell,
            "POWER" => CombatMoveType.Power,
            //"SKILL" => CombatMoveType.SKILL,
            "ATTACK_DEFEND" => CombatMoveType.AttackDefend,
            _ => CombatMoveType.Attack // Default to Attack if the value is unknown
        };
    }
}