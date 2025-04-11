namespace TestMudBlazor.Contracts
{
    public class MessageLogService
    {


        SizedQueue<string> _LastMessages = new(5);

        public void AddMessageLog(string message)
        {
            _LastMessages.Enqueue(message);
            //add to cache?
        }

        public IList<string> GetMessages()
        {
            return [.. _LastMessages];
        }
    }
}
