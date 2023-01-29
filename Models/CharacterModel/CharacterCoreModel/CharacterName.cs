using System;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Models.CharacterModel.CharacterCoreModel;

public class CharacterName
{
    public string androgynous { get; }
    public string feminine { get; }
    public string masculine { get; }

    public CharacterName(XElement nameElement)
    {
        if (nameElement.Name != "name")
        {
            throw new IncorrectElementException(nameElement);
        }
        
        var attributes = nameElement.Attributes();
        foreach (var attribute in attributes)
        {
            var name = attribute.Name.LocalName;
            switch (name)
            {
                case "nameAndrogynous":
                    androgynous = name;
                    break;
                case "nameFeminine":
                    feminine = name;
                    break;
                case "nameMasculine":
                    masculine = name;
                    break;
                default:
                    throw new Exception($"Unknown Attribute Found: {name}");
            }
        }

        if (androgynous == null || feminine == null || masculine == null)
        {
            throw new Exception("Name attributes not initialized");
        }
    }
}