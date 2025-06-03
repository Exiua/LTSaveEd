namespace LTSaveEd.Models.Enums.Game;

public enum InventorySlot
{
    // HEAD:
	
	/** Clothing slot "head". Used for headgear.<br/>
	 *  Tattoo slot "head".*/
	Head,

	/** Clothing slot "eyes". Used for glasses.<br/>
	 *  Tattoo slot "upper face".*/
	Eyes,

	/** Clothing slot "hair". Used for ribbons and hairbands.<br/>
	 *  Tattoo slot "ears".*/
	Hair,

	/** Clothing slot "mouth". Used for ballgags.<br/>
	 *  Tattoo slot "lower face".*/
	Mouth,

	/** Clothing slot "neck". Used for necklaces and scarfs.<br/>
	 *  Tattoo slot "neck".*/
	Neck,
	
	
	// TORSO:

	/** Clothing slot "over-torso". Used for coats.<br/>
	 *  Tattoo slot "upper back".*/
	TorsoOver,

	/** Clothing slot "torso". Used for shirts.<br/>
	 *  Tattoo slot "lower back".*/
	TorsoUnder,

	/** Clothing slot "chest". Used for bras.<br/>
	 *  Tattoo slot "chest".*/
	Chest,

	/** Clothing slot "nipples". Used for nipple shields, plugs.<br/>
	 *  Tattoo slot "nipples".*/
	Nipple,

	/** Clothing slot "stomach". Used for corsets.<br/>
	 *  Tattoo slot "stomach".*/
	Stomach,

	
	// HAND:

	/** Clothing slot "hands". Used for gloves.<br/>
	 *  Tattoo slot "forearms".*/
	Hand,

	/** Clothing slot "wrists". Used for bracelets.<br/>
	 *  Tattoo slot "upper arms".*/
	Wrist,

	/** Clothing slot "fingers". Used for rings.<br/>
	 *  Tattoo slot "hands".*/
	Finger,

	/** Clothing slot "hips". Used for belts.<br/>
	 *  Tattoo slot "hips".*/
	Hips,

//	/** Clothing slot "hips-under". Used for suspender belts.<br/>
//	 *  Tattoo slot "".*/
//	HIPS_UNDER,

	
	// LEG & FOOT:

	/** Clothing slot "legs". Used for trousers.<br/>
	 *  Tattoo slot "upper leg".*/
	Leg,

	/** Clothing slot "groin". Used for underwear.<br/>
	 *  Tattoo slot "lower abdomen".*/
	Groin,

	/** Clothing slot "feet". Used for shoes.<br/>
	 *  Tattoo slot "feet".*/
	Foot,

	/** Clothing slot "calves". Used for socks.<br/>
	 *  Tattoo slot "lower leg".*/
	Sock,

	/** Clothing slot "ankles". Used for bracelets.<br/>
	 *  Tattoo slot "ankles".*/
	Ankle,
	
	
	// OPTIONAL EXTRAS:

	/** Clothing slot "horns". Used for horn decorations.<br/>
	 *  Tattoo slot "horns".*/
	Horns,

	/** Clothing slot "wings". Used for wing decorations.<br/>
	 *  Tattoo slot "wings".*/
	Wings,

	/** Clothing slot "tail". Used for tail decorations.<br/>
	 *  Tattoo slot "tail".*/
	Tail,

	/** Clothing slot "penis". Used for cock socks, cages, and plugs.<br/>
	 *  Tattoo slot "penis".*/
	Penis,

	/** Clothing slot "vagina". Used for plugs.<br/>
	 *  Tattoo slot "vagina".*/
	Vagina,

	// PIERCING:
	PiercingEar,
	PiercingNose,
	PiercingTongue,
	PiercingLip,
	PiercingStomach,
	PiercingNipple,
	PiercingVagina,
	PiercingPenis,

	// EQUIPPABLE:
	WeaponMain1,
	WeaponMain2,
	WeaponMain3,
	
	WeaponOffhand1,
	WeaponOffhand2,
	WeaponOffhand3,
}

public static class InventorySlotExtensions
{
	public static string GetValue(this InventorySlot slot)
	{
		return slot switch {
			InventorySlot.Head => "HEAD",
			InventorySlot.Eyes => "EYES",
			InventorySlot.Hair => "HAIR",
			InventorySlot.Mouth => "MOUTH",
			InventorySlot.Neck => "NECK",
			InventorySlot.TorsoOver => "TORSO_OVER",
			InventorySlot.TorsoUnder => "TORSO_UNDER",
			InventorySlot.Chest => "CHEST",
			InventorySlot.Nipple => "NIPPLE",
			InventorySlot.Stomach => "STOMACH",
			InventorySlot.Hand => "HAND",
			InventorySlot.Wrist => "WRIST",
			InventorySlot.Finger => "FINGER",
			InventorySlot.Hips => "HIPS",
			InventorySlot.Leg => "LEG",
			InventorySlot.Groin => "GROIN",
			InventorySlot.Foot => "FOOT",
			InventorySlot.Sock => "SOCK",
			InventorySlot.Ankle => "ANKLE",
			InventorySlot.Horns => "HORNS",
			InventorySlot.Wings => "WINGS",
			InventorySlot.Tail => "TAIL",
			InventorySlot.Penis => "PENIS",
			InventorySlot.Vagina => "VAGINA",
			InventorySlot.PiercingEar => "PIERCING_EAR",
			InventorySlot.PiercingNose => "PIERCING_NOSE",
			InventorySlot.PiercingTongue => "PIERCING_TONGUE",
			InventorySlot.PiercingLip => "PIERCING_LIP",
			InventorySlot.PiercingStomach => "PIERCING_STOMACH",
			InventorySlot.PiercingNipple => "PIERCING_NIPPLE",
			InventorySlot.PiercingVagina => "PIERCING_VAGINA",
			InventorySlot.PiercingPenis => "PIERCING_PENIS",
			InventorySlot.WeaponMain1 => "WEAPON_MAIN_1",
			InventorySlot.WeaponMain2 => "WEAPON_MAIN_2",
			InventorySlot.WeaponMain3 => "WEAPON_MAIN_3",
			InventorySlot.WeaponOffhand1 => "WEAPON_OFFHAND_1",
			InventorySlot.WeaponOffhand2 => "WEAPON_OFFHAND_2",
			InventorySlot.WeaponOffhand3 => "WEAPON_OFFHAND_3",
			_ => throw new ArgumentOutOfRangeException(nameof(slot), slot, null)
		};
	}

	public static InventorySlot FromValue(string value)
	{
		return value switch {
			"HEAD" => InventorySlot.Head,
			"EYES" => InventorySlot.Eyes,
			"HAIR" => InventorySlot.Hair,
			"MOUTH" => InventorySlot.Mouth,
			"NECK" => InventorySlot.Neck,
			"TORSO_OVER" => InventorySlot.TorsoOver,
			"TORSO_UNDER" => InventorySlot.TorsoUnder,
			"CHEST" => InventorySlot.Chest,
			"NIPPLE" => InventorySlot.Nipple,
			"STOMACH" => InventorySlot.Stomach,
			"HAND" => InventorySlot.Hand,
			"WRIST" => InventorySlot.Wrist,
			"FINGER" => InventorySlot.Finger,
			"HIPS" => InventorySlot.Hips,
			"LEG" => InventorySlot.Leg,
			"GROIN" => InventorySlot.Groin,
			"FOOT" => InventorySlot.Foot,
			"SOCK" => InventorySlot.Sock,
			"ANKLE" => InventorySlot.Ankle,
			"HORNS" => InventorySlot.Horns,
			"WINGS" => InventorySlot.Wings,
			"TAIL" => InventorySlot.Tail,
			"PENIS" => InventorySlot.Penis,
			"VAGINA" => InventorySlot.Vagina,
			"PIERCING_EAR" => InventorySlot.PiercingEar,
			"PIERCING_NOSE" => InventorySlot.PiercingNose,
			"PIERCING_TONGUE" => InventorySlot.PiercingTongue,
			"PIERCING_LIP" => InventorySlot.PiercingLip,
			"PIERCING_STOMACH" => InventorySlot.PiercingStomach,
			"PIERCING_NIPPLE" => InventorySlot.PiercingNipple,
			"PIERCING_VAGINA" => InventorySlot.PiercingVagina,
			"PIERCING_PENIS" => InventorySlot.PiercingPenis,
			"WEAPON_MAIN_1" => InventorySlot.WeaponMain1,
			"WEAPON_MAIN_2" => InventorySlot.WeaponMain2,
			"WEAPON_MAIN_3" => InventorySlot.WeaponMain3,
			"WEAPON_OFFHAND_1" => InventorySlot.WeaponOffhand1,
			"WEAPON_OFFHAND_2" => InventorySlot.WeaponOffhand2,
			"WEAPON_OFFHAND_3" => InventorySlot.WeaponOffhand3,
			_ => InventorySlot.Head // Default value if string value is unknown
		};
	}
}