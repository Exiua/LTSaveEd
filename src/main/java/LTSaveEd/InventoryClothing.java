package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;

public class InventoryClothing extends InventoryElement{

    private boolean enchantmentsKnown;
    private boolean isDirty;

    public InventoryClothing(Node clothingNode){
        super(clothingNode);
        Element attrs = (Element) clothingNode;
        enchantmentsKnown = Boolean.parseBoolean(attrs.getAttribute("enchantmentsKnown"));
        isDirty = Boolean.parseBoolean(attrs.getAttribute("isDirty"));
    }

    public boolean isDirty() {
        return isDirty;
    }

    public void setDirty(boolean dirty) {
        isDirty = dirty;
    }

    public boolean isEnchantmentsKnown() {
        return enchantmentsKnown;
    }

    public void setEnchantmentsKnown(boolean enchantmentsKnown) {
        this.enchantmentsKnown = enchantmentsKnown;
    }
}
