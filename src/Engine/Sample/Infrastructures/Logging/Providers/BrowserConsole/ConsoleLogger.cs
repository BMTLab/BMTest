using System;
using System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;


namespace BMTest.Engine.Sample.Infrastructures.Logging.Providers.BrowserConsole
{
    [UsedImplicitly]
    [SuppressMessage("It is an inner class that is never instantiated. If this class should only contain static methods, make it static", "CA1812")]
    public class ConsoleLogger<T> : ConsoleLogger, ILogger<T>
    {
        public ConsoleLogger() : base(typeof(T).Name, null)
        {
        }


        public ConsoleLogger(Func<string, LogLevel, bool> filter) : base(typeof(T).Name, filter)
        {
        }
    }


    [UsedImplicitly]
    public class ConsoleLogger : ILogger
    {
        #region Ctors
        public ConsoleLogger(string? name, Func<string, LogLevel, bool>? filter)
        {
            Filter = filter ?? ((_, _) => true);

            Name = name ??
                   throw new ArgumentNullException(nameof(name));
        }
        #endregion _Ctors
        
        
        #region Properties
        public Func<string, LogLevel, bool> Filter { get; }

        public string Name { get; }
        
        public bool IsEnabled(LogLevel logLevel) =>
            logLevel != LogLevel.None && Filter(Name, logLevel);
        
        public IDisposable? BeginScope<TState>(TState state) =>
            null;
        #endregion _Properties


        #region Methods
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            
            if (formatter is null)
                throw new ArgumentNullException(nameof(formatter));

            var levelString = logLevel >= LogLevel.Warning
                ? $"---! {logLevel.ToString().ToUpperInvariant()}"
                : logLevel.ToString();
            
            var message = exception is not null 
                ? $"{levelString} {DateTime.Now:HH:mm:ss} [{Name}]: {formatter(state, exception)} {exception.StackTrace}" 
                : $"{levelString} {DateTime.Now:HH:mm:ss} [{Name}]: {formatter(state, null)}";

            Console.WriteLine(message);
        }
        #endregion _Methods
    }
}