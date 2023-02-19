using System.Collections.Generic;

namespace LTSaveEd.Models.CharacterModel.Attributes.Perks;

public static class PerkTree
{
    public static List<PerkNode> Perks { get; }

    static PerkTree()
    {
        PerkNode p1_1 = new PerkNode("1", "PHYSICAL_BASE", "Natural Fitness");
        PerkNode p1_2 = new PerkNode("1", "ARCANE_BASE", "Natural Arcane Power");
        PerkNode p1_3 = new PerkNode("1", "LEWD_KNOWLEDGE", "Lewd Knowledge");

        PerkNode p2_11 = new PerkNode(p1_2, "2", "ARCANE_BOOST", "Arcane Training");
        PerkNode p2_10 = new PerkNode(p1_2, "2", "ARCANE_CRITICALS", "Arcane Precision");
        PerkNode p2_2 = new PerkNode(p1_1, "2", "OBSERVANT", "Observant");
        PerkNode p2_6 = new PerkNode(p1_3, "2", "SEDUCTION_BOOST", "Seductive");
        PerkNode p2_7 = new PerkNode(p1_3, "2", "FERTILITY_BOOST", "Fertile");
        PerkNode p2_1 = new PerkNode(p1_1, "2", "PHYSIQUE_BOOST", "Physically Fit");
        PerkNode p2_4 = new PerkNode(p1_3, "2", "FIRING_BLANKS", "Sterile");
        PerkNode p2_5 = new PerkNode(p1_3, "2", "VIRILITY_BOOST", "Virile");
        PerkNode p2_8 = new PerkNode(p1_3, "2", "BARREN", "Barren");
        PerkNode p2_3 = new PerkNode(p1_1, "2", "ENCHANTMENT_STABILITY", "Stable Enchantments");        //Physical
        PerkNode p2_9 = new PerkNode(p1_2, "2", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments");    //Arcane

        PerkNode p3_3 = new PerkNode(p2_1, "3", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p3_11 = new PerkNode(p2_11, "3", "SPELL_DAMAGE", "Spell Power");
        PerkNode p3_7 = new PerkNode(p2_6, "3", "ORGASMIC_LEVEL_DRAIN", "Orgasmic Level Drain");
        PerkNode p3_12 = new PerkNode(p2_11, "3", "AURA_BOOST", "Aura Reserves");
        PerkNode p3_5 = new PerkNode(p2_5, "3", "VIRILITY_MAJOR_BOOST", "Virile");
        PerkNode p3_8 = new PerkNode(p2_6, "3", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p3_13 = new PerkNode(p2_11, "3", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p3_1 = new PerkNode(p2_1, "3", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p3_6 = new PerkNode(p2_6, "3", "SEDUCTION_BOOST", "Seductive");
        PerkNode p3_2 = new PerkNode(p2_1, "3", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p3_9 = new PerkNode(p2_7, "3", "FERTILITY_MAJOR_BOOST", "Fertile");
        PerkNode p3_4 = new PerkNode(p2_3, "3", "ENCHANTMENT_STABILITY", "Stable Enchantments");        //Physical
        PerkNode p3_10 = new PerkNode(p2_9, "3", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments");   //Arcane

        PerkNode p4_3 = new PerkNode(p3_3, "4", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p4_1 = new PerkNode(p3_1, "4", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p4_11 = new PerkNode(p3_11, "4", "SPELL_DAMAGE", "Spell Power");
        PerkNode p4_6 = new PerkNode(p3_6, "4", "SEDUCTION_BOOST", "Seductive");
        PerkNode p4_4 = new PerkNode(p3_4, "4", "WEAPON_ENCHANTER", "Arcane Smith");
        PerkNode p4_9 = new PerkNode(p3_9, "4", "FETISH_BROODMOTHER", "Broodmother");
        PerkNode p4_12 = new PerkNode(p3_12, "4", "AURA_BOOST", "Aura Reserves");
        PerkNode p4_2 = new PerkNode(p3_2, "4", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p4_10 = new PerkNode(p3_10, "4", "CLOTHING_ENCHANTER", "Arcane Weaver");
        PerkNode p4_5 = new PerkNode(p3_5, "4", "FETISH_SEEDER", "Seeder");
        PerkNode p4_8 = new PerkNode(p3_8, "4", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p4_13 = new PerkNode(p3_13, "4", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p4_7 = new PerkNode(p4_6, p4_8, "4", "AHEGAO", "Ahegao");

        PerkNode p5_13 = new PerkNode(p4_12, p4_13, "5", "ARCANE_COMBATANT", "Arcane Combatant");
        PerkNode p5_9 = new PerkNode(p4_9, "5", "FERTILITY_BOOST", "Fertile");
        PerkNode p5_4 = new PerkNode(p4_3, "5", "UNARMED_DAMAGE", "Hand-to-Hand");
        PerkNode p5_10 = new PerkNode(p4_11, "5", "ELEMENTAL_BOOST", "Elemental Striker");
        PerkNode p5_3 = new PerkNode(p5_4, "5", "CRITICAL_BOOST", "Critical Power");
        PerkNode p5_7 = new PerkNode(p4_6, p4_8, "5", "CRITICAL_BOOST_LUST", "Critical Power");
        PerkNode p5_11 = new PerkNode(p5_10, "5", "CRITICAL_BOOST_ARCANE", "Critical Power");
        PerkNode p5_12 = new PerkNode(p5_11, "5", "CHUUNI", "Chuuni");
        PerkNode p5_2 = new PerkNode(p5_3, "5", "UNARMED_TRAINING", "Martial Artist");
        PerkNode p5_1 = new PerkNode(p4_1, p4_2, "5", "RUNNER_2", "Cardio King");
        PerkNode p5_5 = new PerkNode(p4_5, "5", "VIRILITY_BOOST", "Virile");
        PerkNode p5_6 = new PerkNode(p5_5, "5", "VIRILITY_MAJOR_BOOST", "Virile");
        PerkNode p5_8 = new PerkNode(p5_9, "5", "FERTILITY_MAJOR_BOOST", "Fertile");

        PerkNode p6_1 = new PerkNode(p5_1, p5_4, "6", "PHYSIQUE_BOOST_MAJOR", "Physically Fit");
        PerkNode p6_3 = new PerkNode(p5_7, "6", "SEDUCTION_BOOST_MAJOR", "Seductive");
        PerkNode p6_2 = new PerkNode(p6_3, "6", "MALE_ATTRACTION", "Minx");
        PerkNode p6_4 = new PerkNode(p6_3, "6", "FEMALE_ATTRACTION", "Ladykiller");
        PerkNode p6_6 = new PerkNode(p5_10, p5_13, "6", "ARCANE_BOOST_MAJOR", "Arcane Affinity");

        PerkNode p7_1 = new PerkNode(p6_1, "7", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p7_6 = new PerkNode(p6_3, "7", "SEDUCTION_BOOST_ALT", "Seductive");            //Middle Branch
        PerkNode p7_5 = new PerkNode(p6_3, "7", "SEDUCTION_BOOST", "Seductive");                //Left Branch
        PerkNode p7_2 = new PerkNode(p7_1, "7", "UNARMED_DAMAGE", "Hand-to-Hand");
        PerkNode p7_8 = new PerkNode(p6_6, "7", "AURA_BOOST", "Aura Reserves");
        PerkNode p7_4 = new PerkNode(p6_1, "7", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p7_3 = new PerkNode(p7_4, "7", "ENERGY_BOOST_DRAIN_DAMAGE", "Aura Shielding");
        PerkNode p7_7 = new PerkNode(p6_3, "7", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p7_9 = new PerkNode(p6_6, "7", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p7_10 = new PerkNode(p7_9, "7", "SPELL_DAMAGE", "Spell Power");

        PerkNode p8_1 = new PerkNode(p7_1, "8", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p8_3 = new PerkNode(p7_4, "8", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p8_12 = new PerkNode(p7_10, "8", "SPELL_DAMAGE", "Spell Power");
        PerkNode p8_5 = new PerkNode(p7_5, "8", "SEDUCTION_BOOST", "Seductive");
        PerkNode p8_10 = new PerkNode(p7_8, "8", "AURA_BOOST", "Aura Reserves");
        PerkNode p8_4 = new PerkNode(p7_4, "8", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p8_2 = new PerkNode(p8_1, "8", "MELEE_DAMAGE", "Melee Weapons Expert");
        PerkNode p8_7 = new PerkNode(p7_6, "8", "SEDUCTION_BOOST_MAJOR", "Seductive");
        PerkNode p8_6 = new PerkNode(p8_7, "8", "CONVINCING_REQUESTS", "Irresistible Appeals");
        PerkNode p8_8 = new PerkNode(p8_7, "8", "OBJECT_OF_DESIRE", "Object of Desire");
        PerkNode p8_9 = new PerkNode(p7_7, "8", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p8_11 = new PerkNode(p7_9, "8", "SPELL_EFFICIENCY", "Spell Efficiency");

        PerkNode p9_1 = new PerkNode(p8_1, "9", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p9_3 = new PerkNode(p8_3, "9", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p9_6 = new PerkNode(p8_7, "9", "SEDUCTION_BOOST_ALT", "Seductive");                //Middle Branch
        PerkNode p9_5 = new PerkNode(p8_5, "9", "SEDUCTION_BOOST", "Seductive");                    //Left Branch
        PerkNode p9_4 = new PerkNode(p8_4, "9", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p9_2 = new PerkNode(p9_1, "9", "RANGED_DAMAGE", "Sharp-shooter");
        PerkNode p9_10 = new PerkNode(p8_12, "9", "SPELL_DAMAGE_MAJOR", "Spell Mastery");
        PerkNode p9_7 = new PerkNode(p8_9, "9", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p9_9 = new PerkNode(p8_11, "9", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p9_8 = new PerkNode(p9_9, "9", "AURA_BOOST", "Aura Reserves");

        PerkNode p10_5 = new PerkNode(p9_6, "10", "NYMPHOMANIAC", "Nymphomaniac");
        PerkNode p10_7 = new PerkNode(p9_8, "10", "SACRIFICIAL_SHIELDING", "Sacrificial Shielding");
        PerkNode p10_3 = new PerkNode(p9_3, p9_4, "10", "COMBAT_REGENERATION", "Combat Regeneration");
        PerkNode p10_1 = new PerkNode(p9_1, "10", "FEROCIOUS_WARRIOR", "Ferocious Warrior");
        PerkNode p10_6 = new PerkNode(p9_7, "10", "PURE_MIND", "Pure Thoughts");
        PerkNode p10_4 = new PerkNode(p9_5, "10", "LUSTPYRE", "Lustpyre");
        PerkNode p10_2 = new PerkNode(p10_1, "10", "BESERK", "Berserk");
        PerkNode p10_8 = new PerkNode(p9_9, "10", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p10_9 = new PerkNode(p9_10, "10", "ARCANE_VAMPYRISM", "Arcane Vampyrism");

        PerkNode p11_2 = new PerkNode(p10_1, p10_3, "11", "PHYSIQUE_BOOST_MAJOR", "Physically Fit");
        PerkNode p11_6 = new PerkNode(p10_8, "11", "ARCANE_BOOST_MAJOR", "Arcane Affinity");
        PerkNode p11_5 = new PerkNode(p11_6, "11", "ELEMENTAL_DEFENCE_BOOST", "Elemental Defender");
        PerkNode p11_1 = new PerkNode(p11_2, "11", "MELEE_DAMAGE", "Melee Weapons Expert");
        PerkNode p11_4 = new PerkNode(p10_4, p10_6, "11", "SEDUCTION_BOOST_MAJOR", "Seductive");
        PerkNode p11_3 = new PerkNode(p11_2, "11", "RANGED_DAMAGE", "Sharp-shooter");
        PerkNode p11_7 = new PerkNode(p11_6, "11", "ELEMENTAL_BOOST", "Elemental Striker");

        PerkNode p12_1 = new PerkNode(p11_2, "12", "ELEMENTAL_BOOST", "Elemental Striker");         //Physical
        PerkNode p12_2 = new PerkNode(p11_4, "12", "ELEMENTAL_BOOST_ALT", "Elemental Striker");     //Seductive
        PerkNode p12_3 = new PerkNode(p11_6, "12", "ELEMENTAL_BOOST_ALT_2", "Elemental Striker");   //Arcane

        Perks = new List<PerkNode>
        {
            p1_1, p1_2, p1_3, p2_11, p2_10, p2_2, p2_6, p2_7, p2_1, p2_4, p2_5, p2_8, p2_3, p2_9, p3_3, p3_11, p3_7, p3_12, p3_5, p3_8, p3_13, p3_1, p3_6, p3_2, p3_9, p3_4, p3_10, p4_3, p4_1, p4_11,
            p4_6, p4_4, p4_9, p4_12, p4_2, p4_10, p4_5, p4_8, p4_13, p4_7, p5_13, p5_9, p5_4, p5_10, p5_3, p5_7, p5_11, p5_12, p5_2, p5_1, p5_5, p5_6, p5_8, p6_1, p6_3, p6_2, p6_4, p6_6, p7_1, p7_6,
            p7_5, p7_2, p7_8, p7_4, p7_3, p7_7, p7_9, p7_10, p8_1, p8_3, p8_12, p8_5, p8_10, p8_4, p8_2, p8_7, p8_6, p8_8, p8_9, p8_11, p9_1, p9_3, p9_6, p9_5, p9_4, p9_2, p9_10, p9_7, p9_9, p9_8,
            p10_5, p10_7, p10_3, p10_1, p10_6, p10_4, p10_2, p10_8, p10_9, p11_2, p11_6, p11_5, p11_1, p11_4, p11_3, p11_7, p12_1, p12_2, p12_3
        };
    }
}