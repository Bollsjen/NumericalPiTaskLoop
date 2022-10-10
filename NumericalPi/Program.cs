using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NumericalPi
{
    class Program
    {
        static void Main(string[] args)
        {
            TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            //TryAgain();
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");

            Console.ReadKey();
        }

        static void TryAgain()
        {
            Stopwatch watch = new Stopwatch();
            PiCalc calculator = new PiCalc();

            Console.WriteLine("Started");
            watch.Start();
            double numPi = calculator.Calculate(10000000000, 32).Result;
            watch.Stop();
            Console.WriteLine("Done");

            Console.WriteLine($"Numeric PI = {numPi:0.000000}");
            Console.WriteLine($"Real PI    = {Math.PI:0.000000}");
            Console.WriteLine($"Took {watch.ElapsedMilliseconds} milliSecs");
        }
    }
}
