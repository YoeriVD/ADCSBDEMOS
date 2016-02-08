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
            for (int i = 0; i < 10; i++)
            {
                DoWork(i);
            }

            Parallel.For(0, 10, (i, state) =>
            {
                //DoWork(i);
            });
        }

        public void DoWork(int i)
        {
            Thread.Sleep(new Random().Next(200, 2000));
            Console.WriteLine(i + " is ready");
        }
    }
}
