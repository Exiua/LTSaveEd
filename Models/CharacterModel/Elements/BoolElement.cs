using System;
using System.Diagnostics;
using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.Elements;

public class BoolElement : AbstractElement
{
    private bool _value;
    
    public bool Value
    {
        get => _value;
        set
        {
            if (!value)
            {
                if(Nullable)
                {
                    DeleteElement();
                }
                else
                {
                    Debug.Assert(Element != null, nameof(Element) + " != null");
                    Element.Attribute("value")!.Value = "false";
                }
                _value = false;
            }
            else
            {
                if (Element is null)
                {
                    CreateElement();
                }
                _value = value;
                Debug.Assert(Element != null, nameof(Element) + " != null");
                Element.Attribute("value")!.Value = value.ToString();
            }
        }
    }

    public BoolElement(XElement parent, Func<XElement> elementCreator)
    {
        Nullable = true;
        Parent = parent;
        ElementCreator = elementCreator;
    }

    public BoolElement(XElement element, Func<XElement> elementCreator, bool nullable = false)
    {
        Nullable = nullable;
        Parent = element.Parent ?? throw new InvalidOperationException("Parent cannot be null");
        ElementCreator = elementCreator;
        Element = element;
        _value = bool.Parse(Element.GetAttributeValueByName());
    }
}