namespace LTSaveEd.Models.CharacterData.InventoryData.Clothes;

public class ClothingData(string displayValue, string value, int colorCount) : InventoryElementData(displayValue, value)
{
    public int ColorCount { get; } = colorCount;
}