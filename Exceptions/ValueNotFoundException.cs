using System;

namespace LTSaveEd.Exceptions;

public class ValueNotFoundException : SaveEditorException
{
    public ValueNotFoundException() { }
    public ValueNotFoundException(string tagName) : base($"Attribute value not found for tag: {tagName}") { }
    public ValueNotFoundException(string tagName, Exception inner) : base($"Attribute value not found for tag: {tagName}", inner) { }
}