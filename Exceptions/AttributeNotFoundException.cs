using System;

namespace LTSaveEd.Exceptions;

public class AttributeNotFoundException : SaveEditorException
{
    public AttributeNotFoundException() { }
    public AttributeNotFoundException(string attributeName) : base($"Attribute not found: {attributeName}") { }
    public AttributeNotFoundException(string attributeName, Exception inner) : base($"Attribute not found: {attributeName}", inner) { }
}