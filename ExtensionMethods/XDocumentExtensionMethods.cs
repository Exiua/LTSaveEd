using System.Xml.Linq;

namespace LTSaveEd.ExtensionMethods;

/// <summary>
///     Extension methods for Linq to XML's classes.
/// </summary>
public static class XDocumentExtensionMethods
{
    /// <summary>
    ///     Get the child element's attribute value. Only use if child and attribute are guaranteed to exist.
    /// </summary>
    /// <param name="element">Element to get child of</param>
    /// <param name="childName">Name of child element to get</param>
    /// <param name="attributeName">Name of attribute of child element to get value of</param>
    /// <returns>Value of specified attribute</returns>
    public static T GetChildsAttribute<T>(this XContainer element, string childName, string attributeName = "value")
    {
        var childElement = element.Element(childName) ?? throw new InvalidOperationException($"Child element not found: {childName}");
        var value = childElement.Attribute(attributeName)?.Value ?? throw new InvalidOperationException($"Attribute not found: {attributeName}");

        if (typeof(T) == typeof(string))
        {
            return (T)(object)value; // Cast string to object, then to T
        }
        
        return (T)Convert.ChangeType(value, typeof(T));
    }
    
    /// <summary>
    ///    Get the child element's attribute node. Only use if child and attribute are guaranteed to exist.
    /// </summary>
    /// <param name="element">Element to get child of</param>
    /// <param name="childName">Name of child element to get</param>
    /// <param name="attributeName">Name of attribute of child element to get</param>
    /// <returns>XAttribute of the specified attribute</returns>
    /// <exception cref="InvalidOperationException">Thrown when the child element or attribute are not found</exception>
    public static XAttribute GetChildsAttributeNode(this XContainer element, string childName, string attributeName = "value")
    {
        var childElement = element.Element(childName) ?? throw new InvalidOperationException($"Child element not found: {childName}");
        var node = childElement.Attribute(attributeName) ?? throw new InvalidOperationException($"Attribute not found: {attributeName}");

        return node;
    }

    /// <summary>
    ///     Get the element's attribute value.
    /// </summary>
    /// <param name="element">Element to get attribute value of</param>
    /// <param name="attributeName">Name of attribute to get value of</param>
    /// <typeparam name="T">Expected type of value</typeparam>
    /// <returns>Value of attribute converted to the type specified</returns>
    /// <exception cref="InvalidOperationException">Thrown when attribute not found</exception>
    public static T GetAttributeValue<T>(this XElement element, string attributeName = "value")
    {
        var value = element.Attribute(attributeName)?.Value ?? throw new InvalidOperationException($"Attribute not found: {attributeName}");

        if (typeof(T) == typeof(string))
        {
            return (T)(object)value; // Cast string to object, then to T
        }
        
        return (T)Convert.ChangeType(value, typeof(T));
    }

    /// <summary>
    ///     Get an element by a sequence of child element names.
    /// </summary>
    /// <param name="element">Element to start searching from</param>
    /// <param name="childNames">List of child element names to search by</param>
    /// <returns>Descendant element found through sequence of child element names</returns>
    /// <exception cref="Exception">Thrown when a child element could not be found</exception>
    private static XElement GetElementByChildSequence(this XElement element, params string[] childNames)
    {
        return childNames.Aggregate(element, (current, childName) => current.Element(childName) ?? throw new Exception($"Child element not found: {childName}"));
    }

    /// <summary>
    ///     Get an element's attribute by a sequence of child element names plus the attribute name.
    /// </summary>
    /// <param name="element">Element to start searching from</param>
    /// <param name="childNames">List of child element and attribute names to search by</param>
    /// <returns>Attribute found through sequence of child element names</returns>
    /// <exception cref="Exception">Thrown when child element or attribute is not found</exception>
    public static XAttribute GetAttributeByChildSequence(this XElement element, params string[] childNames)
    {
        var current = element.GetElementByChildSequence(childNames[..^1]);
        return current.Attribute(childNames[^1]) ?? throw new Exception($"Attribute not found: {childNames[^1]}");
    }
}