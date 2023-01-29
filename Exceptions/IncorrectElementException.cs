using System;
using System.Xml.Linq;

namespace LTSaveEd.Exceptions;

public class IncorrectElementException : SaveEditorException
{
    public IncorrectElementException() { }
    public IncorrectElementException(XElement element) : base($"Incorrect Element Supplied: {element}") { }
    public IncorrectElementException(XElement element, Exception inner) : base($"Incorrect Element Supplied: {element}", inner) { }
}