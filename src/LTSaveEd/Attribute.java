package LTSaveEd;

public class Attribute {

    private final String name;
    private final String value;

    public Attribute(String name, String value){
        this.name = name;
        this.value = value;
    }

    public String getName() {
        return name;
    }

    public String getValue() {
        return value;
    }

    public boolean equals(String s){
        return value.equals(s);
    }
}
