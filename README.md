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
        Task DownloadElementIamge(string elementId,string fileName);
        Task PutToCanvas(string from, string canvasTag,int width, int hight);
        Task PutToImg(string from, string imgTag);
```

### Usage in Blazor page

``` c#

@page "/"

@using Arad.Blazor.JavaScriptCalling

@inject IJavaScriptCallingService javaScriptCallingService
<div class="row">
    <button class="col" @onclick="@PutToCanvas">
       PutToCanvas
    </button>
    <button class="col" @onclick="@PutToImg">
        PutToImg
    </button>
    <button class="col" @onclick="@CallTestElement">
        Call Elements
    </button>
</div>

<div class="row">

    <div class="col">
        <canvas id="myCanvas"></canvas>
        <div>
            <img id="printableImage" alt="Red dot" />
        </div>
    </div>
    <div class="col">
       <div id="printableId">
            @for (int i = 0; i < counter; i++)
            {
            <h1 id="demo">Hello, world!</h1>
            }
            Welcome to your new app.
        </div>
    </div>
</div>





@code{
    private int counter = 0;
    private async void PutToCanvas()
    {
        counter++;
        await javaScriptCallingService.PutToCanvas("printableId", "myCanvas",10,10);
        StateHasChanged();
    }
    private async void PutToImg()
    {
        counter++;
        await javaScriptCallingService.PutToImg( "printableId", "printableImage");
        StateHasChanged();
    }


    private async void CallTestElement()
    {
        var demo1 = await javaScriptCallingService.GetInnerHtmlAsync("demo");
        await javaScriptCallingService.InvokeVoidAsync("alert", $"Call directly GetInnerHtmlAsync  {demo1}");

        var demo2 = await javaScriptCallingService.InvokeAsync("getInnerHtml","demo");
        await javaScriptCallingService.InvokeVoidAsync("alert", $"Call getInnerHtml from InvokeAsync  {demo1}");
    }

}

````