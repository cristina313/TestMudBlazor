﻿namespace TestMudBlazor.Contracts
{
    public class UnhandledExceptionProvider : ILoggerProvider
    {
        UnhandledExceptionSender _unhandledExceptionSender;


        public UnhandledExceptionProvider(UnhandledExceptionSender unhandledExceptionSender)
        {
            _unhandledExceptionSender = unhandledExceptionSender;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new UnhandledExceptionLogger(categoryName, _unhandledExceptionSender);
        }

        public void Dispose()
        {
        }

        public class UnhandledExceptionLogger : ILogger
        {
            private readonly string _categoryName;
            private readonly UnhandledExceptionSender _unhandeledExceptionSender;

            public UnhandledExceptionLogger(string categoryName, UnhandledExceptionSender unhandledExceptionSender)
            {
                _unhandeledExceptionSender = unhandledExceptionSender;
                _categoryName = categoryName;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                // Unhandled exceptions will call this method
                // Blazor already logs unhandled exceptions to the browser console
                // but, one could pass the exception to the server to log, this is easily done with serilog
                Console.WriteLine(exception.Message);
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return new NoopDisposable();
            }

            private class NoopDisposable : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
}
