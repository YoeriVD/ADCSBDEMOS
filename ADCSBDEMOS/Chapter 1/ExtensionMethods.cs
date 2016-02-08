using ADCSBDEMOS.Objects;

namespace ADCSBDEMOS.Chapter_1
{
    internal class ExtensionMethods
    {
        public void Run()
        {
            var p = new Person("Killian", 24);
            p.Shout();
            ShoutExtensions.Shout(p);

            var c = new Car() {Name = "my blue volvo"};
            ShoutLouderExtensions.Shout(c);
        }
    }



}