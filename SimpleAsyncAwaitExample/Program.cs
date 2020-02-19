using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsyncAwaitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var worker = new Worker();
            worker.DoWork();

            while (!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private class Worker
        {
            public bool IsComplete { get; set; }

            public async void DoWork()
            {
                this.IsComplete = false;
                Console.WriteLine("Doing Work");

                LongOperation();

                Console.WriteLine(Environment.NewLine + "Work Completed");

                IsComplete = true;
            }

            private Task LongOperation()
            {
                return Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Working!");
                    Thread.Sleep(3000);
                    Console.WriteLine("Done working.");
                });
            }
        }
    }
}
