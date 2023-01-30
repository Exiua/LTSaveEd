using System;
using System.Xml.Linq;
using LTSaveEd.Exceptions;

namespace LTSaveEd.Models.CharacterModel.CharacterCoreModel;

public class CharacterName
{
    private string _androgynous;
    private string _feminine;
    private string _masculine;

    public string androgynous
    {
        get => _androgynous;
        set
        {
            _androgynous = value;
            nameElement.SetAttributeValue("nameAndrogynous", value);
        }
    }

    public string feminine
    {
        get => _feminine;
        set
        {
            _feminine = value;
            nameElement.SetAttributeValue("nameFeminine", value);
        }
    }

    public string masculine
    {
        get => _masculine;
        set
        {
            _masculine = value;
            nameElement.SetAttributeValue("nameMasculine", value);
        }
    }

    private XElement nameElement { get; } = null!;

    public CharacterName()
    {
        _androgynous = "";
        _feminine = "";
        _masculine = "";
    }
    
    public CharacterName(XElement nameElement)
    {
        if (nameElement.Name != "name")
        {
            throw new IncorrectElementException(nameElement);
        }

        this.nameElement = nameElement;
        var attributes = nameElement.Attributes();
        foreach (var attribute in attributes)
        {
            var name = attribute.Name.LocalName;
            switch (name)
            {
                case "nameAndrogynous":
                    _androgynous = attribute.Value;
                    break;
                case "nameFeminine":
                    _feminine = attribute.Value;
                    break;
                case "nameMasculine":
                    _masculine = attribute.Value;
                    break;
                default:
                    throw new Exception($"Unknown Attribute Found: {name}");
            }
        }

        if (_androgynous == null || _feminine == null || _masculine == null)
        {
            throw new Exception("Name attributes not initialized");
        }
    }

    public override string ToString()
    {
        return $"{nameof(CharacterName)}{{androgynous: {androgynous}, feminine: {feminine}, masculine: {masculine}}}";
    }
}