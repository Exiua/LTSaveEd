package LTSaveEd;

import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.Arrays;

public class NpcCharacter {

    private String id;
    private String[] names = new String[3];
    private String genderId;

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
                case "genderIdentity" -> {
                    genderId = n.getAttributes().getNamedItem("value").getTextContent();
                }
            }
        }
    }

    public NpcCharacter(String player){
        if(player.equals("PlayerCharacter")){
            id = player;
            Arrays.fill(names, "Player");
            genderId = "N_Player"; //Doesn't really matter, just need the first character to match the switch
        }
    }

    public String getId() {
        return id;
    }

    public String getName(){
        return switch (genderId.charAt(0)) {
            case 'N' -> names[0];
            case 'F' -> names[1];
            case 'M' -> names[2];
            default -> null;
        };
    }
}