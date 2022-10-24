package LTSaveEd;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 * Class that initializes and starts the program
 * @author Exiua
 */
public class LTSaveEd extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{
        String version = "v1.3.2";

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
        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
