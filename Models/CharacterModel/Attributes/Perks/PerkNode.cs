using System;
using System.Collections.Generic;
using System.Linq;

namespace LTSaveEd.Models.CharacterModel.Attributes.Perks;

public class PerkNode : Attribute
{
    private readonly string row;
    private readonly List<PerkNode> parents;
    private readonly List<PerkNode> children;

    private bool _active;

    public string PerkName
    {
        get => Name;
    }

    public string PerkType
    {
        get => Value;
    }

    public bool Active
    {
        get => _active;
        set
        {
            if (value)
            {
                _active = false;
                DeactivateChildren();
            }
            else
            {
                _active = true;
                ActivateParents();
            }
        }
    }

    public PerkNode(string perkRow, string perkType, string perkName) : base(perkName, perkType)
    {
        row = perkRow;
        parents = new List<PerkNode>();
        children = new List<PerkNode>();
    }
    
    public PerkNode(PerkNode perkParent, string perkRow, string perkType, string perkName) : this(perkRow, perkType, perkName)
    {
        parents.Add(perkParent);
        parents[0].children.Add(this);
    }
    
    public PerkNode(PerkNode perkParent1, PerkNode perkParent2, string perkRow, string perkType, string perkName) : this(perkParent1, perkRow, perkType, perkName)
    {
        parents.Add(perkParent2);
        parents[1].children.Add(this);
    }

    private void DeactivateChildren()
    {
        foreach (var child in children)
        {
            if (!child.CanBeActive())
            {
                child.Active = false;
            }
        }
    }

    private bool CanBeActive()
    {
        return parents.Any(parent => parent.Active);
    }
    
    private void ActivateParents()
    {
        foreach (var parent in parents)
        {
            parent.Active = true;
        }
    }

    public override string ToString()
    {
        return $"{nameof(PerkNode)}{{row={row}, type={Value}}}";
    }

    public bool Equals(string perkRow, string perkType)
    {
        return row == perkRow && Value == perkType;
    }
}