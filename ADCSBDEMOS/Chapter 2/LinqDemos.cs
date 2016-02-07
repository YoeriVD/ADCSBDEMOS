using System.Linq;

namespace ADCSBDEMOS.Chapter_2
{
    internal class LinqDemos
    {
        public void Run()
        {
            //SimpleFrom();
            //GroupBy();
        }

        private void SimpleFrom()
        {
            var cars = from car in Data.Cars select car.Make;
            cars.Print();
        }

        private static void GroupBy()
        {
            var group =
                from car in Data.Cars
                where car.Mileage > 190000
                group car by car.Make
                into grouping
                where grouping.Count() > 1
                select grouping;

            group
                .ToList()
                .ForEach(g => g.Print());
        }
    }
}