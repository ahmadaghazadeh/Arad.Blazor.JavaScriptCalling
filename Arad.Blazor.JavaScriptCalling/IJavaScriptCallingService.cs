using System.Threading.Tasks;
namespace Arad.Blazor.JavaScriptCalling
{
    public interface IJavaScriptCallingService
    {
       Task InvokeVoidAsync(string functionPath, params object[] args);
       Task<string> GetInnerHtmlAsync(string elementId);
       Task<string> InvokeAsync(string functionPath, params object[] args);

    }
}


