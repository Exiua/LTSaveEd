using System.Reflection;
using System.Xml.Linq;

namespace LTSaveEd.Utility;

public static class EmbeddedXmlLoader
{
    public static XDocument LoadXmlFromResource(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream is null)
        {
            throw new ArgumentException($"Resource '{resourceName}' not found in assembly '{assembly.FullName}'.");
        }
        
        return XDocument.Load(stream);
    }
}