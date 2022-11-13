package LTSaveEd.DataObjects.InventoryElements;

import LTSaveEd.DataObjects.InventoryElements.AbstractInventoryElements.AbstractInventoryElement;
import javafx.scene.control.CheckBox;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;

public class InventoryClothing extends AbstractInventoryElement {

    private boolean enchantmentKnown;
    private boolean isDirty;
    private final Element colorNode;
    private final ArrayList<String> colors;

    public InventoryClothing(Node clothingNode){
        super(clothingNode);
        enchantmentKnown = Boolean.parseBoolean(node.getAttribute("enchantmentKnown"));
        isDirty = Boolean.parseBoolean(node.getAttribute("isDirty"));
        colorNode = (Element) node.getElementsByTagName("colours").item(0);
        colors = new ArrayList<>();
        initializeColors();
    }

    private void initializeColors(){
        NodeList colorList = colorNode.getChildNodes();
        for(int i = 0; i < colorList.getLength(); i++) {
            Node color = colorList.item(i);
            if(color.getNodeType() == Node.ELEMENT_NODE){
                colors.add(color.getTextContent());
            }
        }
    }

    public boolean isDirty() {
        return isDirty;
    }

    public void updateDirty() {
        isDirty = ((CheckBox) hBoxNodes.get(2)).isSelected();
        node.getAttributeNode("isDirty").setValue("" + isDirty);
        System.out.println("Clothing is " + (isDirty ? "dirty" : "clean"));
    }

    public boolean isEnchantmentKnown() {
        return enchantmentKnown;
    }

    public void updateEnchantmentKnown() {
        enchantmentKnown = ((CheckBox) hBoxNodes.get(1)).isSelected();
        node.getAttributeNode("enchantmentKnown").setValue("" + enchantmentKnown);
        System.out.println("Enchantment " + (enchantmentKnown ? "known" : "unknown"));
    }

    @Override
    public boolean isEqual(AbstractInventoryElement element) {
        return (element instanceof InventoryClothing) && this.getId().equals(element.getId()) &&
                hasEqualColors((InventoryClothing) element) && hasEqualEffects(element);
    }

    private boolean hasEqualColors(InventoryClothing element){
        if(colors.size() != element.colors.size()){
            return false;
        }
        for(int i = 0; i < colors.size(); i++) {
            if(!colors.get(i).equals(element.colors.get(i))){
                return false;
            }
        }
        return true;
    }

    @Override
    public String toString() {
        return getId() + "$" + getColorId();
    }

    private String getColorId(){
        StringBuilder idStr = new StringBuilder();
        for(String color : colors) {
            idStr.append(color).append("$");
        }
        return idStr.substring(0, idStr.length());
    }
}
