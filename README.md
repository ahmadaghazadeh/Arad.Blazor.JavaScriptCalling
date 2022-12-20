# Arad.Blazor.JavaScriptCalling
Call Javascript function in Blazor using JavaScript Interop

This is a library to easily use the JavaScript methods in Blazor.

### For inject:
``` c#

    builder.Services.AddJavaScriptCalling();

    or

    services.AddTransient<IJavaScriptCallingService, JavaScriptCallingService>();

```

There are 3 useful methods for calling JavaScript methods.
``` c#

       Task InvokeVoidAsync(string functionPath, params object[] args);
       Task<string> GetInnerHtmlAsync(string elementId);
       Task<string> InvokeAsync(string functionPath, params object[] args);

```

### Useage in Blazor page

``` c#

@page "/"

@using Arad.Blazor.JavaScriptCalling

@inject IJavaScriptCallingService javaScriptCallingService

<h1 id="demo">Hello, world!</h1>

Welcome to your new app.
 
<button @onclick="@CallFunction">
    Print PDF
</button>
@code{

    private async void CallFunction()
    {
        var demo1 = await javaScriptCallingService.GetInnerHtmlAsync("demo");
        await javaScriptCallingService.InvokeVoidAsync("alert", $"Call directly GetInnerHtmlAsync  {demo1}");

        var demo2 = await javaScriptCallingService.InvokeAsync("getInnerHtml","demo");
        await javaScriptCallingService.InvokeVoidAsync("alert", $"Call getInnerHtml from InvokeAsync  {demo1}");
    }

}

````



