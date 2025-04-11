namespace TestMudBlazor.Contracts
{
    public interface IUnhandledExceptionSender
    {
        event EventHandler<Exception> UnhandledExceptionThrown;
    }
}