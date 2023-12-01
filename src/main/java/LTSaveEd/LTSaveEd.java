package LTSaveEd;

import javafx.application.Application;
import javafx.application.HostServices;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.io.File;
import java.io.IOException;

/**
 * Class that initializes and starts the program
 * @author Exiua
 */
public class LTSaveEd extends Application {
    static {
        String logFilePath = "output.log";
        //System.out.println(System.getProperty("user.dir"));
        File file = new File(logFilePath);
        for(var i = 0; i < 10; i++){
            if(file.exists()){
                break;
            }
            try {
                //noinspection ResultOfMethodCallIgnored
                file.createNewFile();
                break;
            }
            catch (IOException e) {
                logFilePath = "../" + logFilePath;
                //System.out.println("Can't write path: " + logFilePath);
                file = new File(logFilePath);
            }
        }
        try {
            logFilePath = file.getCanonicalPath();
            Controller.configPath = file.getParent();
        }
        catch (IOException e) {
            throw new RuntimeException(e);
        }

        //System.out.println("Log Path: " + logFilePath);
        System.setProperty("log4j.logFilePath", logFilePath);
    }

    static Logger log = LogManager.getLogger(LTSaveEd.class);

    private static HostServices hostServices;

    @Override
    public void start(Stage primaryStage) throws Exception{
        String version = "v1.5.2";

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
