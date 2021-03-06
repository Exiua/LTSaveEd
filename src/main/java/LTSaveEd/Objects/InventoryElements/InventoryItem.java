package LTSaveEd.Objects.InventoryElements;

import LTSaveEd.Objects.InventoryElements.AbstractInventoryElements.AbstractInventoryElement;
import org.w3c.dom.Node;

public class InventoryItem extends AbstractInventoryElement {

    private String color;

    public InventoryItem(Node itemNode){
        super(itemNode);
        color = itemNode.getAttributes().getNamedItem("colour").getTextContent();
    }

    public String getColor() {
        return color;
    }

    //Used in Inventory editing v2
    @Deprecated
    public void setColor(String color) {
        this.color = color;
        node.getAttributeNode("colour").setValue(color);
    }

    @Override
    public boolean isEqual(AbstractInventoryElement element) {
        return (element instanceof InventoryItem) && this.getId().equals(element.getId()) &&
                this.color.equals(((InventoryItem) element).getColor()) && hasEqualEffects(element);
    }

    @Override
    public String toString(){
        return getId() + "$" + color;
    }
}
