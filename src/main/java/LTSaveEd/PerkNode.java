package LTSaveEd;

import java.util.ArrayList;

public class PerkNode {

    private final String row;
    private final String name;
    private final String type;
    private boolean active;
    private final ArrayList<PerkNode> parent;
    private final ArrayList<PerkNode> children;

    public PerkNode(PerkNode perkParent, String perkRow, String perkType, String perkName){
        parent = new ArrayList<>();
        if(perkParent != null) {
            parent.add(perkParent);
            parent.get(0).addChild(this);
        }
        row = perkRow;
        type = perkType;
        name = perkName;
        active = false;
        children = new ArrayList<>();
    }

    public PerkNode(PerkNode perkParent1, PerkNode perkParent2, String perkRow, String perkType, String perkName){
        parent = new ArrayList<>();
        parent.add(perkParent1);
        parent.get(0).addChild(this);
        parent.add(perkParent2);
        parent.get(1).addChild(this);
        row = perkRow;
        type = perkType;
        name = perkName;
        active = false;
        children = new ArrayList<>();
    }

    public String getRow(){
        return row;
    }

    public String getName() {
        return name;
    }

    public String getType() {
        return type;
    }

    private void addChild(PerkNode child){
        children.add(child);
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean value){
        if(!value){
            active = false;
            deactivate();
        }
        else{
            if(active = true){
                return;
            }
            active = true;
            activate();
        }
    }

    private void activate(){
        if(parent.size() == 0){
            return;
        }
        for (PerkNode perkNode : parent) {
            perkNode.setActive(true);
        }
    }

    private void deactivate(){
        if(children.size() == 0){
            return;
        }
        for (PerkNode child : children) {
            child.setActive(false);
        }
    }

    private boolean equals(String perkRow, String perkType){
        return row.equals(perkRow) && type.equals(perkType);
    }
}
