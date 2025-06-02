namespace LTSaveEd.Models.ModEditor.Enums;

public enum ColorTag
{
    // These tags will add the Colour to relevant covering lists.
    // Some covering lists only have natural colours, while some have both natural and dye colours (such as SLIME and FEATHER).
    Skin,
    SlimeNatural,
    SlimeDye,
    FeatherNatural,
    FeatherDye,
    Fur,
    Scale,
    Horn,
    Antler,
    Hair,
	
    // This tag will add the Colour to the 'all coverings' list:
    GenericCovering,
	
    // Enables the Colour to be used as a makeup colour
    Makeup,

    // Naturally-spawning iris colour, which is available to non-predatory races:
    IrisNatural,
    // Extra iris colour (only obtainable via transformation), which is available to non-predatory races:
    IrisDye,

    // Naturally-spawning iris colour, which is available to predatory races:
    IrisPredatorNatural,
    // Extra iris colour (only obtainable via transformation), which is available to predatory races:
    IrisPredatorDye,

    // Naturally-spawning pupil colour:
    PupilNatural,
    // Extra pupil colour (only obtainable via transformation):
    PupilDye,

    // Naturally-spawning sclera colour:
    ScleraNatural,
    // Extra sclera colour (only obtainable via transformation):
    ScleraDye,
}

public static class ColorTagExtensions
{
	public static string GetValue(this ColorTag tag)
	{
		return tag switch
		{
			ColorTag.Skin => "SKIN",
			ColorTag.SlimeNatural => "SLIME_NATURAL",
			ColorTag.SlimeDye => "SLIME_DYE",
			ColorTag.FeatherNatural => "FEATHER_NATURAL",
			ColorTag.FeatherDye => "FEATHER_DYE",
			ColorTag.Fur => "FUR",
			ColorTag.Scale => "SCALE",
			ColorTag.Horn => "HORN",
			ColorTag.Antler => "ANTLER",
			ColorTag.Hair => "HAIR",
			ColorTag.GenericCovering => "GENERIC_COVERING",
			ColorTag.Makeup => "MAKEUP",
			ColorTag.IrisNatural => "IRIS_NATURAL",
			ColorTag.IrisDye => "IRIS_DYE",
			ColorTag.IrisPredatorNatural => "IRIS_PREDATOR_NATURAL",
			ColorTag.IrisPredatorDye => "IRIS_PREDATOR_DYE",
			ColorTag.PupilNatural => "PUPIL_NATURAL",
			ColorTag.PupilDye => "PUPIL_DYE",
			ColorTag.ScleraNatural => "SCLERA_NATURAL",
			ColorTag.ScleraDye => "SCLERA_DYE",
			_ => throw new ArgumentOutOfRangeException(nameof(tag), tag, null)
		};
	}
}