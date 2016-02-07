using System;
using System.Collections.Generic;

namespace ADCSBDEMOS.Chapter_2
{
    internal static class Extensions
    {
        internal static void Print<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}