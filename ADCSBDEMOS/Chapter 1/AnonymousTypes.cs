using System;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_1
{
    internal class AnonymousTypes
    {
        public void Run()
        {
            var person = new Person {Age = 33};
            //Person person = new Person {Age = 33};
            Console.WriteLine(person);
            Console.WriteLine(person.GetType());

            var ano = new {Breed = "Dalmatian"};
            Console.WriteLine(ano);
            Console.WriteLine(ano.GetType());
            

            var ano2 = new {Brand = "Coca-cola"};
            Console.WriteLine(ano2);
            Console.WriteLine(ano2.GetType());

            var ano3 = new {Brand = "Coca-cola", Age = person.Age};
            Console.WriteLine(ano3);
            Console.WriteLine(ano3.GetType());

            Console.WriteLine(ano2.Equals(ano3));

            
        }

        
    }
}