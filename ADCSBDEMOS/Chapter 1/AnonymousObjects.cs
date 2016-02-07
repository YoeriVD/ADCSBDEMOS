using System;

namespace ADCSBDEMOS.Chapter_1
{
    public class AnomnymousObjects
    {
        public string Name { get; private set; }
        
        public void Run()
        {
            Name = "Yoeri Property";

            var anonymousObject = new {Name, Age = 26, };
            Console.WriteLine(anonymousObject);
            Console.WriteLine(anonymousObject.GetType());
        }
    }
}
