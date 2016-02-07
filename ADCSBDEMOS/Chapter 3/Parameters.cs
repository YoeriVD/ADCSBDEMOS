using System;

namespace ADCSBDEMOS.Chapter_3
{
    internal class Parameters
    {
        public void Run()
        {
            PrintNumber(5);

            PrintNumber(5, 100);

            PrintNumber(5, 100, true);

            PrintNumber(6, debug: true);
        }

        private void PrintNumber(int number, int factor = 1, bool debug = false)
        {
            if (debug)
            {
                Console.WriteLine($"DEBUG[ NUMBER: {number}, factor: {factor} ]");
            }
            Console.WriteLine(number*factor);
        }
    }
}