using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static LimitedQueue<int> _limitQueue;
        static void Main(string[] args)
        {
            _limitQueue = new LimitedQueue<int>(50);
            ThreadPool.QueueUserWorkItem(writer);
            ThreadPool.QueueUserWorkItem(reader);
            Console.ReadLine();
        }

        private static void writer(object obj)
        {
            for (int i = 0; i < 1000; i++)
                _limitQueue.Enque(i);

        }
        private static void reader(object obj)
        {
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("the item that was drown is "+ _limitQueue.Deque());
        }
    }
}
