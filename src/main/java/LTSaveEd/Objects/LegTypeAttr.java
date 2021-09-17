package LTSaveEd.Objects;

import javafx.collections.ObservableList;

/**
 * Class that stores leg type attributes to make ComboBoxes look cleaner and connects leg configuration, foot structures,
 * and genital arrangements with a leg type as those three's possible values are dependant on the leg type value
 * @author Exiua
 */
public class LegTypeAttr extends Attribute {

    /**
     * Leg configurations associated with this leg type
     */
    private final ObservableList<Attribute> legConfiguration;

    /**
     * Foot structures associated with this leg type
     */
    private final ObservableList<Attribute> footStructure;

    /**
     * Genital arrangements associated with this leg type
     */
    private final ObservableList<Attribute> genitalArrangement;

    /**
     * Default leg configuration Attribute
     */
    private final Attribute defaultLegConfiguration;

    /**
     * Default foot structure Attribute
     */
    private Attribute defaultFootStructure;

    /**
     * Default genital arrangement Attribute
     */
    private final Attribute defaultGenitalArrangement;

    /**
     * Constructor that takes name, value, and dependant lists
     * @param name
     *   Display name of the leg type attribute
     * @param value
     *   Actual value of the leg type attribute
     * @param legConfig
     *   Leg configurations associated with this leg type
     * @param footStruct
     *   Foot structures associated with this leg type
     * @param genitalArrange
     *   Genital arrangements associated with this leg type
     */
    public LegTypeAttr(String name, String value, ObservableList<Attribute> legConfig,
                       ObservableList<Attribute> footStruct, ObservableList<Attribute> genitalArrange){
        super(name, value);
        legConfiguration = legConfig;
        footStructure = footStruct;
        genitalArrangement = genitalArrange;
        defaultLegConfiguration = legConfiguration.get(0);
        defaultFootStructure = footStructure.get(0);
        defaultGenitalArrangement = genitalArrangement.get(0);
    }

    /**
     * Constructor that allows the specification of the default foot structure
     * @param name
     *   Display name of the leg type attribute
     * @param value
     *   Actual value of the leg type attribute
     * @param legConfig
     *   Leg configurations associated with this leg type
     * @param footStruct
     *   Foot structures associated with this leg type
     * @param genitalArrange
     *   Genital arrangements associated with this leg type
     * @param defaultFootStruct
     *   Default foot structure Attribute
     */
    public LegTypeAttr(String name, String value, ObservableList<Attribute> legConfig,
                       ObservableList<Attribute> footStruct, ObservableList<Attribute> genitalArrange,
                       String defaultFootStruct){
        this(name, value, legConfig, footStruct, genitalArrange);
        for (Attribute attribute : footStructure) {
            if (attribute.equals(defaultFootStruct)) {
                defaultFootStructure = attribute;
            }
        }
    }

    /**
     * Gets the list of leg configurations associated with this leg type
     * @return
     *   ObservableList of corresponding leg configurations
     */
    public ObservableList<Attribute> getLegConfiguration(){
        return legConfiguration;
    }

    /**
     * Gets the list of foot structures associated with this leg type
     * @return
     *   ObservableList of corresponding foot structures
     */
    public ObservableList<Attribute> getFootStructure() {
        return footStructure;
    }

    /**
     * Gets the list of genital arrangements associated with this leg type
     * @return
     *   ObservableList of corresponding genital arrangements
     */
    public ObservableList<Attribute> getGenitalArrangement() {
        return genitalArrangement;
    }

    /**
     * Gets the default leg configuration associated with this leg type
     * @return
     *   Attribute of the default leg configuration
     */
    public Attribute getDefaultLegConfiguration() {
        return defaultLegConfiguration;
    }

    /**
     * Gets the default foot structure associated with this leg type
     * @return
     *   Attribute of the default foot structure
     */
    public Attribute getDefaultFootStructure() {
        return defaultFootStructure;
    }

    /**
     * Gets the default genital arrangement associated with this leg type
     * @return
     *   Attribute of the genital arrangement configuration
     */
    public Attribute getDefaultGenitalArrangement() {
        return defaultGenitalArrangement;
    }
}
