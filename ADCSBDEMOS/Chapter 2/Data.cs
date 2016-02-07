using System;
using System.Collections.Generic;

namespace ADCSBDEMOS.Chapter_2
{
    public class Car
    {
        public string Make { get; set; }
        public string Type { get; set; }
        public float Mileage { get; set; }

        public override string ToString()
        {
            return $"Make = {Make}, Type = {Type}, Mileage = {Mileage.ToString("F")}";
        }
    }

    internal class Data
    {
        private static readonly string[] Makes = {"Mercedes", "BMW", "Volvo", "Audi", "Skoda", "FIAT"};
        private static readonly string[] Types = {"Sedan", "Break", "MonoVolume", "Sport"};

        public static IEnumerable<Car> Cars
        {
            get
            {
                var random = new Random();
                for (var i = 0; i < 300; i++)
                    yield return
                        new Car
                        {
                            Make = Makes[random.Next(Makes.Length)],
                            Type = Types[random.Next(Types.Length)],
                            Mileage = ((float)random.Next(9999, 20000000))/100
                        };
            }
        }
    }
}