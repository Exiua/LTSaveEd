package LTSaveEd.Objects.InventoryElements.AbstractInventoryElements;

import LTSaveEd.Objects.InventoryElements.Effect;
import javafx.scene.layout.HBox;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;
import java.util.Collections;

public abstract class AbstractInventoryElement {

    private String count;
    private final String id;
    private final String name;
    private HBox hBox;
    protected static final int MAX_EFFECTS = 100;
    protected final ArrayList<javafx.scene.Node> hBoxNodes;
    protected final ArrayList<Effect> effects;
    protected final Element node;
    protected Element effectsNode;

    public AbstractInventoryElement(Node elementNode){
        node = (Element) elementNode;
        id = node.getAttribute("id");
        name = node.getAttribute("name");
        count = node.getAttribute("count");
        effects = new ArrayList<>();
        String effectsNodeName = node.getNodeName().equals("item") ? "itemEffects" : "effects";
        effectsNode = (Element) node.getElementsByTagName(effectsNodeName).item(0);
        hBoxNodes = new ArrayList<>();
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

    public String getCount() {
        return count;
    }

    public void setCount(String value){
        count = value;
        node.getAttributeNode("count").setValue(value);
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

    public ArrayList<javafx.scene.Node> getHBoxNodes() {
        return hBoxNodes;
    }

    public void addHBoxNodes(javafx.scene.Node... nodes){
        Collections.addAll(hBoxNodes, nodes);
    }

    public javafx.scene.Node getNodeByIdPart(String id){
        for(javafx.scene.Node hBoxNode : hBoxNodes) {
            if(hBoxNode.getId().contains(id)) {
                return hBoxNode;
            }
        }
        return null;
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

    public Element getNode(){
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
