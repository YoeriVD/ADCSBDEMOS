using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADCSBDEMOS.Chapter_5
{
    class TaskParallelLibraryDemos
    {
        public void Run()
        {
            //Parallel();
            Tasks();
            Console.WriteLine("DONE!");
        }

        private void Parallel()
        {
            for (int i = 0; i < 10; i++)
            {
                DoWork(i);
            }

            System.Threading.Tasks.Parallel.For(0, 10, (i, state) =>
            {
                //DoWork(i);
            });
        }

        private void Tasks()
        {
            var listOfTasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var count = i;
                var t = new Task(() => DoWork(count));
                listOfTasks.Add(t);
                t.Start();
            }
            Task.WaitAll(listOfTasks.ToArray());
        }

        public void DoWork(int i)
        {
            Thread.Sleep(new Random().Next(200, 2000));
            Console.WriteLine(i + " is ready");
        }
    }
}
