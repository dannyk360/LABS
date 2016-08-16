using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue<T>
    {
        private readonly Queue<T> queue;
        private readonly SemaphoreSlim readerSem,writerSem;
        public LimitedQueue(int maximumNumberOfItems)
        {
            readerSem = new SemaphoreSlim(0);
            writerSem = new SemaphoreSlim(maximumNumberOfItems);
            queue = new Queue<T>();
        }
        public void Enque(T item)
        {
            writerSem.Wait();
            lock (queue)
            {
                queue.Enqueue(item);
                Console.WriteLine("number of items is " +queue.Count);
            }
            readerSem.Release();
        }

        public T Deque()
        {
            T item;
            readerSem.Wait();
            lock (queue)
            {
                item = queue.Dequeue();
            }
            writerSem.Release();
            return item;
        }
    }
}
