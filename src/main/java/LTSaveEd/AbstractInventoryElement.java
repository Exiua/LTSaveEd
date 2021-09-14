package LTSaveEd;

import javafx.scene.layout.HBox;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;

public abstract class AbstractInventoryElement {

    private int count;
    private final String id;
    private final String name;
    private HBox hBox;
    protected static final int MAX_EFFECTS = 100;
    protected final ArrayList<Effect> effects;
    protected final Element node;
    protected Element effectsNode;

    public AbstractInventoryElement(Node elementNode){
        node = (Element) elementNode;
        id = node.getAttribute("id");
        name = node.getAttribute("name");
        count = Integer.parseInt(node.getAttribute("count"));
        effects = new ArrayList<>();
        String effectsNodeName = node.getNodeName().equals("item") ? "itemEffects" : "effects";
        effectsNode = (Element) node.getElementsByTagName(effectsNodeName).item(0);
        initializeEffects();
    }

    private void initializeEffects(){
        if(effectsNode != null) {
            NodeList effectsList = effectsNode.getChildNodes();
            for(int i = 0; i < effectsList.getLength(); i++) {
                Node effect = effectsList.item(i);
                if(effect.getNodeType() == Node.ELEMENT_NODE) {
                    effects.add(new Effect(effect));
                }
            }
        }
    }

    public int getCount() {
        return count;
    }

    public void updateCount(int increment){
        count += increment;
        node.getAttributeNode("count").setValue("" + count);
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public HBox getHBox() {
        return hBox;
    }

    public void setHBox(HBox hBox) {
        this.hBox = hBox;
    }

    public ArrayList<Effect> getEffects() {
        return effects;
    }

    //Used in Inventory editing v2
    @Deprecated
    public void addEffect(Effect effect){
        if(effects.size() >= MAX_EFFECTS){
            throw new IllegalArgumentException("Exceeded max number of effects");
        }
        effects.add(effect);
    }

    //Used in Inventory editing v2
    @Deprecated
    public void removeEffect(Effect effect){
        effects.remove(effect);
    }

    public void removeAllEffects(){
        effects.clear();
        NodeList effectsList = effectsNode.getChildNodes();
        for(int i = 0; i < effectsList.getLength(); i++) {
            removeNode(effectsList.item(i));
        }
    }

    public Node getNode(){
        return node;
    }

    public void removeNode(){
        removeNode(node);
    }

    public void removeNode(Node node){
        node.getParentNode().removeChild(node);
    }

    public abstract boolean isEqual(AbstractInventoryElement element);
    
    protected boolean hasEqualEffects(AbstractInventoryElement element){
        if(effects.size() != element.effects.size()){
            return false;
        }
        for(int i = 0; i < effects.size(); i++) {
            if(!effects.get(i).equals(element.effects.get(i))){
                return false;
            }
        }
        return true;
    }
}
