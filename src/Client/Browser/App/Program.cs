using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace BMTest.Client.Browser.App
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            #if DEBUG
            await Task.Delay(5000);
            #endif
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}