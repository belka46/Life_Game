namespace LifeGame
{
    internal class GameProcess
    {
        /// <summary>
        ////поиск количества живых клеток на игровом поле
        /// </summary>
        /// <param name="gw">экземпляр игрового поля</param>
        /// <returns></returns>
        public ulong FindSurvivors(GameWorld gw)
        {
            ulong count = 0;
            for (var i = 0; i < gw.GameZone.GetLongLength(0); i++)
            for (var j = 0; j < gw.GameZone.GetLongLength(1); j++)
                if (gw.GameZone[i, j] != 0)
                    count++;

            return count;
        }

        /// <summary>
        ////поиск соседних клеток
        /// </summary>
        /// <param name="nb">игровая зона</param>
        /// <param name="x">координата X в игровой зоне</param>
        /// <param name="y">координата Y в игровой зоне</param>
        public void ReadPointNeighbors(int[,] nb, long x, long y)
        {
            long i, j;
            long k = 0;

            for (i = x - 1; i <= x + 1; i++)
            for (j = y - 1; j <= y + 1; j++)
            {
                if (i == x && j == y) continue;
                nb[k, 0] = (int) i;
                nb[k, 1] = (int) j;
                k++;
            }
        }

        /// <summary>
        ///     Определяет количество живых соседей
        /// </summary>
        /// <param name="gw">игровая зона</param>
        /// <param name="x">координата X в игровой зоне</param>
        /// <param name="y">координата Y в игровой зоне</param>
        /// <returns></returns>
        public uint CountLiveNeighbors(GameWorld gw, long x, long y)
        {
            uint count = 0;
            uint i;
            var nb = new int[8, 2];
            int _x, _y;

            ReadPointNeighbors(nb, x, y);

            for (i = 0; i < 8; i++)
            {
                _x = nb[i, 0];
                _y = nb[i, 1];

                if (_x < 0 || _y < 0) continue;
                if (_x >= gw.GameZone.GetLongLength(0) || _y >= gw.GameZone.GetLongLength(1)) continue;

                if (gw.GameZone[_x, _y] == 1) count++;
            }

            return count;
        }

        /// <summary>
        ///     генерация следующего поколения в игровой зоне
        /// </summary>
        /// <param name="gw">текущее состояние игровой зоны</param>
        /// <returns>новое состояние игровой зоны</returns>
        public GameWorld NextGeneration(GameWorld gw)
        {
            var newGv = new GameWorld(gw.GameZone.GetLongLength(0), gw.GameZone.GetLongLength(1));
            for (long i = 0; i < gw.GameZone.GetLongLength(0); i++)
            {
                for (long j = 0; j < gw.GameZone.GetLongLength(1); j++)
                {
                    var liveNb = CountLiveNeighbors(gw, i, j);

                    if (gw.GameZone[i, j] == 0)
                    {
                        if (liveNb == 3) newGv.GameZone[i, j] = 1;
                    }
                    else
                    {
                        if (liveNb < 2 || liveNb > 3) newGv.GameZone[i, j] = 0;
                    }
                }
            }

            return newGv;
            //unsigned int i, j;
            //unsigned int live_nb;
            //point p;

            //for (i = 0; i < __WORLD_WIDTH__; i++)
            //{
            //    for (j = 0; j < __WORLD_HEIGHT__; j++)
            //    {
            //        p = prev_world[i][j];
            //        live_nb = count_live_neighbors(prev_world, i, j);

            //        if (p.is_live == 0)
            //        {
            //            if (live_nb == 3)
            //            {
            //                world[i][j].is_live = 1;
            //            }
            //        }
            //        else
            //        {
            //            if (live_nb < 2 || live_nb > 3)
            //            {
            //                world[i][j].is_live = 0;
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// копирует состояние игровой зоны, для сохранения и последующего сравнения
        /// </summary>
        /// <param name="src">текущее состояние</param>
        /// <param name="dest">сохраненная копия</param>
        public void CopyWorld(GameWorld src, GameWorld dest)
        {
            long i, j;
            for (i = 0; i < src.GameZone.GetLongLength(0); i++)
            {
                for (j = 0; j < src.GameZone.GetLongLength(1); j++)
                {
                    dest.GameZone[i, j] = src.GameZone[i, j];
                }
            }
        }

        /// <summary>
        /// сравнивает текущее и предыдущее состояние игровой зоны
        /// </summary>
        /// <param name="w1">текущее состояние игровой зоны</param>
        /// <param name="w2">предыдущее состояние игровой зоны</param>
        /// <returns></returns>
        public int CmpWorld(GameWorld w1, GameWorld w2)
        {
            long i, j;
            for (i = 0; i < w1.GameZone.GetLongLength(0); i++)
            {
                for (j = 0; j < w1.GameZone.GetLongLength(1); j++)
                {
                    if (w1.GameZone[i, j] != w2.GameZone[i, j])
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
