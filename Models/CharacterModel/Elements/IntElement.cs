using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.Elements;

public class IntElement : AbstractElement
{
    private int _value;
    
    public int Value
    {
        get => _value;
        set
        {
            if (value == 0)
            {
                if(Nullable)
                {
                    DeleteElement();
                }
                else
                {
                    Debug.Assert(Element != null, nameof(Element) + " != null");
                    Element.Attribute("value")!.Value = "0";
                }
                _value = 0;
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

    public IntElement(XElement parent, Func<XElement> elementCreator)
    {
        Nullable = true;
        Parent = parent;
        ElementCreator = elementCreator;
    }

    public IntElement(XElement element, Func<XElement> elementCreator, bool nullable = false)
    {
        Nullable = nullable;
        Parent = element.Parent ?? throw new InvalidOperationException("Parent cannot be null");
        ElementCreator = elementCreator;
        Element = element;
        _value = int.Parse(Element.GetAttributeValueByName());
    }
}