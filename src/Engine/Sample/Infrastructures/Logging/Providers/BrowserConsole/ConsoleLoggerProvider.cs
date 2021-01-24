using System;
using System.Collections.Concurrent;

using Microsoft.Extensions.Logging;


namespace BMTest.Engine.Sample.Infrastructures.Logging.Providers.BrowserConsole
{
    [ProviderAlias("BrowserConsole")]
    public sealed class ConsoleLoggerProvider : ILoggerProvider
    {
        #region Fields
        private static readonly Func<string, LogLevel, bool> TrueFilter = (_, _) => true;
        private static ConcurrentDictionary<string, ConsoleLogger>? _loggers;
        private readonly Func<string, LogLevel, bool>? _filter;
        private bool _isDisposed;
        #endregion _Fields
        
        
        #region Ctors
        public ConsoleLoggerProvider(Func<string, LogLevel, bool>? filter)
        {
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }
        #endregion _Ctors


        #region Methods
        public ILogger CreateLogger(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException(@"The category must not be empty", nameof(categoryName));

            _loggers ??= new ConcurrentDictionary<string, ConsoleLogger>();

            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }


        private ConsoleLogger CreateLoggerImplementation(string name) =>
            new(name, GetFilter());


        private Func<string, LogLevel, bool> GetFilter() =>
            _filter ?? TrueFilter;
        #endregion _Methods


        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
                _loggers?.Clear();

            _isDisposed = true;
        }


        ~ConsoleLoggerProvider()
        {
            Dispose(false);
        }
        #endregion _IDisposable
    }
}