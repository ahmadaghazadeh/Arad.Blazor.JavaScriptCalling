
using Microsoft.Extensions.DependencyInjection;

namespace Arad.Blazor.JavaScriptCalling
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddJavaScriptCalling(this IServiceCollection services)
        {
            services.AddTransient<IJavaScriptCallingService, JavaScriptCallingService>();
            return services;
        }
    }
}
