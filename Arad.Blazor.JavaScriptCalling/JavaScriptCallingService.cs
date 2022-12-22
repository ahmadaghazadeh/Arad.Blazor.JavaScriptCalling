using Microsoft.JSInterop;

namespace Arad.Blazor.JavaScriptCalling
{
    public class JavaScriptCallingService: IJavaScriptCallingService
    {
        private IJSObjectReference module;
        private IJSObjectReference html2canvasModule;

        private readonly IJSRuntime jsRuntime;

        public JavaScriptCallingService(IJSRuntime jsRuntime)
        {
           this.jsRuntime = jsRuntime;
        }


        public async Task InvokeVoidAsync(string functionPath, params object[] args)
        {
            await ImportModule();
            await module.InvokeVoidAsync("InvokeVoidAsync", functionPath, args);
        }

        public async Task<string> InvokeAsync(string functionPath, params object[] args)
        {
            await ImportModule();
            return await module.InvokeAsync<string>(functionPath, args);
        }

        internal async ValueTask ImportModule()
        {
            if (module is null)
                module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Arad.Blazor.JavaScriptCalling/scripts.js");
        }

        internal async ValueTask ImportHtml2canvasModule()
        {
            if (html2canvasModule is null)
                html2canvasModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Arad.Blazor.JavaScriptCalling/html2canvas.js");
        }

        public async Task<string> GetInnerHtmlAsync(string elementId)
        {
            return  await InvokeAsync("getInnerHtml", elementId);
        }


        public async Task<string> GetImageBase64(string elementId)
        {
            await ImportHtml2canvasModule();
            return await html2canvasModule.InvokeAsync<string>("GetImageBase64", elementId);
        }

       

        public async Task DownloadElementIamge(string elementId, string fileName)
        {
            await ImportHtml2canvasModule();
            await html2canvasModule.InvokeVoidAsync("ConvertElementToJpg", elementId, fileName);
        }

     

        public async Task PutToCanvas(string from, string canvasTag, int width, int hight)
        {
            await ImportHtml2canvasModule();
            await html2canvasModule.InvokeVoidAsync("putToCanvas", from, canvasTag, width, hight);
        }

        public async Task PutToImg(string from, string imgTag)
        {
          
            await ImportHtml2canvasModule();
            await html2canvasModule.InvokeVoidAsync("putToImg", from, imgTag);
        }
    }
}
