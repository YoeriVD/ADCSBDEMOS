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
            //Demo();
            //RunAndPrintExecutionTime(CooleQuery);
            //RunAndPrintExecutionTime(Demo);
            //GroupBy();
            //LetPerformance().Wait();
            //SlowSelect();
        }

        private void Demo()
        {
            var list = new IRepeater[]
            {
                new SomeGeneratedClass0(),
                new SomeGeneratedClass1(),
                new SomeGeneratedClass0(),
                new SomeGeneratedClass3()
            };

            var result = list.OfType<SomeGeneratedClass3>().Count();
            result.Print();
        }

        private static void CooleQuery()
        {
            var result =
                from car in Data.Cars
                let maxDepth = car.Wheels.Max(w => w.Depth)
                let avDepth = Data.Cars.SelectMany(c => c.Wheels).Average(w => w.Depth)
                where maxDepth > avDepth
                orderby car.Make
                select new
                {
                    car,
                    wheels = car
                        .Wheels
                        .Aggregate("Wheels: ", (s, wheel) => s += ", " + wheel.Depth)
                };

            foreach (var item in result)
            {
                //Console.WriteLine(string.Format("Car: {0} - {1}", item.car.Make, item.wheels));
                Console.WriteLine($"Car: {item.car.Make} - {item.car.Type}");
                Console.WriteLine($"Wheels: {item.wheels}");
            }
            //result.Print();
            //Console.WriteLine(result);
        }

        private async Task LetPerformance()
        {
            var withoutTask = Task.Run(() => Performance.ExecuteALot(() => PerformanceWithoutLet()));
            var withTask = Task.Run(() => Performance.ExecuteALot(() => PerformanceWithLet()));

            await Task.WhenAll(withTask, withoutTask);
            Performance.PrintResult("without", withoutTask.Result);
            Performance.PrintResult("with", withTask.Result);
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
                //.AsParallel()
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
    }
}