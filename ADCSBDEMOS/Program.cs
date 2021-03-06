﻿using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using ADCSBDEMOS.Chapter_1;
using ADCSBDEMOS.Chapter_2;
using ADCSBDEMOS.Chapter_3;
using ADCSBDEMOS.Chapter_4;
using ADCSBDEMOS.Chapter_5;
using ADCSBDEMOS.Objects;

namespace demos
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Chapter1();
                Chapter2();
                Chapter3();
                Chapter4();
                Chapter5();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                //write to log or show message
            }
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
            //new Parameters().Run();

        }
        private static void Chapter4()
        {
            //new DynamicDemos().Run();
        }
        private static void Chapter5()
        {
            //new TaskParallelLibraryDemos().Run();
            //new Plinq().Run();
            //new ConcurrentDataClasses().Run();
            new SyncPrimitives().Run();
        }
    }
}