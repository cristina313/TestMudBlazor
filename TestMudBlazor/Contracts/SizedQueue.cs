using System.Collections.Concurrent;

namespace TestMudBlazor.Contracts
{
    public class SizedQueue<T>
    {
        readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();

        public int Size { get; private set; }

        public SizedQueue(int size)
        {
            Size = size;
        }

        public void Enqueue(T obj)
        {
            queue.Enqueue(obj);

            while (queue.Count > Size)
            {
                T outObj;
                queue.TryDequeue(out outObj);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

       
    }
}
