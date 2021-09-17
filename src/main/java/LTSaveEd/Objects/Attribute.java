package LTSaveEd.Objects;

/**
 * Class that stores attribute display name and actual values to make ComboBoxes look cleaner
 * @author Exiua
 */
public class Attribute {

    /**
     * Display name for the attribute
     */
    private final String name;

    /**
     * Actual value of the attribute
     */
    private final String value;

    /**
     * Constructor that takes the name and value
     * @param name
     *   Display name of the attribute
     * @param value
     *   Actual value of the attribute
     */
    public Attribute(String name, String value){
        this.name = name;
        this.value = value;
    }

    /**
     * Gets the display name of the attribute
     * @return
     *   Display name of the attribute
     */
    public String getName() {
        return name;
    }

    /**
     * Gets the actual value of the attribute
     * @return
     *   Actual value of the attribute
     */
    public String getValue() {
        return value;
    }

    /**
     * Checks if the supplied value is equal to the value of this object
     * @param value
     *   Supplied value to check against
     * @return
     *   Boolean of whether the supplied value matches the value of the object
     */
    public boolean equals(String value){
        return this.value.equals(value);
    }

    /**
     * Checks if the supplied Attribute object is equal to the value of this object
     * @param other
     *   Supplied Attribute object to be checked against
     * @return
     *   Boolean of whether the supplied Attribute object values matches the value of this object
     */
    public boolean equals(Attribute other){
        return value.equals(other.getValue());
    }

    @Override
    public String toString(){
        return value;
    }
}
