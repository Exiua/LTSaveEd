package LTSaveEd;

import java.util.Arrays;

public class SpellTier extends Attribute{

    private final String type;

    private final int tier;

    public SpellTier(String name, String value){
        super(name, value);
        type = readType(value);
        tier = readTier(value);
    }

    private static char getLastNum(String str){
        char num = str.charAt(str.length() - 1);
        if(num == 'A' || num == 'B'){
            num = '3';
        }
        return num;
    }

    public static String readType(String str){
        return str.replace("_UNOWNED", "").replace("_3A", "")
               .replace("_3B", "").replace("_3", "").replace("_2", "")
               .replace("_1", "");
    }

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

    public String getType(){
        return type;
    }

    public int getTier(){
        return tier;
    }
}
