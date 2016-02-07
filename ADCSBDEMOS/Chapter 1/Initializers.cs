using System;
using System.Collections.Generic;

namespace ADCSBDEMOS.Chapter_1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Person : {Name}, Age: {Age}";
        }
    }

    internal class Initializers
    {
        private readonly IList<Person> _people;
        private readonly Person _person;


        public Initializers()
        {
            _person = new Person();
            _person.Name = "Something";
            _person.Age = 34;

            _person = new Person {Age = 45, Name = "Initialized Person"};

            _people = new List<Person>
            {
                _person,
                new Person {Name = "ListPerson", Age = 14}
            };
        }

        public void Run()
        {
            foreach (var person in _people)
            {
                Console.WriteLine(person);
            }
        }
    }
}