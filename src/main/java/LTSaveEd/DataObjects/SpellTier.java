package LTSaveEd.DataObjects;

/**
 * Class that stores spell attributes to make adding and removing spells and spell upgrades easier
 * @author Exiua
 */
public class SpellTier extends Attribute{

    /**
     * Base value of a spell (e.g. FIREBALL_1 would have a type of FIREBALL)
     */
    private final String type;

    /**
     * Tier of the spell
     * <p>
     *     -1: Unowned
     *     0: Base spell
     *     1: Upgrade 1
     *     2: Upgrade 2
     *     3: Upgrade 3 or upgrade 3A or 3B in the case of elemental spells
     *     4: Upgrade 3B in the case of steal spell
     */
    private final int tier;

    /**
     * Constructor that takes the name and value and parses type and tier from value
     * @param name
     *   Display name of the spell
     * @param value
     *   Actual value of the spell
     */
    public SpellTier(String name, String value){
        super(name, value);
        type = readType(value);
        tier = readTier(value);
    }

    /**
     * Gets the last number in a String
     * @param str
     *   String to get the last number from
     * @return
     *   Last number in the String as a char
     */
    private static char getLastNum(String str){
        char num = str.charAt(str.length() - 1);
        if(num == 'A' || num == 'B'){
            num = '3';
        }
        return num;
    }

    /**
     * Gets the type from a String
     * @param str
     *   String to read type from
     * @return
     *   String representing the type of the spell
     */
    public static String readType(String str){
        return str.replace("_UNOWNED", "").replace("_3A", "")
               .replace("_3B", "").replace("_3", "").replace("_2", "")
               .replace("_1", "");
    }

    /**
     * Gets the tier from a String
     * @param value
     *   String to read tier from
     * @return
     *   Integer representing the tier of the String
     */
    public static int readTier(String value){
        String valueType = readType(value);
        if(value.endsWith("UNOWNED")){
            return -1;
        }
        else if(value.equals(valueType)){
            return 0;
        }
        else{
            if(valueType.equals("STEAL")){
                if(value.endsWith("3A")){
                    return 3;
                }
                else if(value.endsWith("3B")){
                    return 4;
                }
                else{
                    return Character.getNumericValue(getLastNum(value));
                }
            }
            return Character.getNumericValue(getLastNum(value));
        }
    }

    /**
     * Gets the type of this spell
     * @return
     *   Type of this spell
     */
    public String getType(){
        return type;
    }

    /**
     * Gets the tier of this spell
     * @return
     *   Tier of this spell
     */
    public int getTier(){
        return tier;
    }
}
