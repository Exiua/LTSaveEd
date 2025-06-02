using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor;

public class ColorMod
{
    public XmlElement<bool> Metallic { get; }
    public XmlElement<string> Name { get; }
    public XmlElement<string> Colour { get; }
    public XmlElement<string> LightColour { get; }
    public NullableXmlElement<string> CoveringIconColour { get; }
    public List<XmlElement<string>> FormattingNames { get; }
    
    private XElement ColorElement { get; set; }

    private ColorMod(XElement element)
    {
        ColorElement = element;
        // TODO: Finish the rest of the properties
        XElement? metallicNode = null;
        XElement? nameNode = null;
        XElement? colourNode = null;
        XElement? lightColourNode = null;
        XElement? coveringIconColourNode = null;
        XElement? formattingNamesNode = null;
        var children = element.Elements();
        foreach (var child in children)
        {
            switch (child.Name.LocalName)
            {
                case "metallic":
                    metallicNode = child;
                    break;
                case "name":
                    nameNode = child;
                    break;
                case "colour":
                    colourNode = child;
                    break;
                case "lightColour":
                    lightColourNode = child;
                    break;
                case "coveringIconColour":
                    coveringIconColourNode = child;
                    break;
                case "formattingNames":
                    formattingNamesNode = child;
                    break;
            }
        }
        
        // Throw exception if any of the required nodes are missing
        if (metallicNode is null || nameNode is null || colourNode is null || lightColourNode is null)
        {
            throw new InvalidOperationException("Missing required nodes in the XML element.");
        }
        
        Metallic = new XmlElement<bool>(metallicNode);
        Name = new XmlElement<string>(nameNode);
        Colour = new XmlElement<string>(colourNode);
        LightColour = new XmlElement<string>(lightColourNode);
        CoveringIconColour = new NullableXmlElement<string>(element, "coveringIconColour");
        if (coveringIconColourNode is not null)
        {
            CoveringIconColour.Initialize(coveringIconColourNode);
        }
        
        FormattingNames = formattingNamesNode?.Elements("name")
            .Select(e => new XmlElement<string>(e))
            .ToList() ?? [];
    }
    
    public static ColorMod New()
    {
        var root = new XElement("colour",
            new XDeclaration("1.0", "UTF-8", "no"),
            new XElement("metallic", "false"),
            new XElement("name", new XCData("white")),
            new XElement("colour", "ffffff"),
            new XElement("lightColour", "ffffff"),
            new XElement("coveringIconColour", "ffffff"),
            new XElement("formattingNames", 
                new XElement("name", new XCData("white"))
            )
        );
        
        return new ColorMod(root);
    }
    
    public static ColorMod Load(XElement element)
    {
        return new ColorMod(element);
    }
}