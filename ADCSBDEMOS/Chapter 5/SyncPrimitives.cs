using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ADCSBDEMOS.Chapter_2;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_5
{
    internal class SyncPrimitives
    {
        public void Run()
        {
            //            Barrier();
            //            CountDownEvent();
            //Semaphore();
            Lazy();
        }

        public void Barrier()
        {
            var range = Enumerable.Range(0, 10).ToList();
            var barrier = new Barrier(range.Count + 1);
            Parallel.ForEach(range, i =>
            {
                Task.Run(() =>
                {
                    Console.Write(i + " ");
                    barrier.SignalAndWait();
                    Console.WriteLine($"{i} stopped");
                });
            });
            barrier.SignalAndWait();
            Console.WriteLine("done");
        }

        public void CountDownEvent()
        {
            var range = Enumerable.Range(0, 10).ToList();
            var countDown = new CountdownEvent(range.Count);
            Parallel.ForEach(range, i =>
            {
                Task.Run(() =>
                {
                    Console.Write(i + " ");
                    countDown.Signal();
                    Console.WriteLine("after signal " + i);
                });
            });
            countDown.Wait();
            Console.WriteLine("done");
        }

        public void Semaphore()
        {
            var range = Enumerable.Range(0, 10).ToList();
            var sem = new SemaphoreSlim(2);
            Parallel.ForEach(range, i =>
            {
                sem.Wait();
                Console.WriteLine($"Current sem count after wait of {i} : {sem.CurrentCount}");
                Task.Run(() =>
                {
                    Thread.Sleep(500);
                    sem.Release();
                    Console.WriteLine($"Current sem count after release of {i} : {sem.CurrentCount}");
                });
            });
            Console.WriteLine("done");
        }


        public void Lazy()
        {
            var cars = new Lazy<IEnumerable<Car>>(() => Data.Cars.ToList());

            var range = Enumerable.Range(0, 10).ToList();
            Parallel.ForEach(range, i =>
            {
                Task.Run(() =>
                {
                    Thread.Sleep(500);
                    var carList = cars.Value;
                });
            });
            Console.WriteLine("done");
        }
    }

}