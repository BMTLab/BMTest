using System;
using System.Runtime.CompilerServices;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;


namespace BMTest.Engine.Sample.Infrastructures.Logging.Extensions
{
    public static class LoggingExtensions
    {
        // ReSharper disable once ConvertIfStatementToReturnStatement
        // ReSharper disable once UnusedMethodReturnValue.Global
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static ILoggingBuilder SetMinimumLevel(this ILoggingBuilder builder, [NotNull] string environmentName)
        {
            if (string.IsNullOrWhiteSpace(environmentName))
                throw new ArgumentException(@"Environment name must be setted", nameof(environmentName));

            if (environmentName.Equals(@"PRODUCTION", StringComparison.InvariantCultureIgnoreCase))
                return builder.SetMinimumLevel(LogLevel.Information);

            if (environmentName.Equals(@"STAGING", StringComparison.InvariantCultureIgnoreCase))
                return builder.SetMinimumLevel(LogLevel.Debug);

            if (environmentName.Equals(@"DEVELOPMENT", StringComparison.InvariantCultureIgnoreCase))
                return builder.SetMinimumLevel(LogLevel.Trace);

            return builder.SetMinimumLevel(LogLevel.Information);
        }
    }
}