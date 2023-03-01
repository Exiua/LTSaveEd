using System;
using System.Xml.Linq;

namespace LTSaveEd.Exceptions;

public class ElementExistsException : SaveEditorException
{
    public ElementExistsException() { }
    public ElementExistsException(XElement element) : base($"Element Already Exists: {element}") { }
    public ElementExistsException(XElement element, Exception inner) : base($"Element Already Exists: {element}", inner) { }
}