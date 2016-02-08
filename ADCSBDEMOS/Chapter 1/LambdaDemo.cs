using System;
using System.Collections.Generic;
using System.Linq;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_1
{
    class LambdaDemo
    {
        public void DoWork(Action<int> work)
        {
            work(5);
        }

        public string ReturnWork(Func<string, string> work)
        {
            return work("some string");
        }
        public void Run()
        {
            var people = new List<Person>()
            {
                new Person("Yoeri", 26),
                new Person("Zlati", 44),
                new Person("Tiffany", 18),
            };
            var ordered = people.OrderBy(person => person.Age);
            DoWork(number => people.Print());
            DoWork(number => ordered.Print());
            var message = ReturnWork(x =>
            {
                return "more bla bla";
            });

            Console.WriteLine(message);
        }

    }
}
