using System;

namespace LTSaveEd.Exceptions;

public class TagNotFound : SaveEditorException
{
    public TagNotFound() { }
    public TagNotFound(string tagName) : base($"Tag not found: {tagName}") { }
    public TagNotFound(string tagName, Exception inner) : base($"Tag not found: {tagName}", inner) { }
}