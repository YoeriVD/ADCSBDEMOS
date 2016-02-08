using System;

namespace ADCSBDEMOS.Chapter_1
{
    public static class ShoutExtensions
    {
        public static void Shout(this ICanShout p)
        {
            Console.WriteLine(p.Name.ToUpperInvariant());
        }
       
    }

    public static class ShoutLouderExtensions
    {
        public static void Shout(this ICanShoutLouder p)
        {
            Console.WriteLine(p.Name.ToUpperInvariant() + "!!!!!!!!!!!!!!!!!");
        }
    }
}