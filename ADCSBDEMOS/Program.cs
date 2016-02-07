using System;
using ADCSBDEMOS.Chapter_1;
using ADCSBDEMOS.Chapter_2;
using ADCSBDEMOS.Chapter_3;

namespace ADCSBDEMOS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ChapterOne();
            ChapterTwo();
            ChapterThree();
            Console.ReadKey();
        }




        private static void ChapterOne()
        {
           //new PartialMethods().Run();

            //new Initializers().Run();

            //new AnomnymousObjects().Run();

            //new AutoProperties().Run();

            //new ExtensionMethods().Run();

            //new LambdaExpressions().Run();
            
        }

        private static void ChapterTwo()
        {
            //new LinqDemos().Run();
        }

        private static void ChapterThree()
        {
            new Parameters().Run();
        }
    }
}