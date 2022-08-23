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
            queue.Add(20);
            queue.Add(15);
            queue.Add(11);
            queue.Add(10);
            queue.Add(7);
            queue.Add(6);
            queue.Add(3);
            queue.Add(16);

            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
