using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCSBDEMOS.Chapter_1;

namespace ADCSBDEMOS.Chapter_5
{
    class Plinq
    {
        public void Run()
        {
            var numbers = Enumerable.Range(0, 20);
            Console.WriteLine("AsOrdered");
            AsOrdered(numbers);
            Console.WriteLine("Order by");
            OrderBy(numbers);

        }

        private static void OrderBy(IEnumerable<int> numbers)
        {
            var evenNumbers =
                from number in numbers
                    .AsParallel()
                where number%2 == 0
                orderby number
                select number;

            evenNumbers.AsEnumerable().Print();
        }

        private static void AsOrdered(IEnumerable<int> numbers)
        {
            var evenNumbers =
                from number in numbers
                    .AsParallel()
                    .AsOrdered()
                where number%2 == 0
                select number;

            evenNumbers.AsEnumerable().Print();
        }
    }
}