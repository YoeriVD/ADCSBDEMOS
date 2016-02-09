using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADCSBDEMOS.Chapter_5
{
    internal class TaskParallelLibraryDemos
    {
        public event EventHandler SomeEvent;

        public void Run()
        {
            //ParallelDemo();
            Tasks();
            
            Console.WriteLine("DONE!");
        }

       

        private void ParallelDemo()
        {
            for (var i = 0; i < 10; i++)
            {
                //                DoWork(i);
            }

            var range = new List<string>
            {
                "test",
                "tfgsdfgt",
                "tfgsdfgdsfgft",
                "testfgsdfgsdgdsfgd"
            };

            Parallel.ForEach(range, (current, loopState) => { DoWork(current); });
        }


        private void Tasks()
        {
            var listOfTasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                var count = i;

                var source = new CancellationTokenSource();
                var t = Task.Run(() => DoWork(count.ToString()), source.Token);

                t.ContinueWith(previousTask =>
                {
                    if (!previousTask.IsCanceled && previousTask.IsCompleted)
                    {
                        Console.WriteLine(previousTask.Result);
                    }
                    else
                    {
                        Console.WriteLine($"c: {previousTask.IsCanceled}, f: {previousTask.IsFaulted}");
                    }
                    throw new Exception();
                }, source.Token)
                    .ContinueWith(
                    task => Console.WriteLine("faulted: " + task.IsFaulted),
                    source.Token);

                listOfTasks.Add(t);

                source.Cancel();
            }
            try
            {
                Task.WaitAll(listOfTasks.ToArray());
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
        }

        private string DoWork(string i)
        {
            Thread.Sleep(new Random().Next(200, 2000));
            Console.WriteLine(i + " is ready");
            return i + "from task 1";
        }
    }
}