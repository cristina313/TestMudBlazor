namespace TestMudBlazor.Contracts
{
    public class UnhandledExceptionSender : ILogger, IUnhandledExceptionSender
    {

        public event EventHandler<Exception> UnhandledExceptionThrown;

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (exception != null)
            {
                UnhandledExceptionThrown?.Invoke(this, exception);
            }
        }
    }
}
