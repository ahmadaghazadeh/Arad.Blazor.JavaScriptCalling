using Microsoft.JSInterop;

namespace Arad.Blazor.JavaScriptCalling
{
    public class JavaScriptCallingService: IJavaScriptCallingService
    {
        private IJSObjectReference module;
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

        public async Task<string> GetInnerHtmlAsync(string elementId)
        {
            return  await InvokeAsync("getInnerHtml", elementId);
        }
    }
}
