using PriorityQueue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new BinaryHeap();
            queue.Enqueue(20);
            queue.Enqueue(15);
            queue.Enqueue(11);
            queue.Enqueue(10);
            queue.Enqueue(7);
            queue.Enqueue(6);
            queue.Enqueue(3);
            queue.Enqueue(16);

            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
