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
            if (module is null)
                await ImportModule();
            await module.InvokeVoidAsync("InvokeVoidAsync", functionPath, args);
        }

        public async Task<string> InvokeAsync(string functionPath, params object[] args)
        {
            if (module is null)
                await ImportModule();
            return await module.InvokeAsync<string>(functionPath, args);
        }

        internal async ValueTask ImportModule()
        {
            module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Arad.Blazor.JavaScriptCalling/scripts.js");
        }

        internal async ValueTask ImportHtml2canvasModule()
        {
            html2canvasModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Arad.Blazor.JavaScriptCalling/html2canvas.js");
        }

        public async Task<string> GetInnerHtmlAsync(string elementId)
        {
            return  await InvokeAsync("getInnerHtml", elementId);
        }


        public async Task<string> getElementCanvas(string elementId)
        {
            if (html2canvasModule is null)
                await ImportHtml2canvasModule();
            return await html2canvasModule.InvokeAsync<string>("getElementCanvas", elementId);
        }

        public async Task downloadElementIamge(string elementId, string fileName)
        {
            if (html2canvasModule is null)
                await ImportHtml2canvasModule();
            await html2canvasModule.InvokeVoidAsync("ConvertElementToJpg", elementId, fileName);
        }
    }
}
