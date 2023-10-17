module LTSaveEd {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.xml;
    requires org.jetbrains.annotations;
    requires org.apache.logging.log4j;

//    opens LTSaveEd to javafx.fxml, org.apache.logging.log4j, org.apache.logging.log4j.core;
//    //exports LTSaveEd;
    exports LTSaveEd to javafx.controls, javafx.fxml, org.apache.logging.log4j, org.apache.logging.log4j.core;
}