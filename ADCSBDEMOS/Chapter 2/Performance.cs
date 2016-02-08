using System;
using System.Diagnostics;

namespace ADCSBDEMOS.Chapter_2
{
    internal static class Performance
    {
        internal static long ExecuteALot(Action action)
        {
            return MeasureExecutionTime(() =>
            {
                for (var i = 0; i < 1000; i++)
                {
                    action();
                }
            });
        }

        internal static long MeasureExecutionTime(Action action)
        {
            var timer = new Stopwatch();
            timer.Start();
            action();
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        internal static void RunAndPrintExecutionTime(Action action)
        {
            var time = MeasureExecutionTime(action);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Execution time : {time} milliseconds");
        }

        internal static void PrintResult(string withOrWithout, long time)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Execution time {withOrWithout} let: {time} milliseconds");
        }
    }
}