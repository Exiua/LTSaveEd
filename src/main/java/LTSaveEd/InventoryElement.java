package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;

import java.util.ArrayList;

public abstract class InventoryElement {

    private int count;
    private final String id;
    private final String name;
    protected static final int MAX_EFFECTS = 100;
    private ArrayList<Effect> effects;

    public InventoryElement(Node elementNode){
        Element attrs = (Element) elementNode;
        this.id = attrs.getAttribute("id");
        this.name = attrs.getAttribute("name");
        this.count = Integer.parseInt(attrs.getAttribute("count"));
        effects = new ArrayList<>();
    }

    public int getCount() {
        return count;
    }

    public void updateCount(int increment){
        count += increment;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public ArrayList<Effect> getEffects() {
        return effects;
    }

    //Used in Inventory editing v2
    public void addEffect(Effect effect){
        if(effects.size() >= MAX_EFFECTS){
            throw new IllegalArgumentException("Exceeded max number of effects");
        }
        effects.add(effect);
    }

    //Used in Inventory editing v2
    public void removeEffect(Effect effect){
        effects.remove(effect);
    }

    public void removeAllEffects(){
        effects.clear();
    }

    public abstract boolean isEqual(InventoryElement element);
}
