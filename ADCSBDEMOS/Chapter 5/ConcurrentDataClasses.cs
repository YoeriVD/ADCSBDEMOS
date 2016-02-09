using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ADCSBDEMOS.Chapter_1;

namespace ADCSBDEMOS.Chapter_5
{
    class ConcurrentDataClasses
    {
        private ConcurrentDictionary<int, string> _dict;
        private IList<string> _list;

        public void Run()
        {
            _list = new List<string>();
            Parallel.For(0, 10, i => InsertInList());

            _dict = new ConcurrentDictionary<int, string>();
            Parallel.For(0, 10, i => InsertInDict());

            var listCount = _list.Count();
            Console.WriteLine($"list count is {listCount}");

            _dict.Values.Print();

        }

        private readonly object _lockObject = new object();
        private void InsertInList()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(new Random().Next(100, 500));
                Task.Run(() =>
                {
                    lock (_lockObject) _list.Add("Number : " + i.ToString());
                });
            });
        }


        private void InsertInDict()
        {
            Parallel.For(0, 10, i =>
            {
                Task.Run(() =>
                {
                    _dict.AddOrUpdate(i, "some string",
                        updateValueFactory: (key, valueToUpdate) =>
                        {
                            Console.WriteLine("updating " + i + ": " + valueToUpdate);
                            //return updatedValue
                            return valueToUpdate + "updated";
                        });

                });
            });

        }
    }
}
