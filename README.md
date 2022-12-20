# Arad.Blazor.JavaScriptCalling

[Nuget](https://www.nuget.org/packages/Arad.Blazor.JavaScriptCalling)

[Github](https://github.com/ahmadaghazadeh/Arad.Blazor.JavaScriptCalling)

Install
``` bash

dotnet add package Arad.Blazor.JavaScriptCalling  

```

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
       Task<string> getElementCanvas(string elementId);
       Task downloadElementIamge(string elementId,string fileName);
```

### Usage in Blazor page

``` c#

@page "/"

@using Arad.Blazor.JavaScriptCalling

@inject IJavaScriptCallingService javaScriptCallingService

<div id="printableId">
<h1 id="demo">Hello, world!</h1>

Welcome to your new app.


<div>
    <img src="@printableImage" alt="Red dot" />
</div>

    <button @onclick="@CallFunction">
        Execute
    </button>

</div>
 

@code{
    private string printableImage="";
    private async void CallFunction()
    {
        var demo1 = await javaScriptCallingService.GetInnerHtmlAsync("demo");
        await javaScriptCallingService.InvokeVoidAsync("alert", $"Call directly GetInnerHtmlAsync  {demo1}");

        var demo2 = await javaScriptCallingService.InvokeAsync("getInnerHtml","demo");
        await javaScriptCallingService.InvokeVoidAsync("alert", $"Call getInnerHtml from InvokeAsync  {demo1}");

        printableImage = await javaScriptCallingService.getElementCanvas("printableId");
        StateHasChanged();
    }

}

````