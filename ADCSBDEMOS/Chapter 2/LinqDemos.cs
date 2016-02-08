using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ADCSBDEMOS.Chapter_1;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_2
{
    internal class LinqDemos
    {
        public void Run()
        {
            Demo();
            //RunAndPrintExecutionTime(Demo);
            //GroupBy();
            //LetPerformance().Wait();
            //SlowSelect();
        }

        private void Demo()
        {
            var cars = Data.Cars;

            cars.Print();
        }
       

        private async Task LetPerformance()
        {
            var withoutTask = Task.Run(() => ExecuteALot(() => PerformanceWithoutLet()));
            var withTask = Task.Run(() => ExecuteALot(() => PerformanceWithLet()));

            await Task.WhenAll(withTask, withoutTask);
            PrintResult("without", withoutTask.Result);
            PrintResult("with", withTask.Result);
        }
        private static IEnumerable<Car> PerformanceWithoutLet()
        {
            var cars = from car in Data.Cars
                where car.Mileage > Data.Cars.Average(c => c.Mileage)
                select car;
            return cars.ToList();
        }
        private static IEnumerable<Car> PerformanceWithLet()
        {
            var cars = from car in Data.Cars
                let av = Data.Cars.Average(c => c.Mileage)
                where car.Mileage > av
                select car;
            return cars.ToList();
        }
        private static void SlowSelect()
        {
            var cars = Data
                .Cars
                .Where(car => car.Mileage > 100000)
                .Where(car => !string.IsNullOrEmpty(car.Make) && car.Make.Contains("a"))
                .Select((car, index) =>
                {
                    Thread.Sleep(new Random().Next(100, 2000));
                    Console.WriteLine($"car {index} ready");
                    return new {car.Mileage};
                });

            var result = cars.ToList();
            result.Print();
        }
        private static void GroupBy()
        {
            var groups =
                from car in Data.Cars
                where car.Mileage > 190000
                orderby car.Make
                group car by car.Make
                into grouping
                where grouping.Count() > 1
                select grouping;

            groups = groups.ToList();

            groups
                .ToList()
                .ForEach(g => g.Print());

            var keys = groups.Select(g => g.Key);
            keys.Print();
        }

        #region helpers
        private static long ExecuteALot(Action action)
        {
            return MeasureExecutionTime(() =>
            {
                for (var i = 0; i < 1000; i++)
                {
                    action();
                }
            });
        }
        private static long MeasureExecutionTime(Action action)
        {
            var timer = new Stopwatch();
            timer.Start();
            action();
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
        private void RunAndPrintExecutionTime(Action action)
        {
            var time = MeasureExecutionTime(action);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Execution time : {time} milliseconds");
        }
        private static void PrintResult(string withOrWithout, long time)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Execution time {withOrWithout} let: {time} milliseconds");
        }
        #endregion
    }
}