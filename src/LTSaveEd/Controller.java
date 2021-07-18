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
            "#body$nipplesCrotch$areolaeShape", "#body$nipplesCrotch$nippleShape", "#body$hair$hairStyle"};

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
     * ObservableList of all leg types in the game
     */
    private final ObservableList<Attribute> legTypes = FXCollections.observableArrayList(
            new Attribute("Alligator", "ALLIGATOR_MORPH"), new Attribute("Angel", "ANGEL"),
            new Attribute("Badger", "innoxia_badger_leg"), new Attribute("Bat", "BAT_MORPH"),
            new Attribute("Bear", "dsg_bear_leg"),
            new Attribute("Capybara", "NoStepOnSnek_capybara_leg"), new Attribute("Cat", "CAT_MORPH"),
            new Attribute("Cow", "COW_MORPH"), new Attribute("Demonic", "DEMON_COMMON"),
            new Attribute("Demonic-hoofed", "DEMON_HOOFED"),
            new Attribute("Demonic-horse", "DEMON_HORSE"),
            new Attribute("Demonic-snake", "DEMON_SNAKE"),
            new Attribute("Demonic-spider", "DEMON_SPIDER"),
            new Attribute("Demonic-octopus", "DEMON_OCTOPUS"),
            new Attribute("Demonic-fish", "DEMON_FISH"),
            new Attribute("Demonic-eagle", "DEMON_EAGLE"), new Attribute("Dog", "DOG_MORPH"),
            new Attribute("Dragon", "dsg_dragon_leg"), new Attribute("Ferret", "dsg_ferret_leg"),
            new Attribute("Fox", "FOX_MORPH"), new Attribute("Goat", "innoxia_goat_leg"),
            new Attribute("Gryphon", "dsg_gryphon_leg"), new Attribute("Harpy", "HARPY"),
            new Attribute("Horse", "HORSE_MORPH"), new Attribute("Human", "HUMAN"),
            new Attribute("Hyena", "innoxia_hyena_leg"),
            new Attribute("Octopus", "NoStepOnSnek_octopus_leg"),
            new Attribute("Otter", "dsg_otter_leg"), new Attribute("Panther", "innoxia_panther_leg"),
            new Attribute("Pig", "innoxia_pig_leg"), new Attribute("Rabbit", "RABBIT_MORPH"),
            new Attribute("Racoon", "dsg_racoon_leg"), new Attribute("Rat", "RAT_MORPH"),
            new Attribute("Reindeer", "REINDEER_MORPH"), new Attribute("Shark", "dsg_shark_leg"),
            new Attribute("Sheep", "innoxia_sheep_leg"),
            new Attribute("Snake", "NoStepOnSnek_snake_leg"),
            new Attribute("Furred Spider", "charisma_spider_legFluffy"),
            new Attribute("Spider", "charisma_spider_leg"),
            new Attribute("Squirrel", "SQUIRREL_MORPH"), new Attribute("Wolf", "WOLF_MORPH")); //TODO: Add Foot Structure, Leg Configuration, and Genital Arrangement Dependence

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

    private final ObservableList<Attribute> legConfigurations = FXCollections.observableArrayList(); //TODO

    private final ObservableList<Attribute> footStructures = FXCollections.observableArrayList(); //TODO

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
        initializeHairStyles();
    }

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
                            hairStyles.setValue(attr);
                            hairStyles.setItems(hairStylesB);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 11){
                            attr = hairStyles.getValue();
                            if(!hairStylesVS.contains(attr)){
                                attr = hairStylesVS.get(0);
                            }
                            hairStyles.setValue(attr);
                            hairStyles.setItems(hairStylesVS);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 22){
                            attr = hairStyles.getValue();
                            if(!hairStylesS.contains(attr)){
                                attr = hairStylesS.get(0);
                            }
                            hairStyles.setValue(attr);
                            hairStyles.setItems(hairStylesS);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 45){
                            attr = hairStyles.getValue();
                            if(!hairStylesSL.contains(attr)){
                                attr = hairStylesSL.get(0);
                            }
                            hairStyles.setValue(attr);
                            hairStyles.setItems(hairStylesSL);
                            hairStyles.setValue(attr);
                        }
                        else if(nv < 265){
                            attr = hairStyles.getValue();
                            if(!hairStylesL.contains(attr)){
                                attr = hairStylesL.get(0);
                            }
                            hairStyles.setValue(attr);
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

        private boolean objectInList(Attribute attr, ObservableList<Attribute> list){
            for (Attribute attribute : list) {
                if (attribute.equals(attr)) {
                    return true;
                }
            }
            return false;
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
        //TODO:
        for(int i = 0; i < ComboBoxIds.length; i++) {
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) root.lookup(ComboBoxIds[i]);
            cb.setItems(comboBoxValues.get(i));
            cb.setValue(cb.getItems().get(0));
            cb.setConverter(new StringConverter<>() {
                @Override
                public String toString(Attribute attribute) {
                    return attribute.getName(); //TODO: Fix this method throwing exceptions whenever hairStyles ComboBox values are updated
                }

                @Override
                public Attribute fromString(String s) {
                    return null;
                }
            });
        }
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
        value.setTextContent("" + cb.isSelected());
        event.consume();
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
        event.consume();
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
                            try { //Using TextFields for numerical and string values
                                TextField tf = (TextField) root.lookup(nodeId);
                                if (tf != null) {
                                    tf.setText(value);
                                    if(nodeId.equals("#body$hair$length")){
                                        int v = Integer.parseInt(value);
                                        @SuppressWarnings("unchecked")
                                        ComboBox<Attribute> hairStyles = (ComboBox<Attribute>) root.lookup("#body$hair$hairStyle");
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
                }
            }
            addListeners();
        }
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
