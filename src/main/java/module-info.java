module LTSaveEd {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.xml;
    requires org.jetbrains.annotations;

    opens LTSaveEd to javafx.fxml;
    exports LTSaveEd;
}