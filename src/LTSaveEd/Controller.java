package LTSaveEd;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.*;
import java.nio.file.Paths;
import java.util.Properties;

public class Controller {

    private Stage stage;
    private AnchorPane root;
    private final Properties prop;
    private File workingFile;
    private Document saveFile;
    private boolean fileLoaded = false;

    /**
     * Creates a new Controller object and parses config.ini
     * @throws IOException
     *   If config.ini cannot be properly read
     */
    public Controller() throws IOException {
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
        setFields("");
    }

    /**
     * Reads data from xml save file and sSets all fields with the selected character data
     * @param id
     *   Id value of the character to read data for
     */
    private void setFields(String id){
        if(fileLoaded) {
            id = "PlayerCharacter"; //Placeholder; will change to take input from combobox to select character
            Node idNode = getElementByIdValue(id);
            Node characterNode = idNode.getParentNode().getParentNode();
            //System.out.println(characterNode.getNodeName());
            NodeList attributeNodes = characterNode.getChildNodes();
            //System.out.println(attributeNodes.item(3).getNodeName());
            //Debug.printList(attributeNodes);
            for(int i = 3; i < attributeNodes.getLength() - 1; i+=2){
                if(attributeNodes.item(i).getNodeType() != Node.TEXT_NODE) {
                    NodeList attributeElements = attributeNodes.item(i).getChildNodes();
                    String attributeName = attributeNodes.item(i).getNodeName();
                    //System.out.println(attributeName);
                    //Debug.printList(attributeElements);
                    for(int j = 1; j < attributeElements.getLength() - 1; j+=2){
                        Node currNode = attributeElements.item(j);
                        String elementName = currNode.getNodeName();
                        if(attributeName.equals("core") && elementName.equals("name")){
                            NamedNodeMap attributes = currNode.getAttributes();
                            TextField andName = (TextField) root.lookup("#nameAndrogynous");
                            TextField femName = (TextField) root.lookup("#nameFeminine");
                            TextField masName = (TextField) root.lookup("#nameMasculine");
                            andName.setText(attributes.getNamedItem("nameAndrogynous").getTextContent());
                            femName.setText(attributes.getNamedItem("nameFeminine").getTextContent());
                            masName.setText(attributes.getNamedItem("nameMasculine").getTextContent());
                        }
                        else{
                            Node valueNode = currNode.getAttributes().getNamedItem("value");
                            if(valueNode != null) {
                                String value = valueNode.getTextContent();
                                //System.out.println("#" + attributeName + j);
                                TextField tf = (TextField) root.lookup("#" + attributeName + j);
                                if(tf != null) {
                                    tf.setText(value);
                                }
                            }
                        }
                    }
                }
            }
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
    private void saveFile(ActionEvent event){
        //TODO: Write saveFile method
    }

    /*@FXML
    private void lookupTest(ActionEvent event){
        event.consume();
        TextField tf = (TextField) root.lookup("#core3");
        tf.setText("25.234");
    }*/
}
