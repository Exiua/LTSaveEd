using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.ModEditor.Xml;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.ModEditor;

public class ColorMod : Mod
{
    public XmlElement<bool> Metallic { get; }
    public XmlCData<string> Name { get; }
    public XmlElement<string> Colour { get; }
    public XmlElement<string> LightColour { get; }
    public NullableXmlElement<string> CoveringIconColour { get; }
    public List<XmlCData<string>> FormattingNames { get; }
    public ColorTagsElement ColorTags { get; }
    
    private XElement FormattingNamesElement { get; set; }

    // Internal use only, to create a new mod document.
    public ColorMod()
    {
        
    }
    
    private ColorMod(XDocument root) : base(root)
    {
        if (root.Root is null || root.Root.Name.LocalName != "colour")
        {
            throw new InvalidOperationException("Invalid XML structure: Root element must be 'colour'.");
        }
        
        var element = root.Root;
        XElement? metallicNode = null;
        XElement? nameNode = null;
        XElement? colourNode = null;
        XElement? lightColourNode = null;
        XElement? coveringIconColourNode = null;
        XElement? formattingNamesNode = null;
        XElement? colorTags = null;
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
                case "tags":
                    colorTags = child;
                    break;
            }
        }
        
        // Throw exception if any of the required nodes are missing
        if (metallicNode is null || nameNode is null || colourNode is null || lightColourNode is null || formattingNamesNode is null)
        {
            throw new InvalidOperationException("Missing required nodes in the XML element.");
        }
        
        Metallic = new XmlElement<bool>(metallicNode);
        Name = new XmlCData<string>(nameNode.GetCData());
        Colour = new XmlElement<string>(colourNode);
        LightColour = new XmlElement<string>(lightColourNode);
        CoveringIconColour = new NullableXmlElement<string>(element, "coveringIconColour");
        if (coveringIconColourNode is not null)
        {
            CoveringIconColour.Initialize(coveringIconColourNode);
        }
        
        ColorTags = new ColorTagsElement(element);
        if (colorTags is not null)
        {
            ColorTags.Initialize(colorTags);
        }
        
        FormattingNamesElement = formattingNamesNode;
        FormattingNames = formattingNamesNode.Elements("name")
                                             .Select(e => new XmlCData<string>(e.GetCData()))
                                             .ToList();
        
        #if DEBUG
        Console.WriteLine("Metallic: " + Metallic.Value);
        Console.WriteLine("Name: " + Name.Value);
        Console.WriteLine("Colour: " + Colour.Value);
        Console.WriteLine("LightColour: " + LightColour.Value);
        Console.WriteLine("CoveringIconColour: " + CoveringIconColour.Value);
        Console.WriteLine("FormattingNames: " + FormattingNames.Select(fn => fn.Value).ToFormattedString());
        Console.WriteLine("ColorTags: " + ColorTags);
        #endif
    }

    protected override XDocument CreateNewModDocument()
    {
        var root = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("colour",
                new XElement("metallic", "false"),
                new XElement("name", new XCData("white")),
                new XElement("colour", "ffffff"),
                new XElement("lightColour", "ffffff"),
                new XElement("coveringIconColour", "ffffff"),
                new XElement("formattingNames",
                    new XElement("name", new XCData("white"))
                )
            )
        );
        
        return root;
    }

    public void AddNewFormattingName()
    {
        var cdata = new XCData("NewFormattingName");
        var newNameElement = new XElement("name", cdata);
        FormattingNamesElement.Add(newNameElement);
        FormattingNames.Add(new XmlCData<string>(cdata));
    }

    public void PopFormattingName()
    {
        if (FormattingNames.Count > 1)
        {
            FormattingNames.Pop();
        }
    }
}