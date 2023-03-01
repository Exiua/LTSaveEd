using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using LTSaveEd.Utility;

namespace LTSaveEd.Models.CharacterModel.Elements;

public class FloatElement : AbstractElement
{
    private float _value;
    
    public float Value
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
                    Element.Attribute("value")!.Value = "0.0";
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
                Element.Attribute("value")!.Value = value.ToString(CultureInfo.InvariantCulture);
            }
        }
    }

    public FloatElement(XElement parent, Func<XElement> elementCreator)
    {
        Nullable = true;
        Parent = parent;
        ElementCreator = elementCreator;
    }

    public FloatElement(XElement element, Func<XElement> elementCreator, bool nullable = false)
    {
        Nullable = nullable;
        Parent = element.Parent ?? throw new InvalidOperationException("Parent cannot be null");
        ElementCreator = elementCreator;
        Element = element;
        _value = float.Parse(Element.GetAttributeValueByName());
    }
}