package LTSaveEd;

import javafx.collections.ObservableList;

public class LegTypeAttr extends Attribute{

    private final ObservableList<Attribute> legConfiguration;
    private final ObservableList<Attribute> footStructure;
    private final ObservableList<Attribute> genitalArrangement;
    private final Attribute defaultLegConfiguration;
    private Attribute defaultFootStructure;
    private final Attribute defaultGenitalArrangement;

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

    public ObservableList<Attribute> getLegConfiguration(){
        return legConfiguration;
    }

    public ObservableList<Attribute> getFootStructure() {
        return footStructure;
    }

    public ObservableList<Attribute> getGenitalArrangement() {
        return genitalArrangement;
    }

    public Attribute getDefaultLegConfiguration() {
        return defaultLegConfiguration;
    }

    public Attribute getDefaultFootStructure() {
        return defaultFootStructure;
    }

    public Attribute getDefaultGenitalArrangement() {
        return defaultGenitalArrangement;
    }
}
