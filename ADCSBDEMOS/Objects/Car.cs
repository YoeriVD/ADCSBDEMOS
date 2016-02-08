using System.Collections.Generic;
using ADCSBDEMOS.Chapter_1;

namespace ADCSBDEMOS.Objects
{
    public class Car : ICanShout, ICanShoutLouder
    {

        public string Make { get; set; }
        public string Type { get; set; }
        public float Mileage { get; set; }

        public override string ToString()
        {
            return $"Make = {Make}, Type = {Type}, Mileage = {Mileage.ToString("F")}";
        }

        public string Name { get; set; }
        public IEnumerable<Wheel> Wheels { get; set; }
    }


    public class Wheel
    {
        public int Depth { get; set; }
    }
}