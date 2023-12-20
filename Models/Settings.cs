using LTSaveEd.Models.JSWrappers;

namespace LTSaveEd.Models;

public class Settings
{
    private LocalStorageAccessor _localStorageAccessor = null!;
    private bool _darkMode;

    public bool DarkMode
    {
        get => _darkMode;
        set
        {
            _darkMode = value;
            SaveSettingAsync(SettingsKey.DarkMode, value);
        }
    }

    public async Task InitializeAsync(LocalStorageAccessor localStorageAccessor)
    {
        _localStorageAccessor = localStorageAccessor;
        _darkMode = await ReadSettingAsync<bool>(SettingsKey.DarkMode);
    }
    
    private async void SaveSettingAsync<T>(SettingsKey key, T value) where T : struct
    {
        var keyString = key.ToString(); 
        try
        {
            await _localStorageAccessor.SetValueAsync(keyString, value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving setting {keyString}: {ex}");
        }
    }

    private Task<T> ReadSettingAsync<T>(SettingsKey key) where T : struct
    {
        return _localStorageAccessor.GetValueAsync<T>(key.ToString());
    }
}