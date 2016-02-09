using System;
using System.Collections.Generic;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_2
{
    internal static class Data
    {
        private static readonly string[] Makes = {"Mercedes", "BMW", "Volvo", "Audi", "Skoda", "FIAT"};
        private static readonly string[] Types = {"Sedan", "Break", "MonoVolume", "Sport"};

        public static IEnumerable<Car> Cars
        {
            get
            {
                var random = new Random();
                Console.WriteLine("creating car list");
                for (var i = 0; i < 300; i++)
                    yield return
                        new Car
                        {
                            Make = Makes[random.Next(Makes.Length)],
                            Type = Types[random.Next(Types.Length)],
                            Mileage = (float) random.Next(9999, 20000000)/100,
                            Name = Guid.NewGuid().ToString(),
                            Wheels = new List<Wheel>()
                            {
                                new Wheel() {Depth = random.Next(0,400)},
                                new Wheel() {Depth = random.Next(0,400)},
                                new Wheel() {Depth = random.Next(0,400)},
                                new Wheel() {Depth = random.Next(0,400)}
                            }
                        };
            }
        }
    }
}