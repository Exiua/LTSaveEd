package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;

public class InventoryWeapon extends InventoryElement{

    private String coreEnchantment;
    private String damageType;

    public InventoryWeapon(Node weaponNode) {
        super(weaponNode);
        Element attrs = (Element) weaponNode;
        coreEnchantment = attrs.getAttribute("coreEnchantment");
        damageType = attrs.getAttribute("damageType");
    }

    public String getCoreEnchantment() {
        return coreEnchantment;
    }

    public void setCoreEnchantment(String coreEnchantment) {
        this.coreEnchantment = coreEnchantment;
    }

    public String getDamageType() {
        return damageType;
    }

    public void setDamageType(String damageType) {
        this.damageType = damageType;
    }
}
