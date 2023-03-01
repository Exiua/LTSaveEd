using System;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Models.CharacterModel.Elements;

public abstract class AbstractElement
{

    private XElement? _element;

    public XElement? Element
    {
        get => _element;
        init => _element = value;
    }

    protected bool Nullable { get; init; }
    
    protected Func<XElement> ElementCreator { get; init; }
    protected XElement Parent { get; init; }

    protected void DeleteElement()
    {
        if (_element is null)
        {
            return;
        }
        if (!Nullable)
        {
            throw new InvalidOperationException("Cannot Nullify Non-Nullable Element");
        }
        _element.Remove();
        _element = null;
    }

    protected void CreateElement()
    {
        if (_element is not null)
        {
            throw new ElementExistsException(_element);
        }
        _element = ElementCreator.Invoke();
        Parent.Add(_element);
    }
}