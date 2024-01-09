namespace LTSaveEd.Models.CharacterData.InventoryData.Weapons;

public class WeaponData(string displayValue, string value, int colorCount, string coreEnchantment,
    string defaultEnchantment) : InventoryElementData(displayValue, value)
{
    public int ColorCount { get; } = colorCount;
    public string CoreEnchantment { get; } = coreEnchantment;
    public string DefaultEnchantment { get; } = defaultEnchantment;
}