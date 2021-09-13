package LTSaveEd;

import org.w3c.dom.Element;
import org.w3c.dom.Node;

public class InventoryWeapon extends AbstractInventoryElement {

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

    @Override
    public boolean isEqual(AbstractInventoryElement element) {
        return (element instanceof InventoryWeapon) && this.getId().equals(element.getId()) &&
                coreEnchantment.equals(((InventoryWeapon) element).getCoreEnchantment()) &&
                damageType.equals(((InventoryWeapon) element).getDamageType());
    }
}
