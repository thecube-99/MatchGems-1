using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MatchGems.Core
{
    /// <summary>
    /// 寶石填充服務
    /// </summary>
    public class FillService
    {
        #region 公開方法
        /// <summary>
        /// 將棋盤補滿寶石
        /// </summary>
        /// <param name="board">棋盤資料</param>
        public void Fill(BoardModel board)
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