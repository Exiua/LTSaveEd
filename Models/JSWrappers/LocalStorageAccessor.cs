using System.Globalization;
using LTSaveEd.Utility;
using Microsoft.JSInterop;

namespace LTSaveEd.Models.JSWrappers;

public class LocalStorageAccessor(IJSRuntime jsRuntime) : JsWrapper(jsRuntime)
{
    protected override string JsFileName => "/js/LocalStorageAccessor.js";
    
    public async Task<T> GetValueAsync<T>(string key)
    {
        await WaitForReference();
        var result =  await AccessorJsRef.Value.InvokeAsync<string>("get", key);
        if (typeof(T) == typeof(int))
        {
            return (T)(object)TypeHelper.ParseInt(result);
        }
        if (typeof(T) == typeof(float))
        {
            return (T)(object)TypeHelper.ParseFloat(result);
        }
        if (typeof(T) == typeof(bool))
        {
            return (T)(object)TypeHelper.ParseBool(result);
        }
        return (T)(object)result;
    }

    public async Task<bool> CheckValueExistsAsync(string key)
    {
        await WaitForReference();
        return await AccessorJsRef.Value.InvokeAsync<bool>("exists", key);
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await WaitForReference();
        await AccessorJsRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task Clear()
    {
        await WaitForReference();
        await AccessorJsRef.Value.InvokeVoidAsync("clear");
    }

    public async Task RemoveAsync(string key)
    {
        await WaitForReference();
        await AccessorJsRef.Value.InvokeVoidAsync("remove", key);
    }
}