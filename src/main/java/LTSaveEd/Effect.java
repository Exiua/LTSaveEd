package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;

public class Effect {

    private int limit;
    private String mod1;
    private String mod2;
    private String potency;
    private int timer;
    private String type;

    public Effect(Node effectNode){
        Element attrs = (Element) effectNode;
        limit = Integer.parseInt(attrs.getAttribute("limit"));
        mod1 = attrs.getAttribute("mod1");
        mod2 = attrs.getAttribute("mod2");
        potency = attrs.getAttribute("potency");
        timer = Integer.parseInt(attrs.getAttribute("timer"));
        type = attrs.getAttribute("type");
    }


    public int getLimit() {
        return limit;
    }

    public void setLimit(int limit) {
        this.limit = limit;
    }

    public String getMod1() {
        return mod1;
    }

    public void setMod1(String mod1) {
        this.mod1 = mod1;
    }

    public String getMod2() {
        return mod2;
    }

    public void setMod2(String mod2) {
        this.mod2 = mod2;
    }

    public String getPotency() {
        return potency;
    }

    public void setPotency(String potency) {
        this.potency = potency;
    }

    public int getTimer() {
        return timer;
    }

    public void setTimer(int timer) {
        this.timer = timer;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
}
