using System.Xml.Linq;

namespace LTSaveEd.Models.ModEditor;

public abstract class Mod(XDocument root)
{
    public XDocument Root { get; private set; } = root;
}