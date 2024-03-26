﻿#region Using directives
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise.Icons.FontAwesome;
using Blazorise.Tailwind;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace Blazorise.Demo.Tailwind;

public class Program
{
    public static async Task Main( string[] args )
    {
        var builder = WebAssemblyHostBuilder.CreateDefault( args );

        builder.Services
            .SetupDemoServices( builder.Configuration["Licensing:ProductToken"], builder.Configuration["ReCaptchaSiteKey"] )
            .AddTailwindProviders()
            .AddFontAwesomeIcons();

        builder.RootComponents.Add<App>( "#app" );
        builder.Services.AddScoped( sp => new HttpClient { BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) } );

        await builder.Build().RunAsync();
    }
}