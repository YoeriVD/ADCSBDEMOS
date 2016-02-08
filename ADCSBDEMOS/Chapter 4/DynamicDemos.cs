using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_4
{
    class DynamicDemos
    {
        private object CreateSomeObject()
        {
            return new {Make = "bla"};
        }

        public void Run()
        {
            dynamic car = CreateSomeObject();

            Console.WriteLine(car.Make);
            Console.WriteLine(car.GetType());

            Console.WriteLine();
            dynamic str = "hey";
            A a = new B();
            a.SomeMethod(str);

            var c = new C();
            c.SomeMethod(str);
        }
    }

    class A
    {
        public void SomeMethod(dynamic c)
        {
            Console.WriteLine("A: " + c);
        }
    }

    class B : A
    {
        public void SomeMethod(string c)
        {
            Console.WriteLine("B: " + c);
        }
    }

    class C
    {
        public void SomeMethod(dynamic c)
        {
            Console.WriteLine("dynamic: " + c);
        }
        public void SomeMethod(string c)
        {
            Console.WriteLine("string: " + c);
        }
    }
}