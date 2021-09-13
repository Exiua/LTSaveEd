package LTSaveEd;

import org.w3c.dom.Node;

public class InventoryItem extends InventoryElement{

    private String color;

    public InventoryItem(Node itemNode){
        super(itemNode);
        this.color = itemNode.getAttributes().getNamedItem("colour").getTextContent();
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }
}
