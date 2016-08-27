using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    //No IDisposable to release the semaphore?
    class LimitedQueue<T>
    {
        private readonly Queue<T> queue;

        //Why do you need two of them? You could have implemented this only with one semaphore
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

            //According to C#'s best practices it is a good idea to use a new and seperate object for the lock.
            lock (queue)
            {
                queue.Enqueue(item);
                Console.WriteLine("number of items is " +queue.Count);
            }

            //You should insert it into a finaly clause when working with acquire-release pattern
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
