using System.Xml.Linq;
using LTSaveEd.Models.Enums.Game;
using LTSaveEd.Models.ModEditor.Xml.EnumXml;

namespace LTSaveEd.Models.ModEditor.Xml;

public class EquipSlotElements
{
    private readonly XElement _parent;
    
    public List<InventorySlotElement> Slots { get; private set; } = [];
    
    public EquipSlotElements(XElement parent)
    {
        _parent = parent;
        var slots = parent.Elements("Slot")
                          .Select(slot => new InventorySlotElement(slot));
        Slots.AddRange(slots);
    }
    
    private static XElement CreateSlotNode(InventorySlot slot)
    {
        var node = new XElement("slot", slot.GetValue());
        return node;
    }
    
    private XElement? GetSlotNode(InventorySlot slot)
    {
        return _parent.Elements("slot").FirstOrDefault(s => s.Value == slot.GetValue());
    }

    private void AddSlot(InventorySlot slot)
    {
        var slotNode = CreateSlotNode(slot);
        if (GetSlotNode(slot) is not null)
        {
            return; // Slot already exists, no need to add it again
        }
        
        _parent.Add(slotNode);
        Slots.Add(new InventorySlotElement(slotNode));
    }
    
    private void RemoveSlot(InventorySlot slot)
    {
        var slotNode = GetSlotNode(slot);
        var slotElement = Slots.FirstOrDefault(s => s.Value == slot);
        // Has a possibility to desync with the XML if the slot was not found in Slots
        slotNode?.Remove();
        if (slotElement is not null)
        {
            Slots.Remove(slotElement);
        }
    }

    public bool HasSlot(InventorySlot slot)
    {
        return GetSlotNode(slot) is not null;
    }

    public override string ToString()
    {
        return "[" + string.Join(", ", _parent.Elements("slot").Select(s => s.Value)) + "]";
    }
}