using System.Collections.Generic;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_1
{
    internal class Initializers
    {
        public void Run()
        {
//            var person = new Person();
//            person.Name = "Zlati";
//            person.Age = 44;

            var person = new Person
            {
                Name = "Zlati",
                Age = 44
            };

            var other = new Person("Yoeri", 26) {HairColor = "Brown"};

//            Console.WriteLine(person);
//            Console.WriteLine(other);


            var people = new List<Person> {person, other};


            people.Print();

            var cars = new List<Car>()
            {
                new Car(),
                new Car(),
                new Car(),
                new Car(),
                new Car(),
            };
            cars.Print();
        }
    }
}