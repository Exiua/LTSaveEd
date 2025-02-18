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
        _darkMode = await ReadOrSetDefaultSettingAsync(SettingsKey.DarkMode, false);
    }
    
    // ReSharper disable once AsyncVoidMethod
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

    private async Task<T> ReadOrSetDefaultSettingAsync<T>(SettingsKey key, T defaultValue)
    {
        var keyString = key.ToString();
        if (await _localStorageAccessor.CheckValueExistsAsync(keyString))
        {
            return await _localStorageAccessor.GetValueAsync<T>(keyString);
        }

        await _localStorageAccessor.SetValueAsync(keyString, defaultValue);
        return defaultValue;
    }
}