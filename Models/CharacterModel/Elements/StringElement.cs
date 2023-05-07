using System;
using System.Diagnostics;
using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.Elements;

public class StringElement : AbstractElement
{
    private string _value;
    
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            Debug.Assert(Element != null, nameof(Element) + " != null");
            Element.Attribute("value")!.Value = value;
        }
    }

    public StringElement(XElement element, Func<XElement> elementCreator)
    {
        Nullable = false;
        Parent = element.Parent ?? throw new InvalidOperationException("Parent cannot be null");
        ElementCreator = elementCreator;
        Element = element;
        _value = Element.GetAttributeValueByName();
    }
}