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
    }
}
