using System;
using ADCSBDEMOS.Chapter_1;
using ADCSBDEMOS.Chapter_2;
using ADCSBDEMOS.Chapter_4;

namespace demos
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Chapter1();
            Chapter2();
            Chapter3();
            Chapter4();
            Console.ReadKey();
        }

        private static void Chapter1()
        {
            //new PartialMethods().Run();

            //new Initializers().Run();

            //new AnonymousTypes().Run();

            //new ExtensionMethods().Run();

            //new LambdaDemo().Run();
        }

        private static void Chapter2()
        {
            new LinqDemos().Run();
        }

        private static void Chapter3()
        {
        }

        private static void Chapter4()
        {
            new DynamicDemos().Run();
        }
    }
}