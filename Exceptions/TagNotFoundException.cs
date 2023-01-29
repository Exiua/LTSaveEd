using System;

namespace LTSaveEd.Exceptions;

public class TagNotFoundException : SaveEditorException
{
    public TagNotFoundException() { }
    public TagNotFoundException(string tagName) : base($"Tag not found: {tagName}") { }
    public TagNotFoundException(string tagName, Exception inner) : base($"Tag not found: {tagName}", inner) { }
}