using System.Xml.Linq;
using LTSaveEd.Models.XmlData;

namespace LTSaveEd.Models.CharacterData;

public class PerkNode : NullableXmlObject
{
    public static event Action? OnActivenessChanged;

    public string DisplayName { get; }
    public string Row { get; }
    public string Type { get; }
    public List<PerkNode> Parents { get; } = [];
    public List<PerkNode> Children { get; } = [];

    private bool CanBeActive => Parents.All(parent => parent.Exists);

    public bool Active
    {
        get => Exists;
        set
        {
            Exists = value;
            if (value)
            {
                ActivateParents();
            }
            else
            {
                DeactivateChildren();
            }
            OnActivenessChanged?.Invoke();
        }
    }
    
    public PerkNode(string row, string type, string displayName, XElement parentNode) : base(parentNode)
    {
        DisplayName = displayName;
        Row = row;
        Type = type;
    }
    
    public PerkNode(PerkNode parent, string row, string type, string displayName, XElement parentNode) : this(row, type, displayName, parentNode)
    {
        Parents.Add(parent);
        parent.Children.Add(this);
        
        #if DEBUG

        var parentRow = int.Parse(parent.Row);
        var selfRow = int.Parse(row);
        if (parentRow != selfRow && parentRow != selfRow - 1)
        {
            Console.WriteLine($"Incorrect hierarchy detected: {row} {type} {displayName}");
        } 

        #endif
    }
    
    public PerkNode(PerkNode parentLeft, PerkNode parentRight, string row, string type, string displayName, XElement parentNode) : this(row, type, displayName, parentNode)
    {
        Parents.Add(parentLeft);
        parentLeft.Children.Add(this);
        Parents.Add(parentRight);
        parentRight.Children.Add(this);
        
        #if DEBUG
        
        var parentLeftRow = int.Parse(parentLeft.Row);
        var parentRightRow = int.Parse(parentRight.Row);
        var selfRow = int.Parse(row);
        if ((parentLeftRow != selfRow && parentLeftRow != selfRow - 1) || (parentRightRow != selfRow && parentRightRow != selfRow - 1))
        {
            Console.WriteLine($"Incorrect hierarchy detected: {row} {type} {displayName}");
        }
        
        #endif
    }

    protected override XElement CreateNode()
    {
        var perkNode = new XElement("perk", new XAttribute("row", Row), new XAttribute("type", Type));
        Parent.Add(perkNode);
        return perkNode;
    }

    private void ActivateParents()
    {
        if(Parents.Count == 0){
            return;
        }

        foreach (var parent in Parents)
        {
            parent.Active = true;
        }
    }

    private void DeactivateChildren()
    {
        if(Children.Count == 0){
            return;
        }

        foreach (var child in Children.Where(child => !child.CanBeActive))
        {
            child.Active = false;
        }
    }

    public override string ToString(){
        return $"PerkNode{{row={Row}, type='{Type}'}}";
    }
}