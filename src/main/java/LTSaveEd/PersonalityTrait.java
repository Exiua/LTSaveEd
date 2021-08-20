package LTSaveEd;

import javafx.collections.ObservableMap;
import javafx.scene.control.CheckBox;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import java.util.ArrayList;

/**
 * Class that store personality trait values and incompatible personality traits
 * @author Exiua
 */
public class PersonalityTrait{

    /**
     * Namespace of the fxml file
     */
    private static ObservableMap<String, Object> namespace;

    /**
     * The parsed xml save file
     */
    private static Document saveFile;

    /**
     * The personality Node where all the personality traits are stored in the save file
     */
    private static Node personalityNode;

    /**
     * Value of this personality trait
     */
    private final String value;

    /**
     * CheckBox id that corresponds to this personality trait
     */
    private final String id;

    /**
     * ArrayList of incompatible personality traits
     */
    private final ArrayList<PersonalityTrait> incompatibleValues;

    /**
     * Constructor to create a new PersonalityTrait based on the given trait
     * @param trait
     *   Value of this PersonalityTrait
     */
    public PersonalityTrait(String trait){
        value = trait;
        id = "personalityTrait$" + value;
        incompatibleValues = new ArrayList<>();
    }

    /**
     * Sets the namespace that is shared across all PersonalityTrait objects
     * @param namespace
     *   Namespace of the fxml file
     */
    public static void setNamespace(ObservableMap<String, Object> namespace){
        PersonalityTrait.namespace = namespace;
    }

    /**
     * Sets the parsed xml save file that is shared across all PersonalityTrait objects
     * @param saveFile
     *   Parsed xml save file
     */
    public static void setSaveFile(Document saveFile){
        PersonalityTrait.saveFile = saveFile;
    }

    /**
     * Sets the Node that stores all personality traits that is shared across all PersonalityTrait objects
     * @param personalityNode
     *   Node that stores all personality traits
     */
    public static void setPersonalityNode(Node personalityNode){
        PersonalityTrait.personalityNode = personalityNode;
    }

    /**
     * Adds given PersonalityTraits to the ArrayList of incompatible personality traits
     * @param incompatibleTraits
     *   Array of incompatible PersonalityTraits
     */
    public void addIncompatibleTrait(PersonalityTrait... incompatibleTraits){
        for(PersonalityTrait incompatibleTrait : incompatibleTraits){
            if(!incompatibleValues.contains(incompatibleTrait)){
                incompatibleValues.add(incompatibleTrait);
                incompatibleTrait.addIncompatibleTrait(this);
            }
        }
    }

    /**
     * Sets the activeness of this PersonalityTrait to the given boolean value
     * @param activate
     *   Boolean value to activate or deactivate this PersonalityTrait
     */
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
