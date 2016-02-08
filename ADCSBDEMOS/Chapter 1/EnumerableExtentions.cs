using System;
using System.Collections.Generic;

namespace ADCSBDEMOS.Chapter_1
{
    public static class EnumerableExtentions
    {
        public static void Print<T>(this IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}