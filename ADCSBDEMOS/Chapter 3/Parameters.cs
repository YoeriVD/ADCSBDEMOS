using System;

namespace ADCSBDEMOS.Chapter_3
{
    /// <summary>
    ///     This class contains all the demo's for parameters
    /// </summary>
    internal class Parameters
    {
        /// <summary>
        ///     run the selected demo (comment/uncomment)
        /// </summary>
        public void Run()
        {
            DoWork("a", "b", "c");
            DoWork("a", "b");
            DoWork("a");

            DoWork("a", param3: "nummer 3");

            DoOtherWork(c: 10, b: 4, a: 3);
            DoOtherWork(1, 2, 3, inPercent: true);
        }

        private void DoOtherWork(int a, int b, int c, bool inPercent = false)
        {
            var value = a + b + c;
            if (inPercent) value /= 100;
            Console.WriteLine(value);
        }

        private void DoWork(
            string param,
            string param2 = "ook een default",
            string param3 = "een default waarde")
        {
            Console.WriteLine($"{param} : {param2} : {param3}");
        }
    }
}