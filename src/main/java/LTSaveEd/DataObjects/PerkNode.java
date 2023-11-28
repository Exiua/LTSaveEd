package LTSaveEd.DataObjects;

import LTSaveEd.DataObjects.InventoryElements.InventoryClothing;
import javafx.collections.ObservableMap;
import javafx.scene.control.CheckBox;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.w3c.dom.*;

import java.util.ArrayList;

/**
 * Class that stores perk attributes and the parents and children of this perk
 * @author Exiua
 */
public class PerkNode {
    static Logger log = LogManager.getLogger(InventoryClothing.class);

    /**
     * Namespace of the fxml file
     */
    private static ObservableMap<String, Object> namespace;

    /**
     * The parsed xml save file
     */
    private static Document saveFile;

    /**
     * The perks Node where all the perks are stored in the save file
     */
    private static Node perksNode;

    /**
     * Row value of this perk
     */
    private final String row;

    /**
     * Display value of this perk
     */
    private final String name;

    /**
     * Actual value of this perk
     */
    private final String type;

    /**
     * ArrayList of perks that are parents to this perk
     */
    private final ArrayList<PerkNode> parent;

    /**
     * ArrayList of perks that are children to this perk
     */
    private final ArrayList<PerkNode> children;

    /**
     * Id of the CheckBox associated with this perk
     */
    private final String id;

    /**
     * Whether this perk is active or not
     */
    private boolean active;

    /**
     * Base constructor
     * @param perkRow
     *   Row value of this perk
     * @param perkType
     *   Type value of this perk
     * @param perkName
     *   Display name of this perk
     */
    public PerkNode(String perkRow, String perkType, String perkName){
        parent = new ArrayList<>();
        row = perkRow;
        type = perkType;
        name = perkName;
        active = false;
        children = new ArrayList<>();
        id = "perks$" + row + "$" + type;
    }

    /**
     * Perk constructor with one parent parameter
     * @param perkParent
     *   Parent perk to this perk
     * @param perkRow
     *   Row value of this perk
     * @param perkType
     *   Type value of this perk
     * @param perkName
     *   Display name of this perk
     */
    public PerkNode(PerkNode perkParent, String perkRow, String perkType, String perkName){
        this(perkRow, perkType, perkName);
        if(perkParent != null) {
            parent.add(perkParent);
            parent.get(0).addChild(this);
        }

    }

    /**
     * Perk constructor with two parent parameters
     * @param perkParent1
     *   Parent perk to this perk
     * @param perkParent2
     *   Parent perk to this perk
     * @param perkRow
     *   Row value of this perk
     * @param perkType
     *   Type value of this perk
     * @param perkName
     *   Display name of this perk
     */
    public PerkNode(PerkNode perkParent1, PerkNode perkParent2, String perkRow, String perkType, String perkName){
        this(perkParent1, perkRow, perkType, perkName);
        parent.add(perkParent2);
        parent.get(1).addChild(this);

    }

    /**
     * Sets the namespace that is shared across all PerkNode objects
     * @param namespace
     *   Namespace of the fxml file
     */
    public static void setNamespace(ObservableMap<String, Object> namespace){
        PerkNode.namespace = namespace;
    }

    /**
     * Sets the Node that stores all perks that is shared across all PerkNode objects
     * @param perksNode
     *   Node that stores all perks
     */
    public static void setPerksNode(Node perksNode){
        PerkNode.perksNode = perksNode;
    }

    /**
     * Sets the parsed xml save file that is shared across all PerkNode objects
     * @param saveFile
     *   Parsed xml save file
     */
    public static void setSaveFile(Document saveFile){
        PerkNode.saveFile = saveFile;
    }

    /**
     * Adds a child to the children ArrayList
     * @param child
     *   Child to be added
     */
    private void addChild(PerkNode child){
        children.add(child);
    }

    /**
     * Checks if this perk is active
     * @return
     *   Boolean based on if this perk is active
     */
    public boolean isActive() {
        return active;
    }

    /**
     * Sets the active value of this perk to the given boolean
     * @param value
     *   Boolean to set the active value of this perk to
     */
    public void setActive(boolean value){
        CheckBox cb = (CheckBox) namespace.get(id);
        cb.setSelected(value);
        log.debug("Setting active: " + value);
        if(!value){
            active = false;
            Node perk = getPerkNode();
            if(perk != null){
                perk.getParentNode().removeChild(perk);
                log.debug("Removed node: " + this);
            }
            deactivate();
        }
        else{
            active = true;
            Element perk = createPerkNode();
            perksNode.appendChild(perk);
            log.debug("Created node: " + this);
            activate();
        }
    }

    /**
     * Finds the perk Node that matches the values of this perk stored under the perks Node
     * @return
     *   Perk Node that matches the values of this perk if found else null
     */
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

    /**
     * Creates a new Element based on the values of this perk
     * @return
     *   Element based on the values of this perk
     */
    private Element createPerkNode(){
        Element perk = saveFile.createElement("perk");
        perk.setAttribute("row", row);
        perk.setAttribute("type", type);
        return perk;
    }

    /**
     * Activates all parent perks if they exist
     */
    private void activate(){
        if(parent.size() == 0){
            return;
        }
        for (PerkNode perkNode : parent) {
            perkNode.setActive(true);
            log.debug(perkNode);
        }
    }

    /**
     * Deactivates all children perks if they exist
     */
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

    /**
     * Checks if this perk can be active based of if any parent to this perk is active
     * @return
     *   Boolean based on if this perk can be active
     */
    private boolean canBeActive(){
        for(PerkNode perkNode : parent){
            if(perkNode.isActive()){
                return true;
            }
        }
        return false;
    }

    /**
     * Checks if the given row and type match the row and type of this perk
     * @param perkRow
     *   Row value to match
     * @param perkType
     *   Type value to match
     * @return
     *   Boolean based on if the row and types match
     */
    public boolean equals(String perkRow, String perkType){
        return row.equals(perkRow) && type.equals(perkType);
    }

    @Override
    public String toString(){
        return "PerkNode{" +
                "row=" + row +
                ", type='" + type + '\'' +
                '}';
    }
}
