using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.ModEditor;

public abstract class Mod
{
    private static Dictionary<Type, XDocument> ModTemplates { get; } = new()
    {
        {typeof(ColorMod), EmbeddedXmlLoader.LoadXmlFromResource("LTSaveEd.Resources.white.xml")},
        {typeof(ClothingMod), EmbeddedXmlLoader.LoadXmlFromResource("LTSaveEd.Resources.tshirt.xml")},
    };
    
    public XDocument Root { get; private set; }

    protected Mod(XDocument root)
    {
        Root = root;
    }
    
    public static T Load<T>(XDocument root) where T : Mod
    {
        return (T)Activator.CreateInstance(typeof(T), root)!;
    }
    
    public static T New<T>() where T : Mod
    {
        if (!ModTemplates.TryGetValue(typeof(T), out var template))
        {
            throw new InvalidOperationException($"No template found for mod type {typeof(T).Name}.");
        }
        
        return (T)Activator.CreateInstance(typeof(T), template)!;
    }
}