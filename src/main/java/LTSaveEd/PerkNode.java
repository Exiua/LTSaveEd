package LTSaveEd;

import javafx.collections.ObservableMap;
import javafx.scene.control.CheckBox;
import org.w3c.dom.*;

import java.util.ArrayList;

public class PerkNode {

    private static ObservableMap<String, Object> namespace;
    private static Document saveFile;
    private static Node perksNode;
    private final String row;
    private final String name;
    private final String type;
    private final ArrayList<PerkNode> parent;
    private final ArrayList<PerkNode> children;
    private final String id;
    private boolean active;

    public PerkNode(String perkRow, String perkType, String perkName){
        parent = new ArrayList<>();
        row = perkRow;
        type = perkType;
        name = perkName;
        active = false;
        children = new ArrayList<>();
        id = "perks$" + row + "$" + type;
    }

    public PerkNode(PerkNode perkParent, String perkRow, String perkType, String perkName){
        this(perkRow, perkType, perkName);
        if(perkParent != null) {
            parent.add(perkParent);
            parent.get(0).addChild(this);
        }

    }

    public PerkNode(PerkNode perkParent1, PerkNode perkParent2, String perkRow, String perkType, String perkName){
        this(perkParent1, perkRow, perkType, perkName);
        parent.add(perkParent2);
        parent.get(1).addChild(this);

    }

    public static void setNamespace(ObservableMap<String, Object> namespace){
        PerkNode.namespace = namespace;
    }

    public static void setPerksNode(Node perksNode){
        PerkNode.perksNode = perksNode;
    }

    public static void setSaveFile(Document saveFile){
        PerkNode.saveFile = saveFile;
    }

    private void addChild(PerkNode child){
        children.add(child);
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean value){
        CheckBox cb = (CheckBox) namespace.get(id);
        cb.setSelected(value);
        System.out.println("Setting active: " + value);
        if(!value){
            active = false;
            Node perk = getPerkNode();
            if(perk != null){
                perk.getParentNode().removeChild(perk);
                System.out.println("Removed node: " + this);
            }
            deactivate();
        }
        else{
            active = true;
            Element perk = createPerkNode();
            perksNode.appendChild(perk);
            System.out.println("Created node: " + this);
            activate();
        }
    }

    private Node getPerkNode(){
        NodeList perks = perksNode.getChildNodes();
        for(int i = 0; i < perks.getLength(); i++){
            if(perks.item(i).getNodeType() == Node.ELEMENT_NODE){
                Element perk = (Element) perks.item(i);
                if(perk.getAttribute("row").equals(row) && perk.getAttribute("type").equals(type)){
                    return perks.item(i);
                }
            }
        }
        return null;
    }

    private Element createPerkNode(){
        Element perk = saveFile.createElement("perk");
        perk.setAttribute("row", row);
        perk.setAttribute("type", type);
        return perk;
    }

    private void activate(){
        if(parent.size() == 0){
            return;
        }
        for (PerkNode perkNode : parent) {
            perkNode.setActive(true);
            System.out.println(perkNode);
        }
    }

    private void deactivate(){
        if(children.size() == 0){
            return;
        }
        for (PerkNode perkNode : children) {
            if(!perkNode.canBeActive()){
                perkNode.setActive(false);
            }
        }
    }

    private boolean canBeActive(){
        for(PerkNode perkNode : parent){
            if(perkNode.isActive()){
                return true;
            }
        }
        return false;
    }

    public boolean equals(String perkRow, String perkType){
        return ("" + row).equals(perkRow) && type.equals(perkType);
    }

    @Override
    public String toString(){
        return "PerkNode{" +
                "row=" + row +
                ", type='" + type + '\'' +
                '}';
    }
}
