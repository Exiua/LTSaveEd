namespace LTSaveEd.Models.CharacterData.InventoryData.Weapons;

public class WeaponData(string displayValue, string value, int colorCount, string coreEnchantment) : InventoryElementData(displayValue, value)
{
    public int ColorCount { get; } = colorCount;
    public string CoreEnchantment { get; } = coreEnchantment;
}