using System;

namespace LTSaveEd.Exceptions;

public class SaveEditorException : Exception
{
    public SaveEditorException() { }
    public SaveEditorException(string message) : base(message) { }
    public SaveEditorException(string message, Exception inner) : base(message, inner) { }
}