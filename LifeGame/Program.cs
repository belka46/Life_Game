using System;
using System.Threading;

namespace LifeGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long x = 4;
            long y = 4;

            var gz = new GameWorld(x, y);
            var prevGz = gz;
            var gp = new GameProcess();

            ulong livePoints;
            var isOptimal = false;

            do
            {
                gz.Print();
                gp.CopyWorld(gz, prevGz);
                gz = gp.NextGeneration(prevGz);

                isOptimal = gp.CmpWorld(gz, prevGz) == 0;
                livePoints = gp.FindSurvivors(gz);


                if (isOptimal) Console.WriteLine("Достигнута оптимальная конфигурация игрового мира");

                if (livePoints == 0) Console.WriteLine("Все умерли");
                Thread.Sleep(50);
            } while (livePoints != 0 && !isOptimal);
        }
    }
}


