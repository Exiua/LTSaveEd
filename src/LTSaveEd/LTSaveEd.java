package LTSaveEd;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class LTSaveEd extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{
        FXMLLoader loader = new FXMLLoader(getClass().getResource("LTSaveEd.fxml"));
        Parent root = loader.load();
        Controller controller = loader.getController();
        controller.setStage(primaryStage);
        controller.setRoot(loader.getRoot());
        controller.initializeComboBoxes();
        primaryStage.setTitle("LTSaveEd v1.0.0");
        primaryStage.setScene(new Scene(root, 1024, 700));
        //primaryStage.setMaximized(true);
        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
