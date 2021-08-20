package LTSaveEd;

import javafx.collections.ObservableMap;
import javafx.scene.control.CheckBox;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;

public class PersonalityTrait{

    private static ObservableMap<String, Object> namespace;
    private static Document saveFile;
    private static Node personalityNode;
    private final String value;
    private final String id;
    private final ArrayList<PersonalityTrait> incompatibleValues;

    public PersonalityTrait(String trait){
        value = trait;
        id = "personalityTrait$" + value;
        incompatibleValues = new ArrayList<>();
    }

    public static void setNamespace(ObservableMap<String, Object> namespace){
        PersonalityTrait.namespace = namespace;
    }

    public static void setSaveFile(Document saveFile){
        PersonalityTrait.saveFile = saveFile;
    }

    public static void setPersonalityNode(Node personalityNode){
        PersonalityTrait.personalityNode = personalityNode;
    }

    public void addIncompatibleTrait(PersonalityTrait... incompatibleTraits){
        for(PersonalityTrait incompatibleTrait : incompatibleTraits){
            if(!incompatibleValues.contains(incompatibleTrait)){
                incompatibleValues.add(incompatibleTrait);
                incompatibleTrait.addIncompatibleTrait(this);
            }
        }
    }

    public void setActive(boolean activate){
        if(activate){
            for(PersonalityTrait incompatibleValue : incompatibleValues){
                incompatibleValue.setActive(false);
            }
            Element personalityTrait = saveFile.createElement("trait");
            personalityTrait.setTextContent(value);
            personalityNode.appendChild(personalityTrait);
        }
        else{
            CheckBox cb = (CheckBox) namespace.get(id);
            cb.setSelected(false);
            NodeList traits = personalityNode.getChildNodes();
            for(int i = 0; i < traits.getLength(); i++){
                if(traits.item(i).getNodeType() == Node.ELEMENT_NODE){
                    Node trait = traits.item(i);
                    if(trait.getTextContent().equals(value)){
                        trait.getParentNode().removeChild(trait);
                    }
                }
            }
        }
    }
}
