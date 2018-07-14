using System;
using System.Security.Cryptography;

namespace LifeGame
{
    /// <summary>
    ///     Создает игровое поле с заданными параметрами.
    /// </summary>
    internal class GameWorld
    {
        public byte[,] GameZone { get; }

        public GameWorld(long x, long y)
        {
            GameZone = new byte[x, y];
            InitGameZone();
        }

        /// <summary>
        ////инициализация случайными значениями игрового поля
        /// </summary>
        private void InitGameZone()
        {
            var rngCsp = new RNGCryptoServiceProvider();

            for (var i = 0; i < GameZone.GetLongLength(0); i++)
            for (var j = 0; j < GameZone.GetLongLength(1); j++)
                GameZone[i, j] = Rnd(rngCsp);
        }

        /// <summary>
        ///     генератор случайных чисел
        /// </summary>
        /// <param name="rngCsp">экземпляр генератора</param>
        /// <returns>значения 1 или 0, для заполнения поля</returns>
        private byte Rnd(RNGCryptoServiceProvider rngCsp)
        {
            var randomNumber = new byte[1];
            rngCsp.GetBytes(randomNumber);
            if (randomNumber[0] % 2 == 0)
                return 0;
            return 1;
        }

        /// <summary>
        ///     печать игового поля
        /// </summary>
        public void Print()
        {
            Console.Clear();
            long i;
            for (i = 0; i < GameZone.GetLongLength(0); i++)
            {
                long j;
                for (j = 0; j < GameZone.GetLongLength(1); j++)
                {
                    Console.Write(GameZone[i, j] == 1 ? "* " : " ");
                    
                }
                Console.WriteLine();
            }
        }
    }
}
