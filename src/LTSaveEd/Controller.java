package LTSaveEd;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.CheckBox;
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
    private String[] intTextFieldIds = {"#core$level$value", "#core$experience$value", "#core$perkPoints$value"};
    private String[] doubleTextFieldIds = {"#core$obedience$value", "#core$health$value", "#core$mana$value"};

    /**
     * Creates a new Controller object and parses config.ini
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
        private TextFieldType tfType;

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
