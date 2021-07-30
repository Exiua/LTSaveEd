package LTSaveEd;

import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.util.StringConverter;
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
import java.util.ArrayList;
import java.util.Objects;
import java.util.Properties;

/**
 * Controller class that handles events and interactions of the GUI
 * @author Exiua
 * @version 0.1.0
 */
public class Controller {

    /**
     * Gui's stage object
     */
    private Stage stage;

    /**
     * Root node of the fxml
     */
    private AnchorPane root;

    /**
     * Properties object of the config.ini file
     */
    private Properties prop;

    /**
     * File that was loaded in
     */
    private File workingFile;

    /**
     * Parsed xml object
     */
    private Document saveFile;

    /**
     * Boolean of whether a valid file has been loaded
     */
    private boolean fileLoaded = false;

    /**
     * Id of the character to edit
     */
    private String charId;

    /**
     * String array of all TextField ids using an int data type
     */
    private final String[] intTextFieldIds = {"#core$level$value", "#core$experience$value", "#core$perkPoints$value",
            "#body$bodyCore$bodySize", "#body$bodyCore$femininity", "#body$bodyCore$height", "#body$bodyCore$muscle",
            "#body$antennae$antennaePerRow", "#body$antennae$length", "#body$antennae$rows", "#body$mouth$depth",
            "#body$mouth$elasticity", "#body$mouth$lipSize", "#body$mouth$plasticity", "#body$mouth$wetness",
            "#body$eye$eyePairs", "#body$tongue$tongueLength", "#body$horn$hornsPerRow", "#body$horn$length",
            "#body$horn$rows", "#body$ass$assSize", "#body$ass$hipSize", "#body$anus$depth", "#body$anus$elasticity",
            "#body$anus$plasticity", "#body$anus$wetness", "#body$breasts$milkRegeneration", "#body$breasts$milkStorage",
            "#body$breasts$nippleCountPerBreast", "#body$breasts$rows", "#body$breasts$size", "#body$nipples$areolaeSize",
            "#body$nipples$depth", "#body$nipples$elasticity", "#body$nipples$nippleSize", "#body$nipples$plasticity",
            "#body$breastsCrotch$milkRegeneration", "#body$breastsCrotch$milkStorage",
            "#body$breastsCrotch$nippleCountPerBreast", "#body$breastsCrotch$rows", "#body$breastsCrotch$size",
            "#body$nipplesCrotch$areolaeSize", "#body$nipplesCrotch$depth", "#body$nipplesCrotch$elasticity",
            "#body$nipplesCrotch$nippleSize", "#body$nipplesCrotch$plasticity", "#body$penis$depth",
            "#body$penis$elasticity", "#body$penis$girth", "#body$penis$plasticity", "#body$penis$size",
            "#body$testicles$cumExpulsion", "#body$testicles$cumRegeneration", "#body$testicles$cumStorage",
            "#body$testicles$numberOfTesticles", "#body$testicles$testicleSize", "#body$vagina$clitGirth",
            "#body$vagina$clitSize", "#body$vagina$depth", "#body$vagina$elasticity", "#body$vagina$labiaSize",
            "#body$vagina$plasticity", "#body$tail$count", "#body$tail$girth", "#body$tentacle$count",
            "#body$tentacle$girth", "#body$wing$size", "#body$spinneret$depth", "#body$spinneret$elasticity",
            "#body$spinneret$plasticity", "#body$spinneret$wetness", "#body$arm$rows"};

    /**
     * String array of all TextField ids using a double data type
     */
    private final String[] doubleTextFieldIds = {"#core$obedience$value", "#core$health$value", "#core$mana$value",
            "#body$mouth$capacity", "#body$mouth$stretchedCapacity", "#body$anus$capacity",
            "#body$anus$stretchedCapacity", "#body$breasts$storedMilk", "#body$nipples$capacity",
            "#body$nipples$stretchedCapacity", "#body$breastsCrotch$storedMilk", "#body$nipplesCrotch$capacity",
            "#body$nipplesCrotch$stretchedCapacity", "#body$penis$capacity", "#body$penis$stretchedCapacity",
            "#body$testicles$storedCum", "#body$vagina$capacity", "#body$vagina$stretchedCapacity", "#body$tail$length",
            "#body$tentacle$length", "#body$spinneret$capacity", "#body$spinneret$stretchedCapacity"};

    /**
     * String array of all TextField ids using a String data type
     */
    private final String[] stringTextFieldIds = {"#core$name$nameAndrogynous", "#core$name$nameFeminine",
            "#core$name$nameMasculine", "#core$surname$value"};

    /**
     * String array of all ComboBox ids
     */
    private final String[] ComboBoxIds = {"#core$sexualOrientation$value", "#core$genderIdentity$value",
            "#body$antennae$type", "#body$ear$type", "#body$face$type", "#body$eye$type", "#body$hair$type",
            "#body$horn$type", "#body$leg$type", "#body$ass$type", "#body$breasts$type", "#body$milk$flavour",
            "#body$breastsCrotch$type", "#body$milkCrotch$flavour", "#body$penis$type", "#body$cum$flavour",
            "#body$vagina$type", "#body$girlcum$flavour", "#body$torso$type", "#body$tail$type", "#body$tentacle$type",
            "#body$wing$type", "#body$arm$type", "#body$eye$irisShape", "#body$eye$pupilShape", "#body$breasts$shape",
            "#body$nipples$areolaeShape", "#body$nipples$nippleShape", "#body$breastsCrotch$shape",
            "#body$nipplesCrotch$areolaeShape", "#body$nipplesCrotch$nippleShape", "#body$hair$hairStyle",
            "#body$bodyCore$bodyMaterial", "#body$bodyCore$genitalArrangement", "#body$leg$configuration",
            "#body$leg$footStructure"};

    /**
     * ObservableList of all sexual orientations in the game
     */
    private final ObservableList<Attribute> sexualOrientations = FXCollections.observableArrayList(
            new Attribute("Androphilic", "ANDROPHILIC"), new Attribute("Ambiphilic", "AMBIPHILIC"),
            new Attribute("Gynephilic", "GYNEPHILIC"));

    /**
     * ObservableList of all gender identities in the game based on Masculinity/Femininity (M/N/F) and the presence
     * (or lack of) of a penis (P), vagina (V), and breasts (B)
     */
    private final ObservableList<Attribute> genderIdentities = FXCollections.observableArrayList(
            new Attribute("M_P_V_B_HERMAPHRODITE", "M_P_V_B_HERMAPHRODITE"),
            new Attribute("M_P_V_HERMAPHRODITE", "M_P_V_HERMAPHRODITE"),
            new Attribute("M_P_B_BUSTYBOY", "M_P_B_BUSTYBOY"), new Attribute("M_P_MALE", "M_P_MALE"),
            new Attribute("M_V_B_BUTCH", "M_V_B_BUTCH"), new Attribute("M_V_CUNTBOY", "M_V_CUNTBOY"),
            new Attribute("M_B_MANNEQUIN", "M_B_MANNEQUIN"),
            new Attribute("M_MANNEQUIN", "M_MANNEQUIN"),
            new Attribute("F_P_V_B_FUTANARI", "F_P_V_B_FUTANARI"),
            new Attribute("F_P_V_FUTANARI", "F_P_V_FUTANARI"),
            new Attribute("F_P_B_SHEMALE", "F_P_B_SHEMALE"),
            new Attribute("F_P_TRAP", "F_P_TRAP"),
            new Attribute("F_V_B_FEMALE", "F_V_B_FEMALE"), new Attribute("F_V_FEMALE", "F_V_FEMALE"),
            new Attribute("F_B_DOLL", "F_B_DOLL"), new Attribute("F_DOLL", "F_DOLL"),
            new Attribute("N_P_V_B_HERMAPHRODITE", "N_P_V_B_HERMAPHRODITE"),
            new Attribute("N_P_V_HERMAPHRODITE", "N_P_V_HERMAPHRODITE"),
            new Attribute("N_P_B_SHEMALE", "N_P_B_SHEMALE"), new Attribute("N_P_TRAP", "N_P_TRAP"),
            new Attribute("N_V_B_TOMBOY", "N_V_B_TOMBOY"), new Attribute("N_V_TOMBOY", "N_V_TOMBOY"),
            new Attribute("N_B_DOLL", "N_B_DOLL"), new Attribute("N_NEUTER", "N_NEUTER"));

    /**
     * ObservableList of all antennae types in the game
     */
    private final ObservableList<Attribute> antennaeTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE")); //TODO: Find antennae types

    /**
     * ObservableList of all ear types in the game
     */
    private final ObservableList<Attribute> earTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_ear"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_ear"), new Attribute("Capybara", "NoStepOnSnek_capybara_ear"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Tufted Cat", "CAT_MORPH_TUFTED"),
            new Attribute("Cow", "COW_MORPH"), new Attribute("Demonic", "DEMON_COMMON"),
            new Attribute("Floppy Dog", "DOG_MORPH"),
            new Attribute("Pointed Dog", "DOG_MORPH_POINTED"),
            new Attribute("Folded Dog", "DOG_MORPH_FOLDED"),
            new Attribute("Dragon", "dsg_dragon_ear"),
            new Attribute("Dragon external", "dsg_dragon_earExternal"),
            new Attribute("Ferret", "dsg_ferret_ear"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Fennec Fox", "FOX_MORPH_BIG"), new Attribute("Goat", "innoxia_goat_ear"),
            new Attribute("Gryphon", "dsg_gryphon_ear"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_ear"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_ear"),
            new Attribute("Otter", "dsg_otter_ear"),
            new Attribute("Panther", "innoxia_panther_ear"), new Attribute("Pig", "innoxia_pig_ear"),
            new Attribute("Upright Rabbit", "RABBIT_MORPH"),
            new Attribute("Floppy Rabbit", "RABBIT_MORPH_FLOPPY"),
            new Attribute("Racoon", "dsg_raccoon_ear"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_ear"),
            new Attribute("Shark finned", "dsg_shark_earFin"),
            new Attribute("Sheep", "innoxia_sheep_ear"),
            new Attribute("Pointed Snake", "NoStepOnSnek_snake_ear_1"),
            new Attribute("Snake", "NoStepOnSnek_snake_ear"),
            new Attribute("Spider", "charisma_spider_ear"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all face types in the game
     */
    private final ObservableList<Attribute> faceTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_face"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_face"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_face"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Coatl", "dsg_dragon_faceCoatl"),
            new Attribute("Ryu", "dsg_dragon_faceRyu"), new Attribute("Dragon", "dsg_dragon_face"),
            new Attribute("Ferret", "dsg_ferret_face"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_face"), new Attribute("Gryphon", "dsg_gryphon_face"),
            new Attribute("Harpy", "HARPY"), new Attribute("Horse", "HORSE_MORPH"),
            new Attribute("Human", "HUMAN"), new Attribute("Hyena", "innoxia_hyena_face"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_face"),
            new Attribute("Otter", "dsg_otter_face"),
            new Attribute("Panther", "innoxia_panther_face"),
            new Attribute("Pig", "innoxia_pig_face"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_face"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_face"),
            new Attribute("Sheep", "innoxia_sheep_face"),
            new Attribute("Snake", "NoStepOnSnek_snake_face"),
            new Attribute("Hooded Snake", "NoStepOnSnek_snake_face_h"),
            new Attribute("Spider", "charisma_spider_face"),
            new Attribute("Furred Spider", "charisma_spider_faceFluffy"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all eye types in the game
     */
    private final ObservableList<Attribute> eyeTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_eye"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_eye"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_eye"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_eye"), new Attribute("Ferret", "dsg_ferret_eye"),
            new Attribute("Fox", "FOX_MORPH"), new Attribute("Goat", "innoxia_goat_eye"),
            new Attribute("Gryphon", "dsg_gryphon_eye"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_eye"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_eye"),
            new Attribute("Otter", "dsg_otter_eye"), new Attribute("Panther", "innoxia_panther_eye"),
            new Attribute("Pig", "innoxia_pig_eye"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_eye"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_eye"),
            new Attribute("Sheep", "innoxia_sheep_eye"),
            new Attribute("Snake", "NoStepOnSnek_snake_eye"),
            new Attribute("Spider", "charisma_spider_eye"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all hair types in the game
     */
    private final ObservableList<Attribute> hairTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_hair"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_hair"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_hair"),
            new Attribute("Cat", "CAT_MORPH"),
            new Attribute("Cat (sidefluff)", "CAT_MORPH_SIDEFLUFF"),
            new Attribute("Cow", "COW_MORPH"), new Attribute("Demonic", "DEMON"),
            new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon head feathers", "dsg_dragon_hairFeathers"),
            new Attribute("Dragon mane", "dsg_dragon_hairMane"),
            new Attribute("Dragon", "dsg_dragon_hair"), new Attribute("Ferret", "dsg_ferret_hair"),
            new Attribute("Fox", "FOX_MORPH"), new Attribute("Goat", "innoxia_goat_hair"),
            new Attribute("Gryphon", "dsg_gryphon_hair"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_hair"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_hair"),
            new Attribute("Otter", "dsg_otter_hair"),
            new Attribute("Panther", "innoxia_panther_hair"),
            new Attribute("Pig", "innoxia_pig_hair"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_hair"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_hair"),
            new Attribute("Sheep", "innoxia_sheep_hair"),
            new Attribute("Snake", "NoStepOnSnek_snake_hair"),
            new Attribute("Spider", "charisma_spider_hair"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all horn types in the game
     */
    private final ObservableList<Attribute> hornTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Dragon", "dsg_dragon_horn"),
            new Attribute("Dragon antler", "dsg_dragon_hornAntlers"),
            new Attribute("Dragon curled", "dsg_dragon_hornCurled"),
            new Attribute("Dragon curved", "dsg_dragon_hornCurved"),
            new Attribute("Unicorn", "HORSE_STRAIGHT"), new Attribute("Curled", "CURLED"),
            new Attribute("Curved", "CURVED"), new Attribute("Spiral", "SPIRAL"),
            new Attribute("Straight", "STRAIGHT"), new Attribute("Swept-back", "SWEPT_BACK"),
            new Attribute("Multi-branched", "REINDEER_RACK"));

    /**
     * ObservableList of all ass types in the game
     */
    private final ObservableList<Attribute> assTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_ass"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_ass"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_ass"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_ass"), new Attribute("Ferret", "dsg_ferret_ass"),
            new Attribute("Fox", "FOX_MORPH"), new Attribute("", "innoxia_goat_ass"),
            new Attribute("Gryphon", "dsg_gryphon_ass"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_ass"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_ass"),
            new Attribute("Otter", "dsg_otter_ass"), new Attribute("Panther", "innoxia_panther_ass"),
            new Attribute("Pig", "innoxia_pig_ass"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_ass"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_ass"),
            new Attribute("Sheep", "innoxia_sheep_ass"),
            new Attribute("Snake", "NoStepOnSnek_snake_ass"),
            new Attribute("Spider", "charisma_spider_ass"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all breast types in the game
     */
    private final ObservableList<Attribute> breastsTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_breast"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_breast"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_breast"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_breast"),
            new Attribute("Ferret", "dsg_ferret_breast"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_breast"),
            new Attribute("Gryphon", "dsg_gryphon_breast"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_breast"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_breast"),
            new Attribute("Otter", "dsg_otter_breast"),
            new Attribute("Panther", "innoxia_panther_breast"),
            new Attribute("Pig", "innoxia_pig_breast"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_breast"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_breast"),
            new Attribute("Sheep", "innoxia_sheep_breast"),
            new Attribute("Snake", "NoStepOnSnek_snake_breast"),
            new Attribute("Spider", "charisma_spider_breast"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all milk flavours in the game
     */
    private final ObservableList<Attribute> milkFlavours = FXCollections.observableArrayList(
            new Attribute("Cum", "CUM"), new Attribute("Milk", "MILK"),
            new Attribute("Girlcum", "GIRL_CUM"), new Attribute("Bubblegum", "BUBBLEGUM"),
            new Attribute("Beer", "BEER"), new Attribute("Vanilla", "VANILLA"),
            new Attribute("Strawberry", "STRAWBERRY"), new Attribute("Chocolate", "CHOCOLATE"),
            new Attribute("Pineapple", "PINEAPPLE"), new Attribute("Honey", "HONEY"),
            new Attribute("Mint", "MINT"), new Attribute("Cherry", "CHERRY"),
            new Attribute("Coffee", "COFFEE"), new Attribute("Tea", "TEA"),
            new Attribute("Maple", "MAPLE"), new Attribute("Cinnamon", "CINNAMON"),
            new Attribute("Lemon", "LEMON"), new Attribute("Orange", "ORANGE"),
            new Attribute("Grape", "GRAPE"), new Attribute("Melon", "MELON"),
            new Attribute("Coconut", "COCONUT"), new Attribute("Blueberry", "BLUEBERRY"));

    /**
     * ObservableList of all breastCrotch types in the game
     */
    private final ObservableList<Attribute> breastCrotchTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Alligator", "ALLIGATOR_MORPH"),
            new Attribute("Angel", "ANGEL"), new Attribute("Badger", "innoxia_badger_breast"),
            new Attribute("Bat", "BAT_MORPH"), new Attribute("Bear", "dsg_bear_breast"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_breast"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_breast"),
            new Attribute("Ferret", "dsg_ferret_breast"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_breast"),
            new Attribute("Gryphon", "dsg_gryphon_breast"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_breast"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_breast"),
            new Attribute("Otter", "dsg_otter_breast"),
            new Attribute("Panther", "innoxia_panther_breast"),
            new Attribute("Pig", "innoxia_pig_breast"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_breast"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_breast"),
            new Attribute("Sheep", "innoxia_sheep_breast"),
            new Attribute("Snake", "NoStepOnSnek_snake_breast"),
            new Attribute("Spider", "charisma_spider_breast"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH")
    );

    /**
     * ObservableList of all milkCrotch flavours in the game (same as milkFlavours)
     */
    private final ObservableList<Attribute> milkCrotchFlavours = milkFlavours; //Reusing object to simplify the code

    /**
     * ObservableList of all penis types in the game
     */
    private final ObservableList<Attribute> penisTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Alligator", "ALLIGATOR_MORPH"),
            new Attribute("Angel", "ANGEL"), new Attribute("Badger", "innoxia_badger_penis"),
            new Attribute("Bat", "BAT_MORPH"), new Attribute("Bear", "dsg_bear_penis"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_penis"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_penis"), new Attribute("Ferret", "dsg_ferret_penis"),
            new Attribute("Fox", "FOX_MORPH"), new Attribute("Goat", "innoxia_goat_penis"),
            new Attribute("Gryphon", "dsg_gryphon_penis"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "EQUINE"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_penis"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_penis"),
            new Attribute("Otter", "dsg_otter_penis"),
            new Attribute("Panther", "innoxia_panther_penis"),
            new Attribute("Pig", "innoxia_pig_penis"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_penis"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_penis"),
            new Attribute("Sheep", "innoxia_sheep_penis"),
            new Attribute("Snake", "NoStepOnSnek_snake_penis"),
            new Attribute("Spider", "charisma_spider_penis"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all cum flavours in the game (same as milkFlavours)
     */
    private final ObservableList<Attribute> cumFlavours = milkFlavours;

    /**
     * ObservableList of all vagina types in the game
     */
    private final ObservableList<Attribute> vaginaTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Alligator", "ALLIGATOR_MORPH"),
            new Attribute("Angel", "ANGEL"), new Attribute("Badger", "innoxia_badger_vagina"),
            new Attribute("Bat", "BAT_MORPH"), new Attribute("Bear", "dsg_bear_vagina"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_vagina"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_vagina"),
            new Attribute("Ferret", "dsg_ferret_vagina"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_vagina"),
            new Attribute("Gryphon", "dsg_gryphon_vagina"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_vagina"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_vagina"),
            new Attribute("Otter", "dsg_otter_vagina"),
            new Attribute("Panther", "innoxia_panther_vagina"),
            new Attribute("Pig", "innoxia_pig_vagina"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_vagina"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_vagina"),
            new Attribute("Sheep", "innoxia_sheep_vagina"),
            new Attribute("Snake", "NoStepOnSnek_snake_vagina"),
            new Attribute("Spider", "charisma_spider_vagina"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all girlcum flavours in the game (same as milkFlavours)
     */
    private final ObservableList<Attribute> girlcumFlavours = milkFlavours;

    /**
     * ObservableList of all torso types in the game
     */
    private final ObservableList<Attribute> torsoTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_torso"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_torso"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_torso"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Ryu", "dsg_dragon_torsoRyu"), new Attribute("Dragon", "dsg_dragon_torso"),
            new Attribute("Ferret", "dsg_ferret_torso"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_torso"),
            new Attribute("Gryphon", "dsg_gryphon_torso"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_torso"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_torso"),
            new Attribute("Otter", "dsg_otter_torso"),
            new Attribute("Panther", "innoxia_panther_torso"),
            new Attribute("Pig", "innoxia_pig_torso"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_torso"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_torso"),
            new Attribute("Shark finned", "dsg_shark_torsoDorsalFin"),
            new Attribute("Sheep", "innoxia_sheep_torso"),
            new Attribute("Snake", "NoStepOnSnek_snake_torso"),
            new Attribute("Furred Spider", "charisma_spider_torsoFluffy"),
            new Attribute("Spider", "charisma_spider_torso"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all tail types in the game
     */
    private final ObservableList<Attribute> tailTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Alligator", "ALLIGATOR_MORPH"),
            new Attribute("Badger", "innoxia_badger_tail"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_tail"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_arm"),
            new Attribute("Feline", "CAT_MORPH"), new Attribute("Short Feline", "CAT_MORPH_SHORT"),
            new Attribute("Tufted Feline", "CAT_MORPH_TUFTED"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic spaded", "DEMON_COMMON"),
            new Attribute("Demonic hair-tipped", "DEMON_HAIR_TIP"),
            new Attribute("Demonic tapered", "DEMON_TAPERED"),
            new Attribute("Demonic horse", "DEMON_HORSE"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Stubby Dog", "DOG_MORPH_STUBBY"),
            new Attribute("Dragon tufted", "dsg_dragon_tailTufted"),
            new Attribute("Dragon", "dsg_dragon_tail"),
            new Attribute("Dragon feathered", "dsg_dragon_tailFeathered"),
            new Attribute("Dragon spaded", "dsg_dragon_tailSpaded"),
            new Attribute("Ferret", "dsg_ferret_tail"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_tail"),
            new Attribute("Gryphon feathered", "dsg_gryphon_tailFeathers"),
            new Attribute("Gryphon", "dsg_gryphon_tail"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Zebra", "HORSE_MORPH_ZEBRA"),
            new Attribute("Hyena", "innoxia_hyena_tail"), new Attribute("Otter", "dsg_otter_tail"),
            new Attribute("Panther", "innoxia_panther_tail"),
            new Attribute("Pig", "innoxia_pig_tail"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_tail"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_tail"),
            new Attribute("Sheep", "innoxia_sheep_tail"),
            new Attribute("Snake", "NoStepOnSnek_snake_tail"),
            new Attribute("Furred Spider", "charisma_spider_tailFluffy"),
            new Attribute("Spider", "charisma_spider_tail"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all tentacle types in the game
     */
    private final ObservableList<Attribute> tentacleTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE")); //TODO: Find tentacle types

    /**
     * ObservableList of all wing types in the game
     */
    private final ObservableList<Attribute> wingTypes = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Angel", "ANGEL"),
            new Attribute("Demonic feathered", "DEMON_FEATHERED"), new Attribute("Demonic leathery", "DEMON_COMMON"),
            new Attribute("Dragon", "dsg_dragon_wing"), new Attribute("Dragon feathered", "dsg_dragon_wingFeathered"),
            new Attribute("Gryphon", "dsg_gryphon_wing"),
            new Attribute("Feathered", "FEATHERED"), new Attribute("Insect", "INSECT"),
            new Attribute("Leathery", "LEATHERY"));

    /**
     * ObservableList of all arm types in the game
     */
    private final ObservableList<Attribute> armTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_arm"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_arm"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_arm"),
            new Attribute("Cat", "CAT_MORPH"), new Attribute("Cow", "COW_MORPH"),
            new Attribute("Demonic", "DEMON_COMMON"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_arm"),
            new Attribute("Dragon winged", "dsg_dragon_armWings"),
            new Attribute("Ferret", "dsg_ferret_arm"), new Attribute("Fox", "FOX_MORPH"),
            new Attribute("Goat", "innoxia_goat_arm"), new Attribute("Gryphon", "dsg_gryphon_arm"),
            new Attribute("Harpy", "HARPY"), new Attribute("Horse", "HORSE_MORPH"),
            new Attribute("Human", "HUMAN"), new Attribute("Hyena", "innoxia_hyena_arm"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_arm"),
            new Attribute("Otter", "dsg_otter_arm"), new Attribute("Panther", "innoxia_panther_arm"),
            new Attribute("Pig", "innoxia_pig_arm"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_raccoon_arm"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_arm"),
            new Attribute("Shark finned", "dsg_shark_armFin"),
            new Attribute("Sheep", "innoxia_sheep_arm"),
            new Attribute("Snake", "NoStepOnSnek_snake_arm"),
            new Attribute("Spider", "charisma_spider_arm"),
            new Attribute("Furred Spider", "charisma_spider_armFluffy"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH"));

    /**
     * ObservableList of all iris shapes in the game
     */
    private final ObservableList<Attribute> irisShapes = FXCollections.observableArrayList(
            new Attribute("Round", "ROUND"), new Attribute("Horizontal", "HORIZONTAL"),
            new Attribute("Vertical", "VERTICAL"), new Attribute("Heart-shaped", "HEART"),
            new Attribute("Star-shaped", "STAR"));

    /**
     * ObservableList of all pupil shapes in the game (same as irisShapes)
     */
    private final ObservableList<Attribute> pupilShapes = irisShapes;

    /**
     * ObservableList of all breast shapes in the game
     */
    private final ObservableList<Attribute> breastShapes = FXCollections.observableArrayList(
            new Attribute("Round", "ROUND"), new Attribute("Pointy", "POINTY"),
            new Attribute("Perky", "PERKY"), new Attribute("Side-set", "SIDE_SET"),
            new Attribute("Wide", "WIDE"), new Attribute("Narrow", "NARROW"));

    /**
     * ObservableList of all areolae shapes in the game
     */
    private final ObservableList<Attribute> areolaeShapes = FXCollections.observableArrayList(
            new Attribute("Normal", "NORMAL"), new Attribute("Heart-shaped", "HEART"),
            new Attribute("Star-shaped", "STAR"));

    /**
     * ObservableList of all nipple shapes in the game
     */
    private final ObservableList<Attribute> nippleShapes = FXCollections.observableArrayList(
            new Attribute("Normal", "NORMAL"), new Attribute("Inverted", "INVERTED"),
            new Attribute("Nipple-cunts", "VAGINA"), new Attribute("Lipples", "LIPS"));

    /**
     * ObservableList of all breastCrotch shapes in the game
     */
    private final ObservableList<Attribute> breastCrotchShapes = FXCollections.observableArrayList(
            new Attribute("Udders", "UDDERS"), new Attribute("Round", "ROUND"),
            new Attribute("Pointy", "POINTY"), new Attribute("Perky", "PERKY"),
            new Attribute("Side-set", "SIDE_SET"), new Attribute("Wide", "WIDE"),
            new Attribute("Narrow", "NARROW"));

    /**
     * ObservableList of all areolaeCrotch shapes in the game (same as areolaeShapes)
     */
    private final ObservableList<Attribute> areolaeCrotchShapes = areolaeShapes;

    /**
     * ObservableList of all nippleCrotch shapes in the game (same as areolaeShapes)
     */
    private final ObservableList<Attribute> nippleCrotchShapes = nippleShapes;

    /**
     * ObservableList of hairstyles for bald hair length
     */
    private final ObservableList<Attribute> hairStylesB = FXCollections.observableArrayList();

    /**
     * ObservableList of hairstyles for very short hair length
     */
    private final ObservableList<Attribute> hairStylesVS = FXCollections.observableArrayList();

    /**
     * ObservableList of hairstyles for short hair length
     */
    private final ObservableList<Attribute> hairStylesS = FXCollections.observableArrayList();

    /**
     * ObservableList of hairstyles for shoulder-length hair length
     */
    private final ObservableList<Attribute> hairStylesSL = FXCollections.observableArrayList();

    /**
     * ObservableList of hairstyles for long+ hair length
     */
    private final ObservableList<Attribute> hairStylesL = FXCollections.observableArrayList();

    /**
     * ObservableList of hairstyles for floor-length hair length (all the hairstyles in the game)
     */
    private final ObservableList<Attribute> hairStylesFL = FXCollections.observableArrayList(
            new Attribute("Natural", "NONE"), new Attribute("Messy", "MESSY"),
            new Attribute("Loose", "LOOSE"), new Attribute("Curly", "CURLY"),
            new Attribute("Straight", "STRAIGHT"), new Attribute("Slicked-back", "SLICKED_BACK"),
            new Attribute("Sidecut", "SIDECUT"), new Attribute("Mohawk", "MOHAWK"),
            new Attribute("Dreadlocks", "DREADLOCKS"), new Attribute("Afro", "AFRO"),
            new Attribute("Topknot", "TOPKNOT"), new Attribute("Pixie-cut", "PIXIE_CUT"),
            new Attribute("Bun", "BUN"), new Attribute("Bob-cut", "BOB_CUT"),
            new Attribute("Chonmage", "CHONMAGE"), new Attribute("Wavy", "WAVY"),
            new Attribute("Ponytail", "PONYTAIL"), new Attribute("Low ponytail", "LOW_PONYTAIL"),
            new Attribute("Twintails", "TWINTAILS"), new Attribute("Chignon", "CHIGNON"),
            new Attribute("Braided", "BRAIDED"), new Attribute("Twin braids", "TWIN_BRAIDS"),
            new Attribute("Crown braid", "CROWN_BRAID"), new Attribute("Drill hair", "DRILL_HAIR"),
            new Attribute("Hime-cut", "HIME_CUT"), new Attribute("Bird cage", "BIRD_CAGE"));

    private final ObservableList<Attribute> bodyMaterials = FXCollections.observableArrayList(
            new Attribute("Flesh", "FLESH"), new Attribute("Slime", "SLIME"),
            new Attribute("Fire", "FIRE"), new Attribute("Water", "WATER"),
            new Attribute("Ice", "ICE"), new Attribute("Storm-clouds", "AIR"),
            new Attribute("Stone", "STONE"), new Attribute("Rubber", "RUBBER"),
            new Attribute("Energy", "ENERGY"));

    private final ObservableList<Attribute> subspeciesOverrides = FXCollections.observableArrayList(); //TODO

    private final ObservableList<Attribute> pubicHairTypes = FXCollections.observableArrayList(); //TODO

    private final ObservableList<Attribute> facialHairTypes = FXCollections.observableArrayList(); //TODO

    private final ObservableList<Attribute> assHairTypes = FXCollections.observableArrayList(); //TODO

    private final ObservableList<Attribute> underarmHairTypes = FXCollections.observableArrayList(); //TODO

    private final ObservableList<Attribute> legConfigurationsMaster = FXCollections.observableArrayList(
            new Attribute("Bipedal", "BIPEDAL"), new Attribute("Quadrupedal", "QUADRUPEDAL"),
            new Attribute("Serpent-tailed", "TAIL_LONG"), new Attribute("Arachnid", "ARACHNID"),
            new Attribute("Cephalopod", "CEPHALOPOD"), new Attribute("Mer-tailed", "TAIL"),
            new Attribute("Avian", "AVIAN"));

    private final ObservableList<Attribute> legConfigurationsBQ = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsB = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsS = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsAr = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsC = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsM = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsAv = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsBQSM = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsBAv = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsBM = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsBS = FXCollections.observableArrayList();

    private final ObservableList<Attribute> legConfigurationsBAr = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresMaster = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Plantigrade", "PLANTIGRADE"),
            new Attribute("Unguligrade", "UNGULIGRADE"), new Attribute("Digitigrade", "DIGITIGRADE"),
            new Attribute("Arachnoid", "ARACHNOID"), new Attribute("Tentacled", "TENTACLED"));

    private final ObservableList<Attribute> footStructuresP = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresU = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresN = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresA = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresT = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresPD = FXCollections.observableArrayList();

    private final ObservableList<Attribute> footStructuresD = FXCollections.observableArrayList();

    private final ObservableList<Attribute> genitalArrangementsNCR = FXCollections.observableArrayList(
            new Attribute("Normal", "NORMAL"), new Attribute("Cloaca", "CLOACA"),
            new Attribute("Rear-facing cloaca", "CLOACA_BEHIND"));

    private final ObservableList<Attribute> genitalArrangementsCR = FXCollections.observableArrayList();

    private final ObservableList<Attribute> genitalArrangementsN = FXCollections.observableArrayList();

    private final ObservableList<Attribute> genitalArrangementsC = FXCollections.observableArrayList();

    private final ObservableList<Attribute> genitalArrangementsR = FXCollections.observableArrayList();

    /**
     * ObservableList of all leg types in the game
     */
    private final ObservableList<Attribute> legTypes = FXCollections.observableArrayList(
            new LegTypeAttr("Placeholder", "Placeholder", legConfigurationsMaster, footStructuresMaster, genitalArrangementsNCR));


    private final ArrayList<PerkNode> perks = new ArrayList<>();

    /**
     * ArrayList to hold all the ObservableList objects to make it easier to add them to their respective ComboBoxes
     */
    private final ArrayList<ObservableList<Attribute>> comboBoxValues = new ArrayList<>();

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
            //Uses working directory as default file path
            prop.setProperty("defaultFilePath", Paths.get(".").toAbsolutePath().normalize().toString());
            prop.store(new FileOutputStream("config.ini"), null);
            in = new FileInputStream("config.ini");
        }
        prop.load(in);
        initializeComboBoxValues();
    }

    /**
     * Adds various ObservableLists to an ArrayList to make it easier to initialize the various ComboBoxes
     */
    private void initializeComboBoxValues(){
        comboBoxValues.add(sexualOrientations);
        comboBoxValues.add(genderIdentities);
        comboBoxValues.add(antennaeTypes);
        comboBoxValues.add(earTypes);
        comboBoxValues.add(faceTypes);
        comboBoxValues.add(eyeTypes);
        comboBoxValues.add(hairTypes);
        comboBoxValues.add(hornTypes);
        comboBoxValues.add(legTypes);
        comboBoxValues.add(assTypes);
        comboBoxValues.add(breastsTypes);
        comboBoxValues.add(milkFlavours);
        comboBoxValues.add(breastCrotchTypes);
        comboBoxValues.add(milkCrotchFlavours);
        comboBoxValues.add(penisTypes);
        comboBoxValues.add(cumFlavours);
        comboBoxValues.add(vaginaTypes);
        comboBoxValues.add(girlcumFlavours);
        comboBoxValues.add(torsoTypes);
        comboBoxValues.add(tailTypes);
        comboBoxValues.add(tentacleTypes);
        comboBoxValues.add(wingTypes);
        comboBoxValues.add(armTypes);
        comboBoxValues.add(irisShapes);
        comboBoxValues.add(pupilShapes);
        comboBoxValues.add(breastShapes);
        comboBoxValues.add(areolaeShapes);
        comboBoxValues.add(nippleShapes);
        comboBoxValues.add(breastCrotchShapes);
        comboBoxValues.add(areolaeCrotchShapes);
        comboBoxValues.add(nippleCrotchShapes);
        comboBoxValues.add(hairStylesFL);
        comboBoxValues.add(bodyMaterials);
        comboBoxValues.add(legConfigurationsMaster);
        comboBoxValues.add(footStructuresMaster);
        comboBoxValues.add(genitalArrangementsNCR);
        initializeHairStyles();
        initializeLegConfigurations();
        initializeFootStructures();
        initializeGenitalArrangements();
        initializeLegTypes();
    }

    /**
     * Initializes all the hairStyle sublists
     */
    private void initializeHairStyles(){
        hairStylesL.addAll(hairStylesFL.subList(0, 25));
        hairStylesSL.addAll(hairStylesFL.subList(0, 19));
        hairStylesS.addAll(hairStylesFL.subList(0, 10));
        hairStylesS.addAll(hairStylesFL.subList(11, 12));
        hairStylesVS.addAll(hairStylesFL.subList(0, 6));
        hairStylesVS.addAll(hairStylesFL.subList(9, 10));
        hairStylesB.addAll(hairStylesFL.subList(0, 1));
    }

    /**
     * Initializes all the legConfiguration sublists
     */
    private void initializeLegConfigurations(){
        legConfigurationsBQ.addAll(legConfigurationsMaster.subList(0, 2));
        legConfigurationsB.add(legConfigurationsMaster.get(0));
        legConfigurationsS.add(legConfigurationsMaster.get(2));
        legConfigurationsAr.add(legConfigurationsMaster.get(3));
        legConfigurationsC.add(legConfigurationsMaster.get(4));
        legConfigurationsM.add(legConfigurationsMaster.get(5));
        legConfigurationsAv.add(legConfigurationsMaster.get(6));
        legConfigurationsBQSM.addAll(legConfigurationsMaster.subList(0, 3));
        legConfigurationsBQSM.add(legConfigurationsMaster.get(5));
        legConfigurationsBAv.add(legConfigurationsMaster.get(0));
        legConfigurationsBAv.add(legConfigurationsMaster.get(6));
        legConfigurationsBM.add(legConfigurationsMaster.get(0));
        legConfigurationsBM.add(legConfigurationsMaster.get(5));
        legConfigurationsBS.add(legConfigurationsMaster.get(0));
        legConfigurationsBS.add(legConfigurationsMaster.get(2));
        legConfigurationsBAr.add(legConfigurationsMaster.get(0));
        legConfigurationsBAr.add(legConfigurationsMaster.get(3));
    }

    /**
     * Initializes all the footStructure sublists
     */
    private void initializeFootStructures(){
        footStructuresP.add(footStructuresMaster.get(1));
        footStructuresU.add(footStructuresMaster.get(2));
        footStructuresN.add(footStructuresMaster.get(0));
        footStructuresA.add(footStructuresMaster.get(4));
        footStructuresT.add(footStructuresMaster.get(5));
        footStructuresPD.add(footStructuresMaster.get(1));
        footStructuresPD.add(footStructuresMaster.get(3));
        footStructuresD.add(footStructuresMaster.get(3));
    }

    /**
     * Initializes all the genitalArrangements sublists
     */
    private void initializeGenitalArrangements(){
        genitalArrangementsCR.addAll(genitalArrangementsNCR.subList(1,3));
        genitalArrangementsN.add(genitalArrangementsNCR.get(0));
        genitalArrangementsC.add(genitalArrangementsNCR.get(1));
        genitalArrangementsR.add(genitalArrangementsNCR.get(2));
    }

    /**
     * Initializes the legType list
     * Has to be done after the above three initializations as the LegTypeAttr class depends
     *   on those lists not being empty
     */
    private void initializeLegTypes(){
        legTypes.remove(0);
        legTypes.addAll(FXCollections.observableArrayList(
                new LegTypeAttr("Alligator", "ALLIGATOR_MORPH", legConfigurationsBQ, footStructuresP, genitalArrangementsNCR),
                new LegTypeAttr("Angel", "ANGEL", legConfigurationsB, footStructuresP, genitalArrangementsNCR),
                new LegTypeAttr("Badger", "innoxia_badger_leg", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Bat", "BAT_MORPH", legConfigurationsB, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Bear", "dsg_bear_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Capybara", "NoStepOnSnek_capybara_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Cat", "CAT_MORPH", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Cow", "COW_MORPH", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Demonic", "DEMON_COMMON", legConfigurationsB, footStructuresP, genitalArrangementsNCR),
                new LegTypeAttr("Demonic-hoofed", "DEMON_HOOFED", legConfigurationsB, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Demonic-horse", "DEMON_HORSE", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Demonic-snake", "DEMON_SNAKE", legConfigurationsS, footStructuresN, genitalArrangementsCR),
                new LegTypeAttr("Demonic-spider", "DEMON_SPIDER", legConfigurationsAr, footStructuresA, genitalArrangementsN),
                new LegTypeAttr("Demonic-octopus", "DEMON_OCTOPUS", legConfigurationsC, footStructuresT, genitalArrangementsC),
                new LegTypeAttr("Demonic-fish", "DEMON_FISH", legConfigurationsM, footStructuresN, genitalArrangementsCR),
                new LegTypeAttr("Demonic-eagle", "DEMON_EAGLE", legConfigurationsAv, footStructuresD, genitalArrangementsR),
                new LegTypeAttr("Dog", "DOG_MORPH", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Dragon", "dsg_dragon_leg", legConfigurationsBQSM, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Ferret", "dsg_ferret_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Fox", "FOX_MORPH", legConfigurationsBQ, legConfigurationsBQ, footStructuresPD, "DIGITIGRADE"),
                new LegTypeAttr("Goat", "innoxia_goat_leg", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Gryphon", "dsg_gryphon_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Harpy", "HARPY", legConfigurationsBAv, footStructuresD, genitalArrangementsNCR),
                new LegTypeAttr("Horse", "HORSE_MORPH", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Human", "HUMAN", legConfigurationsB, footStructuresP, genitalArrangementsNCR),
                new LegTypeAttr("Hyena", "innoxia_hyena_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Octopus", "NoStepOnSnek_octopus_leg", legConfigurationsC, footStructuresT, genitalArrangementsC),
                new LegTypeAttr("Otter", "dsg_otter_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Panther", "innoxia_panther_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE"),
                new LegTypeAttr("Pig", "innoxia_pig_leg", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Rabbit", "RABBIT_MORPH", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Racoon", "dsg_racoon_leg", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Rat", "RAT_MORPH", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Reindeer", "REINDEER_MORPH", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Shark", "dsg_shark_leg", legConfigurationsBM, footStructuresP, genitalArrangementsNCR),
                new LegTypeAttr("Sheep", "innoxia_sheep_leg", legConfigurationsBQ, footStructuresU, genitalArrangementsNCR),
                new LegTypeAttr("Snake", "NoStepOnSnek_snake_leg", legConfigurationsBS, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Furred Spider", "charisma_spider_legFluffy", legConfigurationsBAr, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Spider", "charisma_spider_leg", legConfigurationsBAr, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Squirrel", "SQUIRREL_MORPH", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR),
                new LegTypeAttr("Wolf", "WOLF_MORPH", legConfigurationsBQ, footStructuresPD, genitalArrangementsNCR, "DIGITIGRADE")));
    }

    //TODO
    private void initializePerks(){
       PerkNode p1 = new PerkNode(null, "1", "PHYSICAL_BASE", "Natural Fitness");
       PerkNode p2 = new PerkNode(null, "1", "ARCANE_BASE", "Natural Arcane Power");
       PerkNode p3 = new PerkNode(null, "1", "LEWD_KNOWLEDGE", "Lewd Knowledge");

       PerkNode p4 = new PerkNode(p2, "2", "ARCANE_BOOST", "Arcane Training");
       PerkNode p5 = new PerkNode(p2, "2", "ARCANE_CRITICALS", "Arcane Precision");
       PerkNode p6 = new PerkNode(p1, "2", "OBSERVANT", "Observant");
       PerkNode p7 = new PerkNode(p3, "2", "SEDUCTION_BOOST", "Seductive");
       PerkNode p8 = new PerkNode(p3, "2", "FERTILITY_BOOST", "Fertile");
       PerkNode p9 = new PerkNode(p1, "2", "PHYSIQUE_BOOST", "Physically Fit");
       PerkNode p10 = new PerkNode(p3, "2", "FIRING_BLANKS", "Sterile");
       PerkNode p11 = new PerkNode(p3, "2", "VIRILITY_BOOST", "Virile");
       PerkNode p12 = new PerkNode(p3, "2", "BARREN", "Barren");
       PerkNode p13 = new PerkNode(p1, "2", "ENCHANTMENT_STABILITY", "Stable Enchantments"); //Physical
       PerkNode p14 = new PerkNode(p2, "2", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments"); //Arcane

       PerkNode p15 = new PerkNode(p9, "3", "PHYSICAL_DAMAGE", "Striker");
       PerkNode p16 = new PerkNode(p4, "3", "SPELL_DAMAGE", "Spell Power");
       PerkNode p17 = new PerkNode(p7, "3", "ORGASMIC_LEVEL_DRAIN", "Orgasmic Level Drain");
       PerkNode p18 = new PerkNode(p4, "3", "AURA_BOOST", "Aura Reserves");
       PerkNode p19 = new PerkNode(p11, "3", "VIRILITY_MAJOR_BOOST", "Virile");
       PerkNode p20 = new PerkNode(p7, "3", "SEDUCTION_DEFENCE_BOOST", "Resistance");
       PerkNode p21 = new PerkNode(p4, "3", "SPELL_EFFICIENCY", "Spell Efficiency");
       PerkNode p22 = new PerkNode(p9, "3", "PHYSICAL_DEFENCE", "Defender");
       PerkNode p23 = new PerkNode(p7, "3", "SEDUCTION_BOOST", "Seductive");
       PerkNode p24 = new PerkNode(p9, "3", "ENERGY_BOOST", "Energy Reserves");
       PerkNode p25 = new PerkNode(p8, "3", "FERTILITY_MAJOR_BOOST", "Fertile");
       PerkNode p26 = new PerkNode(p13, "3", "ENCHANTMENT_STABILITY", "Stable Enchantments"); //Physical
       PerkNode p27 = new PerkNode(p14, "3", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments"); //Arcane

       PerkNode p28 = new PerkNode(p15, "4", "PHYSICAL_DAMAGE", "Striker");
       PerkNode p29 = new PerkNode(p22, "4", "PHYSICAL_DEFENCE", "Defender");
       PerkNode p30 = new PerkNode(p16, "4", "SPELL_DAMAGE", "Spell Power");
       PerkNode p31 = new PerkNode(p23, "4", "SEDUCTION_BOOST", "Seductive");
       PerkNode p32 = new PerkNode(p26, "4", "WEAPON_ENCHANTER", "Arcane Smith");
       PerkNode p33 = new PerkNode(p25, "4", "FETISH_BROODMOTHER", "Broodmother");
       PerkNode p34 = new PerkNode(p18, "4", "AURA_BOOST", "Aura Reserves");
       PerkNode p35 = new PerkNode(p24, "4", "ENERGY_BOOST", "Energy Reserves");
       PerkNode p36 = new PerkNode(p27, "4", "CLOTHING_ENCHANTER", "Arcane Weaver");
       PerkNode p37 = new PerkNode(p19, "4", "FETISH_SEEDER", "Seeder");
       PerkNode p38 = new PerkNode(p20, "4", "SEDUCTION_DEFENCE_BOOST", "Resistance");
       PerkNode p39 = new PerkNode(p21, "4", "SPELL_EFFICIENCY", "Spell Efficiency");

       PerkNode p40 = new PerkNode(p34, p39, "5", "ARCANE_COMBATANT", "Arcane Combatant");
       PerkNode p41 = new PerkNode(p33, "5", "FERTILITY_BOOST", "Fertile");
       PerkNode p42 = new PerkNode(p28, "5", "UNARMED_DAMAGE", "Hand-to-Hand");
       PerkNode p51 = new PerkNode(p30, "5", "ELEMENTAL_BOOST", "Elemental Striker");
       PerkNode p46 = new PerkNode(p42, "5", "CRITICAL_BOOST", "Critical Power"); //Physical
       PerkNode p47 = new PerkNode(p31, p38, "5", "CRITICAL_BOOST_ALT", "Critical Power"); //Seductive
       PerkNode p48 = new PerkNode(p51, "5", "CRITICAL_BOOST_ALT_2", "Critical Power"); //Arcane
       PerkNode p44 = new PerkNode(p48, "5", "CHUUNI", "Chuuni");
       PerkNode p45 = new PerkNode(p46, "5", "UNARMED_TRAINING", "Martial Artist");
       PerkNode p49 = new PerkNode(p29, p35, "5", "RUNNER_2", "Cardio King");
       PerkNode p50 = new PerkNode(p37, "5", "VIRILITY_BOOST", "Virile");
       PerkNode p43 = new PerkNode(p50, "5", "VIRILITY_MAJOR_BOOST", "Virile");
       PerkNode p52 = new PerkNode(p41, "5", "FERTILITY_MAJOR_BOOST", "Fertile");

       PerkNode p53 = new PerkNode(p49, p42, "6", "PHYSIQUE_BOOST_MAJOR", "Physically Fit");
       PerkNode p57 = new PerkNode(p47, "6", "SEDUCTION_BOOST_MAJOR", "Seductive");
       PerkNode p54 = new PerkNode(p57, "6", "MALE_ATTRACTION", "Minx");
       PerkNode p55 = new PerkNode(p57, "6", "FEMALE_ATTRACTION", "Ladykiller");
       PerkNode p56 = new PerkNode(p51, p40, "6", "ARCANE_BOOST_MAJOR", "Arcane Affinity");

       PerkNode p59 = new PerkNode(p53, "7", "PHYSICAL_DAMAGE", "Striker");
       PerkNode p61 = new PerkNode(p57, "7", "SEDUCTION_BOOST_ALT", "Seductive"); //Middle Branch
       PerkNode p62 = new PerkNode(p57, "7", "SEDUCTION_BOOST", "Seductive"); //Left Branch
       PerkNode p63 = new PerkNode(p59, "7", "UNARMED_DAMAGE", "Hand-to-Hand");
       PerkNode p64 = new PerkNode(p56, "7", "AURA_BOOST", "Aura Reserves");
       PerkNode p65 = new PerkNode(p53, "7", "ENERGY_BOOST", "Energy Reserves");
       PerkNode p58 = new PerkNode(p65, "7", "ENERGY_BOOST_DRAIN_DAMAGE", "Aura Shielding");
       PerkNode p66 = new PerkNode(p57, "7", "SEDUCTION_DEFENCE_BOOST", "Resistance");
       PerkNode p67 = new PerkNode(p56, "7", "SPELL_EFFICIENCY", "Spell Efficiency");
       PerkNode p60 = new PerkNode(p67, "7", "SPELL_DAMAGE", "Spell Power");

       PerkNode p69 = new PerkNode(p59, "8", "PHYSICAL_DAMAGE", "Striker");
       PerkNode p70 = new PerkNode(p65, "8", "PHYSICAL_DEFENCE", "Defender");
       PerkNode p71 = new PerkNode(p60, "8", "SPELL_DAMAGE", "Spell Power");
       PerkNode p72 = new PerkNode(p62, "8", "SEDUCTION_BOOST", "Seductive");
       PerkNode p74 = new PerkNode(p64, "8", "AURA_BOOST", "Aura Reserves");
       PerkNode p75 = new PerkNode(p65, "8", "ENERGY_BOOST", "Energy Reserves");
       PerkNode p76 = new PerkNode(p69, "8", "MELEE_DAMAGE", "Melee Weapons Expert");
       PerkNode p77 = new PerkNode(p61, "8", "SEDUCTION_BOOST_MAJOR", "Seductive");
       PerkNode p73 = new PerkNode(p77, "8", "CONVINCING_REQUESTS", "Irresistible Appeals");
       PerkNode p68 = new PerkNode(p77, "8", "OBJECT_OF_DESIRE", "Object of Desire");
       PerkNode p78 = new PerkNode(p66, "8", "SEDUCTION_DEFENCE_BOOST", "Resistance");
       PerkNode p79 = new PerkNode(p67, "8", "SPELL_EFFICIENCY", "Spell Efficiency");

       PerkNode p80 = new PerkNode(p69, "9", "PHYSICAL_DAMAGE", "Striker");
       PerkNode p81 = new PerkNode(p70, "9", "PHYSICAL_DEFENCE", "Defender");
       PerkNode p82 = new PerkNode(p77, "9", "SEDUCTION_BOOST_ALT", "Seductive"); //Middle Branch
       PerkNode p83 = new PerkNode(p72, "9", "SEDUCTION_BOOST", "Seductive"); //Left Branch
       PerkNode p85 = new PerkNode(p75, "9", "ENERGY_BOOST", "Energy Reserves");
       PerkNode p86 = new PerkNode(p80, "9", "RANGED_DAMAGE", "Sharp-shooter");
       PerkNode p87 = new PerkNode(p71, "9", "SPELL_DAMAGE_MAJOR", "Spell Mastery");
       PerkNode p88 = new PerkNode(p78, "9", "SEDUCTION_DEFENCE_BOOST", "Resistance");
       PerkNode p89 = new PerkNode(p79, "9", "SPELL_EFFICIENCY", "Spell Efficiency");
       PerkNode p84 = new PerkNode(p89, "9", "AURA_BOOST", "Aura Reserves");

       PerkNode p90 = new PerkNode(p82, "10", "NYMPHOMANIAC", "Nymphomaniac");
       PerkNode p91 = new PerkNode(p84, "10", "SACRIFICIAL_SHIELDING", "Sacrificial Shielding");
       PerkNode p92 = new PerkNode(p81, p85, "10", "COMBAT_REGENERATION", "Combat Regeneration");
       PerkNode p93 = new PerkNode(p80, "10", "FEROCIOUS_WARRIOR", "Ferocious Warrior");
       PerkNode p94 = new PerkNode(p88, "10", "PURE_MIND", "Pure Thoughts");
       PerkNode p95 = new PerkNode(p83, "10", "LUSTPYRE", "Lustpyre");
       PerkNode p96 = new PerkNode(p93, "10", "BESERK", "Berserk");
       PerkNode p97 = new PerkNode(p89, "10", "SPELL_EFFICIENCY", "Spell Efficiency");
       PerkNode p98 = new PerkNode(p87, "10", "ARCANE_VAMPYRISM", "Arcane Vampyrism");

       PerkNode p99 = new PerkNode(p93, p92, "11", "PHYSIQUE_BOOST_MAJOR", "Physically Fit");
       PerkNode p101 = new PerkNode(p97, "11", "ARCANE_BOOST_MAJOR", "Arcane Affinity");
       PerkNode p100 = new PerkNode(p101, "11", "ELEMENTAL_DEFENCE_BOOST", "Elemental Defender");
       PerkNode p102 = new PerkNode(p99, "11", "MELEE_DAMAGE", "Melee Weapons Expert");
       PerkNode p103 = new PerkNode(p95, p94, "11", "SEDUCTION_BOOST_MAJOR", "Seductive");
       PerkNode p104 = new PerkNode(p99, "11", "RANGED_DAMAGE", "Sharp-shooter");
       PerkNode p105 = new PerkNode(p101, "11", "ELEMENTAL_BOOST", "Elemental Striker");

       PerkNode p106 = new PerkNode(p99, "12", "ELEMENTAL_BOOST", "Elemental Striker"); //Physical
       PerkNode p107 = new PerkNode(p103, "12", "ELEMENTAL_BOOST_ALT", "Elemental Striker"); //Seductive
       PerkNode p108 = new PerkNode(p101, "12", "ELEMENTAL_BOOST_ALT_2", "Elemental Striker"); //Arcane
    } //This is suffering
    //I'm probably dumb and there was an easier way to do this

    /**
     * Class that detects focus loss for TextFields
     */
    public class TextObjectListener implements ChangeListener<Boolean> {

        /**
         * TextInputControl descendant to monitor
         */
        private final TextInputControl textInputControl;

        /**
         * Data type of the TextField (e.g. int, double, string, etc.)
         */
        private final TextFieldType tfType;

        /**
         * Constructor for a new TextFieldListener
         * @param textControl
         *   TextInputControl descendant to monitor
         * @param textFieldType
         *   Data type of the TextField
         */
        public TextObjectListener(TextInputControl textControl, TextFieldType textFieldType) {
            textInputControl = textControl;
            tfType = textFieldType;
        }

        /**
         * Detects when the TextField has lost focus
         * @param observable
         *   (Taken from StackOverflow, so I'm not too sure what each parameter is for lol)
         * @param oldValue
         *   (Same)
         * @param newValue
         *   (Same)
         */
        @Override
        public void changed(ObservableValue<? extends Boolean> observable, Boolean oldValue, Boolean newValue) {
            if(!newValue) {  // check if focus gained or lost
                textInputControl.setText(getFormattedText(textInputControl.getText()));
            }
        }

        /**
         * Verifies that the text is being changed appropriately based on the data type expected in the TextField and
         * modifies the xml data if a valid String was entered
         * @param newValue
         *   String entered into the TextField
         * @return
         *   Either the new String (with minor modifications if needed) or a String of the old value
         */
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
                    value.setTextContent(newValue);
                    return newValue;
                case HAIR:
                    try {
                        int nv = Integer.parseInt(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(nv < 0){
                            return oldValue;
                        }
                        value.setTextContent(newValue);
                        @SuppressWarnings("unchecked")
                        ComboBox<Attribute> hairStyles = (ComboBox<Attribute>) root.lookup("#body$hair$hairStyle");
                        Attribute attr;
                        if(nv < 4){
                            attr = hairStylesB.get(0);
                            hairStyles.setItems(hairStylesB);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 11){
                            attr = hairStyles.getValue();
                            if(!hairStylesVS.contains(attr)){
                                attr = hairStylesVS.get(0);
                            }
                            hairStyles.setItems(hairStylesVS);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 22){
                            attr = hairStyles.getValue();
                            if(!hairStylesS.contains(attr)){
                                attr = hairStylesS.get(0);
                            }
                            hairStyles.setItems(hairStylesS);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 45){
                            attr = hairStyles.getValue();
                            if(!hairStylesSL.contains(attr)){
                                attr = hairStylesSL.get(0);
                            }
                            hairStyles.setItems(hairStylesSL);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 265){
                            attr = hairStyles.getValue();
                            if(!hairStylesL.contains(attr)){
                                attr = hairStylesL.get(0);
                            }
                            hairStyles.setItems(hairStylesL);
                            hairStyles.setValue(attr);
                        }
                        else{
                            hairStyles.setItems(hairStylesFL);
                        }
                        return newValue;
                    }
                    catch (NumberFormatException e) {
                        return oldValue;
                    }
                default:
                    return null;
            }
        }

        /**
         * Gets the Node of the attribute value of the TextField
         * @return
         *   Node containing the attribute value
         */
        private Node getValueNode(){
            String[] id = textInputControl.getId().split("\\$");
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
     * Initializes all the ComboBoxes by setting the items (i.e. ObservableList<\String> objects) of each ComboBox
     */
    public void initializeComboBoxes(){
        for(int i = 0; i < ComboBoxIds.length; i++) {
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) root.lookup(ComboBoxIds[i]);
            cb.setItems(comboBoxValues.get(i));
            cb.setValue(cb.getItems().get(0));
            cb.setConverter(new StringConverter<>() {
                @Override
                public String toString(Attribute attribute) {
                    return attribute.getName();
                } //TODO: Fix this method throwing exceptions whenever hairStyles ComboBox values are updated

                @Override
                public Attribute fromString(String s) {
                    return null;
                }
            });
        }
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> cb = (ComboBox<Attribute>) root.lookup("#body$leg$type");
        updateLegTypeDependants(cb, true);
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
                TabPane tb = (TabPane) root.lookup("#tabPane");
                tb.setDisable(false);
            }
            catch(ParserConfigurationException | SAXException e){
                e.printStackTrace();
            }
            loadCharacterSelector();
        }
    }

    /**
     * Parses the xml file for NPCs and adds them to the character selector ComboBox along with the Player Character
     */
    public void loadCharacterSelector(){
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> characterSelector = (ComboBox<NpcCharacter>) root.lookup("#characterSelector");
        NpcCharacter player = new NpcCharacter("PlayerCharacter");
        ObservableList<NpcCharacter> characterList = FXCollections.observableArrayList(player);
        NodeList npcList = saveFile.getElementsByTagName("NPC");
        for(int i = 0; i < npcList.getLength(); i++){
            characterList.add(new NpcCharacter(npcList.item(i)));
        }
        characterSelector.setItems(characterList);
        characterSelector.setValue(player);
        charId = "PlayerCharacter";
        characterSelector.setConverter(new StringConverter<>() {
            @Override
            public String toString(NpcCharacter npcCharacter) {
                return npcCharacter.getName();
            }

            @Override
            public NpcCharacter fromString(String s) {
                return null;
            }
        });
        setFields();
    }

    /**
     * Changes the current character to be edited to the character selected by the character selector
     * @param event
     *   ActionEvent from the character selector ComboBox
     */
    @FXML
    private void selectCharacter(ActionEvent event){
        event.consume();
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> cb = (ComboBox<NpcCharacter>) root.lookup("#characterSelector");
        charId = cb.getValue().getId(); //Placeholder; will change to take input from a combobox to select character
        Button btn = (Button) root.lookup("#deleteCharacter");
        btn.setVisible(!charId.equals("PlayerCharacter") && !charId.startsWith("-1"));
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

    /**
     * Gets the Node of the attribute by reverse tracing the id (Id Format: #parent$child$attribute)
     * @param event
     *   ActionEvent of the element that was interacted with
     * @return
     *   Node containing the attribute value
     */
    private Node getValueNode(ActionEvent event){
        String[] id = getId(event).split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return attr.getAttributes().getNamedItem(id[id.length-1]);
    }

    private Node getValueNode(String objId){
        String[] id = objId.split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return attr.getAttributes().getNamedItem(id[id.length-1]);
    }

    private Node getValueNode(Node node){
        return node.getAttributes().getNamedItem("value");
    }

    private Node getValueNodeParent(ActionEvent event){
        String[] id = getId(event).split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return attr;
    }

    private Node getValueNodeParent(String objId){
        String[] id = objId.split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return attr;
    }

    private Node getChildNode(Node node, String targetNode){
        NodeList children = node.getChildNodes();
        for(int i = 0; i < children.getLength(); i++){
            if(children.item(i).getNodeName().equals(targetNode)){
                return children.item(i);
            }
        }
        System.out.println("No Match (null node): " + node + " " + targetNode); //Debugging
        return null;
    }

    /**
     * Updates xml boolean values changed by CheckBoxes
     * @param event
     *   ActionEvent from the CheckBox that was changed
     */
    @FXML
    private void updateXmlBoolean(ActionEvent event){
        String fxId = "#" + getId(event);
        CheckBox cb = (CheckBox) root.lookup(fxId);
        Node value = getValueNode(event);
        try {
            value.setTextContent("" + cb.isSelected());
        }
        catch(NullPointerException e){
            value = getValueNodeParent(event);
            ((Element) value).setAttribute(fxId.split("\\$")[3], "" + cb.isSelected());
        }
        String[] idParts = fxId.split("\\$");
        if(idParts[idParts.length - 1].equals("FLARED") || idParts[idParts.length - 1].equals("TAPERED")){
            checkboxFlaredTaperedToggle(fxId);
        }
        event.consume();
    }


    private void checkboxFlaredTaperedToggle(String id){
        boolean flared = id.split("\\$")[3].equals("FLARED");
        String targetId;
        CheckBox target;
        if(flared){
            targetId = id.replace("FLARED", "TAPERED");
        }
        else{
            targetId = id.replace("TAPERED", "FLARED");
        }
        target = (CheckBox) root.lookup(targetId);
        target.setSelected(false);
        Node value = getValueNode(targetId.replace("#", ""));
        try {
            value.setTextContent("" + target.isSelected());
        }
        catch(NullPointerException e){
            value = getValueNodeParent(id.replace("#", ""));
            ((Element) value).setAttribute(id.split("\\$")[3], "" + target.isSelected());
        }

    }

    /**
     * Updates xml values changed by ComboBoxes
     * @param event
     *   ActionEvent from the ComboBox that was changed
     */
    @FXML
    private void updateXmlComboBox(ActionEvent event){
        String fxId = "#" + getId(event);
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> cb = (ComboBox<Attribute>) root.lookup(fxId);
        Node value = getValueNode(event);
        value.setTextContent(cb.getValue().getValue());
        if(fxId.equals("#body$leg$type")){
            updateLegTypeDependants(cb, false);
        }
        event.consume();
    }

    private void updateLegTypeDependants(ComboBox<Attribute> cb, boolean initializing){
        LegTypeAttr legType = (LegTypeAttr) cb.getValue();
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> lc = (ComboBox<Attribute>) root.lookup("#body$leg$configuration");
        lc.setItems(legType.getLegConfiguration());
        lc.setValue(legType.getDefaultLegConfiguration());
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> fs = (ComboBox<Attribute>) root.lookup("#body$leg$footStructure");
        fs.setItems(legType.getFootStructure());
        fs.setValue(legType.getDefaultFootStructure());
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> ga = (ComboBox<Attribute>) root.lookup("#body$bodyCore$genitalArrangement");
        ga.setItems(legType.getGenitalArrangement());
        ga.setValue(legType.getDefaultGenitalArrangement());
        if(!initializing){
            Node lcValue = getValueNode(lc.getId());
            lcValue.setTextContent(lc.getValue().getValue());
            Node fsValue = getValueNode(fs.getId());
            fsValue.setTextContent(fs.getValue().getValue());
            Node gaValue = getValueNode(ga.getId());
            gaValue.setTextContent(ga.getValue().getValue());
        }
    }

    /**
     * Reads data from xml save file and sSets all fields with the selected character data
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
                        NodeList childNodes = currNode.getChildNodes();
                        if(childNodes.getLength() != 0){
                            for(int k = 0; k < childNodes.getLength(); k++){
                                Node modifiers = childNodes.item(k);
                                if(modifiers.getNodeType() == Node.TEXT_NODE) {
                                    continue;
                                }
                                String modifierName = modifiers.getNodeName();
                                if(modifierName.contains("Modifiers")){
                                    NamedNodeMap mods = modifiers.getAttributes();
                                    for(int l = 0; l < mods.getLength(); l++){
                                        Node mod = mods.item(l);
                                        String value = mod.getTextContent();
                                        String modId = "#" + attributeName + "$" + elementName + "$" + modifierName + "$" + mod.getNodeName();
                                        CheckBox cb = (CheckBox) root.lookup(modId);
                                        if (cb != null) {
                                            cb.setSelected(Boolean.parseBoolean(value));
                                        }
                                    }
                                }
                            }
                        }
                        for(int k = 0; k < attributes.getLength(); k++){
                            Node valueNode = attributes.item(k);
                            String value = valueNode.getTextContent();
                            String bodyNodeName = valueNode.getNodeName();
                            String nodeId = "#" + attributeName + "$" + elementName + "$" + bodyNodeName;
                            if(nodeId.equals("#core$description$value")){
                                TextArea ta = (TextArea) root.lookup(nodeId);
                                ta.setText(value);
                                continue;
                            }
                            //TODO: Instead of using nested try-catch, parse the value's data type and assign the value to the correct container
                            try { //Using TextFields for numerical and string values
                                TextField tf = (TextField) root.lookup(nodeId);
                                if (tf != null) {
                                    tf.setText(value);
                                    if(nodeId.equals("#body$hair$length")){
                                        int v = Integer.parseInt(value);
                                        @SuppressWarnings("unchecked")
                                        ComboBox<Attribute> hairStyles = (ComboBox<Attribute>) root.lookup("#body$hair$hairStyle");
                                        Attribute attr = hairStyles.getValue();
                                        if(v >= 0 && v < 4){
                                            hairStyles.setItems(hairStylesB);
                                        }
                                        else if(v < 11){
                                            hairStyles.setItems(hairStylesVS);
                                        }
                                        else if(v < 22){
                                            hairStyles.setItems(hairStylesS);
                                        }
                                        else if(v < 45){
                                            hairStyles.setItems(hairStylesSL);
                                        }
                                        else if(v < 265){
                                            hairStyles.setItems(hairStylesL);
                                        }
                                        else{
                                            hairStyles.setItems(hairStylesFL);
                                        }
                                    }
                                }
                            }
                            catch(ClassCastException e){ //Using CheckBox for boolean values
                                try {
                                    CheckBox cb = (CheckBox) root.lookup(nodeId);
                                    if (cb != null) {
                                        cb.setSelected(Boolean.parseBoolean(value));
                                    }
                                }
                                catch(ClassCastException e2){ //Using ComboBoxes for fixed values
                                    @SuppressWarnings("unchecked")
                                    ComboBox<Attribute> cb = (ComboBox<Attribute>) root.lookup(nodeId);
                                    if (cb != null){
                                        ObservableList<Attribute> itemList = cb.getItems();
                                        cb.setValue(matchComboBoxItem(itemList, value));
                                    }
                                }
                            }
                        }
                    }
                if(attributeName.equals("body")){ //Ends the loop early as all the needed data has been parsed
                    break;
                }
                }
            }
            addListeners();
        }
    }

    private void setFieldsRec(){
        //TODO: Recursive setFields method
    }

    private Attribute matchComboBoxItem(ObservableList<Attribute> list, String value){
        for (Attribute attribute : list) {
            if (attribute.equals(value)) {
                return attribute;
            }
        }
        return null;
    }

    /**
     * Method to attach listeners to TextFields to properly detect and record changes to the xml data
     */
    private void addListeners(){
        TextArea ta = (TextArea) root.lookup("#core$description$value");
        ta.focusedProperty().addListener(new TextObjectListener(ta, TextFieldType.STRING));
        TextField hairStyles = (TextField) root.lookup("#body$hair$length");
        hairStyles.focusedProperty().addListener(new TextObjectListener(hairStyles, TextFieldType.HAIR));
        for(String intTextFieldId : intTextFieldIds) {
            TextField tf = (TextField) root.lookup(intTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.INT));
        }
        for(String doubleTextFieldId : doubleTextFieldIds){
            TextField tf = (TextField) root.lookup(doubleTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.DOUBLE));
        }
        for(String stringTextFieldId: stringTextFieldIds){
            TextField tf = (TextField) root.lookup(stringTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.STRING));
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

    private void removeNode(Node node){
        node.getParentNode().removeChild(node);
    }

    /**
     *
     */
    @FXML
    private void deleteCharacter(){
        Node idNode = getElementByIdValue(charId);
        assert idNode != null;
        Node characterNode = idNode.getParentNode().getParentNode().getParentNode(); //idNode > coreNode > characterNode > npcNode
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> charSelect = (ComboBox<NpcCharacter>) root.lookup("#characterSelector");
        ObservableList<NpcCharacter> charList = charSelect.getItems();
        NpcCharacter deletedChar = charSelect.getValue();
        NpcCharacter prevChar = charList.get(charList.indexOf(deletedChar) - 1);
        charSelect.setValue(prevChar);
        charList.remove(deletedChar);
        removeNode(characterNode);
    }

    @FXML
    private void deleteOffsprings(){
        NodeList npcList = saveFile.getElementsByTagName("NPC");
        ArrayList<String> offspringList = new ArrayList<>();
        for(int i = 0; i < npcList.getLength(); i++){
            Node character = getChildNode(npcList.item(i), "character");
            assert character != null;
            Node core = getChildNode(character, "core");
            assert core != null;
            Node pathname = getChildNode(core, "pathName");
            assert pathname != null;
            Node locationInfo = getChildNode(character, "locationInformation");
            assert locationInfo != null;
            Node worldLoc = getChildNode(locationInfo, "worldLocation");
            if(getValueNode(pathname).getTextContent().equals("com.lilithsthrone.game.character.npc.misc.NPCOffspring")) {
                assert worldLoc != null;
                if (getValueNode(worldLoc).getTextContent().equals("EMPTY")) {
                    Node id = getChildNode(core, "id");
                    assert id != null;
                    offspringList.add(getValueNode(id).getTextContent());
                }
            }
        }
        for (String s : offspringList) {
            Node npc = Objects.requireNonNull(getElementByIdValue(s)).getParentNode().getParentNode().getParentNode();
            removeNode(npc);
        }
    }

    /**
     * Overwrites the file that was used to load in the xml data
     * @param event
     *   ActionEvent triggering the save call
     */
    @FXML
    private void saveFileOverwrite(ActionEvent event){
        event.consume();
        if(fileLoaded) {
            saveToFile(workingFile);
        }
    }

    /**
     * Writes xml data to a new file
     * @param event
     *   ActionEvent triggering the save call
     */
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

    /**
     * Saves xml data to the given file
     * @param f
     *   File to save the xml data to
     */
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