using System.Xml.Linq;

namespace LTSaveEd.Models;

public class PerkNode(string row, string type, string displayName, XElement parentNode) : NullableXmlAttribute(parentNode)
{
    public string DisplayName { get; } = displayName;
    public string Row { get; } = row;
    public string Type { get; } = type;
    public List<PerkNode> Parents { get; } = new();
    public List<PerkNode> Children { get; } = new();

    private bool CanBeActive => Parents.All(parent => parent.Exists);

    public bool Active
    {
        get => Exists;
        set
        {
            Exists = value;
            if (value)
            {
                Activate();
            }
            else
            {
                Deactivate();
            }
        }
    }

    public PerkNode(PerkNode parent, string row, string type, string displayName, XElement parentNode) : this(row, type, displayName, parentNode)
    {
        Parents.Add(parent);
        parent.Children.Add(this);
    }
    
    public PerkNode(PerkNode parentLeft, PerkNode parentRight, string row, string type, string displayName, XElement parentNode) : this(row, type, displayName, parentNode)
    {
        Parents.Add(parentLeft);
        parentLeft.Children.Add(this);
        Parents.Add(parentRight);
        parentRight.Children.Add(this);
    }

    protected override XElement CreateElement()
    {
        var perkNode = new XElement("perk", new XAttribute("row", Row), new XAttribute("type", Type));
        parentNode.Add(perkNode);
        return perkNode;
    }

    protected override void DeleteElement()
    {
        throw new NotImplementedException();
    }

    private void Activate()
    {
        if(Parents.Count == 0){
            return;
        }

        foreach (var parent in Parents)
        {
            parent.Active = true;
            Console.WriteLine(parent);
        }
    }

    private void Deactivate()
    {
        if(Children.Count == 0){
            return;
        }

        foreach (var child in Children.Where(child => !child.CanBeActive))
        {
            child.Active = true;
        }
    }
    
    public override string ToString(){
        return $"PerkNode{{row={row}, type='{type}'}}";
    }
}