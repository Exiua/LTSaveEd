package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;

public abstract class InventoryElement {

    private int count;
    private final String id;
    private final String name;

    public InventoryElement(Node elementNode){
        Element attrs = (Element) elementNode;
        this.id = attrs.getAttribute("id");
        this.name = attrs.getAttribute("name");
        this.count = Integer.parseInt(attrs.getAttribute("count"));
    }

    public int getCount() {
        return count;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void updateCount(int increment){
        count += increment;
    }
}
