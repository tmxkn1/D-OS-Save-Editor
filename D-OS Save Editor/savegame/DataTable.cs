﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace D_OS_Save_Editor
{
    public class DataTable
    {
        public enum Attributes
        {
            Strength = 0,
            Dexerity,
            Intelligence,
            Consitution,
            Speed,
            Perception
        }

        public enum Abilities
        {
            ManAtArms = 0,
            ExpertMarksman,
            Scoundrel,
            SingleHanded,
            TwoHanded,
            PlaceHolder_1,
            Bow,
            Crossbow,
            ShieldSpecialist,
            PlaceHolder_2,
            ArmorSpecialist,
            Witchcraft,
            Telekinesis,
            Willpower,
            Pyrokinetic,
            Hydrosophist,
            Aerotheurge,
            Geomancer,
            Blacksmithing,
            Sneaking,
            Pickpocketing,
            Lockpicking,
            Loremaster,
            Crafting,
            Bartering,
            PlaceHolder_3,
            PlaceHolder_4,
            PlaceHolder_5,
            Charisma,
            Leadership,
            LuckyCharm,
            Bodybuilding,
            DuelWelding,
            Wand
        }

        public static Dictionary<string, string> Traits;

        public static string[] Skills =
        {

        };

        /// <summary>
        /// Names used for Gold category items
        /// </summary>
        public static readonly string[] GoldNames =
            {"small_gold", "inbetween_gold", "trader_large_gold", "trader_insane_gold"};

        /// <summary>
        /// Names used for Arrow category items. Arrow items have prefix WPN which is shared with the Weapon category. Therefore, we need these strings to identify the Arrow category.
        /// </summary>
        public static readonly string[] ArrowTypeNames = {"arrow", "arrowhead", "arrowshaft"};

        public static string[] TraitNames =
        {
            "Forgiving",
            "Vindictive",
            "Bold",
            "Cautious",
            "Altruistic",
            "Egotistical",
            "Independent",
            "Obedient",
            "Pragmatic",
            "Romantic",
            "Spiritual",
            "Materialistic",
            "Righteous",
            "Renegade",
            "Blunt",
            "Considerate",
            "Compassionate",
            "Heartless"
        };

        public static string[] TraitEffects =
        {
            "Immune to Cursed",
            "+20% chance to hit on attacks of opportunity",
            "+1 Initiative",
            "+1 Sneaking",
            "+2 Reputation",
            "+1 Bartering",
            "+1 Willpower",
            "+1 Willpower when an ally with Leadership is in sight (+2 Willpower if ally has Leadership 5 or higher)",
            "+1 Crafting",
            "+1 Lucky Charm",
            "Immune to Fear",
            "+1 Loremaster",
            "+1 Leadership",
            "+1 Pickpocketing",
            "Immune to Charmed",
            "+1 Charisma",
            "`+3% Critical Chance",
            "+20% chance to hit when backstabbing"
        };

        public static string[] GenerationBoosts =
        {
            "Armor_Belt_Boost_Bow",
            "Armor_Belt_Boost_DualWield",
            "Armor_Belt_Boost_PoisonRes_Mod",
            "Armor_Belt_Boost_PoisonRes_ModLarge",
            "Armor_Belt_Boost_PoisonRes_ModLate",
            "Armor_Belt_Boost_PoisonRes_ModSmall",
            "Armor_Belt_Boost_ShadowRes_Mod",
            "Armor_Belt_Boost_ShadowRes_ModLarge",
            "Armor_Belt_Boost_VitalityBoost_Mod",
            "Armor_Belt_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor_Belt_Boost_VitalityBoost_Mod_LargeLate",
            "Armor_Belt_Boost_VitalityBoost_Mod_Late",
            "Armor_Belt_Boost_VitalityBoost_Mod_Mid",
            "Armor_Body_Boost_Ranged",
            "Armor_Body_Boost_Ranged_Mod",
            "Armor_Body_Boost_Wands",
            "Armor_Body_Boost_Wands_Robe",
            "Armor_Boost_Amulet_Reflection_Air_Large",
            "Armor_Boost_Amulet_Reflection_Air_Legendary",
            "Armor_Boost_Amulet_Reflection_Air_Normal",
            "Armor_Boost_Amulet_Reflection_Earth_Large",
            "Armor_Boost_Amulet_Reflection_Earth_Legendary",
            "Armor_Boost_Amulet_Reflection_Earth_Normal",
            "Armor_Boost_Amulet_Reflection_Fire_Large",
            "Armor_Boost_Amulet_Reflection_Fire_Legendary",
            "Armor_Boost_Amulet_Reflection_Fire_Normal",
            "Armor_Boost_Amulet_Reflection_Water_Large",
            "Armor_Boost_Amulet_Reflection_Water_Legendary",
            "Armor_Boost_Amulet_Reflection_Water_Normal",
            "Armor_Boost_DEX_Mod_Ring",
            "Armor_Boost_FreezeContact_Ring",
            "Armor_Boost_Heal_CureWoundsKnight",
            "Armor_Boost_INT_Mod_Ring",
            "Armor_Boost_PoisonContact_Ring",
            "Armor_Boost_Projectile_BlitzBoltStartRing",
            "Armor_Boost_Projectile_BlitzBoltStartRingLate",
            "Armor_Boost_Projectile_FlareStartRing",
            "Armor_Boost_Projectile_FlareStartRingLate",
            "Armor_Boost_StunContact_Ring",
            "Armor_Boost_Target_Fortify",
            "Armor_Boost_Target_VampiricTouchRing",
            "Armor_Gloves_Boost_VitalityBoost_Mod",
            "Armor_Gloves_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor_Gloves_Boost_VitalityBoost_Mod_LargeLate",
            "Armor_Gloves_Boost_VitalityBoost_Mod_LargeLate ",
            "Armor_Gloves_Boost_VitalityBoost_Mod_Late",
            "Armor_Gloves_Boost_VitalityBoost_Mod_Mid",
            "Armor_Gloves_DefenseValue_ArmorBoost_Large",
            "Armor_Gloves_DefenseValue_ArmorBoost_Large_Late",
            "Armor_Gloves_DefenseValue_ArmorBoost_Large_Mid",
            "Armor_Gloves_DefenseValue_ArmorBoost_Normal",
            "Armor_Gloves_DefenseValue_ArmorBoost_Normal_Late",
            "Armor_Gloves_DefenseValue_ArmorBoost_Normal_Mid",
            "Armor_Gloves_ReflectMelee",
            "Armor_Gloves_ReflectMelee_Large",
            "Armor_Helmet_DefenseValue_Legendary_ArmorBoost",
            "Armor_Helmet_DefenseValue_Medium_ArmorBoost",
            "Armor_Helmet_Medium_ArmorDefense_Mod",
            "Armor_Helmet_Small_ArmorDefense_Mod",
            "Armor_Helmet_Target_Farsight",
            "Armor_Helmet_Target_TargetedPerception",
            "Armor_Large_AirResistance_ModRing",
            "Armor_Large_AirResistance_ModRing_Late",
            "Armor_Large_AirResistance_Mod_Amulet",
            "Armor_Large_AirResistance_Mod_Amulet_Late",
            "Armor_Large_ArmorDefense_ModHelmet",
            "Armor_Large_ArmorDefense_Mod_LateMail",
            "Armor_Large_ArmorDefense_Mod_LatePlate",
            "Armor_Large_EarthResistance_ModRing",
            "Armor_Large_EarthResistance_ModRing_Late",
            "Armor_Large_EarthResistance_Mod_Amulet_Late",
            "Armor_Large_FireResistance_ModRing",
            "Armor_Large_FireResistance_ModRing_Late",
            "Armor_Large_FireResistance_Mod_Amulet",
            "Armor_Large_FireResistance_Mod_Amulet_Late",
            "Armor_Large_WaterResistance_ModRing",
            "Armor_Large_WaterResistance_ModRing_Late",
            "Armor_Large_WaterResistance_Mod_Amulet",
            "Armor_Legendary_ArmorDefense_ModPlate",
            "Armor_Medium_ArmorDefense_ModMail_Late",
            "Armor_Medium_ArmorDefense_ModPlate_Late",
            "Armor_Path_Firefly_Garment",
            "Armor_ReflectMelee",
            "Armor_ReflectMelee_Large",
            "Armor_ReflectMelee_Plate",
            "Armor_Ring_Boost_BurnImmunity",
            "Armor_Ring_Boost_BurnImmunity_Late",
            "Armor_Ring_Boost_FreezeImmunity",
            "Armor_Ring_Boost_FreezeImmunity_Late",
            "Armor_Ring_Boost_PetrifiedImmunity",
            "Armor_Ring_Boost_PetrifiedImmunity_Late",
            "Armor_Ring_Boost_StunImmunity",
            "Armor_Ring_Boost_StunImmunity_Late",
            "Armor_Shield_Air_Amulet",
            "Armor_Shield_Earth_Amulet",
            "Armor_Shield_Fire_Amulet",
            "Armor_Shield_Water_Amulet",
            "Armor_Shoes_DefenseValue_ArmorBoost",
            "Armor_Shoes_DefenseValue_Large_ArmorBoost",
            "Armor_Shoes_DefenseValue_Legendary_ArmorBoost",
            "Armor_Shoes_DefenseValue_Medium_ArmorBoost",
            "Armor_Shoes_DefenseValue_Medium_ArmorBoost_Early",
            "Armor_Small_AirResistance_ModAmulet",
            "Armor_Small_AirResistance_ModRing",
            "Armor_Small_AirResistance_ModRing_Late",
            "Armor_Small_AirResistance_Mod_Amulet_Late",
            "Armor_Small_ArmorDefense_ModLeather",
            "Armor_Small_ArmorDefense_ModPlate",
            "Armor_Small_EarthResistance_ModAmulet",
            "Armor_Small_EarthResistance_ModRing",
            "Armor_Small_EarthResistance_ModRing_Late",
            "Armor_Small_EarthResistance_Mod_Amulet_Late",
            "Armor_Small_FireResistance_ModAmulet",
            "Armor_Small_FireResistance_ModRing",
            "Armor_Small_FireResistance_ModRing_Late",
            "Armor_Small_FireResistance_Mod_Amulet_Late",
            "Armor_Small_WaterResistance_ModAmulet",
            "Armor_Small_WaterResistance_ModRing",
            "Armor_Small_WaterResistance_ModRing_Late",
            "Armor_Small_WaterResistance_Mod_Amulet_Late",
            "Armor_Summon_Undead_Garment",
            "Armor_Target_InvisibilityTarget_Garment",
            "Armor_Target_PetrifyingTouch_Garment",
            "Armor_Target_PurifyingFire_Garment",
            "Armor_Teleportation_Resurrect_Garment",
            "Armor_Tornado_Air_Garment",
            "Armor_Unbreakable_Mod_Helmet",
            "Armor_Unbreakable_Mod_Plate",
            "Armor__AmuletBoost_Initiative_Mod_Late",
            "Armor__AmuletBoost_Initiative_Mod_Mid",
            "Armor__Amulet_Boost_Barter_Mod",
            "Armor__Amulet_Boost_Blackrock_Mod",
            "Armor__Amulet_Boost_Charisma_Mod",
            "Armor__Amulet_Boost_DEX_Mod",
            "Armor__Amulet_Boost_DEX_Mod_Large",
            "Armor__Amulet_Boost_INT _Mod_Large",
            "Armor__Amulet_Boost_INT_Mod",
            "Armor__Amulet_Boost_INT_Mod_Large",
            "Armor__Amulet_Boost_Initiative_Mod",
            "Armor__Amulet_Boost_Loremaster_Mod",
            "Armor__Amulet_Boost_PoisonRes_Mod",
            "Armor__Amulet_Boost_PoisonRes_Mod_Large",
            "Armor__Amulet_Boost_SPD_Mod_Large",
            "Armor__Amulet_Boost_STR_Mod",
            "Armor__Amulet_Boost_STR_Mod_Large",
            "Armor__Amulet_Boost_ShadowRes_Mod",
            "Armor__Amulet_Boost_ShadowRes_Mod_Large",
            "Armor__Amulet_Boost_VitalityBoost_Mod",
            "Armor__Amulet_Boost_VitalityBoost_Mod_LargeLate",
            "Armor__Amulet_Boost_VitalityBoost_Mod_Late",
            "Armor__Amulet_Boost_VitalityBoost_Mod_Mid",
            "Armor__Armor_Boost_BleedingImmunityLeather",
            "Armor__Armor_Boost_BleedingImmunityLeather_Late",
            "Armor__Armor_Boost_BlindImmunity",
            "Armor__Armor_Boost_BurnContactPlate",
            "Armor__Armor_Boost_BurnContact_All",
            "Armor__Armor_Boost_CrippledImmunityBoots",
            "Armor__Armor_Boost_CursedImmunityRobe",
            "Armor__Armor_Boost_CursedImmunityRobe_Late",
            "Armor__Armor_Boost_FearImmunityMail",
            "Armor__Armor_Boost_FearImmunityMail_Late",
            "Armor__Armor_Boost_FreezeContactPlate",
            "Armor__Armor_Boost_FreezeContact_All",
            "Armor__Armor_Boost_KnockdownImmunity_All",
            "Armor__Armor_Boost_MuteImmunity",
            "Armor__Armor_Boost_MuteImmunityRobe",
            "Armor__Armor_Boost_MuteImmunityRobe_Late",
            "Armor__Armor_Boost_PoisonContactLeather",
            "Armor__Armor_Boost_PoisonContact_All",
            "Armor__Armor_Boost_PoisonImmunityLeather",
            "Armor__Armor_Boost_PoisonImmunity_All",
            "Armor__Armor_Boost_SlowedImmunity",
            "Armor__Armor_Boost_StunContactPlate",
            "Armor__Armor_Boost_StunContact_All",
            "Armor__Belt_Boost_BodyBuilding_Mod",
            "Armor__Belt_Boost_Bow_Mod",
            "Armor__Belt_Boost_Crafting_Mod",
            "Armor__Belt_Boost_Crossbow_Mod",
            "Armor__Belt_Boost_DEX_Mod",
            "Armor__Belt_Boost_Initiative_Mod",
            "Armor__Belt_Boost_Initiative_Mod_Late",
            "Armor__Belt_Boost_Initiative_Mod_Mid",
            "Armor__Belt_Boost_Lockpicking_Mod",
            "Armor__Belt_Boost_Repair_Mod",
            "Armor__Belt_Boost_STR_Mod",
            "Armor__Belt_Boost_STR_Mod_Late",
            "Armor__Belt_Boost_Shield_Mod",
            "Armor__Belt_Boost_TwoHanded_Mod",
            "Armor__Belt_Boost_XBow_Mod",
            "Armor__Body_Boost_AirRes_ModHuge",
            "Armor__Body_Boost_AirRes_ModLarge",
            "Armor__Body_Boost_AirRes_ModNormal",
            "Armor__Body_Boost_AirRes_ModNormal_Late",
            "Armor__Body_Boost_ArmorMastery_ModMail",
            "Armor__Body_Boost_ArmorMastery_ModPlate",
            "Armor__Body_Boost_CON_Mod",
            "Armor__Body_Boost_CON_Mod_Late",
            "Armor__Body_Boost_DEX_Mod",
            "Armor__Body_Boost_DEX_Mod_Late",
            "Armor__Body_Boost_EarthRes_ModHuge",
            "Armor__Body_Boost_EarthRes_ModLarge",
            "Armor__Body_Boost_EarthRes_ModNormal",
            "Armor__Body_Boost_EarthRes_ModNormal_Late",
            "Armor__Body_Boost_FireRes_ModHuge",
            "Armor__Body_Boost_FireRes_ModLarge",
            "Armor__Body_Boost_FireRes_ModNormal",
            "Armor__Body_Boost_FireRes_ModNormal_Late",
            "Armor__Body_Boost_INT_ModRobe",
            "Armor__Body_Boost_INT_Mod_Late",
            "Armor__Body_Boost_Movement_ClothMod_Late",
            "Armor__Body_Boost_Movement_ClothMod_Mid",
            "Armor__Body_Boost_Movement_Mod",
            "Armor__Body_Boost_Movement_Mod_Late",
            "Armor__Body_Boost_Movement_Mod_Mid",
            "Armor__Body_Boost_PER_Mod",
            "Armor__Body_Boost_PER_Mod_Late",
            "Armor__Body_Boost_Ranged",
            "Armor__Body_Boost_SPD_Mod",
            "Armor__Body_Boost_SPD_Mod_Late",
            "Armor__Body_Boost_STR_Mod",
            "Armor__Body_Boost_STR_Mod_Late",
            "Armor__Body_Boost_VitalityBoost_Mod",
            "Armor__Body_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor__Body_Boost_VitalityBoost_Mod_LargeMid",
            "Armor__Body_Boost_VitalityBoost_Mod_Late",
            "Armor__Body_Boost_VitalityBoost_Mod_Mid",
            "Armor__Body_Boost_WaterRes_ModHuge",
            "Armor__Body_Boost_WaterRes_ModLarge",
            "Armor__Body_Boost_WaterRes_ModNormal",
            "Armor__Body_Boost_WaterRes_ModNormal_Late",
            "Armor__Garment_Boost_AirRes_Mod",
            "Armor__Garment_Boost_AirRes_ModLarge",
            "Armor__Garment_Boost_AirRes_ModLate",
            "Armor__Garment_Boost_AirRes_ModSmall",
            "Armor__Garment_Boost_BodyBuilding_Mod",
            "Armor__Garment_Boost_DEX_Mod",
            "Armor__Garment_Boost_DEX_ModLate",
            "Armor__Garment_Boost_EarthRes_Mod",
            "Armor__Garment_Boost_EarthRes_ModLarge",
            "Armor__Garment_Boost_EarthRes_ModLate",
            "Armor__Garment_Boost_EarthRes_ModSmall",
            "Armor__Garment_Boost_FireRes_Mod",
            "Armor__Garment_Boost_FireRes_ModLarge",
            "Armor__Garment_Boost_FireRes_ModLate",
            "Armor__Garment_Boost_INT_Mod",
            "Armor__Garment_Boost_INT_ModLate",
            "Armor__Garment_Boost_Initiative_Mod",
            "Armor__Garment_Boost_Initiative_Mod_Mid",
            "Armor__Garment_Boost_PoisonRes_Mod",
            "Armor__Garment_Boost_PoisonRes_ModLarge",
            "Armor__Garment_Boost_PoisonRes_ModLate",
            "Armor__Garment_Boost_PoisonRes_ModSmall",
            "Armor__Garment_Boost_STR_Mod",
            "Armor__Garment_Boost_STR_ModLate",
            "Armor__Garment_Boost_ShadowRes_Mod",
            "Armor__Garment_Boost_ShadowRes_ModLarge",
            "Armor__Garment_Boost_VitalityBoost_Mod",
            "Armor__Garment_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor__Garment_Boost_VitalityBoost_Mod_LargeMid",
            "Armor__Garment_Boost_VitalityBoost_Mod_Mid",
            "Armor__Garment_Boost_WaterRes_Mod",
            "Armor__Garment_Boost_WaterRes_ModLarge",
            "Armor__Garment_Boost_WaterRes_ModLate",
            "Armor__Garment_Boost_WaterRes_ModSmall",
            "Armor__Garment_Boost_Willpower_Mod",
            "Armor__Gloves_Boost_Crafting_Mod",
            "Armor__Gloves_Boost_DEX_Mod",
            "Armor__Gloves_Boost_Initiative_Mod",
            "Armor__Gloves_Boost_Initiative_Mod_Late",
            "Armor__Gloves_Boost_Initiative_Mod_Mid",
            "Armor__Gloves_Boost_Lockpicking_Mod",
            "Armor__Gloves_Boost_Pickpocket_Mod",
            "Armor__Gloves_Boost_Ranged_Mod",
            "Armor__Gloves_Boost_Ranged_Xbow_Mod",
            "Armor__Gloves_Boost_Repair_Mod",
            "Armor__Gloves_Boost_SingleHanded_Mod",
            "Armor__Gloves_Boost_Telekinesis_Mod",
            "Armor__HelmetBoost_Initiative_Mod",
            "Armor__HelmetBoost_Initiative_Mod_Late",
            "Armor__HelmetBoost_Initiative_Mod_Mid",
            "Armor__Helmet_Boost_ArmorMastery_Mod",
            "Armor__Helmet_Boost_ArmorMastery_Mod_Late",
            "Armor__Helmet_Boost_CON_Mod",
            "Armor__Helmet_Boost_CON_Mod_Late",
            "Armor__Helmet_Boost_Leadership_Mod",
            "Armor__Helmet_Boost_PER_Mod",
            "Armor__Helmet_Boost_Sneaking_Mod",
            "Armor__Helmet_Boost_VitalityBoost_Mod",
            "Armor__Helmet_Boost_VitalityBoost_Mod_LargeEarly",
            "Armor__Helmet_Boost_VitalityBoost_Mod_LargeLate",
            "Armor__Helmet_Boost_VitalityBoost_Mod_Late",
            "Armor__Helmet_Boost_VitalityBoost_Mod_Mid",
            "Armor__Ring_Boost_Blackrock_Mod",
            "Armor__Ring_Boost_CON_Mod",
            "Armor__Ring_Boost_Lockpicking_Mod",
            "Armor__Ring_Boost_Loremaster_Mod",
            "Armor__Ring_Boost_Movement_Mod",
            "Armor__Ring_Boost_Movement_Mod_Large",
            "Armor__Ring_Boost_Movement_Mod_Medium",
            "Armor__Ring_Boost_Movement_Mod_Super",
            "Armor__Ring_Boost_PER_Mod",
            "Armor__Ring_Boost_Pickpocketing_Mod",
            "Armor__Ring_Boost_PoisonRes_Mod",
            "Armor__Ring_Boost_PoisonRes_Mod_Large",
            "Armor__Ring_Boost_SPD_Mod",
            "Armor__Ring_Boost_ShadowRes_Mod",
            "Armor__Ring_Boost_ShadowRes_Mod_Large",
            "Armor__Ring_Boost_Telekinesis_Mod",
            "Armor__Shoes_Boost_ActionPoints_Mod",
            "Armor__Shoes_Boost_Air_Mod",
            "Armor__Shoes_Boost_Air_ModLarge",
            "Armor__Shoes_Boost_Air_Mod_Mid",
            "Armor__Shoes_Boost_Air_Mod_Mid_Large",
            "Armor__Shoes_Boost_Barter_Mod",
            "Armor__Shoes_Boost_Earth_Mod",
            "Armor__Shoes_Boost_Earth_ModLarge",
            "Armor__Shoes_Boost_Earth_Mod_Mid",
            "Armor__Shoes_Boost_Earth_Mod_Mid_Large",
            "Armor__Shoes_Boost_Fire_Mod",
            "Armor__Shoes_Boost_Fire_ModLarge",
            "Armor__Shoes_Boost_Fire_Mod_Mid",
            "Armor__Shoes_Boost_Fire_Mod_Mid_Large",
            "Armor__Shoes_Boost_Initiative_Mod",
            "Armor__Shoes_Boost_Initiative_Mod_Late",
            "Armor__Shoes_Boost_Initiative_Mod_Mid",
            "Armor__Shoes_Boost_Luck_Mod",
            "Armor__Shoes_Boost_Movement_Mod",
            "Armor__Shoes_Boost_Movement_Mod_Large",
            "Armor__Shoes_Boost_Movement_Mod_Medium",
            "Armor__Shoes_Boost_Movement_Mod_Super",
            "Armor__Shoes_Boost_Pickpocket_Mod",
            "Armor__Shoes_Boost_SPD_Mod",
            "Armor__Shoes_Boost_Sneaking_Mod",
            "Armor__Shoes_Boost_VitalityBoost_Mod",
            "Armor__Shoes_Boost_VitalityBoost_Mod_Huge",
            "Armor__Shoes_Boost_VitalityBoost_Mod_Large",
            "Armor__Shoes_Boost_VitalityBoost_Mod_Large_Late",
            "Armor__Shoes_Boost_Water_Mod",
            "Armor__Shoes_Boost_Water_ModLarge",
            "Armor__Shoes_Boost_Water_Mod_Mid",
            "Armor__Shoes_Boost_Water_Mod_Mid_Large",
            "Belt",
            "Shield_CrippledImmunity",
            "Shield_FreezeImmunity",
            "Shield_Giant_AirResistance_Mod",
            "Shield_Giant_EarthResistance_Mod",
            "Shield_Giant_FireResistance_Mod",
            "Shield_Large_AirResistance_Mod",
            "Shield_Large_Blocking_Mod",
            "Shield_Large_EarthResistance_Mod",
            "Shield_Large_FireResistance_Mod",
            "Shield_Large_WaterResistance_Mod",
            "Shield_Legendary_FireResistance_Mod",
            "Shield_Legendary_WaterResistance_Mod",
            "Shield_Medium_Blocking_Mod",
            "Shield_Medium_Blocking_Mod_Late",
            "Shield_Normal_AirResistance_Mod",
            "Shield_Normal_EarthResistance_Mod",
            "Shield_Normal_FireResistance_Mod",
            "Shield_Normal_Movement_Mod_Large",
            "Shield_Normal_WaterResistance_Mod",
            "Shield_ReflectMelee_Large",
            "Shield_ReflectMelee_Legendary",
            "Shield_ReflectMelee_Medium",
            "Shield_ReflectMelee_Small",
            "Shield_Reflect_Melee_Air_Large",
            "Shield_Reflect_Melee_Earth_Large",
            "Shield_Small_AirResistance_Mod",
            "Shield_Small_Blocking_Mod",
            "Shield_Small_Consitution_Mod",
            "Shield_Small_EarthResistance_Mod",
            "Shield_Small_EarthResistance_Mod_Late",
            "Shield_Small_FireResistance_Mod",
            "Shield_Small_FireResistance_Mod_Late",
            "Shield_Small_Luck_Mod",
            "Shield_Small_Movement_Mod",
            "Shield_Small_Movement_Mod_Large",
            "Shield_Small_Movement_Mod_Medium",
            "Shield_Small_WaterResistance_Mod",
            "Shield_Smallest_Blocking_Mod",
            "Shield_StunImmunity",
            "Shield_Unbreakable_Mod",
            "Weapon_Air_Legendary_Skill_WeaponBoost_Axe",
            "Weapon_Air_Legendary_Skill_WeaponBoost_Bow",
            "Weapon_Bleeding_Large_WeaponBoost_All",
            "Weapon_Bleeding_Large_WeaponBoost_Axe",
            "Weapon_Bleeding_Large_WeaponBoost_Bow",
            "Weapon_Bleeding_Large_WeaponBoost_Knife",
            "Weapon_Bleeding_Large_WeaponBoost_Spear",
            "Weapon_Bleeding_Large_WeaponBoost_Xbow",
            "Weapon_Bleeding_WeaponBoost_Bow",
            "Weapon_Bleeding_WeaponBoost_Xbow",
            "Weapon_Blind_Large_WeaponBoost_All",
            "Weapon_Blind_Large_WeaponBoost_Staff",
            "Weapon_Blind_Large_WeaponBoost_Wand",
            "Weapon_Blind_WeaponBoost_Staff",
            "Weapon_Blind_WeaponBoost_Wand",
            "Weapon_Cripple_Large_WeaponBoost_Axe_All",
            "Weapon_Cripple_Large_WeaponBoost_Axe_Late",
            "Weapon_Cripple_Large_WeaponBoost_Club_Late",
            "Weapon_Cripple_Large_WeaponBoost_Staff_Late",
            "Weapon_Cripple_Large_WeaponBoost_Sword_Late",
            "Weapon_Cripple_WeaponBoost_Axe",
            "Weapon_Cripple_WeaponBoost_Staff",
            "Weapon_Cripple_WeaponBoost_Sword",
            "Weapon_Crit_Giant_WeaponBoost",
            "Weapon_Crit_Giant_WeaponBoost_Late",
            "Weapon_Crit_Huge_WeaponBoost",
            "Weapon_Crit_Huge_WeaponBoost_Late",
            "Weapon_Cursed_Large_WeaponBoost_All",
            "Weapon_Cursed_Large_WeaponBoost_Wand",
            "Weapon_Cursed_WeaponBoost_Staff",
            "Weapon_Cursed_WeaponBoost_Wand",
            "Weapon_Damage_Mod_Axe",
            "Weapon_Damage_Mod_Club",
            "Weapon_Damage_Mod_ModKnife",
            "Weapon_Damage_Mod_Sword",
            "Weapon_Damage_Mod_Wand",
            "Weapon_Diseased_WeaponBoost_Knife",
            "Weapon_Earth_Legendary_Skill_WeaponBoost_Club",
            "Weapon_Earth_Legendary_Skill_WeaponBoost_Crossbow",
            "Weapon_Earth_Legendary_Skill_WeaponBoost_Knife",
            "Weapon_FearLarge_Mod_All",
            "Weapon_FearLarge_Mod_Spear",
            "Weapon_Fire_Legendary_Skill_WeaponBoost_Axe",
            "Weapon_Fire_Legendary_Skill_WeaponBoost_Club",
            "Weapon_Fire_Legendary_Skill_WeaponBoost_Crossbow",
            "Weapon_Fire_Legendary_Skill_WeaponBoost_Knife",
            "Weapon_Fire_Legendary_Skill_WeaponBoost_Spear",
            "Weapon_Fire_Legendary_Skill_WeaponBoost_Sword",
            "Weapon_Giant_AirDamage_ModAxe",
            "Weapon_Giant_AirDamage_ModAxe_Late",
            "Weapon_Giant_AirDamage_ModBow",
            "Weapon_Giant_AirDamage_ModBow_Late",
            "Weapon_Giant_AirDamage_ModClub",
            "Weapon_Giant_AirDamage_ModClub_Late",
            "Weapon_Giant_AirDamage_ModKnife",
            "Weapon_Giant_AirDamage_ModKnife_Late",
            "Weapon_Giant_AirDamage_ModSword",
            "Weapon_Giant_AirDamage_ModSword_Late",
            "Weapon_Giant_AirDamage_ModXBow",
            "Weapon_Giant_AirDamage_ModXBow_Late",
            "Weapon_Giant_EarthDamage_ModAxe",
            "Weapon_Giant_EarthDamage_ModAxe_Late",
            "Weapon_Giant_EarthDamage_ModBow",
            "Weapon_Giant_EarthDamage_ModBow_Late",
            "Weapon_Giant_EarthDamage_ModClub",
            "Weapon_Giant_EarthDamage_ModClub_Late",
            "Weapon_Giant_EarthDamage_ModKnife",
            "Weapon_Giant_EarthDamage_ModKnife_Late",
            "Weapon_Giant_EarthDamage_ModSword",
            "Weapon_Giant_EarthDamage_ModSword_Late",
            "Weapon_Giant_EarthDamage_ModXBow",
            "Weapon_Giant_EarthDamage_ModXBow_Late",
            "Weapon_Giant_FireDamage_ModAxe",
            "Weapon_Giant_FireDamage_ModAxe_Late",
            "Weapon_Giant_FireDamage_ModBow",
            "Weapon_Giant_FireDamage_ModBow_Late",
            "Weapon_Giant_FireDamage_ModClub",
            "Weapon_Giant_FireDamage_ModClub_Late",
            "Weapon_Giant_FireDamage_ModKnife",
            "Weapon_Giant_FireDamage_ModKnife_Late",
            "Weapon_Giant_FireDamage_ModSpear_Late",
            "Weapon_Giant_FireDamage_ModSword",
            "Weapon_Giant_FireDamage_ModSword_Late",
            "Weapon_Giant_FireDamage_ModXBow",
            "Weapon_Giant_FireDamage_ModXBow_Late",
            "Weapon_Giant_Vitality_Mod_Late",
            "Weapon_Giant_Vitality_Mod_Mid",
            "Weapon_Giant_WaterDamage_ModAxe",
            "Weapon_Giant_WaterDamage_ModAxe_Late",
            "Weapon_Giant_WaterDamage_ModBow",
            "Weapon_Giant_WaterDamage_ModBow_Late",
            "Weapon_Giant_WaterDamage_ModClub",
            "Weapon_Giant_WaterDamage_ModClub_Late",
            "Weapon_Giant_WaterDamage_ModKnife",
            "Weapon_Giant_WaterDamage_ModKnife_Late",
            "Weapon_Giant_WaterDamage_ModSword",
            "Weapon_Giant_WaterDamage_ModSword_Late",
            "Weapon_Giant_WaterDamage_ModXBow",
            "Weapon_Giant_WaterDamage_ModXBow_Late",
            "Weapon_Huge_Damage_ModKnife",
            "Weapon_Huge_Damage_Mod_2H",
            "Weapon_Huge_Damage_Mod_Axe",
            "Weapon_Huge_Damage_Mod_Club",
            "Weapon_Huge_Damage_Mod_Sword",
            "Weapon_Huge_Damage_Mod_Wand",
            "Weapon_Knockdown_Mod",
            "Weapon_Knockdown_Mod_Large",
            "Weapon_Large_AirDamage_ModAxe",
            "Weapon_Large_AirDamage_ModAxe_Late",
            "Weapon_Large_AirDamage_ModBow",
            "Weapon_Large_AirDamage_ModBow_Late",
            "Weapon_Large_AirDamage_ModClub",
            "Weapon_Large_AirDamage_ModClub_Late",
            "Weapon_Large_AirDamage_ModKnife",
            "Weapon_Large_AirDamage_ModKnife_Late",
            "Weapon_Large_AirDamage_ModSword",
            "Weapon_Large_AirDamage_ModSword_Late",
            "Weapon_Large_AirDamage_ModXBow",
            "Weapon_Large_AirDamage_ModXBow_Late",
            "Weapon_Large_Crit_Mod_Early",
            "Weapon_Large_Crit_Mod_Late",
            "Weapon_Large_Damage_ModKnife",
            "Weapon_Large_Damage_Mod_2H",
            "Weapon_Large_Damage_Mod_Axe",
            "Weapon_Large_Damage_Mod_Sword",
            "Weapon_Large_Damage_Mod_Wand",
            "Weapon_Large_EarthDamage_ModAxe",
            "Weapon_Large_EarthDamage_ModAxe_Late",
            "Weapon_Large_EarthDamage_ModBow",
            "Weapon_Large_EarthDamage_ModBow_Late",
            "Weapon_Large_EarthDamage_ModClub",
            "Weapon_Large_EarthDamage_ModClub_Late",
            "Weapon_Large_EarthDamage_ModKnife",
            "Weapon_Large_EarthDamage_ModKnife_Late",
            "Weapon_Large_EarthDamage_ModSword",
            "Weapon_Large_EarthDamage_ModSword_Late",
            "Weapon_Large_EarthDamage_ModXBow",
            "Weapon_Large_EarthDamage_ModXBow_Late",
            "Weapon_Large_FireDamage_ModAxe",
            "Weapon_Large_FireDamage_ModAxe_Late",
            "Weapon_Large_FireDamage_ModBow",
            "Weapon_Large_FireDamage_ModBow_Late",
            "Weapon_Large_FireDamage_ModClub",
            "Weapon_Large_FireDamage_ModClub_Late",
            "Weapon_Large_FireDamage_ModKnife",
            "Weapon_Large_FireDamage_ModKnife_Late",
            "Weapon_Large_FireDamage_ModSpear_Late",
            "Weapon_Large_FireDamage_ModSword",
            "Weapon_Large_FireDamage_ModSword_Late",
            "Weapon_Large_FireDamage_ModXBow",
            "Weapon_Large_FireDamage_ModXBow_Late",
            "Weapon_Large_Vitality_Mod",
            "Weapon_Large_WaterDamage_ModAxe",
            "Weapon_Large_WaterDamage_ModAxe_Late",
            "Weapon_Large_WaterDamage_ModBow",
            "Weapon_Large_WaterDamage_ModBow_Late",
            "Weapon_Large_WaterDamage_ModClub",
            "Weapon_Large_WaterDamage_ModClub_Late",
            "Weapon_Large_WaterDamage_ModKnife",
            "Weapon_Large_WaterDamage_ModKnife_Late",
            "Weapon_Large_WaterDamage_ModSword",
            "Weapon_Large_WaterDamage_ModSword_Late",
            "Weapon_Large_WaterDamage_ModXBow",
            "Weapon_Large_WaterDamage_ModXBow_Late",
            "Weapon_Leadership_Mod",
            "Weapon_Legendary_Vitality_Mod_Sword",
            "Weapon_Medium_Damage_Mod_Club",
            "Weapon_Medium_Damage_Mod_Sword",
            "Weapon_Medium_Damage_Mod_Wand",
            "Weapon_Medium_Vitality_Mod",
            "Weapon_Movement_Dagger_WeaponBoost_Huge_Late",
            "Weapon_Movement_Dagger_WeaponBoost_Large_Late",
            "Weapon_Movement_Dagger_WeaponBoost_Late",
            "Weapon_Mute_Large_WeaponBoost_All",
            "Weapon_Mute_Large_WeaponBoost_Staff",
            "Weapon_Mute_Large_WeaponBoost_Wand",
            "Weapon_Normal_Damage_Mod_2H",
            "Weapon_Petrify_Large_WeaponBoost_All",
            "Weapon_Petrify_Large_WeaponBoost_Spear",
            "Weapon_Petrify_Large_WeaponBoost_Staff",
            "Weapon_Petrify_Large_WeaponBoost_Wand",
            "Weapon_Petrify_WeaponBoost_Wand",
            "Weapon_Raged_WeaponBoost_Bow",
            "Weapon_Raged_WeaponBoost_Knife",
            "Weapon_Raged_WeaponBoost_Sword",
            "Weapon_Small_AirDamage_ModAxe",
            "Weapon_Small_AirDamage_ModBow",
            "Weapon_Small_AirDamage_ModClub",
            "Weapon_Small_AirDamage_ModKnife",
            "Weapon_Small_AirDamage_ModSword",
            "Weapon_Small_AirDamage_ModXBow",
            "Weapon_Small_Consitution_Mod",
            "Weapon_Small_Consitution_Mod_Late",
            "Weapon_Small_Crit_Mod",
            "Weapon_Small_Damage_Mod_2H",
            "Weapon_Small_Damage_Mod_ModKnife",
            "Weapon_Small_Dexterity_ModBow",
            "Weapon_Small_Dexterity_ModBow_Late",
            "Weapon_Small_Dexterity_ModCrossbow",
            "Weapon_Small_Dexterity_ModCrossbow_Late",
            "Weapon_Small_Dexterity_ModKnife_Late",
            "Weapon_Small_EarthDamage_ModAxe",
            "Weapon_Small_EarthDamage_ModBow",
            "Weapon_Small_EarthDamage_ModClub",
            "Weapon_Small_EarthDamage_ModKnife",
            "Weapon_Small_EarthDamage_ModSword",
            "Weapon_Small_EarthDamage_ModXBow",
            "Weapon_Small_FireDamage_ModAxe",
            "Weapon_Small_FireDamage_ModBow",
            "Weapon_Small_FireDamage_ModClub",
            "Weapon_Small_FireDamage_ModKnife",
            "Weapon_Small_FireDamage_ModSword",
            "Weapon_Small_FireDamage_ModXBow",
            "Weapon_Small_Intelligence_ModStaffLarge",
            "Weapon_Small_Intelligence_ModStaff_Late",
            "Weapon_Small_Intelligence_ModWand",
            "Weapon_Small_Intelligence_ModWand_Late",
            "Weapon_Small_Perception_Mod",
            "Weapon_Small_Perception_Mod_Late",
            "Weapon_Small_Speed_Mod",
            "Weapon_Small_Speed_Mod_Late",
            "Weapon_Small_Strength_ModAxe_Late",
            "Weapon_Small_Strength_ModClub",
            "Weapon_Small_Strength_ModClub_Late",
            "Weapon_Small_Vitality_Mod",
            "Weapon_Small_WaterDamage_ModAxe",
            "Weapon_Small_WaterDamage_ModBow",
            "Weapon_Small_WaterDamage_ModClub",
            "Weapon_Small_WaterDamage_ModKnife",
            "Weapon_Small_WaterDamage_ModKnife_Late",
            "Weapon_Small_WaterDamage_ModSword",
            "Weapon_Small_WaterDamage_ModXBow",
            "Weapon_Unbreakable_Mod",
            "Weapon_Water_Legendary_Skill_WeaponBoost_Crossbow",
            "Weapon_Water_Legendary_Skill_WeaponBoost_Sword",
            "Weapon_WillPower_Mod"
        };

        public static string[] StatsBoosts =
        {
            "Has_Reflection\tFalse"
        };

        /// <summary>
        /// Generation boosts that is new to GenerationBoosts but exists in Online resource
        /// </summary>
        public static string[] GenerationBoostsAddOnline;

        public static string[] StatsBoostsAddedOnline;

        /// <summary>
        /// All generation boosts found in user's savegame
        /// </summary>
        public static string[] UserGenerationBoosts = { };

        public static string[] UserStatsBoosts = { };

        /// <summary>
        /// Generation boosts found in user's savegame but missing from bost GenerationBoosts and online resource
        /// </summary>
        public static string[] UnlistedGenerationBoosts = { };

        public static string[] UnlistedStatsBoosts = { };

        public static bool IsOnlineBoostsGenerated { get; private set; }

        public static async void GetTableFromOnline()
        {
            const string urlAddress =
                @"https://raw.githubusercontent.com/tmxkn1/D-OS-Save-Editor/master/GenerationBoosts.txt";
            var request = WebRequest.Create(urlAddress);
            IsOnlineBoostsGenerated = false;

            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null) return;
                    var boosts = new List<string>();

                    using (var sr = new StreamReader(stream))
                    {
                        string line;
                        while ((line = await sr.ReadLineAsync()) != null)
                        {
                            if (GenerationBoosts.Contains(line.Trim())) continue;
                            boosts.Add(line.Trim());
                        }

                        GenerationBoostsAddOnline = boosts.ToArray();

                        IsOnlineBoostsGenerated = true;

                        GetUnlistedStrings();
                    }
                }
            }
        }

        public static async Task GetUnlistedStrings()
        {
            // if no save game has been loaded, return
            // this would be the case when GetTableFromOnline finishes before user loads any save game
            if (UserGenerationBoosts.Length < 1) return;

            // if no online boosts, submit nothing.
            // this would be the case if the online list is no longer available when development stops or user has no internet, or slow internet
            var tick = 0;
            while (!IsOnlineBoostsGenerated)
            {
                await Task.Delay(500);
                tick++;
                // time out at 120 seconds
                if (tick > 240)
                    return;
            }

            // get genBoost
            var genBoost = UserGenerationBoosts.Where(boost => !GenerationBoosts.Contains(boost))
                .Where(boost => !GenerationBoostsAddOnline.Contains(boost)).ToList();
            UnlistedGenerationBoosts = genBoost.ToArray();
        }
    }
}
