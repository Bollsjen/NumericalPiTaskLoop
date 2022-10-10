using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumericalPi
{
    public class PiCalc
    {
        /// <summary>
        /// Executes the calculation of an 
        /// approximate value of pi.
        /// </summary>
        /// <param name="iterations">Number of iterations to perform</param>
        /// <returns>Approximate value of pi</returns>
        public async Task<double> Calculate(long iterations, int threads)
        {
            int insideUnitCircle = 0;

            //int inside1 = 0;
            //int inside2 = 0;
            //int inside3 = 0;
            //int inside4 = 0;
            //int inside5 = 0;
            //int inside6 = 0;
            //int inside7 = 0;
            //int inside8 = 0;
            //int inside9 = 0;
            //int inside10 = 0;
            //int inside11 = 0;
            //int inside12 = 0;


            //Task task1 = Task.Run(() => inside1 += Iterate(iterations / 12).Result);
            //Task task2 = Task.Run(() => inside2 += Iterate(iterations / 12).Result);
            //Task task3 = Task.Run(() => inside3 += Iterate(iterations / 12).Result);
            //Task task4 = Task.Run(() => inside4 += Iterate(iterations / 12).Result);
            //Task task5 = Task.Run(() => inside5 += Iterate(iterations / 12).Result);
            //Task task6 = Task.Run(() => inside6 += Iterate(iterations / 12).Result);
            //Task task7 = Task.Run(() => inside7 += Iterate(iterations / 12).Result);
            //Task task8 = Task.Run(() => inside8 += Iterate(iterations / 12).Result);
            //Task task9 = Task.Run(() => inside9 += Iterate(iterations / 12).Result);
            //Task task10 = Task.Run(() => inside10 += Iterate(iterations / 12).Result);
            //Task task11 = Task.Run(() => inside11 += Iterate(iterations / 12).Result);
            //Task task12 = Task.Run(() => inside12 += Iterate(iterations / 12).Result);
            //Task.WaitAll(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10, task11, task12);

            //insideUnitCircle = inside1 + inside2 + inside3 + inside4 + inside5 + inside6 + inside7 + inside8 + inside9 + inside10 + inside11 + inside12;

            List<int> insides = new List<int>();
            List<Task<int>> tasks = new List<Task<int>>();
            int tasksCount = threads;
            int result = 0;

            for(int i = 0; i < tasksCount; i++)
            {
                tasks.Add(Task.Run(() => { return Iterate(iterations / tasksCount).Result; }));
            }

            Task.WaitAll(tasks.ToArray());

            foreach(Task<int> item in tasks)
            {
                insideUnitCircle += item.Result;
            }

            return insideUnitCircle * 4.0 / iterations;
        }

        /// <summary>
        /// Perform a number of "dart-throwing" simulations.
        /// </summary>
        /// <param name="iterations">Number of dart-throws to perform</param>
        /// <returns>Number of throws within the unit circle</returns>
        public Task<int> Iterate(long iterations)
        {
            Random _generator = new Random(Guid.NewGuid().GetHashCode());
            int insideUnitCircle = 0;

            for (int i = 0; i < iterations; i++)
            {
                double x = _generator.NextDouble();
                double y = _generator.NextDouble();

                if (x * x + y * y < 1.0)
                {
                    insideUnitCircle++;
                }
            }

            return Task.FromResult(insideUnitCircle);
        }
    }
}