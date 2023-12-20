using Microsoft.JSInterop;

namespace LTSaveEd.Models.JSWrappers;

public class FileHandler(IJSRuntime jsRuntime) : JsWrapper(jsRuntime)
{
    protected override string JsFileName => "/js/FileHandler.js";
    
    public async Task DownloadFileFromByteArrayAsync(byte[] data, string fileName)
    {
        await WaitForReference();
        await AccessorJsRef.Value.InvokeVoidAsync("saveFile", data, fileName);
    }
}