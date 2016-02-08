using System;
using System.Collections.Generic;
using System.Linq;

namespace ADCSBDEMOS.Chapter_1
{
    public static class PrintExtentions
    {
        public static void Print<T>(this IEnumerable<T> list)
        {
            list
                .ToList()
                .ForEach(item => Console.WriteLine(item.ToString()));
        }

        public static void Print<T>(this T obj)
        {
            Console.WriteLine(obj);
        }
    }
}