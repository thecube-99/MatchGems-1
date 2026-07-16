using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MatchGems.Core
{
    /// <summary>
    /// 寶石填充服務
    /// </summary>
    public class FillService
    {
        /// <summary>
        /// 重力移動的暫存清單
        /// </summary>
        private readonly List<TileMove> moves = new List<TileMove>();
        /// <summary>
        /// 定位用的座標暫存
        /// </summary>
        private CellCoord coord;

        #region 公開方法
        /// <summary>
        /// PlaneA：將棋盤補滿寶石
        /// </summary>
        /// <param name="board">棋盤資料</param>
        /*public void Fill(BoardModel board)
        {
            for (int y = 0; y < board.Height; y++) 
            {
                for (int x = 0; x < board.Width; x++)
                {
                    if (board.HasGem(x, y)) continue;
                    //空位補珠
                    board.SetGem(x, y, CreateRandomGem());
                }
            }
        }*/

        /// <summary>
        /// PlaneB：將棋盤補滿寶石
        /// </summary>
        /// <param name="board">棋盤資料</param>
        /// <returns>移動紀錄清單</returns>
        public List<TileMove> Fill(BoardModel board)
        {
            moves.Clear();

            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board.HasGem(coord)) continue;
                    coord.Set(x, y);
                    //空位補珠
                    board.SetGem(coord, CreateRandomGem());
                    moves.Add(new TileMove(coord));
                }
            }
            return moves;
        }
        /// <summary>
        /// 建立隨機的寶石類型
        /// </summary>
        /// <returns>隨機的寶石類型</returns>
        public GemType CreateRandomGem()
        {
            //利用C#系統原生Enun取得列舉長度
            int gemCount = Enum.GetValues(typeof(GemType)).Length;
            return (GemType)Random.Range(0, gemCount);
        }
        #endregion 公開方法
    }
}