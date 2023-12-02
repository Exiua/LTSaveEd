using System.Xml.Linq;

namespace LTSaveEd.ExtensionMethods;

public static class XDocumentExtensionMethods
{
    public static XElement FindCharacterById(this XDocument xmlDoc, string characterId)
    {
        var characterNode = xmlDoc.Descendants("character").FirstOrDefault(character => 
            (string)character.Descendants("id").FirstOrDefault()?.Attribute("value")! == characterId) ?? throw new Exception($"Character not found: {characterId}");
        return characterNode;
    }

    /// <summary>
    ///     Get the child element's attribute value. Only use if child and attribute are guaranteed to exist.
    /// </summary>
    /// <param name="element">Element to get child of</param>
    /// <param name="childName">Name of child element to get</param>
    /// <param name="attributeName">Name of attribute of child element to get value of</param>
    /// <returns>Value of specified attribute</returns>
    public static T GetChildsAttribute<T>(this XElement element, string childName, string attributeName = "value")
    {
        var childElement = element.Element(childName) ?? throw new InvalidOperationException($"Child element not found: {childName}");
        var value = childElement.Attribute(attributeName)?.Value ?? throw new InvalidOperationException($"Attribute not found: {attributeName}");

        if (typeof(T) == typeof(string))
        {
            return (T)(object)value; // Cast string to object, then to T
        }
        
        return (T)Convert.ChangeType(value, typeof(T));
    }
    
    public static XAttribute GetChildsAttributeNode(this XElement element, string childName, string attributeName = "value")
    {
        var childElement = element.Element(childName) ?? throw new InvalidOperationException($"Child element not found: {childName}");
        var node = childElement.Attribute(attributeName) ?? throw new InvalidOperationException($"Attribute not found: {attributeName}");

        return node;
    }
}