using System.Xml.Linq;
using LTSaveEd.ExtensionMethods;
using LTSaveEd.Models.ModEditor.Xml;
using LTSaveEd.Models.XmlData;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LTSaveEd.Models.ModEditor;

public class ColorMod : Mod
{
    private static readonly ILogger Logger = Log.ForContext<ColorMod>();
    
    public XmlElement<bool> Metallic { get; }
    public XmlCData<string> Name { get; }
    public XmlElement<string> Colour { get; }
    public XmlElement<string> LightColour { get; }
    public NullableXmlElement<string> CoveringIconColour { get; }
    public List<XmlCData<string>> FormattingNames { get; }
    public ColorTagsElement ColorTags { get; }
    
    private XElement FormattingNamesElement { get; set; }
    
    public ColorMod(XDocument root) : base(root)
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
        Logger.Debug("Metallic: {Metallic}", Metallic.Value);
        Logger.Debug("Name: {Name}", Name.Value);
        Logger.Debug("Colour: {Colour}", Colour.Value);
        Logger.Debug("LightColour: {LightColour}", LightColour.Value);
        Logger.Debug("CoveringIconColour: {CoveringIconColour}", CoveringIconColour.Value);
        Logger.Debug("FormattingNames: {FormattingNames}", FormattingNames.Select(fn => fn.Value).ToFormattedString());
        Logger.Debug("ColorTags: {ColorTags}", ColorTags);
        #endif
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