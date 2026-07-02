using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// 下落(重力)解析器
    /// </summary>
    public class GravityResolver
    {
        #region 公開方法
        public void Resolve(BoardModel board)
        {
            for (int x = 0; x < board.Width; x++)
            {
                DropColumn(board, x);
            }
        }
        #endregion 公開方法

        #region 私有方法
        /// <summary>
        /// 直列墜落運算
        /// </summary>
        /// <param name="board">棋盤資料</param>
        /// <param name="x">X定位</param>
        private void DropColumn(BoardModel board, int x)
        {
            int writeY = 0;//Y定位
            for (int y = 0; y < board.Height; y++)
            {
                CellCoord readCoord = new CellCoord(x, y);
                //沒資料就跳過
                if (!board.HasGem(readCoord)) continue;

                if (y > writeY)
                {
                    CellCoord writeCoord = new CellCoord(x, writeY);
                    board.SetGem(writeCoord, board.GetGem(readCoord));
                    board.ClearGem(readCoord);
                }

                writeY++;//Y定位增加
            }
        }
        #endregion 私有方法
    }
}