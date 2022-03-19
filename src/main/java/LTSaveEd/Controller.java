package LTSaveEd;

import LTSaveEd.Objects.*;
import LTSaveEd.Objects.InventoryElements.AbstractInventoryElements.AbstractInventoryElement;
import LTSaveEd.Objects.InventoryElements.InventoryClothing;
import LTSaveEd.Objects.InventoryElements.InventoryItem;
import LTSaveEd.Objects.InventoryElements.InventoryWeapon;
import LTSaveEd.Util.Debug;
import LTSaveEd.Util.InitializeElements;
import LTSaveEd.Util.TextFieldType;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.collections.ObservableMap;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.geometry.NodeOrientation;
import javafx.scene.control.*;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.util.StringConverter;
import org.w3c.dom.*;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathExpressionException;
import javax.xml.xpath.XPathFactory;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.file.Paths;
import java.util.*;

/**
 * Controller class that handles events and interactions of the GUI
 *
 * @author Exiua
 * @version 0.7.0
 */
public class Controller{

    /**
     * Gui's stage object
     */
    private Stage stage;

    /**
     * Namespace of the fxml
     */
    private ObservableMap<String, Object> namespace;

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
     * Current version of the save editor
     */
    private String version;

    /**
     * Boolean of whether a valid file has been loaded
     */
    private boolean fileLoaded = false;

    /**
     * Character Node of the character to edit
     */
    private Node characterNode;

    /**
     * Boolean tracking whether the addListeners method was run
     */
    private boolean listenersAdded = false;

    /**
     * Boolean tracking whether setFieldsSpellUpgrades was run
     * <p>
     * Otherwise, removeHigherTierSpells would be called when the ComboBox has the base value set
     * resulting in all spell upgrades being deleted from the save
     */
    private boolean fieldsSet = false;

    /**
     * Boolean tracking whether world fields have been set
     */
    private boolean worldFieldsSet = false;

    /**
     * String array of all TextField ids using an int data type
     */
    private final String[] intTextFieldIds = {"core$level$value", "core$experience$value", "core$perkPoints$value",
                                              "body$bodyCore$bodySize", "body$bodyCore$femininity", "body$bodyCore$height", "body$bodyCore$muscle",
                                              "body$antennae$antennaePerRow", "body$antennae$length", "body$antennae$rows", "body$mouth$depth",
                                              "body$mouth$elasticity", "body$mouth$lipSize", "body$mouth$plasticity", "body$mouth$wetness",
                                              "body$eye$eyePairs", "body$tongue$tongueLength", "body$horn$hornsPerRow", "body$horn$length",
                                              "body$horn$rows", "body$ass$assSize", "body$ass$hipSize", "body$anus$depth", "body$anus$elasticity",
                                              "body$anus$plasticity", "body$anus$wetness", "body$breasts$milkRegeneration", "body$breasts$milkStorage",
                                              "body$breasts$nippleCountPerBreast", "body$breasts$rows", "body$breasts$size", "body$nipples$areolaeSize",
                                              "body$nipples$depth", "body$nipples$elasticity", "body$nipples$nippleSize", "body$nipples$plasticity",
                                              "body$breastsCrotch$milkRegeneration", "body$breastsCrotch$milkStorage",
                                              "body$breastsCrotch$nippleCountPerBreast", "body$breastsCrotch$rows", "body$breastsCrotch$size",
                                              "body$nipplesCrotch$areolaeSize", "body$nipplesCrotch$depth", "body$nipplesCrotch$elasticity",
                                              "body$nipplesCrotch$nippleSize", "body$nipplesCrotch$plasticity", "body$penis$depth",
                                              "body$penis$elasticity", "body$penis$girth", "body$penis$plasticity", "body$penis$size",
                                              "body$testicles$cumExpulsion", "body$testicles$cumRegeneration", "body$testicles$cumStorage",
                                              "body$testicles$numberOfTesticles", "body$testicles$testicleSize", "body$vagina$clitGirth",
                                              "body$vagina$clitSize", "body$vagina$depth", "body$vagina$elasticity", "body$vagina$labiaSize",
                                              "body$vagina$plasticity", "body$tail$count", "body$tail$girth", "body$tentacle$count",
                                              "body$tentacle$girth", "body$wing$size", "body$spinneret$depth", "body$spinneret$elasticity",
                                              "body$spinneret$plasticity", "body$spinneret$wetness", "body$arm$rows", "characterInventory$money$value",
                                              "characterInventory$essenceCount$value", "FETISH_DOMINANT$exp", "FETISH_SUBMISSIVE$exp",
                                              "FETISH_VAGINAL_GIVING$exp", "FETISH_VAGINAL_RECEIVING$exp", "FETISH_PENIS_GIVING$exp",
                                              "FETISH_PENIS_RECEIVING$exp", "FETISH_ANAL_GIVING$exp", "FETISH_ANAL_RECEIVING$exp",
                                              "FETISH_BREASTS_OTHERS$exp", "FETISH_BREASTS_SELF$exp", "FETISH_LACTATION_OTHERS$exp",
                                              "FETISH_LACTATION_SELF$exp", "FETISH_ORAL_RECEIVING$exp", "FETISH_ORAL_GIVING$exp", "FETISH_LEG_LOVER$exp",
                                              "FETISH_STRUTTER$exp", "FETISH_FOOT_GIVING$exp", "FETISH_FOOT_RECEIVING$exp", "FETISH_ARMPIT_GIVING$exp",
                                              "FETISH_ARMPIT_RECEIVING$exp", "FETISH_CUM_STUD$exp", "FETISH_CUM_ADDICT$exp", "FETISH_DEFLOWERING$exp",
                                              "FETISH_PURE_VIRGIN$exp", "FETISH_IMPREGNATION$exp", "FETISH_PREGNANCY$exp",
                                              "FETISH_TRANSFORMATION_GIVING$exp", "FETISH_TRANSFORMATION_RECEIVING$exp", "FETISH_KINK_GIVING$exp",
                                              "FETISH_KINK_RECEIVING$exp", "FETISH_SADIST$exp", "FETISH_MASOCHIST$exp", "FETISH_NON_CON_DOM$exp",
                                              "FETISH_NON_CON_SUB$exp", "FETISH_BONDAGE_APPLIER$exp", "FETISH_BONDAGE_VICTIM$exp", "FETISH_DENIAL$exp",
                                              "FETISH_DENIAL_SELF$exp", "FETISH_VOYEURIST$exp", "FETISH_EXHIBITIONIST$exp", "FETISH_BIMBO$exp",
                                              "FETISH_CROSS_DRESSER$exp", "FETISH_MASTURBATION$exp", "FETISH_INCEST$exp", "FETISH_SIZE_QUEEN$exp",
                                              "FETISH_SWITCH$exp", "FETISH_BREEDER$exp", "FETISH_SADOMASOCHIST$exp", "FETISH_LUSTY_MAIDEN$exp",
                                              "spellUpgradePoints$EARTH", "spellUpgradePoints$WATER", "spellUpgradePoints$FIRE", "spellUpgradePoints$AIR",
                                              "spellUpgradePoints$ARCANE", "body$vagina$urethraDepth", "body$vagina$urethraElasticity",
                                              "body$vagina$urethraPlasticity", "body$vagina$wetness", "core$yearOfBirth$value",
                                              "dialogueFlags$ralphDiscount$value", "dialogueFlags$scarlettPrice$value", "dialogueFlags$eponaStamps$value",
                                              "dialogueFlags$helenaSlaveOrderDay$value", "dialogueFlags$natalyaPoints$value", "coreInfo$date$year"};

    /**
     * String array of all TextField ids using a double data type
     */
    private final String[] doubleTextFieldIds = {"core$obedience$value", "core$health$value", "core$mana$value",
                                                 "body$mouth$capacity", "body$mouth$stretchedCapacity", "body$anus$capacity",
                                                 "body$anus$stretchedCapacity", "body$breasts$storedMilk", "body$nipples$capacity",
                                                 "body$nipples$stretchedCapacity", "body$breastsCrotch$storedMilk", "body$nipplesCrotch$capacity",
                                                 "body$nipplesCrotch$stretchedCapacity", "body$penis$capacity", "body$penis$stretchedCapacity",
                                                 "body$testicles$storedCum", "body$vagina$capacity", "body$vagina$stretchedCapacity", "body$tail$length",
                                                 "body$tentacle$length", "body$spinneret$capacity", "body$spinneret$stretchedCapacity",
                                                 "attributes$HEALTH_MAXIMUM", "attributes$MANA_MAXIMUM",
                                                 "attributes$EXPERIENCE", "attributes$ACTION_POINTS", "attributes$AROUSAL", "attributes$LUST",
                                                 "attributes$RESTING_LUST", "attributes$MAJOR_PHYSIQUE", "attributes$MAJOR_ARCANE",
                                                 "attributes$MAJOR_CORRUPTION", "attributes$ENCHANTMENT_LIMIT", "attributes$FERTILITY", "attributes$VIRILITY",
                                                 "attributes$SPELL_COST_MODIFIER", "attributes$CRITICAL_DAMAGE", "attributes$ENERGY_SHIELDING",
                                                 "attributes$RESISTANCE_PHYSICAL", "attributes$RESISTANCE_LUST", "attributes$RESISTANCE_FIRE",
                                                 "attributes$RESISTANCE_ICE", "attributes$RESISTANCE_POISON", "attributes$DAMAGE_UNARMED",
                                                 "attributes$DAMAGE_MELEE_WEAPON", "attributes$DAMAGE_RANGED_WEAPON", "attributes$DAMAGE_SPELLS",
                                                 "attributes$DAMAGE_PHYSICAL", "attributes$DAMAGE_LUST", "attributes$DAMAGE_FIRE", "attributes$DAMAGE_ICE",
                                                 "attributes$DAMAGE_POISON", "body$vagina$urethraCapacity", "body$vagina$urethraStretchedCapacity"};

    /**
     * String array of all TextField ids using a String data type
     */
    private final String[] stringTextFieldIds = {"core$name$nameAndrogynous", "core$name$nameFeminine",
                                                 "core$name$nameMasculine", "core$surname$value"};

    private final String[] dateTextFieldIds = {"core$dayOfBirth$value", "coreInfo$date$dayOfMonth"};

    /**
     * String array of all ComboBox ids
     */
    private final String[] ComboBoxIds = {"core$sexualOrientation$value", "core$genderIdentity$value",
                                          "body$antennae$type", "body$ear$type", "body$face$type", "body$eye$type", "body$hair$type", "body$horn$type",
                                          "body$leg$type", "body$ass$type", "body$breasts$type", "body$milk$flavour", "body$breastsCrotch$type",
                                          "body$milkCrotch$flavour", "body$penis$type", "body$cum$flavour", "body$vagina$type", "body$girlcum$flavour",
                                          "body$torso$type", "body$tail$type", "body$tentacle$type", "body$wing$type", "body$arm$type",
                                          "body$eye$irisShape", "body$eye$pupilShape", "body$breasts$shape", "body$nipples$areolaeShape",
                                          "body$nipples$nippleShape", "body$breastsCrotch$shape", "body$nipplesCrotch$areolaeShape",
                                          "body$nipplesCrotch$nippleShape", "body$hair$hairStyle", "body$bodyCore$bodyMaterial",
                                          "body$bodyCore$genitalArrangement", "body$leg$configuration", "body$leg$footStructure",
                                          "body$bodyCore$pubicHair", "body$face$facialHair", "body$anus$assHair", "body$arm$underarmHair",
                                          "FETISH_DOMINANT$desire", "FETISH_SUBMISSIVE$desire", "FETISH_VAGINAL_GIVING$desire",
                                          "FETISH_VAGINAL_RECEIVING$desire", "FETISH_PENIS_GIVING$desire", "FETISH_PENIS_RECEIVING$desire",
                                          "FETISH_ANAL_GIVING$desire", "FETISH_ANAL_RECEIVING$desire", "FETISH_BREASTS_OTHERS$desire",
                                          "FETISH_BREASTS_SELF$desire", "FETISH_LACTATION_OTHERS$desire", "FETISH_LACTATION_SELF$desire",
                                          "FETISH_ORAL_RECEIVING$desire", "FETISH_ORAL_GIVING$desire", "FETISH_LEG_LOVER$desire",
                                          "FETISH_STRUTTER$desire", "FETISH_FOOT_GIVING$desire", "FETISH_FOOT_RECEIVING$desire",
                                          "FETISH_ARMPIT_GIVING$desire", "FETISH_ARMPIT_RECEIVING$desire", "FETISH_CUM_STUD$desire",
                                          "FETISH_CUM_ADDICT$desire", "FETISH_DEFLOWERING$desire", "FETISH_PURE_VIRGIN$desire",
                                          "FETISH_IMPREGNATION$desire", "FETISH_PREGNANCY$desire", "FETISH_TRANSFORMATION_GIVING$desire",
                                          "FETISH_TRANSFORMATION_RECEIVING$desire", "FETISH_KINK_GIVING$desire", "FETISH_KINK_RECEIVING$desire",
                                          "FETISH_SADIST$desire", "FETISH_MASOCHIST$desire", "FETISH_NON_CON_DOM$desire", "FETISH_NON_CON_SUB$desire",
                                          "FETISH_BONDAGE_APPLIER$desire", "FETISH_BONDAGE_VICTIM$desire", "FETISH_DENIAL$desire",
                                          "FETISH_DENIAL_SELF$desire", "FETISH_VOYEURIST$desire", "FETISH_EXHIBITIONIST$desire", "FETISH_BIMBO$desire",
                                          "FETISH_CROSS_DRESSER$desire", "FETISH_MASTURBATION$desire", "FETISH_INCEST$desire",
                                          "FETISH_SIZE_QUEEN$desire", "spells$SLAM", "spells$TELEKENETIC_SHOWER", "spells$STONE_SHELL",
                                          "spells$ELEMENTAL_EARTH", "spells$ICE_SHARD", "spells$RAIN_CLOUD", "spells$SOOTHING_WATERS",
                                          "spells$ELEMENTAL_WATER", "spells$FIREBALL", "spells$FLASH", "spells$CLOAK_OF_FLAMES", "spells$ELEMENTAL_FIRE",
                                          "spells$POISON_VAPOURS", "spells$VACUUM", "spells$PROTECTIVE_GUSTS", "spells$ELEMENTAL_AIR",
                                          "spells$ARCANE_AROUSAL", "spells$TELEPATHIC_COMMUNICATION", "spells$ARCANE_CLOUD", "spells$CLEANSE",
                                          "spells$STEAL", "spells$TELEPORT", "spells$LILITHS_COMMAND", "spells$ELEMENTAL_ARCANE",
                                          "core$monthOfBirth$value", "body$bodyCore$subspeciesOverride", "core$history$value", "coreInfo$date$month",
                                          "family$motherFemininity$value", "family$fatherFemininity$value", "family$motherSubspecies",
                                          "family$fatherSubspecies$value"};

    /**
     * String array of ids for all CheckBoxes that would carry over if not reset
     */
    private final String[] resetCheckBoxIds = {"FETISH_DOMINANT$owned", "FETISH_SUBMISSIVE$owned", "FETISH_VAGINAL_GIVING$owned",
                                               "FETISH_VAGINAL_RECEIVING$owned", "FETISH_PENIS_GIVING$owned", "FETISH_PENIS_RECEIVING$owned",
                                               "FETISH_ANAL_GIVING$owned", "FETISH_ANAL_RECEIVING$owned", "FETISH_BREASTS_OTHERS$owned",
                                               "FETISH_BREASTS_SELF$owned", "FETISH_LACTATION_OTHERS$owned", "FETISH_LACTATION_SELF$owned",
                                               "FETISH_ORAL_RECEIVING$owned", "FETISH_ORAL_GIVING$owned", "FETISH_LEG_LOVER$owned",
                                               "FETISH_STRUTTER$owned", "FETISH_FOOT_GIVING$owned", "FETISH_FOOT_RECEIVING$owned",
                                               "FETISH_ARMPIT_GIVING$owned", "FETISH_ARMPIT_RECEIVING$owned", "FETISH_CUM_STUD$owned",
                                               "FETISH_CUM_ADDICT$owned", "FETISH_DEFLOWERING$owned", "FETISH_PURE_VIRGIN$owned",
                                               "FETISH_IMPREGNATION$owned", "FETISH_PREGNANCY$owned", "FETISH_TRANSFORMATION_GIVING$owned",
                                               "FETISH_TRANSFORMATION_RECEIVING$owned", "FETISH_KINK_GIVING$owned", "FETISH_KINK_RECEIVING$owned",
                                               "FETISH_SADIST$owned", "FETISH_MASOCHIST$owned", "FETISH_NON_CON_DOM$owned", "FETISH_NON_CON_SUB$owned",
                                               "FETISH_BONDAGE_APPLIER$owned", "FETISH_BONDAGE_VICTIM$owned", "FETISH_DENIAL$owned",
                                               "FETISH_DENIAL_SELF$owned", "FETISH_VOYEURIST$owned", "FETISH_EXHIBITIONIST$owned", "FETISH_BIMBO$owned",
                                               "FETISH_CROSS_DRESSER$owned", "FETISH_MASTURBATION$owned", "FETISH_INCEST$owned", "FETISH_SIZE_QUEEN$owned",
                                               "body$mouth$mouthModifiers$PUFFY", "body$mouth$mouthModifiers$TENTACLED", "body$mouth$mouthModifiers$RIBBED",
                                               "body$mouth$mouthModifiers$MUSCLE_CONTROL", "body$tongue$tongueModifiers$RIBBED",
                                               "body$tongue$tongueModifiers$TENTACLED", "body$tongue$tongueModifiers$BIFURCATED",
                                               "body$tongue$tongueModifiers$WIDE", "body$tongue$tongueModifiers$FLAT", "body$tongue$tongueModifiers$STRONG",
                                               "body$tongue$tongueModifiers$TAPERED", "body$nipples$nippleModifiers$PUFFY",
                                               "body$nipples$nippleModifiers$TENTACLED", "body$nipples$nippleModifiers$RIBBED",
                                               "body$nipples$nippleModifiers$MUSCLE_CONTROL", "body$milk$milkModifiers$MUSKY",
                                               "body$milk$milkModifiers$VISCOUS", "body$milk$milkModifiers$STICKY", "body$milk$milkModifiers$SLIMY",
                                               "body$milk$milkModifiers$BUBBLING", "body$milk$milkModifiers$MINERAL_OIL", "body$milk$milkModifiers$ALCOHOLIC",
                                               "body$milk$milkModifiers$ADDICTIVE", "body$milk$milkModifiers$HALLUCINOGENIC",
                                               "body$nipplesCrotch$nippleModifiers$PUFFY", "body$nipplesCrotch$nippleModifiers$TENTACLED",
                                               "body$nipplesCrotch$nippleModifiers$RIBBED", "body$nipplesCrotch$nippleModifiers$MUSCLE_CONTROL",
                                               "body$milkCrotch$milkModifiers$MUSKY", "body$milkCrotch$milkModifiers$VISCOUS",
                                               "body$milkCrotch$milkModifiers$STICKY", "body$milkCrotch$milkModifiers$SLIMY",
                                               "body$milkCrotch$milkModifiers$BUBBLING", "body$milkCrotch$milkModifiers$MINERAL_OIL",
                                               "body$milkCrotch$milkModifiers$ALCOHOLIC", "body$milkCrotch$milkModifiers$ADDICTIVE",
                                               "body$milkCrotch$milkModifiers$HALLUCINOGENIC", "body$penis$penisModifiers$SHEATHED",
                                               "body$penis$penisModifiers$RIBBED", "body$penis$penisModifiers$TENTACLED", "body$penis$penisModifiers$KNOTTED",
                                               "body$penis$penisModifiers$BLUNT", "body$penis$penisModifiers$TAPERED", "body$penis$penisModifiers$FLARED",
                                               "body$penis$penisModifiers$BARBED", "body$penis$penisModifiers$VEINY", "body$penis$penisModifiers$PREHENSILE",
                                               "body$penis$penisModifiers$OVIPOSITOR", "body$penis$urethraModifiers$PUFFY",
                                               "body$penis$urethraModifiers$TENTACLED", "body$penis$urethraModifiers$RIBBED",
                                               "body$penis$urethraModifiers$MUSCLE_CONTROL", "body$cum$cumModifiers$MUSKY", "body$cum$cumModifiers$VISCOUS",
                                               "body$cum$cumModifiers$STICKY", "body$cum$cumModifiers$SLIMY", "body$cum$cumModifiers$BUBBLING",
                                               "body$cum$cumModifiers$MINERAL_OIL", "body$cum$cumModifiers$ALCOHOLIC", "body$cum$cumModifiers$ADDICTIVE",
                                               "body$cum$cumModifiers$HALLUCINOGENIC", "body$vagina$vaginaModifiers$PUFFY",
                                               "body$vagina$vaginaModifiers$TENTACLED", "body$vagina$vaginaModifiers$RIBBED",
                                               "body$vagina$vaginaModifiers$MUSCLE_CONTROL", "body$vagina$clitModifiers$SHEATHED",
                                               "body$vagina$clitModifiers$RIBBED", "body$vagina$clitModifiers$TENTACLED", "body$vagina$clitModifiers$KNOTTED",
                                               "body$vagina$clitModifiers$BLUNT", "body$vagina$clitModifiers$TAPERED", "body$vagina$clitModifiers$FLARED",
                                               "body$vagina$clitModifiers$BARBED", "body$vagina$clitModifiers$VEINY", "body$vagina$clitModifiers$PREHENSILE",
                                               "body$vagina$clitModifiers$OVIPOSITOR", "body$girlcum$girlcumModifiers$MUSKY",
                                               "body$girlcum$girlcumModifiers$VISCOUS", "body$girlcum$girlcumModifiers$STICKY",
                                               "body$girlcum$girlcumModifiers$SLIMY", "body$girlcum$girlcumModifiers$BUBBLING",
                                               "body$girlcum$girlcumModifiers$MINERAL_OIL", "body$girlcum$girlcumModifiers$ALCOHOLIC",
                                               "body$girlcum$girlcumModifiers$ADDICTIVE", "body$girlcum$girlcumModifiers$HALLUCINOGENIC",
                                               "body$vagina$urethraModifiers$PUFFY", "body$vagina$urethraModifiers$TENTACLED",
                                               "body$vagina$urethraModifiers$RIBBED", "body$vagina$urethraModifiers$MUSCLE_CONTROL",
                                               "body$anus$anusModifiers$PUFFY", "body$anus$anusModifiers$TENTACLED", "body$anus$anusModifiers$RIBBED",
                                               "body$anus$anusModifiers$MUSCLE_CONTROL", "spells$SOOTHING_WATERS_1_CLEAN", "spells$SOOTHING_WATERS_2_CLEAN",
                                               "perks$1$PHYSICAL_BASE", "perks$2$PHYSIQUE_BOOST", "perks$2$OBSERVANT", "perks$2$ENCHANTMENT_STABILITY",
                                               "perks$3$PHYSICAL_DEFENCE", "perks$3$ENERGY_BOOST", "perks$3$PHYSICAL_DAMAGE", "perks$3$ENCHANTMENT_STABILITY",
                                               "perks$4$PHYSICAL_DEFENCE", "perks$4$ENERGY_BOOST", "perks$4$PHYSICAL_DAMAGE", "perks$4$WEAPON_ENCHANTER",
                                               "perks$5$RUNNER_2", "perks$5$UNARMED_TRAINING", "perks$5$CRITICAL_BOOST", "perks$5$UNARMED_DAMAGE",
                                               "perks$6$PHYSIQUE_BOOST_MAJOR", "perks$7$PHYSICAL_DAMAGE", "perks$7$UNARMED_DAMAGE",
                                               "perks$7$ENERGY_BOOST_DRAIN_DAMAGE", "perks$7$ENERGY_BOOST", "perks$8$PHYSICAL_DAMAGE", "perks$8$MELEE_DAMAGE",
                                               "perks$8$PHYSICAL_DEFENCE", "perks$8$ENERGY_BOOST", "perks$9$PHYSICAL_DAMAGE", "perks$9$RANGED_DAMAGE",
                                               "perks$9$PHYSICAL_DEFENCE", "perks$9$ENERGY_BOOST", "perks$10$FEROCIOUS_WARRIOR", "perks$10$BESERK",
                                               "perks$10$COMBAT_REGENERATION", "perks$11$MELEE_DAMAGE", "perks$11$PHYSIQUE_BOOST_MAJOR",
                                               "perks$11$RANGED_DAMAGE", "perks$12$ELEMENTAL_BOOST", "perks$1$LEWD_KNOWLEDGE", "perks$2$FIRING_BLANKS",
                                               "perks$2$VIRILITY_BOOST", "perks$2$SEDUCTION_BOOST", "perks$2$FERTILITY_BOOST", "perks$2$BARREN",
                                               "perks$3$VIRILITY_MAJOR_BOOST", "perks$3$SEDUCTION_BOOST", "perks$3$ORGASMIC_LEVEL_DRAIN",
                                               "perks$3$SEDUCTION_DEFENCE_BOOST", "perks$3$FERTILITY_MAJOR_BOOST", "perks$4$FETISH_SEEDER",
                                               "perks$4$SEDUCTION_BOOST", "perks$4$SEDUCTION_DEFENCE_BOOST", "perks$4$FETISH_BROODMOTHER",
                                               "perks$5$VIRILITY_BOOST", "perks$5$VIRILITY_MAJOR_BOOST", "perks$5$CRITICAL_BOOST_ALT",
                                               "perks$5$FERTILITY_MAJOR_BOOST", "perks$5$FERTILITY_BOOST", "perks$6$MALE_ATTRACTION",
                                               "perks$6$SEDUCTION_BOOST_MAJOR", "perks$6$FEMALE_ATTRACTION", "perks$7$SEDUCTION_BOOST",
                                               "perks$7$SEDUCTION_BOOST_ALT", "perks$7$SEDUCTION_DEFENCE_BOOST", "perks$8$SEDUCTION_BOOST",
                                               "perks$8$CONVINCING_REQUESTS", "perks$8$SEDUCTION_BOOST_MAJOR", "perks$8$OBJECT_OF_DESIRE",
                                               "perks$8$SEDUCTION_DEFENCE_BOOST", "perks$9$SEDUCTION_BOOST", "perks$9$SEDUCTION_BOOST_ALT",
                                               "perks$9$SEDUCTION_DEFENCE_BOOST", "perks$10$LUSTPYRE", "perks$10$NYMPHOMANIAC", "perks$10$PURE_MIND",
                                               "perks$11$SEDUCTION_BOOST_MAJOR", "perks$12$ELEMENTAL_BOOST_ALT", "perks$1$ARCANE_BASE",
                                               "perks$2$ENCHANTMENT_STABILITY_ALT", "perks$2$ARCANE_CRITICALS", "perks$2$ARCANE_BOOST",
                                               "perks$3$ENCHANTMENT_STABILITY_ALT", "perks$3$SPELL_DAMAGE", "perks$3$AURA_BOOST", "perks$3$SPELL_EFFICIENCY",
                                               "perks$4$CLOTHING_ENCHANTER", "perks$4$SPELL_DAMAGE", "perks$4$AURA_BOOST", "perks$4$SPELL_EFFICIENCY",
                                               "perks$5$ELEMENTAL_BOOST", "perks$5$CRITICAL_BOOST_ALT_2", "perks$5$CHUUNI", "perks$5$ARCANE_COMBATANT",
                                               "perks$6$ARCANE_BOOST_MAJOR", "perks$7$AURA_BOOST", "perks$7$SPELL_EFFICIENCY", "perks$7$SPELL_DAMAGE",
                                               "perks$8$AURA_BOOST", "perks$8$SPELL_EFFICIENCY", "perks$8$SPELL_DAMAGE", "perks$9$AURA_BOOST",
                                               "perks$9$SPELL_EFFICIENCY", "perks$9$SPELL_DAMAGE_MAJOR", "perks$10$SACRIFICIAL_SHIELDING",
                                               "perks$10$SPELL_EFFICIENCY", "perks$10$ARCANE_VAMPYRISM", "perks$11$ELEMENTAL_DEFENCE_BOOST",
                                               "perks$11$ARCANE_BOOST_MAJOR", "perks$11$ELEMENTAL_BOOST", "perks$12$ELEMENTAL_BOOST_ALT_2"};

    /**
     * String array of ids for all ComboBoxes that would carry over if not reset
     */
    private final String[] resetComboBoxIds = {"FETISH_DOMINANT$desire", "FETISH_SUBMISSIVE$desire",
                                               "FETISH_VAGINAL_GIVING$desire", "FETISH_VAGINAL_RECEIVING$desire", "FETISH_PENIS_GIVING$desire",
                                               "FETISH_PENIS_RECEIVING$desire", "FETISH_ANAL_GIVING$desire", "FETISH_ANAL_RECEIVING$desire",
                                               "FETISH_BREASTS_OTHERS$desire", "FETISH_BREASTS_SELF$desire", "FETISH_LACTATION_OTHERS$desire",
                                               "FETISH_LACTATION_SELF$desire", "FETISH_ORAL_RECEIVING$desire", "FETISH_ORAL_GIVING$desire",
                                               "FETISH_LEG_LOVER$desire", "FETISH_STRUTTER$desire", "FETISH_FOOT_GIVING$desire",
                                               "FETISH_ARMPIT_GIVING$desire", "FETISH_ARMPIT_RECEIVING$desire", "FETISH_FOOT_RECEIVING$desire",
                                               "FETISH_CUM_STUD$desire", "FETISH_CUM_ADDICT$desire", "FETISH_DEFLOWERING$desire", "FETISH_PURE_VIRGIN$desire",
                                               "FETISH_IMPREGNATION$desire", "FETISH_PREGNANCY$desire", "FETISH_TRANSFORMATION_GIVING$desire",
                                               "FETISH_TRANSFORMATION_RECEIVING$desire", "FETISH_KINK_GIVING$desire", "FETISH_KINK_RECEIVING$desire",
                                               "FETISH_SADIST$desire", "FETISH_MASOCHIST$desire", "FETISH_NON_CON_DOM$desire", "FETISH_NON_CON_SUB$desire",
                                               "FETISH_BONDAGE_APPLIER$desire", "FETISH_BONDAGE_VICTIM$desire", "FETISH_DENIAL$desire",
                                               "FETISH_DENIAL_SELF$desire", "FETISH_VOYEURIST$desire", "FETISH_EXHIBITIONIST$desire", "FETISH_BIMBO$desire",
                                               "FETISH_CROSS_DRESSER$desire", "FETISH_MASTURBATION$desire", "FETISH_INCEST$desire",
                                               "FETISH_SIZE_QUEEN$desire", "spells$SLAM", "spells$TELEKENETIC_SHOWER", "spells$STONE_SHELL",
                                               "spells$ELEMENTAL_EARTH", "spells$ICE_SHARD", "spells$RAIN_CLOUD", "spells$SOOTHING_WATERS",
                                               "spells$ELEMENTAL_WATER", "spells$FIREBALL", "spells$FLASH", "spells$CLOAK_OF_FLAMES",
                                               "spells$ELEMENTAL_FIRE", "spells$POISON_VAPOURS", "spells$VACUUM", "spells$PROTECTIVE_GUSTS",
                                               "spells$ELEMENTAL_AIR", "spells$ARCANE_AROUSAL", "spells$TELEPATHIC_COMMUNICATION", "spells$ARCANE_CLOUD",
                                               "spells$CLEANSE", "spells$STEAL", "spells$TELEPORT", "spells$LILITHS_COMMAND", "spells$ELEMENTAL_ARCANE"};

    /**
     * String array of ids for all TextFields of int type that would carry over if not reset
     */
    private final String[] resetIntTextFieldsIds = {"FETISH_DOMINANT$exp", "FETISH_SUBMISSIVE$exp",
                                                    "FETISH_VAGINAL_GIVING$exp", "FETISH_VAGINAL_RECEIVING$exp", "FETISH_PENIS_GIVING$exp",
                                                    "FETISH_PENIS_RECEIVING$exp", "FETISH_ANAL_GIVING$exp", "FETISH_ANAL_RECEIVING$exp",
                                                    "FETISH_BREASTS_OTHERS$exp", "FETISH_BREASTS_SELF$exp", "FETISH_LACTATION_OTHERS$exp",
                                                    "FETISH_LACTATION_SELF$exp", "FETISH_ORAL_RECEIVING$exp", "FETISH_ORAL_GIVING$exp", "FETISH_LEG_LOVER$exp",
                                                    "FETISH_STRUTTER$exp", "FETISH_FOOT_GIVING$exp", "FETISH_FOOT_RECEIVING$exp", "FETISH_ARMPIT_GIVING$exp",
                                                    "FETISH_ARMPIT_RECEIVING$exp", "FETISH_CUM_STUD$exp", "FETISH_CUM_ADDICT$exp", "FETISH_DEFLOWERING$exp",
                                                    "FETISH_PURE_VIRGIN$exp", "FETISH_IMPREGNATION$exp", "FETISH_PREGNANCY$exp",
                                                    "FETISH_TRANSFORMATION_GIVING$exp", "FETISH_TRANSFORMATION_RECEIVING$exp", "FETISH_KINK_GIVING$exp",
                                                    "FETISH_KINK_RECEIVING$exp", "FETISH_SADIST$exp", "FETISH_MASOCHIST$exp", "FETISH_NON_CON_DOM$exp",
                                                    "FETISH_NON_CON_SUB$exp", "FETISH_BONDAGE_APPLIER$exp", "FETISH_BONDAGE_VICTIM$exp", "FETISH_DENIAL$exp",
                                                    "FETISH_DENIAL_SELF$exp", "FETISH_VOYEURIST$exp", "FETISH_EXHIBITIONIST$exp", "FETISH_BIMBO$exp",
                                                    "FETISH_CROSS_DRESSER$exp", "FETISH_MASTURBATION$exp", "FETISH_INCEST$exp", "FETISH_SIZE_QUEEN$exp",
                                                    "FETISH_SWITCH$exp", "FETISH_BREEDER$exp", "FETISH_SADOMASOCHIST$exp", "FETISH_LUSTY_MAIDEN$exp"};

    /**
     * String array of ids for all TextFields of double type that would carry over if not reset
     */
    private final String[] resetDoubleTextFieldsIds = {"attributes$HEALTH_MAXIMUM", "attributes$MANA_MAXIMUM",
                                                       "attributes$EXPERIENCE", "attributes$ACTION_POINTS", "attributes$AROUSAL", "attributes$LUST",
                                                       "attributes$RESTING_LUST", "attributes$MAJOR_PHYSIQUE", "attributes$MAJOR_ARCANE",
                                                       "attributes$MAJOR_CORRUPTION", "attributes$ENCHANTMENT_LIMIT", "attributes$FERTILITY", "attributes$VIRILITY",
                                                       "attributes$SPELL_COST_MODIFIER", "attributes$CRITICAL_DAMAGE", "attributes$ENERGY_SHIELDING",
                                                       "attributes$RESISTANCE_PHYSICAL", "attributes$RESISTANCE_LUST", "attributes$RESISTANCE_FIRE",
                                                       "attributes$RESISTANCE_ICE", "attributes$RESISTANCE_POISON", "attributes$DAMAGE_UNARMED",
                                                       "attributes$DAMAGE_MELEE_WEAPON", "attributes$DAMAGE_RANGED_WEAPON", "attributes$DAMAGE_SPELLS",
                                                       "attributes$DAMAGE_PHYSICAL", "attributes$DAMAGE_LUST", "attributes$DAMAGE_FIRE", "attributes$DAMAGE_ICE",
                                                       "attributes$DAMAGE_POISON"};

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
    private final ObservableList<Attribute> hairStylesFL = FXCollections.observableArrayList();

    /**
     * ObservableList of all desire types in the game
     */
    private final ObservableList<Attribute> desireTypes = FXCollections.observableArrayList();

    /**
     * ObservableList of all the damage types in the game
     */
    private final ObservableList<Attribute> damageTypes = FXCollections.observableArrayList(
            new Attribute("Physical", "PHYSICAL"), new Attribute("Fire", "FIRE"),
            new Attribute("Ice", "ICE"), new Attribute("Poison", "POISON"));

    /**
     * HashMap of all the secondary labels' TextField's id (key) and the corresponding ArrayList of values (value)
     */
    private final HashMap<String, ArrayList<String>> labelMap = new HashMap<>();

    /**
     * ArrayList of all perks in the game
     */
    private final ArrayList<PerkNode> perks = new ArrayList<>();

    /**
     * ArrayList of all TextObjectListeners used
     */
    private final ArrayList<TextObjectListener> listeners = new ArrayList<>();

    private final ArrayList<InventoryItem> inventoryItems = new ArrayList<>();

    private final ArrayList<InventoryClothing> inventoryClothes = new ArrayList<>();

    private final ArrayList<InventoryWeapon> inventoryWeapons = new ArrayList<>();

    /**
     * HashMap of all personality traits (key) and the corresponding PersonalityTrait object (value)
     */
    private final HashMap<String, PersonalityTrait> personalityTraits = new HashMap<>();

    /**
     * ArrayList to hold all the ObservableList objects to make it easier to add them to their respective ComboBoxes
     */
    private final ArrayList<ObservableList<Attribute>> comboBoxValues = new ArrayList<>();

    /**
     * Initializes the Controller object and parses config.ini
     *
     * @throws IOException If config.ini cannot be properly read
     */
    public void initialize() throws IOException{
        prop = new Properties();
        FileInputStream in;
        try{
            in = new FileInputStream("config.ini");
        }
        catch(FileNotFoundException e){
            //Uses working directory as default file path
            prop.setProperty("defaultFilePath", Paths.get(".").toAbsolutePath().normalize().toString());
            prop.store(new FileOutputStream("config.ini"), null);
            in = new FileInputStream("config.ini");
        }
        prop.load(in);
        InitializeElements initializer = new InitializeElements();
        initializer.getLabelMap().forEach(labelMap::putIfAbsent);
        initializer.getPersonalityTraits().forEach(personalityTraits::putIfAbsent);
        comboBoxValues.addAll(initializer.getComboBoxValues());
        perks.addAll(initializer.getPerks());
        initializer.initializeHairStyles(hairStylesB, hairStylesVS, hairStylesS, hairStylesSL, hairStylesL, hairStylesFL);
        desireTypes.addAll(initializer.getDesireTypes());
    }

    /**
     * Class that detects focus loss for TextFields
     */
    private class TextObjectListener implements ChangeListener<Boolean>{

        /**
         * TextInputControl descendant to monitor
         */
        private final TextInputControl textInputControl;

        /**
         * Data type of the TextField (e.g. int, double, string, etc.)
         */
        private final TextFieldType tfType;

        /**
         * Id of the TextField
         */
        private String fieldId;

        /**
         * Boolean of whether int and doubles types are only positive values
         */
        private boolean positiveOnly;

        /**
         * Boolean representing whether the TextInputControl object is for fetish exp values
         */
        private final boolean fetishExp;

        /**
         * Boolean representing whether the TextInputControl object has a second label
         */
        private final boolean hasSecondLabel;

        private final boolean inventoryElement;

        /**
         * Constructor for a new TextFieldListener
         *
         * @param textControl   TextInputControl descendant to monitor
         * @param textFieldType Data type of the TextField
         */
        public TextObjectListener(TextInputControl textControl, TextFieldType textFieldType){
            textInputControl = textControl;
            tfType = textFieldType;
            fieldId = textControl.getId();
            hasSecondLabel = labelMap.containsKey(fieldId);
            positiveOnly = false;
            fetishExp = fieldId.startsWith("FETISH_");
            inventoryElement = fieldId.contains("InInventory");
            setLabel();
            listeners.add(this);
        }

        /**
         * Constructor for a new TextFieldListener
         *
         * @param textControl   TextInputControl descendant to monitor
         * @param textFieldType Data type of the TextField
         * @param positivesOnly Whether values are positive only
         */
        public TextObjectListener(TextInputControl textControl, TextFieldType textFieldType, boolean positivesOnly){
            this(textControl, textFieldType);
            positiveOnly = positivesOnly;
        }

        /**
         * Detects when the TextField has lost focus
         *
         * @param observable (Taken from StackOverflow, so I'm not too sure what each parameter is for lol)
         * @param oldValue   (Same)
         * @param newValue   (Same)
         */
        @Override
        public void changed(ObservableValue<? extends Boolean> observable, Boolean oldValue, Boolean newValue){
            if(!newValue && fieldsSet){  // check if focus gained or lost and that the fields initially have the proper value
                textInputControl.setText(getFormattedText(textInputControl.getText()));
                setLabel();
            }
        }

        /**
         * Sets the value of the secondary value if the TextInputControl object has a secondary label
         */
        private void setLabel(){
            if(hasSecondLabel){
                Label valueLabel = (Label) namespace.get(fieldId + "$label");
                String textValue = textInputControl.getText();
                int valueToTextIndex = textValue.contains(".") ? (int) (Double.parseDouble(textValue) * 4) : Integer.parseInt(textValue);
                ArrayList<String> valueToTextList = labelMap.get(fieldId);
                if(valueToTextIndex >= valueToTextList.size()){
                    valueToTextIndex = valueToTextList.size() - 1;
                }
                else if(valueToTextIndex < 0){
                    valueToTextIndex = 0;
                }
                valueLabel.setText(valueToTextList.get(valueToTextIndex));
            }
        }

        /**
         * Verifies that the text is being changed appropriately based on the data type expected in the TextField and
         * modifies the xml data if a valid String was entered
         *
         * @param newValue String entered into the TextField
         * @return Either the new String (with minor modifications if needed) or a String of the old value
         */
        private String getFormattedText(String newValue){
            updateFieldId();
            Node value = getValueNode();
            if(value == null && fetishExp){
                NodeList attributeNodes = getAttributeNodes();
                Node fetishExp = ((Element) attributeNodes).getElementsByTagName("fetishExperience").item(0);
                Element fetishEntry = saveFile.createElement("entry");
                fetishEntry.setAttribute("experience", "0");
                fetishEntry.setAttribute("fetish", fieldId.split("\\$")[0]);
                fetishExp.appendChild(fetishEntry);
                value = getAttributeNode(fetishEntry, "experience");
                System.out.println("Created new element");
            }
            assert value != null;
            String oldValue = value.getTextContent();
            switch(tfType){
                case INT -> {
                    try{
                        int nv = Integer.parseInt(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(positiveOnly && nv < 0){
                            return oldValue;
                        }
                        if(nv == 0 && fetishExp){
                            Node ownerNode = ((Attr) value).getOwnerElement();
                            removeNode(ownerNode);
                            System.out.println("Removed element");
                        }
                        else{
                            if(inventoryElement){
                                int index = Integer.parseInt(fieldId.split("\\$")[3]);
                                if(fieldId.contains("itemsInInventory")){
                                    inventoryItems.get(index).setCount(newValue);
                                }
                                else if(fieldId.contains("clothingInInventory")){
                                    inventoryClothes.get(index).setCount(newValue);
                                }
                                else if(fieldId.contains("weaponsInInventory")){
                                    inventoryWeapons.get(index).setCount(newValue);
                                }
                            }
                            else{
                                value.setTextContent(newValue);
                            }
                        }
                        return newValue;
                    }
                    catch(NumberFormatException e){
                        return oldValue;
                    }
                }
                case DOUBLE -> {
                    try{
                        double nv = Double.parseDouble(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(positiveOnly && nv < 0){
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
                    catch(NumberFormatException e){
                        return oldValue;
                    }
                }
                case STRING -> {
                    value.setTextContent(newValue);
                    return newValue;
                }
                case HAIR -> {
                    try{
                        int nv = Integer.parseInt(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(nv < 0){
                            return oldValue;
                        }
                        value.setTextContent(newValue);
                        @SuppressWarnings("unchecked")
                        ComboBox<Attribute> hairStyles = (ComboBox<Attribute>) namespace.get("body$hair$hairStyle");
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
                    catch(NumberFormatException e){
                        return oldValue;
                    }
                }
                case DATE -> {
                    try{
                        boolean coreInfo = fieldId.startsWith("coreInfo");
                        @SuppressWarnings("unchecked")
                        ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(coreInfo ? "coreInfo$date$month" : "core$monthOfBirth$value");
                        TextField yearField = (TextField) namespace.get(coreInfo ? "coreInfo$date$year" : "core$yearOfBirth$value");
                        int year = Integer.parseInt(yearField.getText());
                        int monthLimit = setMonthLimit(cb.getValue(), year);
                        int nv = Integer.parseInt(newValue);
                        newValue = "" + nv; //Removes leading zeroes
                        if(nv < 1){
                            return oldValue;
                        }
                        if(nv > monthLimit){
                            return oldValue;
                        }
                        value.setTextContent(newValue);
                        return newValue;
                    }
                    catch(NumberFormatException e){
                        return oldValue;
                    }
                }
                default -> {
                    return null;
                }
            }
        }

        /**
         * Gets the Node of the attribute value of the TextField
         *
         * @return Node containing the attribute value
         */
        private Node getValueNode(){
            String[] id = fieldId.split("\\$");
            NodeList attributeNodes = getAttributeNodes();
            if(id[0].startsWith("FETISH_")){
                NodeList fetishes = ((Element) attributeNodes).getElementsByTagName("fetishExperience").item(0).getChildNodes();
                Node childNode = getChildNodeByAttributeValue(fetishes, "fetish", id[0]);
                return childNode != null ? getAttributeNode(childNode, "experience") : null;
            }
            Element attr = (Element) ((Element) attributeNodes).getElementsByTagName(id[0]).item(0);
            switch(id[0]){
                case "characterRelationships" -> {
                    return attr.getChildNodes().item(Integer.parseInt(id[2])).getAttributes().getNamedItem("value");
                }
                case "spellUpgradePoints" -> {
                    return Objects.requireNonNull(getChildNodeByAttributeValue(attr.getChildNodes(), "school", id[1])).getAttributes().getNamedItem("points");
                }
                case "attributes" -> {
                    Element attributeNode = (Element) getChildNodeByAttributeValue(attr.getChildNodes(), "type", id[1]);
                    if(attributeNode == null){
                        attributeNode = saveFile.createElement("attribute");
                        attributeNode.setAttribute("type", id[1]);
                        attributeNode.setAttribute("value", "0.0");
                        attr.appendChild(attributeNode);
                        System.out.println("Created attribute node");
                    }
                    return attributeNode.getAttributeNode("value");
                }
                case "coreInfo", "dialogueFlags" -> {
                    Element attributeNode = (Element) saveFile.getElementsByTagName(id[0]).item(0);
                    for(int i = 1; i < id.length - 1; i++){
                        attributeNode = (Element) attributeNode.getElementsByTagName(id[i]).item(0);
                    }
                    return attributeNode.getAttributeNode(id[id.length - 1]);
                }
                case "characterInventory" -> {
                    switch(id[1]){
                        case "itemsInInventory" -> {
                            //id[3] should be a number corresponding to ArrayList index and id[2] should be attribute Node name
                            return inventoryItems.get(Integer.parseInt(id[3])).getNode().getAttributeNode(id[2]);
                        }
                        case "clothingInInventory" -> {
                            return inventoryClothes.get(Integer.parseInt(id[3])).getNode().getAttributeNode(id[2]);
                        }
                        case "weaponsInInventory" -> {
                            return inventoryWeapons.get(Integer.parseInt(id[3])).getNode().getAttributeNode(id[2]);
                            /*Node inventoryTypeNode = attr.getElementsByTagName(id[1]).item(0);
                            Node inventorySlotNode = getChildNodeByAttributeValue(inventoryTypeNode.getChildNodes(), "id", id[3], "colour", id[4]);
                            assert inventorySlotNode != null;
                            return inventorySlotNode.getAttributes().getNamedItem(id[2]);*/
                        }
                    }
                }
            }
            attr = (Element) attr.getElementsByTagName(id[1]).item(0);
            return getAttributeNode(attr, id[2]);
        }

        private void updateFieldId(){
            if(inventoryElement && !fieldId.equals(textInputControl.getId())){
                fieldId = textInputControl.getId();
            }
        }
    }

    /**
     * Sets stage to supplied Stage object in order for events to work properly
     *
     * @param s Stage object to be used
     */
    public void setStage(Stage s){
        stage = s;
    }

    /**
     * Sets namespace to the namespace of the fxml file
     *
     * @param namespace Namespace of the fxml file
     */
    public void setNamespace(ObservableMap<String, Object> namespace){
        this.namespace = namespace;
        PerkNode.setNamespace(namespace);
        PersonalityTrait.setNamespace(namespace);
        //Disables TabPane so user cannot use the editor without loading a file first (gets re-enabled in the loadFile method)
        TabPane tb = (TabPane) namespace.get("tabPane");
        tb.setDisable(true);
    }

    /**
     * Sets version to the current version number of this save editor
     *
     * @param currentVersion Current version of save editor
     */
    public void setVersion(String currentVersion){
        version = currentVersion;
    }

    /**
     * Initializes all the ComboBoxes by setting the items (i.e. ObservableList<\String> objects) of each ComboBox
     */
    public void initializeComboBoxes(){
        for(int i = 0; i < ComboBoxIds.length; i++){
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(ComboBoxIds[i]);
            cb.setItems(comboBoxValues.get(i));
            if(comboBoxValues.get(i) == desireTypes){
                cb.setValue(cb.getItems().get(2));
            }
            else{
                cb.setValue(cb.getItems().get(0));
            }

            cb.setConverter(new StringConverter<>(){
                @Override
                public String toString(Attribute attribute){
                    return attribute.getName();
                } //TODO: Fix this method throwing exceptions whenever ComboBox values are updated
                /* This exception keeps getting thrown when ComboBox items are changed; Ignore as it doesn't break the program
                    Exception in thread "JavaFX Application Thread" java.lang.NullPointerException
	                    at LTSaveEd.Controller$1.toString(Controller.java:2401)
	                    at LTSaveEd.Controller$1.toString(Controller.java:2398)...
                 */

                @Override
                public Attribute fromString(String s){
                    return null;
                }
            });
        }
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get("body$leg$type");
        updateLegTypeDependants(cb, true);
    }

    /**
     * Opens a file selector so that the user can select their save .xml file they want to edit
     *
     * @param event Action event performed
     * @throws IOException If config.ini cannot be properly written to
     */
    @FXML
    private void loadFile(ActionEvent event) throws IOException{
        event.consume();
        //Get file
        FileChooser fc = new FileChooser();
        FileChooser.ExtensionFilter fileExtensions = new FileChooser.ExtensionFilter("XML files (*.xml)", "*.xml");
        fc.getExtensionFilters().add(fileExtensions);
        String currentPath = prop.getProperty("defaultFilePath");
        fc.setInitialDirectory(new File(currentPath));
        File f = fc.showOpenDialog(stage);
        if(f != null){
            //Update config.ini if a different folder was used
            if(!f.getParent().equals(currentPath)){
                prop.setProperty("defaultFilePath", f.getParent());
                prop.store(new FileOutputStream("config.ini"), null);
            }
            workingFile = f;
            //Load XML
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            try(InputStream is = new FileInputStream(f)){
                DocumentBuilder db = dbf.newDocumentBuilder();
                saveFile = db.parse(is);
                PerkNode.setSaveFile(saveFile);
                PersonalityTrait.setSaveFile(saveFile);
                System.out.println(f);
                fileLoaded = true;
                worldFieldsSet = false;
                TabPane tb = (TabPane) namespace.get("tabPane");
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
    private void loadCharacterSelector(){
        NpcCharacter player = new NpcCharacter("PlayerCharacter");
        ObservableList<NpcCharacter> characterList = FXCollections.observableArrayList(player);
        NodeList npcList = saveFile.getElementsByTagName("NPC");
        for(int i = 0; i < npcList.getLength(); i++){
            characterList.add(new NpcCharacter(npcList.item(i)));
        }
        NpcCharacter nullCharacter = new NpcCharacter("");
        ObservableList<NpcCharacter> parentList = FXCollections.observableArrayList(nullCharacter);
        parentList.addAll(characterList);
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> motherIds = (ComboBox<NpcCharacter>) namespace.get("family$motherId$value");
        motherIds.setItems(parentList);
        motherIds.setValue(player);
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> fatherIds = (ComboBox<NpcCharacter>) namespace.get("family$fatherId$value");
        fatherIds.setItems(parentList);
        fatherIds.setValue(player);
        setCharacterNode("PlayerCharacter");
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> characterSelector = (ComboBox<NpcCharacter>) namespace.get("characterSelector");
        characterSelector.setItems(characterList);
        characterSelector.setValue(player);
        ArrayList<ComboBox<NpcCharacter>> comboBoxes = new ArrayList<>(Arrays.asList(characterSelector, motherIds, fatherIds));
        for(ComboBox<NpcCharacter> comboBox : comboBoxes){
            comboBox.setConverter(new StringConverter<>(){
                @Override
                public String toString(NpcCharacter npcCharacter){
                    return npcCharacter.getName();
                }

                @Override
                public NpcCharacter fromString(String s){
                    return null;
                }
            });
        }
    }

    /**
     * Changes the current character to be edited to the character selected by the character selector
     *
     * @param event ActionEvent from the character selector ComboBox
     */
    @FXML
    private void selectCharacter(ActionEvent event){
        event.consume();
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> cb = (ComboBox<NpcCharacter>) namespace.get("characterSelector");
        String charId = cb.getValue().getId();
        setCharacterNode(charId);
        Button btn = (Button) namespace.get("deleteCharacter");
        btn.setVisible(!charId.equals("PlayerCharacter") && !charId.startsWith("-1"));
        setFields();
    }

    /**
     * Changes that current character to be edited to the character specified by the given id
     * <p>
     * Because of the onAction method on the character selector ComboBox, just by changing the current value of the
     * ComboBox, the corresponding function will be called
     *
     * @param characterId Character id of the new character to edit
     */
    private void setCharacter(String characterId){
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> cb = (ComboBox<NpcCharacter>) namespace.get("characterSelector");
        ObservableList<NpcCharacter> charList = cb.getItems();
        cb.setValue(matchNpc(charList, characterId));
    }

    /**
     * Helper method to get fx:id of the object that was interacted with
     *
     * @param event ActionEvent from the object that was interacted with
     * @return String of the id of the object that was interacted with
     */
    private String getId(ActionEvent event){
        return ((javafx.scene.Node) event.getSource()).getId();
    }

    /**
     * Gets the list of immediate child Nodes of the selected character's characterNode
     *
     * @return NodeList of immediate child Nodes (eg. core, body, attributes, etc.)
     */
    private NodeList getAttributeNodes(){
        return characterNode.getChildNodes();
    }

    /**
     * Sets characterNode to the character Node of the current character that is being edited
     *
     * @param charId Character id of the character being edited
     */
    private void setCharacterNode(String charId){
        Node idNode = getNodeByIdValue(charId);
        assert idNode != null;
        characterNode = idNode.getParentNode().getParentNode();
        Node perksNode = getNode("perks");
        PerkNode.setPerksNode(perksNode);
        Node personalityNode = getNode("core", "personality");
        PersonalityTrait.setPersonalityNode(personalityNode);
    }

    /**
     * Gets the Node of the attribute by reverse tracing the id (Id Format: parent$child$attribute or parent$child$modifier$attribute)
     *
     * @param event ActionEvent of the element that was interacted with
     * @return Node containing the attribute value
     */
    private Node getValueNode(ActionEvent event){
        String[] id = getId(event).split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        if(id[0].startsWith("FETISH_")){ //Fetish ids cannot be reverse traced, so they must be handled differently
            if(id[1].equals("owned")){
                NodeList fetishes = attr.getElementsByTagName("fetishes").item(0).getChildNodes();
                return getChildNodeByAttributeValue(fetishes, "type", id[0]);
            }
            else if(id[1].equals("desire")){
                NodeList fetishes = attr.getElementsByTagName("fetishDesire").item(0).getChildNodes();
                Node fetishEntry = getChildNodeByAttributeValue(fetishes, "fetish", id[0]);
                return fetishEntry != null ? getAttributeNode(fetishEntry, "desire") : null;
            }
        }
        else if(id[0].equals("spells")){ //Same with spell ids
            NodeList spellUpgrades = attr.getElementsByTagName("spellUpgrades").item(0).getChildNodes();
            return getChildNodeByAttributeValue(spellUpgrades, "type", id[1]);
        }
        else if(id[0].equals("coreInfo")){
            Element coreInfo = (Element) saveFile.getElementsByTagName(id[0]).item(0);
            Element date = (Element) coreInfo.getElementsByTagName(id[1]).item(0);
            return date.getAttributeNode(id[2]);
        }
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return getAttributeNode(attr, id[id.length - 1]);
    }

    /**
     * Gets the Node of the attribute by reverse tracing the id (Id Format: parent$child$attribute)
     *
     * @param objId Id of the element that was interacted with
     * @return Node containing the attribute value
     */
    private Node getValueNode(String objId){
        String[] id = objId.split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return getAttributeNode(attr, id[id.length - 1]);
    }

    /**
     * Gets the String value of the attribute of the given Node
     *
     * @param node Node to get the attribute of
     * @param attr Attribute to get
     * @return String containing the attribute value
     */
    private String getAttributeValue(Node node, String attr){
        return node.getAttributes().getNamedItem(attr).getTextContent();
    }

    /**
     * Gets the Node of the specified attribute of the given Node
     *
     * @param node Node to get the attribute of
     * @param attr Attribute to get
     * @return Node containing the attribute Node
     */
    private Node getAttributeNode(Node node, String attr){
        return node.getAttributes().getNamedItem(attr);
    }

    /**
     * Gets the parent Node of the Node with the attribute specified by the id
     *
     * @param event ActionEvent of the element that was interacted with
     * @return Node that is the parent of the Node with the specified attribute
     */
    private Node getValueNodeParent(ActionEvent event){
        String[] id = getId(event).split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        if(id[0].startsWith("FETISH_")){ //Fetish ids cannot be reverse traced, so they must be handled differently
            if(id[1].equals("owned")){
                return attr.getElementsByTagName("fetishes").item(0);
            }
            else if(id[1].equals("desire")){
                return attr.getElementsByTagName("fetishDesire").item(0);
            }
        }
        else if(id[0].equals("spells")){ //Same with spell ids
            return attr.getElementsByTagName("spellUpgrades").item(0);
        }
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return attr;
    }

    /**
     * Gets the parent Node of the Node with the attribute specified by the id
     *
     * @param objId Id of the element that was interacted with
     * @return Node that is the parent of the Node with the specified attribute
     */
    private Node getValueNodeParent(String objId){
        String[] id = objId.split("\\$");
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(int i = 0; i < id.length - 1; i++){
            attr = (Element) attr.getElementsByTagName(id[i]).item(0);
        }
        return attr;
    }

    /**
     * Gets a Node from a NodeList based on specified attribute and value of attribute
     *
     * @param children NodeList to check
     * @param args     Attribute/Value pairs to check for (must have Attribute, followed by value to match for each pair)
     * @return Desired Node if found else null
     * @throws IllegalArgumentException if number of String arguments is not a multiple of 2
     */
    private Node getChildNodeByAttributeValue(NodeList children, String... args){
        if(args.length % 2 != 0){
            throw new IllegalArgumentException();
        }
        for(int i = 0; i < children.getLength(); i++){
            if(children.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            boolean found = true;
            for(int j = 0; j < args.length; j += 2){
                if(!getAttributeValue(children.item(i), args[j]).equals(args[j + 1])){
                    found = false;
                    break;
                }
            }
            if(found){
                return children.item(i);
            }
        }
        return null;
    }

    /**
     * Get a specific Node by supplying all Nodes from the Character Node to the desired Node
     *
     * @param args String array to traverse in order to get to the desired Node
     * @return Desired Node if found else null
     */
    private Node getNode(String... args){
        NodeList attributeNodes = getAttributeNodes();
        Element attr = (Element) attributeNodes;
        for(String arg : args){
            if(arg.equals(args[args.length - 1])){
                Element tempAttr = (Element) attr.getElementsByTagName(arg).item(0);
                if(tempAttr == null){
                    return attr.getAttributeNode(arg);
                }
                else{
                    return tempAttr;
                }
            }
            else{
                attr = (Element) attr.getElementsByTagName(arg).item(0);
            }
        }
        return null;
    }

    /**
     * Updates xml boolean values changed by CheckBoxes
     *
     * @param event ActionEvent from the CheckBox that was changed
     */
    @FXML
    private void updateXmlBoolean(ActionEvent event){
        if(fieldsSet){
            String fxId = getId(event);
            if(fxId.contains("InInventory")){
                String[] id = fxId.split("\\$");
                int index = Integer.parseInt(id[3]);
                switch(id[2]){
                    case "enchantmentKnown" -> inventoryClothes.get(index).updateEnchantmentKnown();
                    case "isDirty" -> inventoryClothes.get(index).updateDirty();
                }
            }
            else{
                CheckBox cb = (CheckBox) namespace.get(fxId);
                Node value = getValueNode(event);
                if(fxId.startsWith("FETISH_")){
                    if(!cb.isSelected()){
                        assert value != null;
                        removeNode(value);
                        System.out.println("Removed fetish");
                    }
                    else{
                        Element fetish = saveFile.createElement("fetish");
                        fetish.setAttribute("type", fxId.split("\\$")[0]);
                        Node fetishes = getValueNodeParent(event);
                        fetishes.appendChild(fetish);
                        System.out.println("Added fetish");
                    }
                }
                else if(fxId.startsWith("spells")){
                    if(cb.isSelected()){
                        Element spellUpgrade = saveFile.createElement("upgrade");
                        spellUpgrade.setAttribute("type", fxId.split("\\$")[1]);
                        Node spellUpgrades = getValueNodeParent(event);
                        spellUpgrades.appendChild(spellUpgrade);
                        System.out.println("Added spell upgrade");
                    }
                    else{
                        assert value != null;
                        removeNode(value);
                        System.out.println("Removed spell upgrade");
                    }
                }
                else{
                    try{
                        assert value != null;
                        value.setTextContent("" + cb.isSelected());
                    }
                    catch(NullPointerException e){ //Modifier attributes are deleted when false by the game
                        value = getValueNodeParent(event);
                        ((Element) value).setAttribute(fxId.split("\\$")[3], "" + cb.isSelected());
                    }
                    String[] idParts = fxId.split("\\$");
                    if(idParts[idParts.length - 1].equals("FLARED") || idParts[idParts.length - 1].equals("TAPERED")){
                        checkboxFlaredTaperedToggle(fxId);
                    }
                }
            }
            event.consume();
        }
    }

    /**
     * Sets the CheckBox of the other value to false if one CheckBox is set to true (i.e. either flared or tapered can be true, but not both)
     *
     * @param id Id of the CheckBox set to true
     */
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
        target = (CheckBox) namespace.get(targetId);
        target.setSelected(false);
        Node value = getValueNode(targetId);
        try{
            value.setTextContent("" + target.isSelected());
        }
        catch(NullPointerException e){
            value = getValueNodeParent(id);
            ((Element) value).setAttribute(id.split("\\$")[3], "" + target.isSelected());
        }

    }

    /**
     * Updates xml values changed by ComboBoxes
     *
     * @param event ActionEvent from the ComboBox that was changed
     */
    @FXML
    private void updateXmlComboBox(ActionEvent event){
        if(fieldsSet){
            String fxId = getId(event);
            if(fxId.contains("InInventory")){
                String[] id = fxId.split("\\$");
                int index = Integer.parseInt(id[3]);
                inventoryWeapons.get(index).updateDamageType();
            }
            else{
                @SuppressWarnings("unchecked")
                ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(fxId);
                Node value = getValueNode(event);
                if(value == null){
                    if(fxId.startsWith("FETISH_")){
                        Element fetishEntry = saveFile.createElement("entry");
                        fetishEntry.setAttribute("desire", cb.getValue().getValue());
                        fetishEntry.setAttribute("fetish", fxId.split("\\$")[0]);
                        value = getValueNodeParent(event);
                        value.appendChild(fetishEntry);
                    }
                }
                else{
                    value.setTextContent(cb.getValue().getValue());
                    if(fxId.equals("body$leg$type")){
                        updateLegTypeDependants(cb, false);
                    }
                }
                if(fxId.contains("month")){
                    updateDayTextField(fxId, cb.getValue());
                }
                event.consume();
            }
        }
    }

    /**
     * Updates the day TextField value if the value is greater than the number of days in the given month
     *
     * @param fxId  Id of the ComboBox
     * @param month Month Attribute to check against
     */
    private void updateDayTextField(String fxId, Attribute month){
        boolean coreInfo = fxId.startsWith("coreInfo");
        String dayId = coreInfo ? "coreInfo$date$dayOfMonth" : "core$dayOfBirth$value";
        TextField dayField = (TextField) namespace.get(dayId);
        TextField yearField = (TextField) namespace.get(coreInfo ? "coreInfo$date$year" : "core$yearOfBirth$value");
        int year = Integer.parseInt(yearField.getText());
        int monthLimit = setMonthLimit(month, year);
        int dayValue = Integer.parseInt(dayField.getText());
        if(dayValue > monthLimit){
            dayField.setText("" + monthLimit);
            Node dayNode = getWorldNode(dayId.split("\\$"));
            assert dayNode != null;
            dayNode.setTextContent("" + monthLimit);
        }
    }

    /**
     * Gets a specific Node by supplied all nodeNames from game Node to desired Node
     *
     * @param args String array of nodeNames to traverse in order to get to the desired Node
     * @return Desired Node if found else null
     */
    private Node getWorldNode(String... args){
        Element node = (Element) saveFile.getElementsByTagName(args[0]).item(0);
        for(int i = 1; i < args.length; i++){
            if(i == args.length - 1){
                Element tempNode = (Element) node.getElementsByTagName(args[i]).item(0);
                if(tempNode == null){
                    return node.getAttributeNode(args[i]);
                }
                else{
                    return tempNode;
                }
            }
            else{
                node = (Element) node.getElementsByTagName(args[i]).item(0);
            }
        }
        return null;
    }

    /**
     * Sets the max day value based on the month
     *
     * @param month Month Attribute to check against
     * @param year  Year integer to check for leap year
     * @return int representing the max days based on the month
     */
    private int setMonthLimit(Attribute month, int year){
        int monthLimit;
        if(month.equals("JANUARY") || month.equals("MARCH") || month.equals("MAY") ||
                month.equals("JULY") || month.equals("AUGUST") || month.equals("OCTOBER") ||
                month.equals("DECEMBER") || month.equals("1") || month.equals("3") || month.equals("5") ||
                month.equals("7") || month.equals("8") || month.equals("10") ||
                month.equals("12")){
            monthLimit = 31;
        }
        else if(month.equals("APRIL") || month.equals("JUNE") || month.equals("SEPTEMBER") ||
                month.equals("NOVEMBER") || month.equals("4") || month.equals("6") || month.equals("9") ||
                month.equals("11")){
            monthLimit = 30;
        }
        else{ //February
            monthLimit = isLeapYear(year) ? 29 : 28;
        }
        return monthLimit;
    }

    /**
     * Checks if the given year is a leap year
     *
     * @param year Year to check
     * @return True if year is a leap year else false
     */
    public boolean isLeapYear(int year){ //Hopefully this handles all edge cases
        Calendar cal = Calendar.getInstance();
        cal.set(Calendar.YEAR, year);
        return cal.getActualMaximum(Calendar.DAY_OF_YEAR) > 365;
    }

    /**
     * Updates xml values changed by SpellTier ComboBoxes
     *
     * @param event ActionEvent from the ComboBox that was changed
     */
    @FXML
    private void updateXmlComboBoxSpells(ActionEvent event){
        if(fieldsSet){
            String fxId = getId(event);
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(fxId);
            SpellTier tier = (SpellTier) cb.getValue();
            switch(tier.getTier()){
                case -1 -> { //Unowned Spell
                    NodeList knownSpells = Objects.requireNonNull(getNode("knownSpells")).getChildNodes(); //Removes base spells
                    for(int i = 0; i < knownSpells.getLength(); i++){
                        if(knownSpells.item(i).getNodeType() != Node.ELEMENT_NODE){
                            continue;
                        }
                        Node spell = knownSpells.item(i);
                        System.out.println(spell);
                        Debug.printList(spell.getAttributes());
                        if(getAttributeValue(spell, "type").equals(tier.getType())){
                            removeNode(spell);
                            break;
                        }
                    }
                    removeHigherTierSpells(tier, false);
                }
                case 0 -> { //Base Spell
                    addBaseSpell(tier);
                    removeHigherTierSpells(tier, true);
                }
                case 1, 2 -> { //Upgrades 1 and 2
                    addBaseSpell(tier);
                    removeHigherTierSpells(tier, true);
                    addLowerTierSpells(tier);
                }
                case 3 -> { //Upgrade 3 (branching in the case of Elemental spell or 3A in the case of Steal spell)
                    addBaseSpell(tier);
                    if(tier.getType().equals("STEAL")){
                        removeHigherTierSpells(tier, true);
                    }
                    addLowerTierSpells(tier);
                    changeWithinTierSpells(tier);
                }
                case 4 -> { //Upgrade 3B only used by Steal spell
                    addBaseSpell(tier);
                    addLowerTierSpells(tier);
                }
            }
        }
        event.consume();
    }

    /**
     * Updates xml values changed by PersonalityTrait CheckBoxes
     *
     * @param event ActionEvent from the CheckBox that was changed
     */
    @FXML
    private void updateXmlCheckBoxPersonality(ActionEvent event){
        if(fieldsSet){
            String fxId = getId(event);
            String[] id = fxId.split("\\$");
            CheckBox cb = (CheckBox) namespace.get(fxId);
            PersonalityTrait trait = personalityTraits.get(id[1]);
            trait.setActive(cb.isSelected());
        }
        event.consume();
    }

    /**
     * Update xml values changed by the character selector ComboBox
     *
     * @param event ActionEvent from the ComboBox that was changed
     */
    @FXML
    private void updateXmlComboBoxIds(ActionEvent event){
        if(fieldsSet){
            String fxId = getId(event);
            @SuppressWarnings("unchecked")
            ComboBox<NpcCharacter> cb = (ComboBox<NpcCharacter>) namespace.get(fxId);
            @SuppressWarnings("unchecked")
            String currentCharacterId = ((ComboBox<NpcCharacter>) namespace.get("characterSelector")).getValue().getId();
            Node valueNode = getNode(fxId.split("\\$"));
            assert valueNode != null;
            if(!cb.getValue().getId().equals(currentCharacterId)){
                valueNode.setTextContent(cb.getValue().getId());
            }
            else{
                ObservableList<NpcCharacter> charList = cb.getItems();
                cb.setValue(matchNpc(charList, valueNode.getTextContent()));
            }
        }
    }

    /**
     * Updates xml values changed by PerkNode CheckBoxes
     *
     * @param event ActionEvent from the CheckBox that was changed
     */
    @FXML
    private void updateXmlCheckBoxPerks(ActionEvent event){
        if(fieldsSet){
            String fxId = getId(event);
            System.out.println(fxId);
            String[] id = fxId.split("\\$");
            CheckBox cb = (CheckBox) namespace.get(fxId);
            PerkNode perk = matchPerk(perks, id[1], id[2]);
            assert perk != null;
            System.out.println(perk);
            perk.setActive(cb.isSelected());
        }
        event.consume();
    }

    /**
     * Gets the matching perk from the provided ArrayList
     *
     * @param perkList ArrayList of perks to check
     * @param row      Row value of the perk
     * @param value    Actual value of the perk
     * @return PerkNode that matches the row and value supplied or null if not matched
     */
    private PerkNode matchPerk(ArrayList<PerkNode> perkList, String row, String value){
        for(PerkNode perkNode : perkList){
            if(perkNode.equals(row, value)){
                return perkNode;
            }
        }
        return null;
    }

    /**
     * Adds the spell Node as a child to the knownSpells Node based on the tier type
     *
     * @param tier SpellTier containing the spell type to be added
     */
    private void addBaseSpell(SpellTier tier){
        Node knownSpellsNode = getNode("knownSpells");
        assert knownSpellsNode != null;
        NodeList knownSpells = knownSpellsNode.getChildNodes();
        boolean exists = false;
        for(int i = 0; i < knownSpells.getLength(); i++){
            if(knownSpells.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            Node spell = knownSpells.item(i);
            if(getAttributeValue(spell, "type").equals(tier.getType())){
                exists = true;
                break;
            }
        }
        if(!exists){
            Element baseSpell = saveFile.createElement("spell");
            baseSpell.setAttribute("type", tier.getType());
            knownSpellsNode.appendChild(baseSpell);
        }
    }

    /**
     * Removes spell upgrades with a higher tier than the given SpellTier tier
     *
     * @param tier  SpellTier to check tier against
     * @param owned Removes all spell upgrades if false (i.e. will remove SOOTHING_WATERS_(1/2)_CLEAN as well)
     */
    private void removeHigherTierSpells(SpellTier tier, boolean owned){
        NodeList spellUpgrades = Objects.requireNonNull(getNode("spellUpgrades")).getChildNodes();
        for(int i = 0; i < spellUpgrades.getLength(); i++){
            if(spellUpgrades.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            Node spell = spellUpgrades.item(i);
            String spellType = getAttributeValue(spell, "type");
            if(spellType.startsWith(tier.getType())){
                int upgradeTier = SpellTier.readTier(getAttributeValue(spellUpgrades.item(i), "type"));
                if(tier.getTier() < upgradeTier){
                    if(owned && !spellType.endsWith("CLEAN")){
                        removeNode(spell);
                        i--;
                    }
                    else if(!owned){
                        removeNode(spell);
                        i--;
                    }
                }
            }
        }
    }

    /**
     * Adds spell upgrades with a lower tier than the given SpellTier tier
     *
     * @param tier SpellTier to check tier against
     */
    private void addLowerTierSpells(SpellTier tier){
        Node spellUpgradesNode = getNode("spellUpgrades");
        assert spellUpgradesNode != null;
        NodeList spellUpgrades = spellUpgradesNode.getChildNodes();
        int count = 0;
        for(int i = 0; i < spellUpgrades.getLength(); i++){
            if(spellUpgrades.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            Node spell = spellUpgrades.item(i);
            String spellType = getAttributeValue(spell, "type");
            if(spellType.startsWith(tier.getType())){
                if(!spellType.endsWith("CLEAN")){
                    count++;
                }
            }
        }
        while(count < tier.getTier()){
            count++;
            Element spellUpgrade = saveFile.createElement("upgrade");
            String value = tier.getType() + "_" + count;
            if(tier.getType().equals("STEAL")){
                if(count == 3){
                    value = "STEAL_3A";
                }
                else if(count == 4){
                    value = "STEAL_3B";
                }
            }
            else if(count == tier.getTier()){
                value = tier.getValue();
            }
            spellUpgrade.setAttribute("type", value);
            spellUpgradesNode.appendChild(spellUpgrade);
        }
    }

    /**
     * Changes max tier spell value when switching within the same tier (i.e. 3A to 3B or vice versa)
     *
     * @param tier SpellTier to check value against
     */
    private void changeWithinTierSpells(SpellTier tier){
        if(!tier.getType().equals("STEAL")){
            Node spellUpgradesNode = getNode("spellUpgrades");
            assert spellUpgradesNode != null;
            NodeList spellUpgrades = spellUpgradesNode.getChildNodes();
            String complementTier = getComplementTier(tier);
            for(int i = 0; i < spellUpgrades.getLength(); i++){
                if(spellUpgrades.item(i).getNodeType() != Node.ELEMENT_NODE){
                    continue;
                }
                Node spell = spellUpgrades.item(i);
                if(getAttributeValue(spell, "type").equals(complementTier)){
                    removeNode(spell);
                    Element spellUpgrade = saveFile.createElement("upgrade");
                    spellUpgrade.setAttribute("type", tier.getValue());
                    spellUpgradesNode.appendChild(spellUpgrade);
                    break;
                }
            }
        }
    }

    /**
     * Gets the complement spell tier
     *
     * @param tier SpellTier to check value against
     * @return String spell value ending in "3A" if SpellTier value ended in "3B" and vice versa
     */
    private String getComplementTier(SpellTier tier){
        if(tier.getValue().endsWith("_3A")){
            return tier.getType() + "_3B";
        }
        return tier.getType() + "_3A";
    }

    /**
     * Updates the ComboBoxes of leg configurations, foot structures, and genital arrangements based on the value of the leg types ComboBox
     *
     * @param cb           Leg types ComboBox
     * @param initializing Whether is method is supposed to just initialize the dependant ComboBoxes or edit the values in the save file as well
     */
    private void updateLegTypeDependants(ComboBox<Attribute> cb, boolean initializing){
        LegTypeAttr legType = (LegTypeAttr) cb.getValue();
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> lc = (ComboBox<Attribute>) namespace.get("body$leg$configuration");
        lc.setItems(legType.getLegConfiguration());
        lc.setValue(legType.getDefaultLegConfiguration());
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> fs = (ComboBox<Attribute>) namespace.get("body$leg$footStructure");
        fs.setItems(legType.getFootStructure());
        fs.setValue(legType.getDefaultFootStructure());
        @SuppressWarnings("unchecked")
        ComboBox<Attribute> ga = (ComboBox<Attribute>) namespace.get("body$bodyCore$genitalArrangement");
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
     * Resets the values of Fields that would carry over if not reset
     */
    private void resetFields(){
        fieldsSet = false;
        for(String resetIntTextFieldsId : resetIntTextFieldsIds){
            TextField tf = (TextField) namespace.get(resetIntTextFieldsId);
            tf.setText("0");
        }
        for(String resetDoubleTextFieldsId : resetDoubleTextFieldsIds){
            TextField tf = (TextField) namespace.get(resetDoubleTextFieldsId);
            tf.setText("0.0");
        }
        for(String resetComboBoxId : resetComboBoxIds){
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(resetComboBoxId);
            ObservableList<Attribute> items = cb.getItems();
            if(resetComboBoxId.startsWith("FETISH")){
                cb.setValue(items.get(2));
            }
            else{
                cb.setValue(items.get(0));
            }
        }
        for(String resetCheckBoxId : resetCheckBoxIds){
            CheckBox cb = (CheckBox) namespace.get(resetCheckBoxId);
            cb.setSelected(false);
        }
    }

    /**
     * Updates all secondaryLabels
     */
    private void updateLabels(){
        for(TextObjectListener listener : listeners){
            listener.setLabel();
        }
    }

    /**
     * Reads data from xml save file and sets all fields with the selected character data
     */
    private void setFields(){
        if(fileLoaded){
            resetFields();
            System.out.println("Fields Reset");
            if(!worldFieldsSet){
                setWorldFields();
                worldFieldsSet = true;
            }
            NodeList attributeNodes = getAttributeNodes();
            Debug.printList(attributeNodes);
            System.out.println(attributeNodes.item(1).getParentNode());
            MainLoop:
            for(int i = 0; i < attributeNodes.getLength(); i++){
                if(attributeNodes.item(i).getNodeType() != Node.ELEMENT_NODE){
                    continue;
                } // Only care about Element Nodes
                NodeList attributeElements = attributeNodes.item(i).getChildNodes();
                String attributeName = attributeNodes.item(i).getNodeName();
                switch(attributeName){
                    case "locationInformation", "lipstickMarks", "tattoos", "potionAttributes", "traits",
                            "specialPerks", "statusEffects", "knownMoves", "equippedMoves" -> {
                        continue;
                    }
                    case "slavery" -> { //Ends the loop early as all the needed data has been parsed //Adjust as needed
                        break MainLoop;
                    }
                    case "characterRelationships" -> {  //These parts have an unknown number of elements which have identical tags
                        setFieldsRelationships(attributeNodes.item(i));
                        System.out.println("Character Relationship Fields Set");
                        continue;
                    }
                    case "fetishes" -> {
                        setFieldsFetishes(attributeNodes.item(i));
                        System.out.println("Fetish Fields Set");
                        continue;
                    }
                    case "fetishDesire" -> {
                        setFieldsFetishDesires(attributeNodes.item(i));
                        System.out.println("Fetish Desire Fields Set");
                        continue;
                    }
                    case "fetishExperience" -> {
                        setFieldsFetishExperience(attributeNodes.item(i));
                        System.out.println("Fetish Experience Fields Set");
                        continue;
                    }
                    case "knownSpells" -> {
                        setFieldsKnownSpells(attributeNodes.item(i));
                        System.out.println("Known Spell Fields Set");
                        continue;
                    }
                    case "spellUpgrades" -> {
                        setFieldsSpellUpgrades(attributeNodes.item(i));
                        System.out.println("Spell Upgrade Fields Set");
                        continue;
                    }
                    case "spellUpgradePoints" -> {
                        setFieldsSpellUpgradePoints(attributeNodes.item(i));
                        System.out.println("Spell Upgrade Points Fields Set");
                        continue;
                    }
                    case "attributes" -> {
                        setFieldsAttributes(attributeNodes.item(i));
                        System.out.println("Attribute Fields Set");
                        continue;
                    }
                    case "perks" -> {
                        setFieldsPerks(attributeNodes.item(i));
                        System.out.println("Perk Fields Set");
                        continue;
                    }
                }
                for(int j = 0; j < attributeElements.getLength(); j++){ //Every other node in the NodeList is a TextNode (so can be skipped)
                    if(attributeElements.item(j).getNodeType() != Node.ELEMENT_NODE){
                        continue;
                    }
                    Node currNode = attributeElements.item(j);
                    System.out.println(currNode.getNodeType());
                    String elementName = currNode.getNodeName();
                    switch(elementName){
                        case "personality" -> {
                            setFieldsPersonality(currNode);
                            continue;
                        }
                        case "itemsInInventory" -> {
                            setFieldsInventoryItems(currNode);
                            continue;
                        }
                        case "clothingInInventory" -> {
                            setFieldsInventoryClothing(currNode);
                            continue;
                        }
                        case "weaponsInInventory" -> {
                            setFieldsInventoryWeapons(currNode);
                            continue;
                        }
                    }
                    NamedNodeMap attributes = currNode.getAttributes();
                    NodeList childNodes = currNode.getChildNodes();
                    if(childNodes.getLength() != 0){
                        for(int k = 0; k < childNodes.getLength(); k++){
                            Node modifiers = childNodes.item(k);
                            if(modifiers.getNodeType() == Node.TEXT_NODE){
                                continue;
                            }
                            String modifierName = modifiers.getNodeName();
                            if(modifierName.contains("Modifiers")){
                                NamedNodeMap mods = modifiers.getAttributes();
                                for(int l = 0; l < mods.getLength(); l++){
                                    Node mod = mods.item(l);
                                    String value = mod.getTextContent();
                                    String modId = attributeName + "$" + elementName + "$" + modifierName + "$" + mod.getNodeName();
                                    CheckBox cb = (CheckBox) namespace.get(modId);
                                    if(cb != null){
                                        cb.setSelected(Boolean.parseBoolean(value));
                                    }
                                }
                            }
                        }
                        System.out.println(elementName + " Modifier Fields Set");
                    } //Modifiers Fields Setter
                    for(int k = 0; k < attributes.getLength(); k++){
                        Node valueNode = attributes.item(k);
                        String value = valueNode.getTextContent();
                        String bodyNodeName = valueNode.getNodeName();
                        String nodeId = attributeName + "$" + elementName + "$" + bodyNodeName;
                        if(nodeId.equals("core$description$value")){
                            TextArea ta = (TextArea) namespace.get(nodeId);
                            ta.setText(value);
                            continue;
                        }
                        //Instead of using nested try-catch, it may be possible to parse the value's data type and assign the value to the correct container
                        try{ //Using TextFields for numerical and string values
                            TextField tf = (TextField) namespace.get(nodeId);
                            if(tf != null){
                                tf.setText(value);
                                if(nodeId.equals("body$hair$length")){
                                    int v = Integer.parseInt(value);
                                    @SuppressWarnings("unchecked")
                                    ComboBox<Attribute> hairStyles = (ComboBox<Attribute>) namespace.get("body$hair$hairStyle");
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
                            try{
                                CheckBox cb = (CheckBox) namespace.get(nodeId);
                                if(cb != null){
                                    cb.setSelected(Boolean.parseBoolean(value));
                                }
                            }
                            catch(ClassCastException e2){ //Using ComboBoxes for fixed values
                                if(nodeId.contains("motherId") || nodeId.contains("fatherId")){
                                    @SuppressWarnings("unchecked")
                                    ComboBox<NpcCharacter> cb = (ComboBox<NpcCharacter>) namespace.get(nodeId);
                                    if(cb != null){
                                        ObservableList<NpcCharacter> itemList = cb.getItems();
                                        cb.setValue(matchNpc(itemList, value));
                                    }
                                }
                                else{
                                    @SuppressWarnings("unchecked")
                                    ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(nodeId);
                                    if(cb != null){
                                        ObservableList<Attribute> itemList = cb.getItems();
                                        cb.setValue(matchComboBoxItem(itemList, value));
                                    }
                                }
                            }
                        }
                    }
                }
                System.out.println(attributeName + " Fields Set");
            }
            if(!listenersAdded){
                addListeners();
            }
            fieldsSet = true;
            updateLabels();
        }
    }

    /**
     * Sets the value of fields relating to world data (i.e. data that is world/save specific, not character specific)
     */
    private void setWorldFields(){
        Element coreInfo = (Element) saveFile.getElementsByTagName("coreInfo").item(0);
        Node date = coreInfo.getElementsByTagName("date").item(0);
        NamedNodeMap dateAttr = date.getAttributes();
        for(int i = 0; i < dateAttr.getLength(); i++){
            Node attr = dateAttr.item(i);
            if(attr.getNodeType() == Node.ATTRIBUTE_NODE){
                String element = attr.getNodeName();
                String id = "coreInfo$date$" + element;
                if(element.equals("month")){
                    @SuppressWarnings("unchecked")
                    ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(id);
                    ObservableList<Attribute> items = cb.getItems();
                    cb.setValue(matchComboBoxItem(items, attr.getTextContent()));
                }
                else{
                    TextField tf = (TextField) namespace.get(id);
                    if(tf != null){
                        tf.setText(attr.getTextContent());
                    }
                }
            }
        }
        Node dialogueFlags = saveFile.getElementsByTagName("dialogueFlags").item(0);
        NodeList flags = dialogueFlags.getChildNodes();
        for(int i = 0; i < flags.getLength(); i++){
            if(flags.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            Node flag = flags.item(i);
            String nodeName = flag.getNodeName();
            if(nodeName.equals("savedLongs")){
                break;
            }
            String id = "dialogueFlags$" + nodeName + "$value";
            TextField tf = (TextField) namespace.get(id);
            if(tf != null){
                tf.setText(getAttributeValue(flag, "value"));
            }
        }
    }

    /**
     * Creates input fields for each character the selected npc/player has a relationship with
     *
     * @param relationshipsNode Relationship Node in the save file
     */
    private void setFieldsRelationships(Node relationshipsNode){
        NodeList relationships = relationshipsNode.getChildNodes();
        VBox relationBox = (VBox) namespace.get("relationshipVbox");
        relationBox.getChildren().clear();
        @SuppressWarnings("unchecked")
        ObservableList<NpcCharacter> npcChars = ((ComboBox<NpcCharacter>) namespace.get("characterSelector")).getItems();
        for(int i = 0; i < relationships.getLength(); i++){
            if(relationships.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            NamedNodeMap attrs = relationships.item(i).getAttributes();
            String charId = attrs.getNamedItem("character").getTextContent();
            TextField nameField = new TextField(getNpcName(charId));
            nameField.setEditable(false);
            TextField idField = new TextField(charId);
            idField.setEditable(false);
            TextField valueField = new TextField(attrs.getNamedItem("value").getTextContent());
            valueField.setId("characterRelationships$relationship$" + i);
            valueField.focusedProperty().addListener(new TextObjectListener(valueField, TextFieldType.DOUBLE, false));
            Button btn = new Button("Goto Character");
            btn.setId("GoToCharBtn$" + charId.replace("-", "_").replace(",", "_"));
            NpcCharacter npc = matchNpc(npcChars, charId);
            if(npc != null){
                btn.setOnAction(event -> {
                    String[] id = getId(event).split("\\$");
                    String characterId = id[1];
                    System.out.println(characterId);
                    if(characterId.charAt(0) == '_'){
                        characterId = characterId.replaceFirst("_", "-");
                    }
                    characterId = characterId.replace("_", ",");
                    setCharacter(characterId);
                });
            }
            else{
                btn.setDisable(true); //May be better to just delete these Node as the character no longer exists
            }
            HBox hBox = new HBox(10);
            hBox.getChildren().addAll(new Label("Id: "), idField, new Label("Name: "), nameField,
                    new Label("Value: "), valueField, btn); //Id: <Id TextField> Name: <Name TextField> Value: <Value TextField> <GoTo Button>
            relationBox.getChildren().add(hBox);
        }
    }

    /**
     * Sets the value of fetish ownership CheckBoxes
     *
     * @param fetishesNode fetishes Node in the save file
     */
    private void setFieldsFetishes(Node fetishesNode){
        NodeList ownedFetishes = fetishesNode.getChildNodes();
        for(int i = 0; i < ownedFetishes.getLength(); i++){
            if(ownedFetishes.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            String fetishType = getAttributeValue(ownedFetishes.item(i), "type");
            if(fetishType.equals("FETISH_BREEDER") || fetishType.equals("FETISH_LUSTY_MAIDEN") ||
                    fetishType.equals("FETISH_SWITCH") || fetishType.equals("FETISH_SADOMASOCHIST")){
                continue; //Skip these values
            }
            String fetishId = fetishType + "$owned";
            CheckBox cb = (CheckBox) namespace.get(fetishId);
            cb.setSelected(true);
        }
    }

    /**
     * Sets the value of fetish desire ComboBoxes
     *
     * @param fetishesNode fetishDesire Node in the save file
     */
    private void setFieldsFetishDesires(Node fetishesNode){
        NodeList fetishDesires = fetishesNode.getChildNodes();
        for(int i = 0; i < fetishDesires.getLength(); i++){
            if(fetishDesires.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            NamedNodeMap attr = fetishDesires.item(i).getAttributes();
            String fetishType = attr.getNamedItem("fetish").getTextContent();
            String fetishId = fetishType + "$desire";
            String fetishValue = attr.getNamedItem("desire").getTextContent();
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(fetishId);
            ObservableList<Attribute> values = cb.getItems();
            cb.setValue(matchComboBoxItem(values, fetishValue));
        }
    }

    /**
     * Sets the value of fetish experience TextFields
     *
     * @param fetishesNode fetishExperiences Node in the save file
     */
    private void setFieldsFetishExperience(Node fetishesNode){
        NodeList fetishExp = fetishesNode.getChildNodes();
        for(int i = 0; i < fetishExp.getLength(); i++){
            if(fetishExp.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            NamedNodeMap attr = fetishExp.item(i).getAttributes();
            String fetishType = attr.getNamedItem("fetish").getTextContent();
            String fetishId = fetishType + "$exp";
            String fetishValue = attr.getNamedItem("experience").getTextContent();
            TextField tf = (TextField) namespace.get(fetishId);
            tf.setText(fetishValue);
        }
    }

    /**
     * Sets the value of SpellTier ComboBoxes based on the childNodes of the knowSpells Node
     *
     * @param spellNode knownSpells Node in the save file
     */
    private void setFieldsKnownSpells(Node spellNode){
        String partialId = "spells$";
        NodeList spells = spellNode.getChildNodes();
        for(int i = 0; i < spells.getLength(); i++){
            if(spells.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            String type = getAttributeValue(spells.item(i), "type");
            String id = partialId + type;
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(id);
            ObservableList<Attribute> spellTiers = cb.getItems();
            cb.setValue(spellTiers.get(1));
        }
    }

    /**
     * Sets the value of SpellTier ComboBoxes based on the childNodes of the spellUpgrades Node
     *
     * @param spellNode spellUpgrades Node in the save file
     */
    private void setFieldsSpellUpgrades(Node spellNode){
        String partialId = "spells$";
        NodeList spells = spellNode.getChildNodes();
        for(int i = 0; i < spells.getLength(); i++){
            if(spells.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            String value = getAttributeValue(spells.item(i), "type");
            if(value.endsWith("_CLEAN")){
                CheckBox checkBox = (CheckBox) namespace.get(partialId + value);
                checkBox.setSelected(true);
                continue;
            }
            String type = SpellTier.readType(value);
            String id = partialId + type;
            @SuppressWarnings("unchecked")
            ComboBox<Attribute> cb = (ComboBox<Attribute>) namespace.get(id);
            ObservableList<Attribute> spellTiers = cb.getItems();
            Attribute tier = matchComboBoxItem(spellTiers, value);
            cb.setValue(tier);
        }
    }

    /**
     * Sets the value of spell TextFields based on the childNodes of the spellUpgradePoints Node
     *
     * @param spellNode spellUpgradePoints Node in the save file
     */
    private void setFieldsSpellUpgradePoints(Node spellNode){
        String idPartial = "spellUpgradePoints$";
        NodeList schools = spellNode.getChildNodes();
        for(int i = 0; i < schools.getLength(); i++){
            if(schools.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            NamedNodeMap attr = schools.item(i).getAttributes();
            String id = idPartial + attr.getNamedItem("school").getTextContent();
            TextField tf = (TextField) namespace.get(id);
            tf.setText(attr.getNamedItem("points").getTextContent());
        }
    }

    /**
     * Sets the values of all attribute TextFields based on the childNodes of the attributes Node
     *
     * @param attributesNode attributes Node in the save file
     */
    private void setFieldsAttributes(Node attributesNode){
        String idPartial = "attributes$";
        NodeList attributeList = attributesNode.getChildNodes();
        for(int i = 0; i < attributeList.getLength(); i++){
            if(attributeList.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            NamedNodeMap attr = attributeList.item(i).getAttributes();
            String id = idPartial + attr.getNamedItem("type").getTextContent();
            TextField tf = (TextField) namespace.get(id);
            tf.setText(attr.getNamedItem("value").getTextContent());

        }
    }

    /**
     * Sets the value of all perks CheckBoxes based on the childNodes of the perks Node
     *
     * @param perksNode perks Node in the save file
     */
    private void setFieldsPerks(Node perksNode){
        String idPartial = "perks$";
        NodeList perks = perksNode.getChildNodes();
        for(int i = 0; i < perks.getLength(); i++){
            if(perks.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            NamedNodeMap attr = perks.item(i).getAttributes();
            String id = idPartial + attr.getNamedItem("row").getTextContent() + "$" + attr.getNamedItem("type").getTextContent();
            System.out.println(id);
            CheckBox cb = (CheckBox) namespace.get(id);
            cb.setSelected(true);
        }
    }

    /**
     * Sets the value of all personality traits CheckBoxes based on the childNodes of the personality Node
     *
     * @param personalityNode personality Node in the save file
     */
    private void setFieldsPersonality(Node personalityNode){
        String idPartial = "personalityTrait$";
        NodeList traits = personalityNode.getChildNodes();
        for(int i = 0; i < traits.getLength(); i++){
            Node trait = traits.item(i);
            if(trait.getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            String id = idPartial + trait.getTextContent();
            System.out.println(id);
            CheckBox cb = (CheckBox) namespace.get(id);
            cb.setSelected(true);
        }
    }

    private void setFieldsInventoryItems(Node inventoryNode){
        inventoryItems.clear();
        VBox vb = (VBox) namespace.get("itemsInInventory");
        vb.getChildren().clear();
        String partialId = "characterInventory$itemsInInventory$";
        NodeList items = inventoryNode.getChildNodes();
        int counter = 0;
        for(int i = 0; i < items.getLength(); i++){
            if(items.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            InventoryItem inventoryItem = new InventoryItem(items.item(i));
            String itemId = inventoryItem.getId();
            //String colorValue = inventoryItem.getColor();
            TextField itemIdTf = new TextField(itemId);
            itemIdTf.setEditable(false);
            TextField nameTf = new TextField(inventoryItem.getName());
            nameTf.setEditable(false);
            TextField itemCount = new TextField("" + inventoryItem.getCount());
            itemCount.setId(partialId + "count$" + counter);
            itemCount.focusedProperty().addListener(new TextObjectListener(itemCount, TextFieldType.INT));
            Button btn = new Button("Delete Item");
            btn.setOnAction(this::removeHBox);
            HBox hBox = new HBox(10);
            hBox.setId(partialId + counter);
            counter++;
            inventoryItem.setHBox(hBox);
            inventoryItem.addHBoxNodes(itemCount);
            hBox.getChildren().addAll(new Label("Id: "), itemIdTf, new Label("Name: "), nameTf,
                    new Label("Count: "), itemCount, btn);
            //Id: <Id TextField> Name: <Name TextField> Count: <Count TextField> <delete btn>
            vb.getChildren().add(hBox);
            inventoryItems.add(inventoryItem);
        }
    }

    private void setFieldsInventoryClothing(Node inventoryNode){
        inventoryClothes.clear();
        VBox vb = (VBox) namespace.get("clothingInInventory");
        vb.getChildren().clear();
        String partialId = "characterInventory$clothingInInventory$";
        NodeList items = inventoryNode.getChildNodes();
        int counter = 0;
        for(int i = 0; i < items.getLength(); i++){
            if(items.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            InventoryClothing inventoryClothing = new InventoryClothing(items.item(i));
            TextField clothingIdTf = new TextField(inventoryClothing.getId());
            clothingIdTf.setEditable(false);
            TextField nameTf = new TextField(inventoryClothing.getName());
            nameTf.setEditable(false);
            TextField clothingCount = new TextField("" + inventoryClothing.getCount());
            clothingCount.setId(partialId + "count$" + counter);
            clothingCount.focusedProperty().addListener(new TextObjectListener(clothingCount, TextFieldType.INT));
            CheckBox enchantmentKnown = new CheckBox("Enchantment Known: ");
            enchantmentKnown.setNodeOrientation(NodeOrientation.RIGHT_TO_LEFT);
            enchantmentKnown.setSelected(inventoryClothing.isEnchantmentKnown());
            enchantmentKnown.setId(partialId + "enchantmentKnown$" + counter);
            enchantmentKnown.setOnAction(this::updateXmlBoolean);
            CheckBox isDirty = new CheckBox("Dirty: ");
            isDirty.setNodeOrientation(NodeOrientation.RIGHT_TO_LEFT);
            isDirty.setSelected(inventoryClothing.isDirty());
            isDirty.setOnAction(this::updateXmlBoolean);
            isDirty.setId(partialId + "isDirty$" + counter);
            Button btn = new Button("Delete Item");
            btn.setOnAction(this::removeHBox);
            HBox hBox = new HBox(10);
            hBox.setId(partialId + counter);
            counter++;
            inventoryClothing.setHBox(hBox);
            inventoryClothing.addHBoxNodes(clothingCount, enchantmentKnown, isDirty);
            hBox.getChildren().addAll(new Label("Id: "), clothingIdTf, new Label("Name: "), nameTf,
                    new Label("Count: "), clothingCount, enchantmentKnown, isDirty, btn);
            //Id: <Id TextField> Name: <Name TextField> Count: <Count TextField> <EnchantmentKnow CheckBox>
            // <IsDirty CheckBox> <delete btn>
            vb.getChildren().add(hBox);
            inventoryClothes.add(inventoryClothing);
        }
    }

    private void setFieldsInventoryWeapons(Node inventoryNode){
        inventoryWeapons.clear();
        VBox vb = (VBox) namespace.get("weaponsInInventory");
        vb.getChildren().clear();
        String partialId = "characterInventory$weaponsInInventory$";
        NodeList items = inventoryNode.getChildNodes();
        int counter = 0;
        for(int i = 0; i < items.getLength(); i++){
            if(items.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            InventoryWeapon inventoryWeapon = new InventoryWeapon(items.item(i));
            TextField weaponIdTf = new TextField(inventoryWeapon.getId());
            weaponIdTf.setEditable(false);
            TextField nameTf = new TextField(inventoryWeapon.getName());
            nameTf.setEditable(false);
            TextField weaponCount = new TextField("" + inventoryWeapon.getCount());
            weaponCount.setId(partialId + "count$" + counter);
            weaponCount.focusedProperty().addListener(new TextObjectListener(weaponCount, TextFieldType.INT));
            String dmgType = inventoryWeapon.getDamageType();
            ComboBox<Attribute> damageType;
            if(dmgType.equals("LUST")){
                damageType = new ComboBox<>(FXCollections.observableArrayList(new Attribute("Lust", "Lust")));
                damageType.setValue(damageType.getItems().get(0));
            }
            else{
                damageType = new ComboBox<>(damageTypes);
                damageType.setValue(matchComboBoxItem(damageTypes, dmgType));
            }
            damageType.setId(partialId + "damageType$" + counter);
            damageType.setConverter(new StringConverter<>(){
                @Override
                public String toString(Attribute attribute){
                    return attribute.getName();
                }

                @Override
                public Attribute fromString(String s){
                    return null;
                }
            });
            damageType.setOnAction(this::updateXmlComboBox);
            Button btn = new Button("Delete Item");
            btn.setOnAction(this::removeHBox);
            HBox hBox = new HBox(10);
            hBox.setId(partialId + counter);
            counter++;
            inventoryWeapon.setHBox(hBox);
            inventoryWeapon.addHBoxNodes(weaponCount, damageType);
            hBox.getChildren().addAll(new Label("Id: "), weaponIdTf, new Label("Name: "), nameTf,
                    new Label("Damage Type: "), damageType, new Label("Count: "), weaponCount, btn);
            //Id: <Id TextField> Name: <Name TextField> Damage Type: <DamageType ComboBox> Count:
            // <Count TextField> <delete btn>
            vb.getChildren().add(hBox);
            inventoryWeapons.add(inventoryWeapon);
        }
    }

    private void removeHBox(ActionEvent event){
        HBox targetHBox = (HBox) ((javafx.scene.Node) event.getSource()).getParent();
        ((VBox) targetHBox.getParent()).getChildren().remove(targetHBox);
        String[] id = targetHBox.getId().split("\\$");
        String partialId = id[0] + "$" + id[1] + "$";
        ArrayList<? extends AbstractInventoryElement> inventoryElements;
        switch(id[1]){
            case "itemsInInventory" -> inventoryElements = inventoryItems;
            case "clothingInInventory" -> inventoryElements = inventoryClothes;
            case "weaponsInInventory" -> inventoryElements = inventoryWeapons;
            default -> throw new IllegalStateException("Unexpected value: " + id[1]);
        }
        int index = Integer.parseInt(id[2]);
        shiftHBoxIds(inventoryElements, index, partialId);
    }

    private <T extends AbstractInventoryElement> void shiftHBoxIds(ArrayList<T> arrayList, int index, String partialId){
        arrayList.get(index).removeNode();
        for(int i = index; i < arrayList.size() - 1; i++){
            AbstractInventoryElement inventoryElement = arrayList.get(i + 1);
            HBox hBox = inventoryElement.getHBox();
            hBox.setId(partialId + i);
            ArrayList<javafx.scene.Node> nodes = inventoryElement.getHBoxNodes();
            String[] attrNames;
            switch(nodes.size()){
                case 1 -> attrNames = new String[]{"count$"};
                case 2 -> attrNames = new String[]{"count$", "damageType$"};
                case 3 -> attrNames = new String[]{"count$", "enchantmentKnown$", "isDirty$"};
                default -> throw new IllegalStateException("Unexpected value: " + nodes.size());
            }
            for(int j = 0; j < nodes.size(); j++){
                nodes.get(j).setId(partialId + attrNames[j] + i);
            }
        }
        arrayList.remove(index);
    }

    private boolean matchItemByColors(Node itemNode, String... colors){
        NodeList colorList = ((Element) itemNode).getElementsByTagName("colours").item(0).getChildNodes();
        int idx = 0;
        for(int i = 0; i < colorList.getLength(); i++){
            Node color = colorList.item(i);
            if(color.getNodeName().equals("colour")){
                if(color.getTextContent().equals(colors[idx])){
                    idx++;
                }
            }
        }
        return idx == colors.length - 1;
    }

    private String getItemColors(Node itemNode){
        NodeList colorList = ((Element) itemNode).getElementsByTagName("colours").item(0).getChildNodes();
        StringBuilder colors = new StringBuilder();
        for(int i = 0; i < colorList.getLength(); i++){
            Node color = colorList.item(i);
            if(color.getNodeName().equals("colour")){
                colors.append(color.getTextContent()).append("$");
            }
        }
        String returnString = colors.toString();
        int strLength = returnString.length();
        return returnString.charAt(strLength - 1) == '$' ? returnString.substring(0, strLength - 1) : returnString;
    }

    /**
     * Gets the name of the Npc based on the given npcId
     *
     * @param npcId Id of the npc
     * @return Name of the npc if found else null
     */
    private String getNpcName(String npcId){
        @SuppressWarnings("unchecked")
        ObservableList<NpcCharacter> npcs = ((ComboBox<NpcCharacter>) namespace.get("characterSelector")).getItems();
        for(NpcCharacter npc : npcs){
            if(npc.equals(npcId)){
                return npc.getName();
            }
        }
        return null;
    }

    /**
     * Gets the Attribute that matches the value from the given ObservableList
     *
     * @param list  ObservableList of Attributes to check
     * @param value Value to match
     * @return Attribute that matches the value if found else null
     */
    private Attribute matchComboBoxItem(ObservableList<Attribute> list, String value){
        for(Attribute attribute : list){
            if(attribute.equals(value)){
                return attribute;
            }
        }
        return null;
    }

    /**
     * Gets the NpcCharacter that matches the value from the given ObservableList
     *
     * @param list  ObservableList of NpcCharacter to check
     * @param value Value to match
     * @return NpcCharacter that matches the value if found else null
     */
    private NpcCharacter matchNpc(ObservableList<NpcCharacter> list, String value){
        for(NpcCharacter npc : list){
            if(npc.equals(value)){
                return npc;
            }
        }
        return null;
    }

    /**
     * Method to attach listeners to TextFields to properly detect and record changes to the xml data
     */
    private void addListeners(){
        TextArea ta = (TextArea) namespace.get("core$description$value");
        ta.focusedProperty().addListener(new TextObjectListener(ta, TextFieldType.STRING));
        TextField hairStyles = (TextField) namespace.get("body$hair$length");
        hairStyles.focusedProperty().addListener(new TextObjectListener(hairStyles, TextFieldType.HAIR));
        for(String intTextFieldId : intTextFieldIds){
            TextField tf = (TextField) namespace.get(intTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.INT, true));
        }
        for(String doubleTextFieldId : doubleTextFieldIds){
            TextField tf = (TextField) namespace.get(doubleTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.DOUBLE, !doubleTextFieldId.equals("core$obedience$value")));
        }
        for(String stringTextFieldId : stringTextFieldIds){
            TextField tf = (TextField) namespace.get(stringTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.STRING));
        }
        for(String dateTextFieldId : dateTextFieldIds){
            TextField tf = (TextField) namespace.get(dateTextFieldId);
            tf.focusedProperty().addListener(new TextObjectListener(tf, TextFieldType.DATE));
        }
        listenersAdded = true;
    }

    /**
     * Finds id tags by their corresponding value attribute
     *
     * @param id Value attribute to search for
     * @return Node representing the id tag with corresponding value attribute if found else null
     */
    private Node getNodeByIdValue(String id){
        if(id.equals("PlayerCharacter")){
            Node playerNode = saveFile.getElementsByTagName("playerCharacter").item(0);
            Node characterNode = playerNode.getChildNodes().item(1);
            Node coreNode = characterNode.getChildNodes().item(3);
            return coreNode.getChildNodes().item(1); //playerNode > characterNode > coreNode > idNode
        }
        else{
            NodeList nodes = saveFile.getElementsByTagName("NPC");
            for(int i = 0; i < nodes.getLength(); i++){
                Node idNode = nodes.item(i).getChildNodes().item(1).getChildNodes().item(3).getChildNodes().item(1);
                NamedNodeMap attributes = idNode.getAttributes();
                Node value = attributes.getNamedItem("value");
                if(value != null && value.getTextContent().equals(id)){
                    return idNode; //npcNode > characterNode > coreNode > idNode
                }
            }
            return null;
        }
    }

    /**
     * Deletes the given Node
     *
     * @param node Node to be deleted
     */
    private void removeNode(Node node){
        node.getParentNode().removeChild(node);
    }

    /**
     * Deletes selected character from the save file and selects the previous character in the npc list
     */
    @FXML
    private void deleteCharacter(){
        Node npcNode = characterNode.getParentNode(); //characterNode > npcNode
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> charSelect = (ComboBox<NpcCharacter>) namespace.get("characterSelector");
        ObservableList<NpcCharacter> charList = charSelect.getItems();
        NpcCharacter deletedChar = charSelect.getValue();
        NpcCharacter prevChar = charList.get(charList.indexOf(deletedChar) - 1);
        charSelect.setValue(prevChar);
        charList.remove(deletedChar);
        removeNode(npcNode);
    }

    /**
     * Deletes all offsprings, that are not on the map, from the save
     */
    @FXML
    private void deleteOffsprings(){
        System.out.println("Starting Offspring Removal");
        NodeList npcList = saveFile.getElementsByTagName("NPC");
        @SuppressWarnings("unchecked")
        ComboBox<NpcCharacter> cb = (ComboBox<NpcCharacter>) namespace.get("characterSelector");
        ObservableList<NpcCharacter> npcObservableList = cb.getItems();
        for(int i = 0; i < npcList.getLength(); i++){
            Element character = (Element) ((Element) npcList.item(i)).getElementsByTagName("character").item(0);
            Element core = (Element) character.getElementsByTagName("core").item(0);
            Element pathname = (Element) core.getElementsByTagName("pathName").item(0);
            Element locationInfo = (Element) character.getElementsByTagName("locationInformation").item(0);
            Element worldLoc = (Element) locationInfo.getElementsByTagName("worldLocation").item(0);
            if(pathname.getAttribute("value").equals("com.lilithsthrone.game.character.npc.misc.NPCOffspring")){ //Npc is an Offspring
                if(worldLoc.getAttribute("value").equals("EMPTY")){ //Npc is not on the map
                    String npcId = ((Element) core.getElementsByTagName("id").item(0)).getAttribute("value");
                    System.out.println("Deleted " + npcId);
                    NpcCharacter npc = matchNpc(npcObservableList, npcId);
                    if(npc == cb.getValue()){ //If character selector on an offspring that will be deleted, switch to the previous character
                        int index = npcObservableList.indexOf(npc);
                        cb.setValue(npcObservableList.get(index - 1));
                    }
                    npcObservableList.remove(npc);
                    removeNode(npcList.item(i));
                }
            }
        }
        System.out.println("Offsprings Removed");
    }

    /**
     * Reveals all map tiles
     */
    @FXML
    private void revealMap(){
        Node mapsNode = saveFile.getElementsByTagName("maps").item(0);
        NodeList worlds = mapsNode.getChildNodes();
        for(int i = 0; i < worlds.getLength(); i++){
            if(worlds.item(i).getNodeType() != Node.ELEMENT_NODE){
                continue;
            }
            Node grid = ((Element) worlds.item(i)).getElementsByTagName("grid").item(0);
            NodeList cells = grid.getChildNodes();
            for(int j = 0; j < cells.getLength(); j++){
                if(cells.item(j).getNodeType() != Node.ELEMENT_NODE){
                    continue;
                }
                NamedNodeMap attr = cells.item(j).getAttributes();
                attr.getNamedItem("discovered").setTextContent("true");
                attr.getNamedItem("travelledTo").setTextContent("true");
            }
        }
        System.out.println("Revealed all map tiles");
    }

    @FXML
    private void checkForUpdate(){
        String latestVersion = getLatestVersionTag();
        if(latestVersion != null){
            MenuItem mi = (MenuItem) namespace.get("updateStatus");
            if(latestVersion.equals(version)){
                mi.setText("Latest version");
            }
            else{
                mi.setText("Update available");
            }
        }
    }

    private String getLatestVersionTag(){
        StringBuilder result = new StringBuilder();
        try{
            URL url = new URL("https://api.github.com/repos/Exiua/LTSaveEd/releases/latest");
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/vnd.github.v3+json");
            try(BufferedReader reader = new BufferedReader(new InputStreamReader(conn.getInputStream()))){
                for(String line; (line = reader.readLine()) != null; ){
                    result.append(line);
                }
            }
            String jsonStr = result.toString();
            String[] jsonArr = jsonStr.replace("{", "").replace("}", "").split(",");
            String test = null;
            for(String s : jsonArr){
                if(s.startsWith("\"tag_name\"")){
                    test = s.split(":")[1].replace("\"", "");
                    break;
                }
            }
            return test;
        }
        catch(IOException e){
            e.printStackTrace();
        }
        return null;
    }

    /**
     * Overwrites the file that was used to load in the xml data
     *
     * @param event ActionEvent triggering the save call
     */
    @FXML
    private void saveFileOverwrite(ActionEvent event){
        event.consume();
        if(fileLoaded){
            saveToFile(workingFile);
        }
    }

    /**
     * Writes xml data to a new file
     *
     * @param event ActionEvent triggering the save call
     */
    @FXML
    private void saveFileExport(ActionEvent event){
        event.consume();
        if(fileLoaded){
            FileChooser fc = new FileChooser();
            FileChooser.ExtensionFilter fileExtensions = new FileChooser.ExtensionFilter("XML files (*.xml)", "*.xml");
            fc.getExtensionFilters().add(fileExtensions);
            String currentPath = prop.getProperty("defaultFilePath");
            fc.setInitialDirectory(new File(currentPath));
            fc.setInitialFileName(workingFile.getName());
            File f = fc.showSaveDialog(stage);
            if(f != null){
                saveToFile(f);
            }
        }
    }

    /**
     * Saves xml data to the given file
     *
     * @param f File to save the xml data to
     */
    private void saveToFile(File f){
        TransformerFactory tff = TransformerFactory.newInstance();
        try{
            Transformer tf = tff.newTransformer();
            //File formatting
            tf.setOutputProperty(OutputKeys.INDENT, "yes");
            saveFile.normalize();
            XPath xPath = XPathFactory.newInstance().newXPath();
            NodeList nodeList = (NodeList) xPath.evaluate("//text()[normalize-space()='']",
                    saveFile, XPathConstants.NODESET);
            for(int i = 0; i < nodeList.getLength(); i++){
                Node node = nodeList.item(i);
                removeNode(node);
            }
            //Saves xml to file
            DOMSource source = new DOMSource(saveFile);
            StreamResult result = new StreamResult(f);
            tf.transform(source, result);
        }
        catch(TransformerException | XPathExpressionException e){
            e.printStackTrace();
        }
    }
}
