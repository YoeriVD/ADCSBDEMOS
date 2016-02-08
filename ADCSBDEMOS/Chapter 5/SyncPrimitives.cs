using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADCSBDEMOS.Chapter_5
{
    class SyncPrimitives
    {
        public void Run()
        {
//            Barrier();
//            CountDownEvent();
            
        }

        public void Barrier()
        {
            var range = Enumerable.Range(0, 10).ToList();
            var barrier = new Barrier(range.Count);
            Parallel.ForEach(range, i =>
            {
                Console.Write(i + " ");
                barrier.SignalAndWait();
            });
            Console.WriteLine("done");
        }

        public void CountDownEvent()
        {
            var range = Enumerable.Range(0, 10).ToList();
            var countDown = new CountdownEvent(range.Count);
            Parallel.ForEach(range, i =>
            {
                Console.Write(i + " ");
                countDown.Signal();
            });
            countDown.Wait();
            Console.WriteLine("done");
        }
    }
}