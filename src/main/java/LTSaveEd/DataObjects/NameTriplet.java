package LTSaveEd.DataObjects;

public class NameTriplet {
    private String androgynous;
    private String feminine;
    private String masculine;
    private String surname;

    public NameTriplet(String androgynous, String feminine, String masculine){
        this.androgynous = androgynous;
        this.feminine = feminine;
        this.masculine = masculine;
    }

    public NameTriplet(String surname){
        this.surname = surname;
    }

    public String getAndrogynous() {
        return androgynous;
    }

    public void setAndrogynous(String androgynous) {
        this.androgynous = androgynous;
    }

    public String getFeminine() {
        return feminine;
    }

    public void setFeminine(String feminine) {
        this.feminine = feminine;
    }

    public String getMasculine() {
        return masculine;
    }

    public void setMasculine(String masculine) {
        this.masculine = masculine;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname){
        this.surname = surname;
    }
}
