using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong i = 10;
            ulong y = 10;

            GameZone gz = new GameZone(i, y);
            gz.initGameZone();
            gz.Print();

        }
    }
}
