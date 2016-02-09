using System;
using System.Threading.Tasks;

namespace Lab4Solution
{
    internal class EventTrigger
    {
        public event EventHandler Ready;

        public void Run(int milleseconds)
        {
            Task.Run(async () =>
            {
                await Task.Delay(milleseconds);
                Ready?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}