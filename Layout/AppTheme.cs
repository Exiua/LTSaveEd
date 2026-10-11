using MudBlazor;

namespace LTSaveEd.Layout;

/// <summary>
///     Central MudBlazor theme for LTSaveEd. Semantic usage in the existing pages:
///     Primary = navigation / focus / links, Secondary = Load, Save and Delete, Tertiary = Add.
/// </summary>
public static class AppTheme
{
    private static readonly string[] FontStack =
        ["Inter", "Roboto", "Helvetica Neue", "Helvetica", "Arial", "sans-serif"];

    public static readonly MudTheme Theme = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#5B4BDB",
            PrimaryContrastText = "#FFFFFF",
            Secondary = "#D6336C",
            SecondaryContrastText = "#FFFFFF",
            Tertiary = "#0D9488",
            TertiaryContrastText = "#FFFFFF",

            Background = "#F6F7FB",
            Surface = "#FFFFFF",
            AppbarBackground = "#FFFFFF",
            AppbarText = "#1E2235",
            DrawerBackground = "#FFFFFF",
            DrawerText = "#3A3F57",
            DrawerIcon = "#6B7190",

            TextPrimary = "#1E2235",
            TextSecondary = "#5B6178",
            ActionDefault = "#5B6178",

            LinesDefault = "#E3E6F0",
            LinesInputs = "#C4C9DA",
            TableLines = "#E3E6F0",
            Divider = "#E3E6F0",
            DividerLight = "#EEF0F7",

            Info = "#2F7DE1",
            Success = "#1F9D63",
            Warning = "#E8A317",
            Error = "#D63B3B"
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#9B8CFF",
            PrimaryContrastText = "#14132B",
            Secondary = "#F06595",
            SecondaryContrastText = "#2A0A18",
            Tertiary = "#2DD4BF",
            TertiaryContrastText = "#042F2B",

            Background = "#0F1220",
            Surface = "#171B2E",
            AppbarBackground = "#131728",
            AppbarText = "#E7E9F5",
            DrawerBackground = "#131728",
            DrawerText = "#C9CDE3",
            DrawerIcon = "#A0A6C0",

            TextPrimary = "#E7E9F5",
            TextSecondary = "#A0A6C0",
            ActionDefault = "#A0A6C0",

            LinesDefault = "#262B45",
            LinesInputs = "#3A4066",
            TableLines = "#262B45",
            Divider = "#262B45",
            DividerLight = "#1E2238",

            Info = "#5BA3FF",
            Success = "#3DD598",
            Warning = "#F5B83D",
            Error = "#FF6B6B"
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "10px",
            DrawerWidthLeft = "264px",
            AppbarHeight = "64px"
        },
        Typography = new Typography
        {
            Default = new DefaultTypography { FontFamily = FontStack },
            H4 = new H4Typography { FontFamily = FontStack, FontWeight = "700", LetterSpacing = "-0.01em" },
            H5 = new H5Typography { FontFamily = FontStack, FontWeight = "700", LetterSpacing = "-0.01em" },
            H6 = new H6Typography { FontFamily = FontStack, FontWeight = "600", LetterSpacing = "-0.005em" },
            Button = new ButtonTypography
            {
                FontFamily = FontStack,
                FontWeight = "600",
                TextTransform = "none",
                LetterSpacing = "0.01em"
            }
        }
    };
}
