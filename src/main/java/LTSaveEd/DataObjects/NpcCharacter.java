package LTSaveEd.DataObjects;

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

    private int femininity;

    /**
     * Constructor that uses the NPC Node to find the id, names, and gender identification
     * @param npcNode
     *   NPC Node of the Npc
     */
    public NpcCharacter(Node npcNode){
        if(!npcNode.getNodeName().equals("NPC")){
            throw new RuntimeException("Node is not NPC");
        }
        NodeList characterNodeChildren = npcNode.getChildNodes().item(1).getChildNodes();
        NodeList coreNodeChildren = characterNodeChildren.item(3).getChildNodes();
        for(int i = 0; i < coreNodeChildren.getLength(); i++){
            Node node = coreNodeChildren.item(i);
            switch (node.getNodeName()) {
                case "id" -> id = node.getAttributes().getNamedItem("value").getTextContent();
                case "name" -> {
                    NamedNodeMap namedNodeMap = node.getAttributes();
                    for (int j = 0; j < namedNodeMap.getLength(); j++) {
                        names[j] = namedNodeMap.item(j).getTextContent();
                    }
                }
            }
        }
        Node femininityAttr = characterNodeChildren.item(7).getChildNodes().item(1).getAttributes()
                .getNamedItem("femininity");
        femininity = Integer.parseInt(femininityAttr.getTextContent());
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
        else if(player.equals("")){ //Used for motherIds and fatherIds as the value can be blank
            id = player;
            Arrays.fill(names, "None");
            genderId = "N";
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
     * Get the name based on the npc's femininity value as that is how the game displays the correct name.
     * @return
     *   Name that corresponds with the npc's femininity value
     */
    public String getName(){
        if(femininity < 40){
            return names[0];
        }
        else if(femininity < 60){
            return names[1];
        }
        else{
            return names[2];
        }
    }

    /**
     * Checks if the supplied id matches the id of the npc
     * @param charId
     *   Supplied id to check against
     * @return
     *   True, if the ids match
     */
    public boolean equals(String charId){
        return id.equals(charId);
    }

    @Override
    public String toString() {
        return getName();
    }
}