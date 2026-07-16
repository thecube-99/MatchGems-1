using System.Collections.Generic;
using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// 下落(重力)解析器
    /// </summary>
    public class GravityResolver
    {
        /// <summary>
        /// 重力移動的暫存清單
        /// </summary>
        private readonly List<TileMove> moves = new List<TileMove>();
        /// <summary>
        /// 定位用的座標暫存
        /// </summary>
        private readonly CellCoord coordFrom = new CellCoord();
        private readonly CellCoord coordTo = new CellCoord();
        #region 公開方法
        /// <summary>
        /// PlaneA：原始墜落方式
        /// </summary>
        /// <param name="board"></param>
        /*public void Resolve(BoardModel board)
        {
            for (int x = 0; x < board.Width; x++)
            {
                DropColumn(board, x);
            }
        }*/
        /// <summary>
        /// PlaneB：回傳每顆寶石 From→To 紀錄
        /// </summary>
        /// <param name="board"></param>
        /// <returns>移動紀錄清單</returns>
        public List<TileMove> Resolve(BoardModel board)
        {
            moves.Clear();

            for (int x = 0; x < board.Width; x++)
            {
                int writeY = 0;//Y定位
                for (int readY = 0; readY < board.Height; readY++)
                {
                    coordFrom.Set(x, readY);
                    if (!board.HasGem(coordFrom)) continue;

                    coordTo.Set(x, writeY);
                    if (readY > writeY)
                    {
                        board.SetGem(coordTo, board.GetGem(coordFrom));
                        board.ClearGem(coordFrom);
                    }

                    moves.Add(new TileMove(coordFrom, coordTo));
                    writeY++;//Y定位增加
                }
            }

            return moves;
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