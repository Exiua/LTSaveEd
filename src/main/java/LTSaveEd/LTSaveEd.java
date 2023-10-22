package LTSaveEd;

import LTSaveEd.DataObjects.InventoryElements.InventoryClothing;
import javafx.application.Application;
import javafx.application.HostServices;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

/**
 * Class that initializes and starts the program
 * @author Exiua
 */
public class LTSaveEd extends Application {
    static Logger log = LogManager.getLogger(InventoryClothing.class.getName());

    private static HostServices hostServices;

    @Override
    public void start(Stage primaryStage) throws Exception{
        String version = "v1.4.2";

        FXMLLoader loader = new FXMLLoader(getClass().getResource("/LTSaveEd.fxml"));
        Parent root = loader.load();
        Controller controller = loader.getController();
        controller.setStage(primaryStage);
        controller.setNamespace(loader.getNamespace());
        controller.setVersion(version);
        controller.initializeComboBoxes();
        primaryStage.setTitle("LTSaveEd " + version);
        primaryStage.setScene(new Scene(root, 1024, 700));
        primaryStage.setMaximized(true);
        hostServices = getHostServices();
        primaryStage.show();
    }

    @Override
    public void init() {
        Thread.setDefaultUncaughtExceptionHandler((t, e) -> log.error("An unhandled exception has occurred.", e));
    }

    public static void openLinkInBrowser(String url){
        hostServices.showDocument(url); // Should never be called before start()
    }


    public static void main(String[] args) {
        launch(args);
    }
}
