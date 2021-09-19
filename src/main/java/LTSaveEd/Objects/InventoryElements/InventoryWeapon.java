package LTSaveEd.Objects.InventoryElements;

import LTSaveEd.Objects.Attribute;
import LTSaveEd.Objects.InventoryElements.AbstractInventoryElements.AbstractInventoryElement;
import javafx.scene.control.ComboBox;
import org.w3c.dom.Node;

public class InventoryWeapon extends AbstractInventoryElement {

    private String coreEnchantment;
    private String damageType;

    public InventoryWeapon(Node weaponNode) {
        super(weaponNode);
        coreEnchantment = node.getAttribute("coreEnchantment");
        damageType = node.getAttribute("damageType");
    }

    public String getCoreEnchantment() {
        return coreEnchantment;
    }

    //Used in Inventory editing v2
    @Deprecated
    public void setCoreEnchantment(String coreEnchantment) {
        this.coreEnchantment = coreEnchantment;
        node.getAttributeNode("coreEnchantment").setValue(coreEnchantment);
    }

    public String getDamageType() {
        return damageType;
    }

    @SuppressWarnings("unchecked")
    public void updateDamageType() {
        damageType = ((ComboBox<Attribute>) hBoxNodes.get(1)).getValue().getValue();
        node.getAttributeNode("damageType").setValue(damageType);
    }

    @Override
    public boolean isEqual(AbstractInventoryElement element) {
        return (element instanceof InventoryWeapon) && this.getId().equals(element.getId()) &&
                coreEnchantment.equals(((InventoryWeapon) element).getCoreEnchantment()) &&
                damageType.equals(((InventoryWeapon) element).getDamageType()) && hasEqualEffects(element);
    }
}
