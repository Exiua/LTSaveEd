package LTSaveEd;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.CheckBox;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import org.w3c.dom.*;
import org.xml.sax.SAXException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import java.io.*;
import java.nio.file.Paths;
import java.util.Properties;

public class Controller {

    private Stage stage;
    private AnchorPane root;
    private Properties prop;
    private File workingFile;
    private Document saveFile;
    private boolean fileLoaded = false;
    private String charId;
    private final String[] intTextFieldIds = {"#core$level$value", "#core$experience$value", "#core$perkPoints$value", "#body$bodyCore$bodySize",
            "#body$bodyCore$femininity", "#body$bodyCore$height", "#body$bodyCore$muscle", "#body$antennae$antennaePerRow",
            "#body$antennae$length", "#body$antennae$rows", "#body$mouth$depth", "#body$mouth$elasticity", "#body$mouth$lipSize",
            "#body$mouth$plasticity", "#body$mouth$wetness", "#body$eye$eyePairs", "#body$tongue$tongueLength", "#body$hair$length",
            "#body$horn$hornsPerRow", "#body$horn$length", "#body$horn$rows", "#body$ass$assSize", "#body$ass$hipSize", "#body$anus$depth",
            "#body$anus$elasticity", "#body$anus$plasticity", "#body$anus$wetness", "#body$breasts$milkRegeneration", "#body$breasts$milkStorage",
            "#body$breasts$nippleCountPerBreast", "#body$breasts$rows", "#body$breasts$size", "#body$nipples$areolaeSize", "#body$nipples$depth",
            "#body$nipples$elasticity", "#body$nipples$nippleSize", "#body$nipples$plasticity", "#body$breastsCrotch$milkRegeneration",
            "#body$breastsCrotch$milkStorage", "#body$breastsCrotch$nippleCountPerBreast", "#body$breastsCrotch$rows", "#body$breastsCrotch$size",
            "#body$nipplesCrotch$areolaeSize", "#body$nipplesCrotch$depth", "#body$nipplesCrotch$elasticity", "#body$nipplesCrotch$nippleSize",
            "#body$nipplesCrotch$plasticity", "#body$penis$depth", "#body$penis$elasticity", "#body$penis$girth", "#body$penis$plasticity",
            "#body$penis$size", "#body$testicles$cumExpulsion", "#body$testicles$cumRegeneration", "#body$testicles$cumStorage",
            "#body$testicles$numberOfTesticles", "#body$testicles$testicleSize", "#body$vagina$clitGirth", "#body$vagina$clitSize",
            "#body$vagina$depth", "#body$vagina$elasticity", "#body$vagina$labiaSize", "#body$vagina$plasticity", "#body$tail$count",
            "#body$tail$girth", "#body$tentacle$count", "#body$tentacle$girth", "#body$wing$size", "#body$spinneret$depth", "#body$spinneret$elasticity",
            "#body$spinneret$plasticity", "#body$spinneret$wetness", "#body$arm$rows"};
    private final String[] doubleTextFieldIds = {"#core$obedience$value", "#core$health$value", "#core$mana$value", "#body$mouth$capacity",
            "#body$mouth$stretchedCapacity", "#body$anus$capacity", "#body$anus$stretchedCapacity", "#body$breasts$storedMilk",
            "#body$nipples$capacity", "#body$nipples$stretchedCapacity", "#body$breastsCrotch$storedMilk", "#body$nipplesCrotch$capacity",
            "#body$nipplesCrotch$stretchedCapacity", "#body$penis$capacity", "#body$penis$stretchedCapacity", "#body$testicles$storedCum",
            "#body$vagina$capacity", "#body$vagina$stretchedCapacity", "#body$tail$length", "#body$tentacle$length", "#body$spinneret$capacity",
            "#body$spinneret$stretchedCapacity"};
    private final String[] stringTextFieldIds = {"#core$name$nameAndrogynous", "#core$name$nameFeminine", "#core$name$nameMasculine",
            "#core$surname$value"};
    private final String[] ComboBoxIds = {"#body$torso$type"};
    private final ObservableList<String> sexualOrientations = FXCollections.observableArrayList("Androphilia", "Ambiphilia", "Gynephilia");
    private final ObservableList<String> antennaeTypes = FXCollections.observableArrayList("NONE");
    private final ObservableList<String> earTypes = FXCollections.observableArrayList();
    private final ObservableList<String> faceTypes = FXCollections.observableArrayList("ALLIGATOR_MORPH", "ANGEL", "innoxia_badger_face", "BAT_MORPH", "dsg_bear_face",
            "NoStepOnSnek_capybara_face", "CAT_MORPH", "COW_MORPH", "DEMON_COMMON", "DOG_MORPH", "dsg_dragon_faceCoatl", "dsg_dragon_faceRyu", "dsg_dragon_face", "dsg_ferret_face", "FOX_MORPH",
            "innoxia_goat_face", "dsg_gryphon_face", "HARPY", "HORSE_MORPH", "HUMAN", "innoxia_hyena_face", "NoStepOnSnek_octopus_face", "dsg_otter_face",
            "innoxia_panther_face", "innoxia_pig_face", "RABBIT_MORPH", "dsg_raccoon_face", "RAT_MORPH", "REINDEER_MORPH", "dsg_shark_face", "innoxia_sheep_torso",
            "NoStepOnSnek_snake_face", "NoStepOnSnek_snake_face_h", "charisma_spider_faceFluffy", "charisma_spider_face", "SQUIRREL_MORPH", "WOLF_MORPH");
    private final ObservableList<String> eyeTypes = FXCollections.observableArrayList();
    private final ObservableList<String> hairTypes = FXCollections.observableArrayList();
    private final ObservableList<String> hornTypes = FXCollections.observableArrayList("NONE");
    private final ObservableList<String> legTypes = FXCollections.observableArrayList("ALLIGATOR_MORPH", "ANGEL", "innoxia_badger_torso", "BAT_MORPH", "dsg_bear_torso",
            "NoStepOnSnek_capybara_torso", "CAT_MORPH", "COW_MORPH", "DEMON_COMMON", "DEMON_HOOFED"); //TODO: Add Foot Structure, Leg Configuration, and Genital Arrangement Dependence
    private final ObservableList<String> assTypes = FXCollections.observableArrayList();
    private final ObservableList<String> breastsTypes = FXCollections.observableArrayList();
    private final ObservableList<String> milkTypes = FXCollections.observableArrayList();
    private final ObservableList<String> penisTypes = FXCollections.observableArrayList();
    private final ObservableList<String> cumTypes = FXCollections.observableArrayList();
    private final ObservableList<String> vaginaTypes = FXCollections.observableArrayList();
    private final ObservableList<String> girlcumTypes = FXCollections.observableArrayList();
    private final ObservableList<String> torsoTypes = FXCollections.observableArrayList("ALLIGATOR_MORPH", "ANGEL", "innoxia_badger_torso", "BAT_MORPH", "dsg_bear_torso",
            "NoStepOnSnek_capybara_torso", "CAT_MORPH", "COW_MORPH", "DEMON_COMMON", "DOG_MORPH", "dsg_dragon_torsoRyu", "dsg_dragon_torso", "dsg_ferret_torso", "FOX_MORPH",
            "innoxia_goat_torso", "dsg_gryphon_torso", "HARPY", "HORSE_MORPH", "HUMAN", "innoxia_hyena_torso", "NoStepOnSnek_octopus_torso", "dsg_otter_torso",
            "innoxia_panther_torso", "innoxia_pig_torso", "RABBIT_MORPH", "dsg_raccoon_torso", "RAT_MORPH", "REINDEER_MORPH", "dsg_shark_torso", "dsg_shark_torsoDorsalFin",
            "innoxia_sheep_torso", "NoStepOnSnek_snake_torso", "charisma_spider_torsoFluffy", "charisma_spider_torso", "SQUIRREL_MORPH", "WOLF_MORPH");
    private final ObservableList<String> tailTypes = FXCollections.observableArrayList("NONE", "ALLIGATOR_MORPH", "innoxia_badger_tail", "BAT_MORPH", "dsg_bear_tail",
            "NoStepOnSnek_capybara_arm", "CAT_MORPH", "CAT_MORPH_SHORT", "CAT_MORPH_TUFTED", "COW_MORPH", "DEMON_COMMON", "DEMON_HAIR_TIP", "DEMON_TAPERED", "DEMON_HORSE",
            "DOG_MORPH", "DOG_MORPH_STUBBY", "dsg_dragon_tailTufted", "dsg_dragon_tail", "dsg_dragon_tailFeathered", "dsg_dragon_tailSpaded", "dsg_ferret_tail", "FOX_MORPH",
            "innoxia_goat_tail", "dsg_gryphon_tailFeathers", "dsg_gryphon_tail", "HARPY", "HORSE_MORPH", "HORSE_MORPH_ZEBRA", "innoxia_hyena_tail", "dsg_otter_tail",
            "innoxia_panther_tail", "innoxia_pig_tail", "RABBIT_MORPH", "dsg_raccoon_tail", "RAT_MORPH", "REINDEER_MORPH", "dsg_shark_tail", "innoxia_sheep_tail",
            "NoStepOnSnek_snake_tail", "charisma_spider_tailFluffy", "charisma_spider_tail", "SQUIRREL_MORPH", "WOLF_MORPH");
    private final ObservableList<String> tentacleTypes = FXCollections.observableArrayList("NONE");
    private final ObservableList<String> wingTypes = FXCollections.observableArrayList("NONE");
    private final ObservableList<String> armTypes = FXCollections.observableArrayList("ALLIGATOR_MORPH", "ANGEL", "innoxia_badger_arm", "BAT_MORPH", "dsg_bear_arm",
            "NoStepOnSnek_capybara_arm", "CAT_MORPH", "COW_MORPH", "DEMON_COMMON", "DOG_MORPH", "dsg_dragon_arm", "dsg_dragon_armWings", "dsg_ferret_arm", "FOX_MORPH",
            "innoxia_goat_arm", "dsg_gryphon_arm", "HARPY", "HORSE_MORPH", "HUMAN", "innoxia_hyena_arm", "NoStepOnSnek_octopus_arm", "dsg_otter_arm",
            "innoxia_panther_arm", "innoxia_pig_arm", "RABBIT_MORPH", "dsg_raccoon_arm", "RAT_MORPH", "REINDEER_MORPH", "dsg_shark_arm", "dsg_shark_armFin",
            "innoxia_sheep_arm", "NoStepOnSnek_snake_arm", "charisma_spider_armFluffy", "charisma_spider_arm", "SQUIRREL_MORPH", "WOLF_MORPH");

    /**
     * Initializes the Controller object and parses config.ini
     * @throws IOException
     *   If config.ini cannot be properly read
     */
    public void initialize() throws IOException {
        prop = new Properties();
        FileInputStream in;
        try {
            in = new FileInputStream("config.ini");
        }
        catch (FileNotFoundException e){
            prop.setProperty("defaultFilePath", Paths.get(".").toAbsolutePath().normalize().toString()); //Uses working directory as default file path
            prop.store(new FileOutputStream("config.ini"), null);
            in = new FileInputStream("config.ini");
        }
        prop.load(in);
    }

    public class TextFieldListener implements ChangeListener<Boolean> {

        private final TextField tf ;
        private final TextFieldType tfType;

        public TextFieldListener(TextField textField, TextFieldType textFieldType) {
            tf = textField;
            tfType = textFieldType;
        }

        @Override
        public void changed(ObservableValue<? extends Boolean> observable, Boolean oldValue, Boolean newValue) {
            if(!newValue) {  // check if focus gained or lost
                tf.setText(getFormattedText(tf.getText()));
            }
        }

        private String getFormattedText(String newValue) {
            Node value = getValueNode();
            String oldValue = value.getTextContent();
            switch(tfType) {
                case INT:
                    try {
                        int nv = Integer.parseInt(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(nv < 0){
                            return oldValue;
                        }
                        value.setTextContent(newValue);
                        return newValue;
                    }
                    catch (NumberFormatException e) {
                        return oldValue;
                    }
                case DOUBLE:
                    try {
                        double nv = Double.parseDouble(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(nv < 0){
                            return oldValue;
                        }
                        if(newValue.indexOf('.') == -1){
                            newValue += ".0";
                        }
                        else if(newValue.indexOf('.') == newValue.length() - 1){
                            newValue += "0";
                        }
                        value.setTextContent(newValue);
                        return newValue;
                    }
                    catch (NumberFormatException e) {
                        return oldValue;
                    }
                case STRING:
                    return newValue;
                default:
                    return null;
            }
        }

        protected Node getValueNode(){
            String[] id = tf.getId().split("\\$");
            NodeList attributeNodes = getAttributeNodes();
            Element attr = (Element) ((Element) attributeNodes).getElementsByTagName(id[0]).item(0);
            attr = (Element) attr.getElementsByTagName(id[1]).item(0);
            return attr.getAttributes().getNamedItem(id[2]);
        }
    }

    /**
     * Sets stage to supplied Stage object in order for events to work properly
     * @param s
     *   Stage object to be used
     */
    public void setStage(Stage s) {
        stage = s;
    }

    /**
     * Sets root to the root node of the fxml file
     * @param r
     *   Root node of fxml file
     */
    public void setRoot(AnchorPane r){
        root = r;
    }

    public void initializeComboBoxes(){
        //TODO:
        for(String ComboBoxId : ComboBoxIds) {
            ComboBox<String> cb = (ComboBox<String>) root.lookup(ComboBoxId);
            cb.setItems(torsoTypes);
        }
    }

    /**
     * Opens a file selector so that the user can select their save .xml file they want to edit
     * @param event
     *   Action event performed
     * @throws IOException
     *   If config.ini cannot be properly written to
     */
    @FXML
    private void loadFile(ActionEvent event) throws IOException {
        event.consume();
        //Get file
        FileChooser fc = new FileChooser();
        FileChooser.ExtensionFilter fileExtensions = new FileChooser.ExtensionFilter("XML files (*.xml)", "*.xml");
        fc.getExtensionFilters().add(fileExtensions);
        String currentPath = prop.getProperty("defaultFilePath");
        fc.setInitialDirectory(new File(currentPath));
        File f = fc.showOpenDialog(stage);
        if(f != null) {
            //Update config.ini if a different folder was used
            if(!f.getParent().equals(currentPath)) {
                prop.setProperty("defaultFilePath", f.getParent());
                prop.store(new FileOutputStream("config.ini"), null);
            }
            workingFile = f;
            //Load XML
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try (InputStream is = new FileInputStream(f)){
                DocumentBuilder db = dbf.newDocumentBuilder();
                saveFile = db.parse(is);
                System.out.println(f);
                fileLoaded = true;
            }
            catch(ParserConfigurationException | SAXException e){
                e.printStackTrace();
            }
        }
    }

    @FXML
    private void selectCharacter(ActionEvent event){
        event.consume();
        charId = "PlayerCharacter"; //Placeholder; will change to take input from a combobox to select character
        setFields();
    }

    /**
     * Helper method to get fx:id of the object that was interacted with
     * @param event
     *   ActionEvent from the object that was interacted with
     * @return
     *   String of the id (without '#') of the object that was interacted with
     */
    private String getId(ActionEvent event){
        return ((javafx.scene.Node) event.getSource()).getId();
    }

    /**
     * Gets the list of immediate child Nodes of the selected character's characterNode
     * @return
     *   NodeList of immediate child Nodes (eg. core, body, attributes, etc.)
     */
    private NodeList getAttributeNodes(){
        Node idNode = getElementByIdValue(charId);
        assert idNode != null;
        Node characterNode = idNode.getParentNode().getParentNode(); //idNode > coreNode > characterNode
        return characterNode.getChildNodes();
    }

    private Node getValueNode(ActionEvent event){
        String[] id = getId(event).split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) ((Element) attributeNodes).getElementsByTagName(id[0]).item(0);
        attr = (Element) attr.getElementsByTagName(id[1]).item(0);
        return attr.getAttributes().getNamedItem(id[2]);
    }

    @FXML
    private void updateXmlBoolean(ActionEvent event){
        String fxId = "#" + getId(event);
        CheckBox cb = (CheckBox) root.lookup(fxId);
        Node value = getValueNode(event);
        value.setTextContent("" + cb.isSelected());
        event.consume();
    }

    /**
     * Reads data from xml save file and sSets all fields with the selected character data
     *
     */
    private void setFields(){
        if(fileLoaded) {
            NodeList attributeNodes = getAttributeNodes();
            for(int i = 3; i < attributeNodes.getLength() - 1; i+=2){ //Every other node in the NodeList is a TextNode (so can be skipped)
                if(attributeNodes.item(i).getNodeType() != Node.TEXT_NODE) { //Probably a redundant check since the TextNodes should already be skipped
                    NodeList attributeElements = attributeNodes.item(i).getChildNodes();
                    String attributeName = attributeNodes.item(i).getNodeName();
                    for(int j = 1; j < attributeElements.getLength() - 1; j+=2){ //Every other node in the NodeList is a TextNode (so can be skipped)
                        Node currNode = attributeElements.item(j);
                        String elementName = currNode.getNodeName();
                        NamedNodeMap attributes = currNode.getAttributes();
                        for(int k = 0; k < attributes.getLength(); k++){
                            Node valueNode = attributes.item(k);
                            String bodyNodeName = valueNode.getNodeName();
                            try { //Using TextFields for numerical and string values
                                TextField tf = (TextField) root.lookup("#" + attributeName + "$" + elementName + "$" + bodyNodeName);
                                if (tf != null) {
                                    tf.setText(valueNode.getTextContent());
                                }
                            }
                            catch(ClassCastException e){ //Using CheckBox for boolean values
                                CheckBox cb = (CheckBox) root.lookup("#" + attributeName + "$" + elementName + "$" + bodyNodeName);
                                if (cb != null){
                                    cb.setSelected(Boolean.parseBoolean(valueNode.getTextContent()));
                                }
                            }
                        }
                    }
                }
            }
            attachListeners();
        }
    }

    private void attachListeners(){
        for(String intTextFieldId : intTextFieldIds) {
            TextField tf = (TextField) root.lookup(intTextFieldId);
            tf.focusedProperty().addListener(new TextFieldListener(tf, TextFieldType.INT));
        }
        for(String doubleTextFieldId : doubleTextFieldIds){
            TextField tf = (TextField) root.lookup(doubleTextFieldId);
            tf.focusedProperty().addListener(new TextFieldListener(tf, TextFieldType.DOUBLE));
        }
        for(String stringTextFieldId: stringTextFieldIds){
            TextField tf = (TextField) root.lookup(stringTextFieldId);
            tf.focusedProperty().addListener(new TextFieldListener(tf, TextFieldType.STRING));
        }
    }

    /**
     * Finds id tags by their corresponding value attribute
     * @param id
     *   Value attribute to search for
     * @return
     *   Node representing the id tag with corresponding value attribute
     */
    private Node getElementByIdValue(String id){
        NodeList nodes = saveFile.getElementsByTagName("id");
        for(int i = 0 ; i < nodes.getLength(); i++){
            Node currNode = nodes.item(i);
            NamedNodeMap attributes = currNode.getAttributes();
            Node value = attributes.getNamedItem("value");
            if(value != null && value.getTextContent().equals(id)){
                return currNode;
            }
        }
        return null;
    }

    @FXML
    private void saveFileOverwrite(ActionEvent event){
        event.consume();
        if(fileLoaded) {
            saveToFile(workingFile);
        }
    }

    @FXML
    private void saveFileExport(ActionEvent event){
        event.consume();
        if(fileLoaded) {
            FileChooser fc = new FileChooser();
            FileChooser.ExtensionFilter fileExtensions = new FileChooser.ExtensionFilter("XML files (*.xml)", "*.xml");
            fc.getExtensionFilters().add(fileExtensions);
            String currentPath = prop.getProperty("defaultFilePath");
            fc.setInitialDirectory(new File(currentPath));
            fc.setInitialFileName(workingFile.getName());
            File f = fc.showSaveDialog(stage);
            if (f != null) {
                saveToFile(f);
            }
        }
    }

    private void saveToFile(File f){
        TransformerFactory tff = TransformerFactory.newInstance();
        try {
            Transformer tf = tff.newTransformer();
            DOMSource source = new DOMSource(saveFile);
            StreamResult sr = new StreamResult(f);
            tf.transform(source, sr);
        }
        catch(TransformerException e){
            e.printStackTrace();
        }
    }
}
