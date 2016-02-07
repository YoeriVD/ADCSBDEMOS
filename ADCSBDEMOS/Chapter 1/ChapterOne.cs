using System;
using System.Collections.Generic;

namespace ADCSBDEMOS.Chapter_1
{
    public class ChapterOne
    {

        private readonly IEnumerable<IRepeater> _repeaters;

        public ChapterOne()
        {
            var repeaters = new List<IRepeater>();
            repeaters.Add(new SomeGeneratedClass0());
            repeaters.Add(new SomeGeneratedClass1());
            repeaters.Add(new SomeGeneratedClass2());
            repeaters.Add(new SomeGeneratedClass3());
            repeaters.Add(new SomeGeneratedClass4());
            _repeaters = repeaters;
        }

        public void Run()
        {
            var count = 1;
            foreach (var repeater in _repeaters)
            {
                Console.WriteLine("Repeater : " + count++);
                repeater.Repeat();
            }
        }
    }

   
}