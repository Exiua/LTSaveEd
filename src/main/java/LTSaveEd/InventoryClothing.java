package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;

public class InventoryClothing extends AbstractInventoryElement {

    private boolean enchantmentsKnown;
    private boolean isDirty;
    private final Element colorNode;
    private final ArrayList<String> colors;

    public InventoryClothing(Node clothingNode){
        super(clothingNode);
        Element attrs = (Element) clothingNode;
        enchantmentsKnown = Boolean.parseBoolean(attrs.getAttribute("enchantmentsKnown"));
        isDirty = Boolean.parseBoolean(attrs.getAttribute("isDirty"));
        colorNode = (Element) node.getElementsByTagName("colours");
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

    public void setDirty(boolean dirty) {
        isDirty = dirty;
    }

    public boolean isEnchantmentsKnown() {
        return enchantmentsKnown;
    }

    public void setEnchantmentsKnown(boolean enchantmentsKnown) {
        this.enchantmentsKnown = enchantmentsKnown;
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
}
