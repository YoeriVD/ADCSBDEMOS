using System;
using ADCSBDEMOS.Chapter_1;

namespace ADCSBDEMOS.Objects
{
    public class Person : ICanShout
    {
        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string HairColor { get; set; }


        public override string ToString()
        {
            return string.Format("Name: {0} , Age : {1}", Name, Age);
        }

        public void Shout()
        {
            Console.WriteLine(this.Name.ToUpper() + "!!!");
        }
    }
}