using System.Xml.Linq;

namespace LTSaveEd.Models.ModEditor;

public abstract class Mod
{
    public XDocument Root { get; private set; } = null!;

    // Internal use only, to create a new mod document.
    protected Mod()
    {
        
    }

    protected Mod(XDocument root)
    {
        Root = root;
    }

    protected abstract XDocument CreateNewModDocument();
    
    public static T Load<T>(XDocument root) where T : Mod
    {
        return (T)Activator.CreateInstance(typeof(T), root)!;
    }
    
    public static T New<T>() where T : Mod, new()
    {
        var root = new T().CreateNewModDocument();
        return (T)Activator.CreateInstance(typeof(T), root)!;
    }
}