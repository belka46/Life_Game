using System;
using System.Security.Cryptography;

namespace LifeGame
{
    /// <summary>
    /// Создает игровое поле с заданными параметрами.
    /// </summary>
    internal class GameZone
    {
        private byte[,] gameZone { get; }

        public GameZone(ulong x, ulong y)
        {
            gameZone = new byte[x, y];
        }
        /// <summary>
        ////инициализация случайными значениями игрового поля
        /// </summary>
        public void initGameZone()
        {
            var rngCsp = new RNGCryptoServiceProvider();

            for (var i = 0; i < gameZone.GetLongLength(0); i++)
            for (var j = 0; j < gameZone.GetLongLength(1); j++) gameZone[i, j] = Rnd(rngCsp);
            //rngCsp.GetBytes(this.gameZone);
        }

        /// <summary>
        /// генератор случайных чисел
        /// </summary>
        /// <param name="rngCsp">экземпляр генератора</param>
        /// <returns>значения 1 или 0, для заполнения поля</returns>
        private byte Rnd(RNGCryptoServiceProvider rngCsp)
        {
            var randomNumber = new byte[1];
            rngCsp.GetBytes(randomNumber);
            if (randomNumber[0]%2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }

        /// <summary>
        /// печать игового поля
        /// </summary>
        public void Print()
        {
            var len = gameZone.GetLongLength(0);
            for (var i = 0; i < gameZone.GetLongLength(0); i++)
            for (var j = 0; j < gameZone.GetLongLength(1); j++)
            {
                Console.Write(gameZone[i, j]);
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
