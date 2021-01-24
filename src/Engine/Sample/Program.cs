using BMTest.Engine.Sample.Infrastructures.Logging.Providers.BrowserConsole.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace BMTest.Engine.Sample
{
    public static class Program
    {
        public static void Main()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging
            (
                builder =>
                {
                    builder.ClearProviders();
                    builder.AddConsole().AddFilter(@"Microsoft", LogLevel.Information);
                }
            );
        }
    }
}