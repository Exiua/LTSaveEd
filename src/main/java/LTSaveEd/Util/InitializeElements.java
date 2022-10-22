package LTSaveEd.Util;

import LTSaveEd.Objects.*;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

public class InitializeElements {

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
            new Attribute("Fox", "FOX_MORPH"), new Attribute("Goat", "innoxia_goat_ass"),
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

    /**
     * ObservableList of all body materials in the game
     */
    private final ObservableList<Attribute> bodyMaterials = FXCollections.observableArrayList(
            new Attribute("Flesh", "FLESH"), new Attribute("Slime", "SLIME"),
            new Attribute("Fire", "FIRE"), new Attribute("Water", "WATER"),
            new Attribute("Ice", "ICE"), new Attribute("Storm-clouds", "AIR"),
            new Attribute("Stone", "STONE"), new Attribute("Rubber", "RUBBER"),
            new Attribute("Energy", "ENERGY"));

    /**
     * ObservableList of all subspecies overrides in the game
     */
    private final ObservableList<Attribute> subspeciesOverrides = FXCollections.observableArrayList(
            new Attribute("Human", "HUMAN"), new Attribute("Angel", "ANGEL"),
            new Attribute("Elder Lilin", "ELDER_LILIN"), new Attribute("Lilin", "LILIN"),
            new Attribute("Demon", "DEMON"), new Attribute("Half Demon", "HALF_DEMON"),
            new Attribute("Imp", "IMP"), new Attribute("Imp Alpha", "IMP_ALPHA"),
            new Attribute("Cow Morph", "COW_MORPH"), new Attribute("Dog Morph", "DOG_MORPH"),
            new Attribute("Dog Morph Border Collie", "DOG_MORPH_BORDER_COLLIE"),
            new Attribute("Dog Morph Dobermann", "DOG_MORPH_DOBERMANN"),
            new Attribute("Dog Morph German Shepherd", "DOG_MORPH_GERMAN_SHEPHERD"),
            new Attribute("Wolf Morph", "WOLF_MORPH"), new Attribute("Fox Morph", "FOX_MORPH"),
            new Attribute("Fox Morph Arctic", "FOX_MORPH_ARCTIC"),
            new Attribute("Fox Morph Fennec", "FOX_MORPH_FENNEC"),
            new Attribute("Fox Ascendant", "FOX_ASCENDANT"),
            new Attribute("Fox Ascendant Arctic", "FOX_ASCENDANT_ARCTIC"),
            new Attribute("Fox Ascendant Fennec", "FOX_ASCENDANT_FENNEC"),
            new Attribute("Cat Morph", "CAT_MORPH"),
            new Attribute("Cat Morph Lynx", "CAT_MORPH_LYNX"),
            new Attribute("Cat Morph Cheetah", "CAT_MORPH_CHEETAH"),
            new Attribute("Cat Morph Caracal", "CAT_MORPH_CARACAL"),
            new Attribute("Cat Morph Leopard Snow", "CAT_MORPH_LEOPARD_SNOW"),
            new Attribute("Cat Morph Leopard", "CAT_MORPH_LEOPARD"),
            new Attribute("Cat Morph Lion", "CAT_MORPH_LION"),
            new Attribute("Cat Morph Tiger", "CAT_MORPH_TIGER"),
            new Attribute("Horse Morph", "HORSE_MORPH"),
            new Attribute("Horse Morph Unicorn", "HORSE_MORPH_UNICORN"),
            new Attribute("Horse Morph Pegasus", "HORSE_MORPH_PEGASUS"),
            new Attribute("Horse Morph Alicorn", "HORSE_MORPH_ALICORN"),
            new Attribute("Centaur", "CENTAUR"), new Attribute("Pegataur", "PEGATAUR"),
            new Attribute("Unitaur", "UNITAUR"), new Attribute("Alitaur", "ALITAUR"),
            new Attribute("Horse Morph Zebra", "HORSE_MORPH_ZEBRA"),
            new Attribute("Reindeer Morph", "REINDEER_MORPH"),
            new Attribute("Alligator Morph", "ALLIGATOR_MORPH"), new Attribute("Slime", "SLIME"),
            new Attribute("Squirrel Morph", "SQUIRREL_MORPH"),
            new Attribute("Rat Morph", "RAT_MORPH"), new Attribute("Rabbit Morph", "RABBIT_MORPH"),
            new Attribute("Rabbit Morph Lop", "RABBIT_MORPH_LOP"),
            new Attribute("Bat Morph", "BAT_MORPH"), new Attribute("Harpy", "HARPY"),
            new Attribute("Harpy Raven", "HARPY_RAVEN"),
            new Attribute("Harpy Bald Eagle", "HARPY_BALD_EAGLE"),
            new Attribute("Harpy Phoenix", "HARPY_PHOENIX"),
            new Attribute("Elemental Fire", "ELEMENTAL_FIRE"),
            new Attribute("Elemental Earth", "ELEMENTAL_EARTH"),
            new Attribute("Elemental Water", "ELEMENTAL_WATER"),
            new Attribute("Elemental Air", "ELEMENTAL_AIR"),
            new Attribute("Elemental Arcane", "ELEMENTAL_ARCANE")); //TODO Check if these are all subspecies in the game

    /**
     * ObservableList of all body hairstyles in the game
     */
    private final ObservableList<Attribute> pubicHairTypes = FXCollections.observableArrayList(
            new Attribute("None", "ZERO_NONE"), new Attribute("Stubble", "ONE_STUBBLE"),
            new Attribute("Manicured", "TWO_MANICURED"), new Attribute("Trimmed", "THREE_TRIMMED"),
            new Attribute("Natural", "FOUR_NATURAL"), new Attribute("Unkempt", "FIVE_UNKEMPT"),
            new Attribute("Bushy", "SIX_BUSHY"), new Attribute("Wild", "SEVEN_WILD"));

    /**
     * ObservableList of all body hairstyles in the game (same as pubicHairTypes)
     */
    private final ObservableList<Attribute> facialHairTypes = pubicHairTypes;

    /**
     * ObservableList of all body hairstyles in the game (same as pubicHairTypes)
     */
    private final ObservableList<Attribute> assHairTypes = pubicHairTypes;

    /**
     * ObservableList of all body hairstyles in the game (same as pubicHairTypes)
     */
    private final ObservableList<Attribute> underarmHairTypes = pubicHairTypes;

    /**
     * ObservableList of all leg configurations in the game
     */
    private final ObservableList<Attribute> legConfigurationsMaster = FXCollections.observableArrayList(
            new Attribute("Bipedal", "BIPEDAL"), new Attribute("Quadrupedal", "QUADRUPEDAL"),
            new Attribute("Serpent-tailed", "TAIL_LONG"), new Attribute("Arachnid", "ARACHNID"),
            new Attribute("Cephalopod", "CEPHALOPOD"), new Attribute("Mer-tailed", "TAIL"),
            new Attribute("Avian", "AVIAN"));

    /**
     * ObservableList of bipedal and quadrupedal leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsBQ = FXCollections.observableArrayList();

    /**
     * ObservableList of bipedal leg configuration
     */
    private final ObservableList<Attribute> legConfigurationsB = FXCollections.observableArrayList();

    /**
     * ObservableList of serpent-tailed leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsS = FXCollections.observableArrayList();

    /**
     * ObservableList of arachnid leg configuration
     */
    private final ObservableList<Attribute> legConfigurationsAr = FXCollections.observableArrayList();

    /**
     * ObservableList of cephalopod leg configuration
     */
    private final ObservableList<Attribute> legConfigurationsC = FXCollections.observableArrayList();

    /**
     * ObservableList of mer-tailed leg configuration
     */
    private final ObservableList<Attribute> legConfigurationsM = FXCollections.observableArrayList();

    /**
     * ObservableList of avian leg configuration
     */
    private final ObservableList<Attribute> legConfigurationsAv = FXCollections.observableArrayList();

    /**
     * ObservableList of bipedal, quadrupedal, serpent-tailed, and mer-tailed leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsBQSM = FXCollections.observableArrayList();

    /**
     * ObservableList of bipedal and avian leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsBAv = FXCollections.observableArrayList();

    /**
     * ObservableList of bipedal and mer-tailed leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsBM = FXCollections.observableArrayList();

    /**
     * ObservableList of bipedal and serpent-tailed leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsBS = FXCollections.observableArrayList();

    /**
     * ObservableList of bipedal and arachnid leg configurations
     */
    private final ObservableList<Attribute> legConfigurationsBAr = FXCollections.observableArrayList();

    /**
     * ObservableList of all foot structures in the game
     */
    private final ObservableList<Attribute> footStructuresMaster = FXCollections.observableArrayList(
            new Attribute("None", "NONE"), new Attribute("Plantigrade", "PLANTIGRADE"),
            new Attribute("Unguligrade", "UNGULIGRADE"), new Attribute("Digitigrade", "DIGITIGRADE"),
            new Attribute("Arachnoid", "ARACHNOID"), new Attribute("Tentacled", "TENTACLED"));

    /**
     * ObservableList of plantigrade foot structure
     */
    private final ObservableList<Attribute> footStructuresP = FXCollections.observableArrayList();

    /**
     * ObservableList of unguligrade foot structure
     */
    private final ObservableList<Attribute> footStructuresU = FXCollections.observableArrayList();

    /**
     * ObservableList of none foot structure (for tailed leg configs)
     */
    private final ObservableList<Attribute> footStructuresN = FXCollections.observableArrayList();

    /**
     * ObservableList of arachnoid foot structure
     */
    private final ObservableList<Attribute> footStructuresA = FXCollections.observableArrayList();

    /**
     * ObservableList of tentacled foot structure
     */
    private final ObservableList<Attribute> footStructuresT = FXCollections.observableArrayList();

    /**
     * ObservableList of plantigrade and digitigrade foot structures
     */
    private final ObservableList<Attribute> footStructuresPD = FXCollections.observableArrayList();

    /**
     * ObservableList of digitigrade foot structure
     */
    private final ObservableList<Attribute> footStructuresD = FXCollections.observableArrayList();

    /**
     * ObservableList of all genital arrangements in the game
     */
    private final ObservableList<Attribute> genitalArrangementsNCR = FXCollections.observableArrayList(
            new Attribute("Normal", "NORMAL"), new Attribute("Cloaca", "CLOACA"),
            new Attribute("Rear-facing cloaca", "CLOACA_BEHIND"));

    /**
     * ObservableList of cloaca and rear-facing cloaca genital arrangements
     */
    private final ObservableList<Attribute> genitalArrangementsCR = FXCollections.observableArrayList();

    /**
     * ObservableList of normal genital arrangement
     */
    private final ObservableList<Attribute> genitalArrangementsN = FXCollections.observableArrayList();

    /**
     * ObservableList of cloaca genital arrangement
     */
    private final ObservableList<Attribute> genitalArrangementsC = FXCollections.observableArrayList();

    /**
     * ObservableList of rear-facing cloaca genital arrangement
     */
    private final ObservableList<Attribute> genitalArrangementsR = FXCollections.observableArrayList();

    /**
     * ObservableList of all leg types in the game
     */
    private final ObservableList<Attribute> legTypes = FXCollections.observableArrayList(
            //This element gets deleted when the initialization method is run
            new LegTypeAttr("Placeholder", "Placeholder", legConfigurationsMaster, footStructuresMaster, genitalArrangementsNCR));

    /**
     * ObservableList of all desire types in the game
     */
    private final ObservableList<Attribute> desireTypes = FXCollections.observableArrayList(
            new Attribute("Hate", "0"), new Attribute("Dislike", "1"),
            new Attribute("Indifferent", "2"), new Attribute("Like", "3"),
            new Attribute("Love", "4"));

    /**
     * ObservableList of all tiers of the Slam spell
     */
    private final ObservableList<Attribute> slamSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "SLAM_UNOWNED"), new SpellTier("Base", "SLAM"),
            new SpellTier("Ground Shake", "SLAM_1"), new SpellTier("Aftershock", "SLAM_2"),
            new SpellTier("Earthquake", "SLAM_3"));

    /**
     * ObservableList of all tiers of the Telekinetic Shower spell
     */
    private final ObservableList<Attribute> telekeneticShowerSpellTiers = FXCollections.observableArrayList(
            // Yes, that is how telekinetic is spelt in the save file
            new SpellTier("Unowned", "TELEKENETIC_SHOWER_UNOWNED"),
            new SpellTier("Base", "TELEKENETIC_SHOWER"),
            new SpellTier("Mind Over Matter", "TELEKENETIC_SHOWER_1"),
            new SpellTier("Precision Strikes", "TELEKENETIC_SHOWER_2"),
            new SpellTier("Unseen Force", "TELEKENETIC_SHOWER_3"));

    /**
     * ObservableList of all tiers of the Stone Shell spell
     */
    private final ObservableList<Attribute> stoneShellSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "STONE_SHELL_UNOWNED"), new SpellTier("Base", "STONE_SHELL"),
            new SpellTier("Shifting Sands", "STONE_SHELL_1"),
            new SpellTier("Hardened Carapace", "STONE_SHELL_2"),
            new SpellTier("Explosive Finish", "STONE_SHELL_3"));

    /**
     * ObservableList of all tiers of the Elemental Earth spell
     */
    private final ObservableList<Attribute> elementalEarthSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ELEMENTAL_EARTH_UNOWNED"),
            new SpellTier("Base", "ELEMENTAL_EARTH"),
            new SpellTier("Rolling Stone", "ELEMENTAL_EARTH_1"),
            new SpellTier("Hardening", "ELEMENTAL_EARTH_2"),
            new SpellTier("Servant of Earth", "ELEMENTAL_EARTH_3A"),
            new SpellTier("Binding of Earth", "ELEMENTAL_EARTH_3B"));

    /**
     * ObservableList of all tiers of the Ice Shard spell
     */
    private final ObservableList<Attribute> iceShardSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ICE_SHARD_UNOWNED"), new SpellTier("Base", "ICE_SHARD"),
            new SpellTier("Freezing Fog", "ICE_SHARD_1"), new SpellTier("Cold Snap", "ICE_SHARD_2"),
            new SpellTier("Deep Freeze", "ICE_SHARD_3"));

    /**
     * ObservableList of all tiers of the Raid Cloud spell
     */
    private final ObservableList<Attribute> rainCloudSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "RAIN_CLOUD_UNOWNED"), new SpellTier("Base", "RAIN_CLOUD"),
            new SpellTier("Deep Chill", "RAIN_CLOUD_1"), new SpellTier("Downpour", "RAIN_CLOUD_2"),
            new SpellTier("Cloud Burst", "RAIN_CLOUD_3"));

    /**
     * ObservableList of all tiers of the Soothing Waters spell
     */
    private final ObservableList<Attribute> soothingWatersSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "SOOTHING_WATERS_UNOWNED"),
            new SpellTier("Base", "SOOTHING_WATERS"),
            new SpellTier("Arcane Springs", "SOOTHING_WATERS_1"),
            new SpellTier("Rejuvenation", "SOOTHING_WATERS_2"),
            new SpellTier("Bouncing Orbs", "SOOTHING_WATERS_3"));

    /**
     * ObservableList of all tiers of the Elemental Water spell
     */
    private final ObservableList<Attribute> elementalWaterSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ELEMENTAL_WATER_UNOWNED"),
            new SpellTier("Base", "ELEMENTAL_WATER"),
            new SpellTier("Crashing Waves", "ELEMENTAL_WATER_1"),
            new SpellTier("Calm Waters", "ELEMENTAL_WATER_2"),
            new SpellTier("Servant of Water", "ELEMENTAL_WATER_3A"),
            new SpellTier("Binding of Water", "ELEMENTAL_WATER_3B"));

    /**
     * ObservableList of all tiers of the Fireball spell
     */
    private final ObservableList<Attribute> fireballSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "FIREBALL_UNOWNED"), new SpellTier("Base", "FIREBALL"),
            new SpellTier("Lingering Flames", "FIREBALL_1"), new SpellTier("Twin Comets", "FIREBALL_2"),
            new SpellTier("Burning Fury", "FIREBALL_3"));

    /**
     * ObservableList of all tiers of the Flash spell
     */
    private final ObservableList<Attribute> flashSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "FLASH_UNOWNED"), new SpellTier("Base", "FLASH"),
            new SpellTier("Secondary Sparks", "FLASH_1"), new SpellTier("Arcing Flash", "FLASH_2"),
            new SpellTier("Efficient Burn", "FLASH_3"));

    /**
     * ObservableList of all tiers of the Cloak of Flames spell
     */
    private final ObservableList<Attribute> cloakOfFlamesSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "CLOAK_OF_FLAMES_UNOWNED"),
            new SpellTier("Base", "CLOAK_OF_FLAMES"),
            new SpellTier("Incendiary", "CLOAK_OF_FLAMES_1"),
            new SpellTier("Inferno", "CLOAK_OF_FLAMES_2"),
            new SpellTier("Ring of Fire", "CLOAK_OF_FLAMES_3"));

    /**
     * ObservableList of all tiers of the Elemental Fire spell
     */
    private final ObservableList<Attribute> elementalFireSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ELEMENTAL_FIRE_UNOWNED"),
            new SpellTier("Base", "ELEMENTAL_FIRE"),
            new SpellTier("Wildfire", "ELEMENTAL_FIRE_1"),
            new SpellTier("Burning Desire", "ELEMENTAL_FIRE_2"),
            new SpellTier("Servant of Fire", "ELEMENTAL_FIRE_3A"),
            new SpellTier("Binding of Fire", "ELEMENTAL_FIRE_3B"));

    /**
     * ObservableList of all tiers of the Poison Vapour spell
     */
    private final ObservableList<Attribute> poisonVapoursSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "POISON_VAPOURS_UNOWNED"), new SpellTier("Base", "POISON_VAPOURS"),
            new SpellTier("Choking Haze", "POISON_VAPOURS_1"),
            new SpellTier("Arcane Sickness", "POISON_VAPOURS_2"),
            new SpellTier("Weakening Cloud", "POISON_VAPOURS_3"));

    /**
     * ObservableList of all tiers of the Vacuum spell
     */
    private final ObservableList<Attribute> vacuumSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "VACUUM_UNOWNED"), new SpellTier("Base", "VACUUM"),
            new SpellTier("Secondary Voids", "VACUUM_1"), new SpellTier("Suction", "VACUUM_2"),
            new SpellTier("Total Void", "VACUUM_3"));

    /**
     * ObservableList of all tiers of the Protective Gusts spell
     */
    private final ObservableList<Attribute> protectiveGustsSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "PROTECTIVE_GUSTS_UNOWNED"),
            new SpellTier("Base", "PROTECTIVE_GUSTS"),
            new SpellTier("Guiding Wind", "PROTECTIVE_GUSTS_1"),
            new SpellTier("Focused Blast", "PROTECTIVE_GUSTS_2"),
            new SpellTier("Lingering Presence", "PROTECTIVE_GUSTS_3"));

    /**
     * ObservableList of all tiers of the Elemental Air spell
     */
    private final ObservableList<Attribute> elementalAirSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ELEMENTAL_AIR_UNOWNED"),
            new SpellTier("Base", "ELEMENTAL_AIR"),
            new SpellTier("Whirlwind", "ELEMENTAL_AIR_1"),
            new SpellTier("Vitalising Scents", "ELEMENTAL_AIR_2"),
            new SpellTier("Servant of Air", "ELEMENTAL_AIR_3A"),
            new SpellTier("Binding of Air", "ELEMENTAL_AIR_3B"));

    /**
     * ObservableList of all tiers of the Arcane Arousal spell
     */
    private final ObservableList<Attribute> arcaneArousalSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ARCANE_AROUSAL_UNOWNED"),
            new SpellTier("Base", "ARCANE_AROUSAL"),
            new SpellTier("Overwhelming Lust", "ARCANE_AROUSAL_1"),
            new SpellTier("Lustful Distraction", "ARCANE_AROUSAL_2"),
            new SpellTier("Dirty Promises", "ARCANE_AROUSAL_3"));

    /**
     * ObservableList of all tiers of the Telepathic Communication spell
     */
    private final ObservableList<Attribute> telepathicCommunicationSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "TELEPATHIC_COMMUNICATION_UNOWNED"),
            new SpellTier("Base", "TELEPATHIC_COMMUNICATION"),
            new SpellTier("Echoing Moans", "TELEPATHIC_COMMUNICATION_1"),
            new SpellTier("Projected Touch", "TELEPATHIC_COMMUNICATION_2"),
            new SpellTier("Power of Suggestion", "TELEPATHIC_COMMUNICATION_3"));

    /**
     * ObservableList of all tiers of the Arcane Cloud spell
     */
    private final ObservableList<Attribute> arcaneCloudSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ARCANE_CLOUD_UNOWNED"), new SpellTier("Base", "ARCANE_CLOUD"),
            new SpellTier("Arcane Lightning", "ARCANE_CLOUD_1"),
            new SpellTier("Arcane Thunder", "ARCANE_CLOUD_2"),
            new SpellTier("Localized Storm", "ARCANE_CLOUD_3"));

    /**
     * ObservableList of all tiers of the Cleanse spell
     */
    private final ObservableList<Attribute> cleanseSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "CLEANSE_UNOWNED"), new SpellTier("Base", "CLEANSE"),
            new SpellTier("Selective Cleansing", "CLEANSE_1"),
            new SpellTier("Arcane Duality", "CLEANSE_2"),
            new SpellTier("Arcane Will", "CLEANSE_3"));

    /**
     * ObservableList of all tiers of the Steal spell
     */
    private final ObservableList<Attribute> stealSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "STEAL_UNOWNED"), new SpellTier("Base", "STEAL"),
            new SpellTier("Stripper", "STEAL_1"), new SpellTier("Disarm", "STEAL_2"),
            new SpellTier("Deep Reach", "STEAL_3A"), new SpellTier("Panty Snatcher", "STEAL_3B"));

    /**
     * ObservableList of all tiers of the Teleport spell
     */
    private final ObservableList<Attribute> teleportSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "TELEPORT_UNOWNED"), new SpellTier("Base", "TELEPORT"),
            new SpellTier("Arcane Arrival", "TELEPORT_1"),
            new SpellTier("Mass Teleportation", "TELEPORT_2"),
            new SpellTier("Rebounding Teleportation", "TELEPORT_3"));

    /**
     * ObservableList of all tiers of the Lilith's Command spell
     */
    private final ObservableList<Attribute> lilithsCommandSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "LILITHS_COMMAND_UNOWNED"),
            new SpellTier("Base", "LILITHS_COMMAND"),
            new SpellTier("Overpowering Presence", "LILITHS_COMMAND_1"),
            new SpellTier("Demonic Servants", "LILITHS_COMMAND_2"),
            new SpellTier("Ultimate Power", "LILITHS_COMMAND_3"));

    /**
     * ObservableList of all tiers of the Elemental Arcane spell
     */
    private final ObservableList<Attribute> elementalArcaneSpellTiers = FXCollections.observableArrayList(
            new SpellTier("Unowned", "ELEMENTAL_ARCANE_UNOWNED"), new SpellTier("Base", "ELEMENTAL_ARCANE"),
            new SpellTier("Lewd Encouragement", "ELEMENTAL_ARCANE_1"),
            new SpellTier("Caressing Touch", "ELEMENTAL_ARCANE_2"),
            new SpellTier("Servant of Arcane", "ELEMENTAL_ARCANE_3A"),
            new SpellTier("Binding of Arcane", "ELEMENTAL_ARCANE_3B"));

    /**
     * ObservableList of all the months
     */
    private final ObservableList<Attribute> months = FXCollections.observableArrayList(
            new Attribute("January", "JANUARY"), new Attribute("February", "FEBRUARY"),
            new Attribute("March", "MARCH"), new Attribute("April", "APRIL"),
            new Attribute("May", "MAY"), new Attribute("June", "JUNE"),
            new Attribute("July", "JULY"), new Attribute("August", "AUGUST"),
            new Attribute("September", "SEPTEMBER"), new Attribute("October", "OCTOBER"),
            new Attribute("November", "NOVEMBER"), new Attribute("December", "DECEMBER"));

    /**
     * ObservableList of all the months with numerical values
     */
    private final ObservableList<Attribute> numericalMonths = FXCollections.observableArrayList(
            new Attribute("January", "1"), new Attribute("February", "2"),
            new Attribute("March", "3"), new Attribute("April", "4"),
            new Attribute("May", "5"), new Attribute("June", "6"),
            new Attribute("July", "7"), new Attribute("August", "8"),
            new Attribute("September", "9"), new Attribute("October", "10"),
            new Attribute("November", "11"), new Attribute("December", "12"));

    /**
     * ObservableList of all the job histories in the game
     */
    private final ObservableList<Attribute> playerJobHistories = FXCollections.observableArrayList(
            new Attribute("Unemployed", "UNEMPLOYED"),
            new Attribute("Office Worker", "OFFICE_WORKER"), new Attribute("Student", "STUDENT"),
            new Attribute("Musician", "MUSICIAN"), new Attribute("Teacher", "TEACHER"),
            new Attribute("Writer", "WRITER"), new Attribute("Chef", "CHEF"),
            new Attribute("Construction Worker", "CONSTRUCTION_WORKER"),
            new Attribute("Soldier", "SOLDIER"), new Attribute("Athlete", "ATHLETE"),
            new Attribute("Aristocrat", "ARISTOCRAT"), new Attribute("Butler", "BUTLER"));

    private final ObservableList<Attribute> npcJobHistories = FXCollections.observableArrayList(
            new Attribute("Unemployed", "NPC_UNEMPLOYED"),
            new Attribute("Beautician", "NPC_BEAUTICIAN"),
            new Attribute("Enforcer Sword Constable", "NPC_ENFORCER_SWORD_CONSTABLE"),
            new Attribute("Enforcer Sword Inspector", "NPC_ENFORCER_SWORD_INSPECTOR"),
            new Attribute("Enforcer Sword Chief Inspector", "NPC_ENFORCER_SWORD_CHIEF_INSPECTOR"),
            new Attribute("Enforcer Sword Sergeant", "NPC_ENFORCER_SWORD_SERGEANT"),
            new Attribute("Enforcer Sword Super", "NPC_ENFORCER_SWORD_SUPER"),
            new Attribute("Enforcer Patrol Constable", "NPC_ENFORCER_PATROL_CONSTABLE"),
            new Attribute("Enforcer Patrol Inspector", "NPC_ENFORCER_PATROL_INSPECTOR"),
            new Attribute("Enforcer Patrol Sergeant", "NPC_ENFORCER_PATROL_SERGEANT"),
            new Attribute("Slime Queen Guard", "NPC_SLIME_QUEEN_GUARD"),
            new Attribute("Slime Queen", "NPC_SLIME_QUEEN"),
            new Attribute("Elis Mayor", "NPC_ELIS_MAYOR"),
            new Attribute("Stable Mistress", "NPC_STABLE_MISTRESS"),
            new Attribute("Epona", "NPC_EPONA"),
            new Attribute("Business Owner", "NPC_BUSINESS_OWNER"),
            new Attribute("Casino Owner", "NPC_CASINO_OWNER"),
            new Attribute("Clothing Store Owner", "NPC_CLOTHING_STORE_OWNER"),
            new Attribute("Gym Owner", "NPC_GYM_OWNER"),
            new Attribute("Nightclub Owner", "NPC_NIGHTCLUB_OWNER"),
            new Attribute("Store Owner", "NPC_STORE_OWNER"),
            new Attribute("Tavern Owner", "NPC_TAVERN_OWNER"),
            new Attribute("Assistant", "NPC_ASSISTANT"),
            new Attribute("Arcane Researcher", "NPC_ARCANE_RESEARCHER"),
            new Attribute("Bar Tender", "NPC_BAR_TENDER"),
            new Attribute("Bouncer", "NPC_BOUNCER"),
            new Attribute("Prostitute", "NPC_PROSTITUTE"),
            new Attribute("Lyssieth Guard", "NPC_LYSSIETH_GUARD"),
            new Attribute("Slave", "NPC_SLAVE"),
            new Attribute("Slaver Admin", "NPC_SLAVER_ADMIN"),
            new Attribute("Harpy Flock Member", "NPC_HARPY_FLOCK_MEMBER"),
            new Attribute("Harpy Matriarch", "NPC_HARPY_MATRIARCH"),
            new Attribute("Construction Worker Arcane", "NPC_CONSTRUCTION_WORKER_ARCANE"),
            new Attribute("Bounty Hunter", "NPC_BOUNTY_HUNTER"),
            new Attribute("Taur Transport", "NPC_TAUR_TRANSPORT"),
            new Attribute("Elemental", "ELEMENTAL"), new Attribute("Mugger", "NPC_MUGGER"),
            new Attribute("Gang Member", "NPC_GANG_MEMBER"),
            new Attribute("Gang Body Guard", "NPC_GANG_BODY_GUARD"),
            new Attribute("Gang Leader", "NPC_GANG_LEADER"),
            new Attribute("Office Worker", "NPC_OFFICE_WORKER"),
            new Attribute("Maid", "NPC_MAID"),
            new Attribute("Elder Lilin", "NPC_ELDER_LILIN"));

    private final ArrayList<ObservableList<Attribute>> jobHistories = new ArrayList<>(Arrays.asList(playerJobHistories,
            npcJobHistories));

    /**
     * ObservableList of all the femininity group values in the game
     */
    private final ObservableList<Attribute> femininityAttributeValues = FXCollections.observableArrayList(
            new Attribute("Very Masculine", "VERY_MASCULINE"),
            new Attribute("Masculine", "MASCULINE"), new Attribute("Androgynous", "ANDROGYNOUS"),
            new Attribute("Feminine", "FEMININE"), new Attribute("Very Feminine", "VERY_FEMININE"));

    /**
     * ArrayList of all breast size groups (gets completed in the initializer method) in the game
     */
    private final ArrayList<String> breastSizes = new ArrayList<>(Arrays.asList("Flat", "Training-AAA-cup",
            "Training-AA-cup", "Training-A-cup"));

    /**
     * ArrayList of all wetness level groups in the game
     */
    private final ArrayList<String> wetnessTypes = new ArrayList<>(Arrays.asList("Dry", "Slightly Moist", "Moist", "Wet",
            "Slimy", "Sloppy", "Sopping Wet", "Drooling"));

    /**
     * ArrayList of all depth size groups in the game
     */
    private final ArrayList<String> depthSizes = new ArrayList<>(Arrays.asList("Very Shallow", "Shallow", "Average-depth",
            "Spacious", "Deep", "Very Deep", "Cavernous", "Fathomless"));

    /**
     * ArrayList of all elasticity size groups in the game
     */
    private final ArrayList<String> elasticitySizes = new ArrayList<>(Arrays.asList("Rigid", "Stiff", "Firm", "Flexible",
            "Limber", "Stretchy", "Supple", "Elastic"));

    /**
     * ArrayList of all plasticity size groups in the game
     */
    private final ArrayList<String> plasticitySizes = new ArrayList<>(Arrays.asList("Rubbery", "Springy", "Tensile",
            "Resilient", "Accommodating", "Yielding", "Malleable", "Moldable"));

    /**
     * ArrayList of all lip size groups in the game
     */
    private final ArrayList<String> lipSizes = new ArrayList<>(Arrays.asList("Thin", "Average-sized", "Full", "Plump",
            "Huge", "Massive", "Gigantic", "Absurdly Colossal"));

    /**
     * ArrayList of all body part size groups in the game
     */
    private final ArrayList<String> bodyPartSizes = new ArrayList<>(Arrays.asList("Tiny", "Small", "Average-sized",
            "Large", "Massive"));

    /**
     * ArrayList of all appendage girth groups in the game
     */
    private final ArrayList<String> appendageGirths = new ArrayList<>(Arrays.asList("Thin", "Slender", "Narrow",
            "Average", "Thick", "Extra-thick", "Extremely-thick", "Unbelievable-thick"));

    /**
     * ArrayList of all penis (and clit) girth groups in the game
     */
    private final ArrayList<String> penisGirths = new ArrayList<>(Arrays.asList("Thin", "Slender", "Narrow",
            "Averagely-girthed", "Girthy", "Thick", "Chubby", "Fat"));

    /**
     * ArrayList of all testicle size groups in the game
     */
    private final ArrayList<String> testicleSizes = new ArrayList<>(Arrays.asList("Vestigial", "Tiny", "Average-sized",
            "Large", "Huge", "Massive", "Gigantic", "Absurdly Enormous"));

    /**
     * ArrayList of all ass size groups in the game
     */
    private final ArrayList<String> assSizes = new ArrayList<>(Arrays.asList("Flat", "Tiny", "Small", "Round", "Large",
            "Huge", "Massive", "Gigantic"));

    /**
     * ArrayList of all hip size groups in the game
     */
    private final ArrayList<String> hipSizes = new ArrayList<>(Arrays.asList("Completely Straight", "Very Narrow",
            "Narrow", "Girly", "Womanly", "Very Wide", "Extremely Wide", "Absurdly Wide"));

    /**
     * HashMap of all the secondary labels' TextField's id (key) and the corresponding ArrayList of values (value)
     */
    private final HashMap<String, ArrayList<String>> labelMap = new HashMap<>();

    /**
     * ArrayList of all femininity value groups in the game
     */
    private final ArrayList<String> femininityValues = addRangeToArrayList(new int[]{20, 20, 20, 20, 1}, //Technically the last int should be 21, but the code already accounts for values greater
            new String[]{"Very Masculine", "Masculine", "Androgynous", "Feminine", "Very Feminine"});

    /**
     * ArrayList of all body size groups in the game
     */
    private final ArrayList<String> bodySizes = addRangeToArrayList(new int[]{20, 20, 20, 20, 1},
            new String[]{"Skinny", "Slender", "Average", "Large", "Huge"});

    /**
     * ArrayList of all muscle size groups in the game
     */
    private final ArrayList<String> muscleDefinitions = addRangeToArrayList(new int[]{20, 20, 20, 20, 1},
            new String[]{"Soft", "Lightly Muscled", "Toned", "Muscular", "Ripped"});

    /**
     * ArrayList of all hair length groups in the game
     */
    private final ArrayList<String> hairLengths = addRangeToArrayList(new int[]{4, 7, 11, 23, 35, 60, 125, 1},
            new String[]{"Bald", "Very Short", "Short", "Shoulder-length", "Long", "Very Long", "Incredibly Long",
                    "Floor-length"});

    /**
     * ArrayList of all extremity length groups in the game
     */
    private final ArrayList<String> extremityLengths = addRangeToArrayList(new int[]{10, 12, 18, 22, 1},
            new String[]{"Tiny", "Small", "Long", "Huge", "Massive"}); //Horn and Antennae lengths

    /**
     * ArrayList of all tongue length groups in the game
     */
    private final ArrayList<String> tongueLengths = addRangeToArrayList(new int[]{7, 8, 10, 20, 1},
            new String[]{"Normal-sized", "Long", "Very Long", "Extremely Long", "Absurdly Long"});

    /**
     * ArrayList of all capacity size groups in the game
     */
    @SuppressWarnings("all")
    private final ArrayList<String> capacitySizes = addRangeToArrayList(new int[]{(int) (1.75 * 4), (int) (2 * 4), //The second cast is redundant, but kept for consistancy
                    (int) (2.5 * 4), (int) (2.5 * 4), (int) (2.5 * 4), (int) (2.5 * 4), (int) (6.25 * 4), 1},
            new String[]{"Extremely Tight", "Tight", "Somewhat Tight", "Slightly Loose", "Loose", "Very Loose",
                    "Stretched Open", "Gaping Wide"});

    /**
     * ArrayList of all milk storage size groups in the game
     */
    private final ArrayList<String> milkStorageSizes = addRangeToArrayList(new int[]{1, 29, 70, 500, 400, 1000, 8000, 1},
            new String[]{"None", "Trickle", "Small", "Decent", "Large", "Huge", "Extreme", "Monstrous"}); //Lactation

    /**
     * ArrayList of all fluid regeneration rate groups in the game
     */
    private final ArrayList<String> fluidRegenerationRates = addRangeToArrayList(new int[]{300, 500, 4200, 95000, 1},
            new String[]{"Slow", "Average", "Fast", "Rapid", "Very Rapid"});

    /**
     * ArrayList of all penis size groups in the game
     */
    private final ArrayList<String> penisSizes = addRangeToArrayList(new int[]{5, 5, 10, 10, 10, 10, 10, 1},
            new String[]{"Tiny", "Small", "Average-sized", "Large", "Huge", "Enormous", "Gigantic", "Stallion-sized"});

    /**
     * ArrayList of all cum storage size groups in the game
     */
    private final ArrayList<String> cumStorageSizes = addRangeToArrayList(new int[]{1, 9, 10, 10, 70, 900, 1},
            new String[]{"None", "Trickle", "Average", "Large", "Huge", "Extreme", "Monstrous"});

    /**
     * ArrayList of all clit size groups in the game
     */
    private final ArrayList<String> clitSizes = addRangeToArrayList(new int[]{1, 4, 5, 15, 15, 10, 10, 1},
            new String[]{"Small", "Big", "Large", "Huge", "Massive", "Enormous", "Gigantic", "Absurdly Colossal"});

    /**
     * ArrayList of all perks in the game
     */
    private final ArrayList<PerkNode> perks = new ArrayList<>();

    /**
     * HashMap of all personality traits (key) and the corresponding PersonalityTrait object (value)
     */
    private final HashMap<String, PersonalityTrait> personalityTraits = new HashMap<>();

    /**
     * ArrayList to hold all the ObservableList objects to make it easier to add them to their respective ComboBoxes
     */
    private final ArrayList<ObservableList<Attribute>> comboBoxValues = new ArrayList<>();

    private final ArrayList<ObservableList<Attribute>> hairStylesArr = new ArrayList<>(Arrays.asList(hairStylesB, hairStylesVS, hairStylesS, hairStylesSL,
            hairStylesL, hairStylesFL));

    public InitializeElements(){
        initializeCollections();
    }

    public ArrayList<PerkNode> getPerks(){
        return perks;
    }

    public ObservableList<Attribute> getDesireTypes(){
        return desireTypes;
    }

    public HashMap<String, PersonalityTrait> getPersonalityTraits(){
        return personalityTraits;
    }

    public ArrayList<ObservableList<Attribute>> getComboBoxValues(){
        return comboBoxValues;
    }

    public HashMap<String, ArrayList<String>> getLabelMap(){
        return labelMap;
    }

    @SafeVarargs
    public final void initializeHairStyles(ObservableList<Attribute>... hairStyles){
        for(int i = 0; i < hairStyles.length; i++) {
            hairStyles[i].addAll(hairStylesArr.get(i));
        }
    }

    /**
     * Initializes all ObservableLists, ArrayLists, and Maps
     */
    private void initializeCollections(){
        initializeComboBoxValues();
        initializePerks();
        initializeBreastSizes();
        initializeLabelMap();
        initializePersonalityTraits();
    }

    /**
     * Adds various ObservableLists to an ArrayList to make it easier to initialize the various ComboBoxes
     */
    private void initializeComboBoxValues(){
        comboBoxValues.addAll(Arrays.asList(sexualOrientations, genderIdentities, antennaeTypes, earTypes, faceTypes,
                eyeTypes, hairTypes, hornTypes, legTypes, assTypes, breastsTypes, milkFlavours, breastCrotchTypes,
                milkCrotchFlavours, penisTypes, cumFlavours, vaginaTypes, girlcumFlavours, torsoTypes, tailTypes,
                tentacleTypes, wingTypes, armTypes, irisShapes, pupilShapes, breastShapes, areolaeShapes, nippleShapes,
                breastCrotchShapes, areolaeCrotchShapes, nippleCrotchShapes, hairStylesFL, bodyMaterials,
                legConfigurationsMaster, footStructuresMaster, genitalArrangementsNCR, pubicHairTypes, facialHairTypes,
                assHairTypes, underarmHairTypes));
        for(int i = 0; i < 45; i++){ //The 45 fetishes uses the same values for desire
            comboBoxValues.add(desireTypes);
        }
        comboBoxValues.addAll(Arrays.asList(slamSpellTiers, telekeneticShowerSpellTiers, stoneShellSpellTiers,
                elementalEarthSpellTiers, iceShardSpellTiers, rainCloudSpellTiers, soothingWatersSpellTiers,
                elementalWaterSpellTiers, fireballSpellTiers, flashSpellTiers, cloakOfFlamesSpellTiers,
                elementalFireSpellTiers, poisonVapoursSpellTiers, vacuumSpellTiers, protectiveGustsSpellTiers,
                elementalAirSpellTiers, arcaneArousalSpellTiers, telepathicCommunicationSpellTiers, arcaneCloudSpellTiers,
                cleanseSpellTiers, stealSpellTiers, teleportSpellTiers, lilithsCommandSpellTiers,
                elementalArcaneSpellTiers, months, subspeciesOverrides, playerJobHistories, numericalMonths,
                femininityAttributeValues, femininityAttributeValues, subspeciesOverrides, subspeciesOverrides));
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
        genitalArrangementsCR.addAll(genitalArrangementsNCR.subList(1, 3));
        genitalArrangementsN.add(genitalArrangementsNCR.get(0));
        genitalArrangementsC.add(genitalArrangementsNCR.get(1));
        genitalArrangementsR.add(genitalArrangementsNCR.get(2));
    }

    /**
     * Initializes the legType list
     * Has to be done after the above three initializations as the LegTypeAttr class depends
     * on those lists not being empty
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

    /**
     * Initializes PerkNodes and fills the ArrayList with the PerkNodes
     */
    private void initializePerks(){
        PerkNode p1_1 = new PerkNode(null, "1", "PHYSICAL_BASE", "Natural Fitness");
        PerkNode p1_2 = new PerkNode(null, "1", "ARCANE_BASE", "Natural Arcane Power");
        PerkNode p1_3 = new PerkNode(null, "1", "LEWD_KNOWLEDGE", "Lewd Knowledge");

        PerkNode p2_11 = new PerkNode(p1_2, "2", "ARCANE_BOOST", "Arcane Training");
        PerkNode p2_10 = new PerkNode(p1_2, "2", "ARCANE_CRITICALS", "Arcane Precision");
        PerkNode p2_2 = new PerkNode(p1_1, "2", "OBSERVANT", "Observant");
        PerkNode p2_6 = new PerkNode(p1_3, "2", "SEDUCTION_BOOST", "Seductive");
        PerkNode p2_7 = new PerkNode(p1_3, "2", "FERTILITY_BOOST", "Fertile");
        PerkNode p2_1 = new PerkNode(p1_1, "2", "PHYSIQUE_BOOST", "Physically Fit");
        PerkNode p2_4 = new PerkNode(p1_3, "2", "FIRING_BLANKS", "Sterile");
        PerkNode p2_5 = new PerkNode(p1_3, "2", "VIRILITY_BOOST", "Virile");
        PerkNode p2_8 = new PerkNode(p1_3, "2", "BARREN", "Barren");
        PerkNode p2_3 = new PerkNode(p1_1, "2", "ENCHANTMENT_STABILITY", "Stable Enchantments"); //Physical
        PerkNode p2_9 = new PerkNode(p1_2, "2", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments"); //Arcane

        PerkNode p3_3 = new PerkNode(p2_1, "3", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p3_11 = new PerkNode(p2_11, "3", "SPELL_DAMAGE", "Spell Power");
        PerkNode p3_7 = new PerkNode(p2_6, "3", "ORGASMIC_LEVEL_DRAIN", "Orgasmic Level Drain");
        PerkNode p3_12 = new PerkNode(p2_11, "3", "AURA_BOOST", "Aura Reserves");
        PerkNode p3_5 = new PerkNode(p2_5, "3", "VIRILITY_MAJOR_BOOST", "Virile");
        PerkNode p3_8 = new PerkNode(p2_6, "3", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p3_13 = new PerkNode(p2_11, "3", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p3_1 = new PerkNode(p2_1, "3", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p3_6 = new PerkNode(p2_6, "3", "SEDUCTION_BOOST", "Seductive");
        PerkNode p3_2 = new PerkNode(p2_1, "3", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p3_9 = new PerkNode(p2_7, "3", "FERTILITY_MAJOR_BOOST", "Fertile");
        PerkNode p3_4 = new PerkNode(p2_3, "3", "ENCHANTMENT_STABILITY", "Stable Enchantments"); //Physical
        PerkNode p3_10 = new PerkNode(p2_9, "3", "ENCHANTMENT_STABILITY_ALT", "Stable Enchantments"); //Arcane

        PerkNode p4_3 = new PerkNode(p3_3, "4", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p4_1 = new PerkNode(p3_1, "4", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p4_11 = new PerkNode(p3_11, "4", "SPELL_DAMAGE", "Spell Power");
        PerkNode p4_6 = new PerkNode(p3_6, "4", "SEDUCTION_BOOST", "Seductive");
        PerkNode p4_4 = new PerkNode(p3_4, "4", "WEAPON_ENCHANTER", "Arcane Smith");
        PerkNode p4_9 = new PerkNode(p3_9, "4", "FETISH_BROODMOTHER", "Broodmother");
        PerkNode p4_12 = new PerkNode(p3_12, "4", "AURA_BOOST", "Aura Reserves");
        PerkNode p4_2 = new PerkNode(p3_2, "4", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p4_10 = new PerkNode(p3_10, "4", "CLOTHING_ENCHANTER", "Arcane Weaver");
        PerkNode p4_5 = new PerkNode(p3_5, "4", "FETISH_SEEDER", "Seeder");
        PerkNode p4_8 = new PerkNode(p3_8, "4", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p4_13 = new PerkNode(p3_13, "4", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p4_7 = new PerkNode(p4_6, p4_8, "4", "AHEGAO", "Ahegao");

        PerkNode p5_13 = new PerkNode(p4_12, p4_13, "5", "ARCANE_COMBATANT", "Arcane Combatant");
        PerkNode p5_9 = new PerkNode(p4_9, "5", "FERTILITY_BOOST", "Fertile");
        PerkNode p5_4 = new PerkNode(p4_3, "5", "UNARMED_DAMAGE", "Hand-to-Hand");
        PerkNode p5_10 = new PerkNode(p4_11, "5", "ELEMENTAL_BOOST", "Elemental Striker");
        PerkNode p5_3 = new PerkNode(p5_4, "5", "CRITICAL_BOOST", "Critical Power"); //Physical
        PerkNode p5_7 = new PerkNode(p4_6, p4_8, "5", "CRITICAL_BOOST_ALT", "Critical Power"); //Seductive
        PerkNode p5_11 = new PerkNode(p5_10, "5", "CRITICAL_BOOST_ALT_2", "Critical Power"); //Arcane
        PerkNode p5_12 = new PerkNode(p5_11, "5", "CHUUNI", "Chuuni");
        PerkNode p5_2 = new PerkNode(p5_3, "5", "UNARMED_TRAINING", "Martial Artist");
        PerkNode p5_1 = new PerkNode(p4_1, p4_2, "5", "RUNNER_2", "Cardio King");
        PerkNode p5_5 = new PerkNode(p4_5, "5", "VIRILITY_BOOST", "Virile");
        PerkNode p5_6 = new PerkNode(p5_5, "5", "VIRILITY_MAJOR_BOOST", "Virile");
        PerkNode p5_8 = new PerkNode(p5_9, "5", "FERTILITY_MAJOR_BOOST", "Fertile");

        PerkNode p6_1 = new PerkNode(p5_1, p5_4, "6", "PHYSIQUE_BOOST_MAJOR", "Physically Fit");
        PerkNode p6_3 = new PerkNode(p5_7, "6", "SEDUCTION_BOOST_MAJOR", "Seductive");
        PerkNode p6_2 = new PerkNode(p6_3, "6", "MALE_ATTRACTION", "Minx");
        PerkNode p6_4 = new PerkNode(p6_3, "6", "FEMALE_ATTRACTION", "Ladykiller");
        PerkNode p6_6 = new PerkNode(p5_10, p5_13, "6", "ARCANE_BOOST_MAJOR", "Arcane Affinity");

        PerkNode p7_1 = new PerkNode(p6_1, "7", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p7_6 = new PerkNode(p6_3, "7", "SEDUCTION_BOOST_ALT", "Seductive"); //Middle Branch
        PerkNode p7_5 = new PerkNode(p6_3, "7", "SEDUCTION_BOOST", "Seductive"); //Left Branch
        PerkNode p7_2 = new PerkNode(p7_1, "7", "UNARMED_DAMAGE", "Hand-to-Hand");
        PerkNode p7_8 = new PerkNode(p6_6, "7", "AURA_BOOST", "Aura Reserves");
        PerkNode p7_4 = new PerkNode(p6_1, "7", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p7_3 = new PerkNode(p7_4, "7", "ENERGY_BOOST_DRAIN_DAMAGE", "Aura Shielding");
        PerkNode p7_7 = new PerkNode(p6_3, "7", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p7_9 = new PerkNode(p6_6, "7", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p7_10 = new PerkNode(p7_9, "7", "SPELL_DAMAGE", "Spell Power");

        PerkNode p8_1 = new PerkNode(p7_1, "8", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p8_3 = new PerkNode(p7_4, "8", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p8_12 = new PerkNode(p7_10, "8", "SPELL_DAMAGE", "Spell Power");
        PerkNode p8_5 = new PerkNode(p7_5, "8", "SEDUCTION_BOOST", "Seductive");
        PerkNode p8_10 = new PerkNode(p7_8, "8", "AURA_BOOST", "Aura Reserves");
        PerkNode p8_4 = new PerkNode(p7_4, "8", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p8_2 = new PerkNode(p8_1, "8", "MELEE_DAMAGE", "Melee Weapons Expert");
        PerkNode p8_7 = new PerkNode(p7_6, "8", "SEDUCTION_BOOST_MAJOR", "Seductive");
        PerkNode p8_6 = new PerkNode(p8_7, "8", "CONVINCING_REQUESTS", "Irresistible Appeals");
        PerkNode p8_8 = new PerkNode(p8_7, "8", "OBJECT_OF_DESIRE", "Object of Desire");
        PerkNode p8_9 = new PerkNode(p7_7, "8", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p8_11 = new PerkNode(p7_9, "8", "SPELL_EFFICIENCY", "Spell Efficiency");

        PerkNode p9_1 = new PerkNode(p8_1, "9", "PHYSICAL_DAMAGE", "Striker");
        PerkNode p9_3 = new PerkNode(p8_3, "9", "PHYSICAL_DEFENCE", "Defender");
        PerkNode p9_6 = new PerkNode(p8_7, "9", "SEDUCTION_BOOST_ALT", "Seductive"); //Middle Branch
        PerkNode p9_5 = new PerkNode(p8_5, "9", "SEDUCTION_BOOST", "Seductive"); //Left Branch
        PerkNode p9_4 = new PerkNode(p8_4, "9", "ENERGY_BOOST", "Energy Reserves");
        PerkNode p9_2 = new PerkNode(p9_1, "9", "RANGED_DAMAGE", "Sharp-shooter");
        PerkNode p9_10 = new PerkNode(p8_12, "9", "SPELL_DAMAGE_MAJOR", "Spell Mastery");
        PerkNode p9_7 = new PerkNode(p8_9, "9", "SEDUCTION_DEFENCE_BOOST", "Resistance");
        PerkNode p9_9 = new PerkNode(p8_11, "9", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p9_8 = new PerkNode(p9_9, "9", "AURA_BOOST", "Aura Reserves");

        PerkNode p10_5 = new PerkNode(p9_6, "10", "NYMPHOMANIAC", "Nymphomaniac");
        PerkNode p10_7 = new PerkNode(p9_8, "10", "SACRIFICIAL_SHIELDING", "Sacrificial Shielding");
        PerkNode p10_3 = new PerkNode(p9_3, p9_4, "10", "COMBAT_REGENERATION", "Combat Regeneration");
        PerkNode p10_1 = new PerkNode(p9_1, "10", "FEROCIOUS_WARRIOR", "Ferocious Warrior");
        PerkNode p10_6 = new PerkNode(p9_7, "10", "PURE_MIND", "Pure Thoughts");
        PerkNode p10_4 = new PerkNode(p9_5, "10", "LUSTPYRE", "Lustpyre");
        PerkNode p10_2 = new PerkNode(p10_1, "10", "BESERK", "Berserk");
        PerkNode p10_8 = new PerkNode(p9_9, "10", "SPELL_EFFICIENCY", "Spell Efficiency");
        PerkNode p10_9 = new PerkNode(p9_10, "10", "ARCANE_VAMPYRISM", "Arcane Vampyrism");

        PerkNode p11_2 = new PerkNode(p10_1, p10_3, "11", "PHYSIQUE_BOOST_MAJOR", "Physically Fit");
        PerkNode p11_6 = new PerkNode(p10_8, "11", "ARCANE_BOOST_MAJOR", "Arcane Affinity");
        PerkNode p11_5 = new PerkNode(p11_6, "11", "ELEMENTAL_DEFENCE_BOOST", "Elemental Defender");
        PerkNode p11_1 = new PerkNode(p11_2, "11", "MELEE_DAMAGE", "Melee Weapons Expert");
        PerkNode p11_4 = new PerkNode(p10_4, p10_6, "11", "SEDUCTION_BOOST_MAJOR", "Seductive");
        PerkNode p11_3 = new PerkNode(p11_2, "11", "RANGED_DAMAGE", "Sharp-shooter");
        PerkNode p11_7 = new PerkNode(p11_6, "11", "ELEMENTAL_BOOST", "Elemental Striker");

        PerkNode p12_1 = new PerkNode(p11_2, "12", "ELEMENTAL_BOOST", "Elemental Striker"); //Physical
        PerkNode p12_2 = new PerkNode(p11_4, "12", "ELEMENTAL_BOOST_ALT", "Elemental Striker"); //Seductive
        PerkNode p12_3 = new PerkNode(p11_6, "12", "ELEMENTAL_BOOST_ALT_2", "Elemental Striker"); //Arcane

        perks.addAll(FXCollections.observableArrayList(p1_1, p1_2, p1_3, p2_11, p2_10, p2_2, p2_6, p2_7, p2_1, p2_4,
                p2_5, p2_8, p2_3, p2_9, p3_3, p3_11, p3_7, p3_12, p3_5, p3_8, p3_13, p3_1, p3_6, p3_2, p3_9, p3_4, p3_10,
                p4_3, p4_1, p4_11, p4_6, p4_4, p4_9, p4_12, p4_2, p4_10, p4_5, p4_8, p4_13, p4_7, p5_13, p5_9, p5_4,
                p5_10, p5_3, p5_7, p5_11, p5_12, p5_2, p5_1, p5_5, p5_6, p5_8, p6_1, p6_3, p6_2, p6_4, p6_6, p7_1, p7_6,
                p7_5, p7_2, p7_8, p7_4, p7_3, p7_7, p7_9, p7_10, p8_1, p8_3, p8_12, p8_5, p8_10, p8_4, p8_2, p8_7, p8_6,
                p8_8, p8_9, p8_11, p9_1, p9_3, p9_6, p9_5, p9_4, p9_2, p9_10, p9_7, p9_9, p9_8, p10_5, p10_7, p10_3,
                p10_1, p10_6, p10_4, p10_2, p10_8, p10_9, p11_2, p11_6, p11_5, p11_1, p11_4, p11_3, p11_7, p12_1, p12_2,
                p12_3));
    }
    //I'm probably dumb and there was an easier way to do this

    /**
     * Initializes and completes the breastSizes ArrayList
     */
    private void initializeBreastSizes(){
        String[] letters = {"AA", "A", "B", "C", "D", "DD", "E", "F", "FF", "G", "GG", "H", "HH", "J", "JJ", "K", "KK",
                "L", "LL", "M", "MM", "N"};
        String[] tiers = {"", "X", "XX", "XXX"};
        for(String tier : tiers){
            for(String letter : letters){
                breastSizes.add((tier.equals("") ? tier : (tier + "-"))  + letter + "-cup");
            }
        }
    }

    /**
     * Initializes the secondary label HashMap
     */
    private void initializeLabelMap(){
        labelMap.put("body$breasts$size", breastSizes);
        labelMap.put("body$breastsCrotch$size", breastSizes);
        labelMap.put("body$vagina$wetness", wetnessTypes);
        labelMap.put("body$anus$wetness", wetnessTypes);
        labelMap.put("body$spinneret$wetness", wetnessTypes);
        labelMap.put("body$mouth$wetness", wetnessTypes);
        labelMap.put("body$mouth$depth", depthSizes);
        labelMap.put("body$mouth$elasticity", elasticitySizes);
        labelMap.put("body$mouth$plasticity", plasticitySizes);
        labelMap.put("body$mouth$lipSize", lipSizes);
        labelMap.put("body$nipples$areolaeSize", bodyPartSizes);
        labelMap.put("body$nipples$depth", depthSizes);
        labelMap.put("body$nipples$elasticity", elasticitySizes);
        labelMap.put("body$nipples$nippleSize", bodyPartSizes);
        labelMap.put("body$nipples$plasticity", plasticitySizes);
        labelMap.put("body$nipplesCrotch$areolaeSize", bodyPartSizes);
        labelMap.put("body$nipplesCrotch$depth", depthSizes);
        labelMap.put("body$nipplesCrotch$elasticity", elasticitySizes);
        labelMap.put("body$nipplesCrotch$nippleSize", bodyPartSizes);
        labelMap.put("body$nipplesCrotch$plasticity", plasticitySizes);
        labelMap.put("body$tail$girth", appendageGirths);
        labelMap.put("body$tentacle$girth", appendageGirths);
        labelMap.put("body$spinneret$depth", depthSizes);
        labelMap.put("body$spinneret$elasticity", elasticitySizes);
        labelMap.put("body$spinneret$plasticity", plasticitySizes);
        labelMap.put("body$penis$depth", depthSizes);
        labelMap.put("body$penis$elasticity", elasticitySizes);
        labelMap.put("body$penis$girth", penisGirths);
        labelMap.put("body$penis$plasticity", plasticitySizes);
        labelMap.put("body$testicles$testicleSize", testicleSizes);
        labelMap.put("body$vagina$clitGirth", penisGirths);
        labelMap.put("body$vagina$depth", depthSizes);
        labelMap.put("body$vagina$elasticity", elasticitySizes);
        labelMap.put("body$vagina$labiaSize", bodyPartSizes);
        labelMap.put("body$vagina$plasticity", plasticitySizes);
        labelMap.put("body$vagina$urethraDepth", depthSizes);
        labelMap.put("body$vagina$urethraElasticity", elasticitySizes);
        labelMap.put("body$vagina$urethraPlasticity", plasticitySizes);
        labelMap.put("body$ass$assSize", assSizes);
        labelMap.put("body$ass$hipSize", hipSizes);
        labelMap.put("body$anus$depth", depthSizes);
        labelMap.put("body$anus$elasticity", elasticitySizes);
        labelMap.put("body$anus$plasticity", plasticitySizes);
        labelMap.put("body$bodyCore$bodySize", bodySizes);
        labelMap.put("body$bodyCore$femininity", femininityValues);
        labelMap.put("body$bodyCore$muscle", muscleDefinitions);
        labelMap.put("body$antennae$length", extremityLengths);
        labelMap.put("body$hair$length", hairLengths);
        labelMap.put("body$horn$length", extremityLengths);
        labelMap.put("body$tongue$tongueLength", tongueLengths);
        labelMap.put("body$mouth$capacity", capacitySizes);
        labelMap.put("body$mouth$stretchedCapacity", capacitySizes);
        labelMap.put("body$nipples$capacity", capacitySizes);
        labelMap.put("body$nipples$stretchedCapacity", capacitySizes);
        labelMap.put("body$nipplesCrotch$capacity", capacitySizes);
        labelMap.put("body$nipplesCrotch$stretchedCapacity", capacitySizes);
        labelMap.put("body$spinneret$capacity", capacitySizes);
        labelMap.put("body$spinneret$stretchedCapacity", capacitySizes);
        labelMap.put("body$penis$capacity", capacitySizes);
        labelMap.put("body$penis$stretchedCapacity", capacitySizes);
        labelMap.put("body$vagina$capacity", capacitySizes);
        labelMap.put("body$vagina$stretchedCapacity", capacitySizes);
        labelMap.put("body$vagina$urethraCapacity", capacitySizes);
        labelMap.put("body$vagina$urethraStretchedCapacity", capacitySizes);
        labelMap.put("body$anus$capacity", capacitySizes);
        labelMap.put("body$anus$stretchedCapacity", capacitySizes);
        labelMap.put("body$breasts$milkRegeneration", fluidRegenerationRates);
        labelMap.put("body$breasts$milkStorage", milkStorageSizes);
        labelMap.put("body$breastsCrotch$milkRegeneration", fluidRegenerationRates);
        labelMap.put("body$breastsCrotch$milkStorage", milkStorageSizes);
        labelMap.put("body$penis$size", penisSizes);
        labelMap.put("body$testicles$cumRegeneration", fluidRegenerationRates);
        labelMap.put("body$testicles$cumStorage", cumStorageSizes);
        labelMap.put("body$vagina$clitSize", clitSizes);
    }

    /**
     * Initializes PersonalityTraits and fills the HashMap with the PersonalityTraits
     */
    private void initializePersonalityTraits(){
        PersonalityTrait confident = new PersonalityTrait("CONFIDENT");
        PersonalityTrait shy = new PersonalityTrait("SHY");
        shy.addIncompatibleTrait(confident);
        PersonalityTrait kind = new PersonalityTrait("KIND");
        PersonalityTrait selfish = new PersonalityTrait("SELFISH");
        selfish.addIncompatibleTrait(kind);
        PersonalityTrait naive = new PersonalityTrait("NAIVE");
        PersonalityTrait cynical = new PersonalityTrait("CYNICAL");
        cynical.addIncompatibleTrait(naive);
        PersonalityTrait brave = new PersonalityTrait("BRAVE");
        PersonalityTrait cowardly = new PersonalityTrait("COWARDLY");
        cowardly.addIncompatibleTrait(brave);
        PersonalityTrait lewd = new PersonalityTrait("LEWD");
        PersonalityTrait innocent = new PersonalityTrait("INNOCENT");
        PersonalityTrait prude = new PersonalityTrait("PRUDE");
        prude.addIncompatibleTrait(lewd, innocent);
        innocent.addIncompatibleTrait(lewd);
        PersonalityTrait lisp = new PersonalityTrait("LISP");
        PersonalityTrait stutter = new PersonalityTrait("STUTTER");
        PersonalityTrait slovenly = new PersonalityTrait("SLOVENLY");
        PersonalityTrait mute = new PersonalityTrait("MUTE");
        mute.addIncompatibleTrait(lisp, stutter, slovenly);
        personalityTraits.put("CONFIDENT", confident);
        personalityTraits.put("SHY", shy);
        personalityTraits.put("KIND", kind);
        personalityTraits.put("SELFISH", selfish);
        personalityTraits.put("NAIVE", naive);
        personalityTraits.put("CYNICAL", cynical);
        personalityTraits.put("BRAVE", brave);
        personalityTraits.put("COWARDLY", cowardly);
        personalityTraits.put("LEWD", lewd);
        personalityTraits.put("INNOCENT", innocent);
        personalityTraits.put("PRUDE", prude);
        personalityTraits.put("LISP", lisp);
        personalityTraits.put("STUTTER", stutter);
        personalityTraits.put("SLOVENLY", slovenly);
        personalityTraits.put("MUTE", mute);
    }

    /**
     * Adds multiple identical Strings to an ArrayList to create a range of indexes that would get that String
     * @param ranges Int array of ranges for each String value
     * @param values String array of values to add
     * @return String ArrayList with a range for each String value
     */
    private ArrayList<String> addRangeToArrayList(int[] ranges, String[] values){
        if(ranges.length != values.length){
            throw new IllegalArgumentException();
        }
        int sum = 0;
        for(int range : ranges){
            sum += range;
        }
        ArrayList<String> list = new ArrayList<>(sum);
        for(int i = 0; i < ranges.length; i++){
            for(int j = 0; j < ranges[i]; j++){
                list.add(values[i]);
            }
        }
        return list;
    }

    public ArrayList<ObservableList<Attribute>> getJobHistories() {
        return jobHistories;
    }
}
