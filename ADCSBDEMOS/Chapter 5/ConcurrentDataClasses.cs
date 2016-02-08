using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ADCSBDEMOS.Chapter_5
{
    class ConcurrentDataClasses
    {
        public void Run()
        {
            var dict = new ConcurrentDictionary<int, string>();
            Parallel.ForEach(Enumerable.Range(0, 2000), i => dict.GetOrAdd(i, "bla " + i));
            Parallel.ForEach(Enumerable.Range(0, 2000), i => dict.AddOrUpdate(i, "bla " + i, UpdateValueFactory));

            Console.WriteLine(dict.Count);
            Console.WriteLine(dict.Values.Count(v => v.Contains("updated")));
        }

        private string UpdateValueFactory(int i, string s)
        {
            return "updated";
        }
    }
}
