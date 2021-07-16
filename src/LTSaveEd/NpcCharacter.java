package LTSaveEd;

import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.Arrays;

/**
 * Class that stores Npc ids and name for easy lookup
 * @author Exiua
 */
public class NpcCharacter {

    /**
     * Id of the Npc
     */
    private String id;

    /**
     * Androgynous, Feminine, and Masculine names of the Npc
     */
    private final String[] names = new String[3];

    /**
     * Gender identification of the Npc
     */
    private String genderId;

    /**
     * Constructor that uses the NPC Node to find the id, names, and gender identification
     * @param npcNode
     *   NPC Node of the Npc
     */
    public NpcCharacter(Node npcNode){
        if(!npcNode.getNodeName().equals("NPC")){
            throw new RuntimeException("Node is not NPC");
        }
        NodeList nl = npcNode.getChildNodes().item(1).getChildNodes().item(3).getChildNodes();
        for(int i = 0; i < nl.getLength(); i++){
            Node n = nl.item(i);
            switch (n.getNodeName()) {
                case "id" -> id = n.getAttributes().getNamedItem("value").getTextContent();
                case "name" -> {
                    NamedNodeMap nnm = n.getAttributes();
                    for (int j = 0; j < nnm.getLength(); j++) {
                        names[j] = nnm.item(j).getTextContent();
                    }
                }
                case "genderIdentity" -> genderId = n.getAttributes().getNamedItem("value").getTextContent();
            }
        }
    }

    /**
     * Constructor for the Player Character
     * @param player
     *   String to indicate the creation of a player NpcCharacter object
     */
    public NpcCharacter(String player){
        if(player.equals("PlayerCharacter")){
            id = player;
            Arrays.fill(names, "Player");
            genderId = "N_Player"; //Doesn't really matter, just need the first character to match in the switch
        }
    }

    /**
     * Get the Npc's id
     * @return
     *   Npc's id
     */
    public String getId() {
        return id;
    }

    /**
     * Get the name based on the npc's gender identity
     * @return
     *   Name that corresponds with the npc's gender identity
     */
    public String getName(){
        return switch (genderId.charAt(0)) {
            case 'N' -> names[0];
            case 'F' -> names[1];
            case 'M' -> names[2];
            default -> null;
        };
    }
}