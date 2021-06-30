package LTSaveEd;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import org.w3c.dom.Document;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.*;
import java.nio.file.Paths;
import java.util.Properties;

public class Controller {

    private Stage stage;
    private final Properties prop;
    private File workingFile;
    private Document xml;

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
            prop.setProperty("defaultFilePath", f.getParent());
            prop.store(new FileOutputStream("config.ini"), null);
            workingFile = f;
            //Load XML
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try (InputStream is = new FileInputStream(f)){
                DocumentBuilder db = dbf.newDocumentBuilder();
                xml = db.parse(is);
                System.out.println("Working?");
            }
            catch(ParserConfigurationException | SAXException e){
                e.printStackTrace();
            }
        }
    }

    @FXML
    private void saveFile(ActionEvent event){
        //TODO: Write saveFile method
    }
}
