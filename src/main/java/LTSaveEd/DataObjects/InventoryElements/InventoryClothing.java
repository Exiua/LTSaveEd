package LTSaveEd.DataObjects.InventoryElements;

import LTSaveEd.DataObjects.InventoryElements.AbstractInventoryElements.InventoryElement;
import javafx.scene.control.CheckBox;
import org.w3c.dom.Element;
import org.w3c.dom.Node;

public class InventoryClothing extends InventoryElement {
    private boolean enchantmentKnown;
    private boolean isDirty;
    private final MultiColor colors;

    public InventoryClothing(Node clothingNode){
        super(clothingNode);
        enchantmentKnown = Boolean.parseBoolean(node.getAttribute("enchantmentKnown"));
        isDirty = Boolean.parseBoolean(node.getAttribute("isDirty"));
        Element colorNode = (Element) node.getElementsByTagName("colours").item(0);
        colors = new MultiColor(colorNode);
    }

    @Override
    public boolean isEqual(InventoryElement element) {
        return false;
    }

    public boolean isDirty() {
        return isDirty;
    }

    public void updateDirty() {
        isDirty = ((CheckBox) hBoxNodes.get(2)).isSelected();
        node.getAttributeNode("isDirty").setValue(String.valueOf(isDirty));
        System.out.println("Clothing is " + (isDirty ? "dirty" : "clean"));
    }

    public boolean isEnchantmentKnown() {
        return enchantmentKnown;
    }

    public void updateEnchantmentKnown() {
        enchantmentKnown = ((CheckBox) hBoxNodes.get(1)).isSelected();
        node.getAttributeNode("enchantmentKnown").setValue(String.valueOf(enchantmentKnown));
        System.out.println("Enchantment " + (enchantmentKnown ? "known" : "unknown"));
    }

    public MultiColor getColors() {
        return colors;
    }
}
