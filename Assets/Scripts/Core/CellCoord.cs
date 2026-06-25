using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// [Struct]棋盤格座標
    /// </summary>
    public struct CellCoord
    {
        #region 基本參數
        /// <summary>
        /// 水平座標位置
        /// </summary>
        public int X { get; }
        /// <summary>
        /// 垂直座標位置
        /// </summary>
        public int Y { get; }

        public string pos => $"座標：[{X},{Y}]";
        #endregion 基本參數

        #region 建構式
        public CellCoord(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion 建構式
    }
}

