using LTSaveEd.Models.JSWrappers;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LTSaveEd.Models;

public class Settings
{
    private static readonly ILogger Logger = Log.ForContext<Settings>();
    
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
            Logger.Error(ex, "Error saving setting {SettingKey}", keyString);
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