package LTSaveEd.DataObjects;

import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import static LTSaveEd.Controller.getAttributeValue;

public class OffspringData {
    private String offspringId;
    private boolean fromPlayer;
    private boolean born;
    private NameTriplet name = null;
    private String motherId;
    private String motherName;
    private String fatherId;
    private String fatherName;

    public OffspringData(Node offspringNode){
        NodeList offspringInfo = offspringNode.getChildNodes();
        for(int j = 0; j < offspringInfo.getLength(); j++){
            Node infoNode = offspringInfo.item(j);
            if(infoNode.getNodeType() != Node.ELEMENT_NODE){
                continue;
            }

            String infoNodeName = infoNode.getNodeName();
            NodeList infoDataNodes = infoNode.getChildNodes();
            for (int k = 0; k < infoDataNodes.getLength(); k++) {
                Node infoDataNode = infoDataNodes.item(k);
                String infoDataNodeName = infoDataNode.getNodeName();
                switch (infoNodeName) {
                    case "data" -> {
                        switch (infoDataNodeName){
                            case "id" -> offspringId = getAttributeValue(infoDataNode, "value");
                            case "fromPlayer" -> {
                                String boolString = getAttributeValue(infoDataNode, "value");
                                fromPlayer = Boolean.parseBoolean(boolString);
                            }
                            case "born" -> {
                                String boolString = getAttributeValue(infoDataNode, "value");
                                born = Boolean.parseBoolean(boolString);
                            }
                            case "name" -> {
                                NamedNodeMap names = infoDataNode.getAttributes();
                                String masc = getAttributeValue(names, "nameMasculine");
                                String andro = getAttributeValue(names, "nameAndrogynous");
                                String fem = getAttributeValue(names, "nameFeminine");
                                if(name == null){
                                    name = new NameTriplet(andro, fem, masc);
                                }
                                else{
                                    name.setMasculine(masc);
                                    name.setFeminine(fem);
                                    name.setAndrogynous(andro);
                                }
                            }
                            case "surname" -> {
                                String surname = getAttributeValue(infoDataNode, "value");
                                if(name == null){
                                    name = new NameTriplet(surname);
                                }
                                else{
                                    name.setSurname(surname);
                                }
                            }
                        }
                    }
                    case "body" -> {}
                    case "family" -> {
                        switch (infoDataNodeName){
                            case "motherId" -> motherId = getAttributeValue(infoDataNode, "value");
                            case "motherName" -> motherName = getAttributeValue(infoDataNode, "value");
                            case "fatherId" -> fatherId = getAttributeValue(infoDataNode, "value");
                            case "fatherName" -> fatherName = getAttributeValue(infoDataNode, "value");
                        }
                    }
                }
            }
        }
    }


    public String getOffspringId() {
        return offspringId;
    }

    public boolean isFromPlayer() {
        return fromPlayer;
    }

    public boolean isBorn() {
        return born;
    }

    public NameTriplet getName() {
        return name;
    }

    public String getMotherId() {
        return motherId;
    }

    public String getMotherName() {
        return motherName;
    }

    public String getFatherId() {
        return fatherId;
    }

    public String getFatherName() {
        return fatherName;
    }
}
