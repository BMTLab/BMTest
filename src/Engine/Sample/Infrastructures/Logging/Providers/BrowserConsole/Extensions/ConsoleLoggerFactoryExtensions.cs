using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;


namespace BMTest.Engine.Sample.Infrastructures.Logging.Providers.BrowserConsole.Extensions
{
    public static class ConsoleLoggerFactoryExtensions
    {
        /// <summary>
        ///     Adds a logger that target the console output
        ///     <param name="builder">The <see cref="ILoggingBuilder" /> to use.</param>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static ILoggingBuilder AddConsole(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());

            // HACK: Override the hardcoded ILogger<> injected by Blazor
            builder.Services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(ConsoleLogger<>)));

            return builder;
        }


        /// <summary>
        ///     Adds a console logger that is enabled for <see cref="LogLevel" />s of minLevel or higher.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory" /> to use.</param>
        /// <param name="minLevel">The minimum <see cref="LogLevel" /> to be logged</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static ILoggingBuilder AddConsole(this ILoggingBuilder factory, LogLevel minLevel)
        {
            factory.AddConsole((_, logLevel) => logLevel >= minLevel);

            return factory;
        }


        /// <summary>
        ///     Adds a console logger that is enabled as defined by the filter function.
        /// </summary>
        /// <param name="factory">The <see cref="ILoggerFactory" /> to use.</param>
        /// <param name="filter">The category filter to apply to logs.</param>
        [SuppressMessage("Dispose BrowserConsoleLoggerProvider", "CA2000")]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static ILoggingBuilder AddConsole(this ILoggingBuilder factory, Func<string, LogLevel, bool> filter)
        {
            factory.AddProvider(new ConsoleLoggerProvider(filter));

            return factory;
        }
    }
}