using System.Collections.Generic;
using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// 消除配方向
    /// </summary>
    public enum MatchDirection
    {
        /// <summary>
        /// 橫向
        /// </summary>
        Horizontal, 
        /// <summary>
        /// 直向
        /// </summary>
        Vertical
    }
    /// <summary>
    /// 連線的寶石配對資料(單線)
    /// </summary>
    public class MatchLine
    {
        #region 唯讀紀錄
        /// <summary>
        /// 連線的棋盤座標清單
        /// </summary>
        private readonly List<CellCoord> _coords;
        #endregion 唯讀紀錄

        #region 公開資訊
        /// <summary>
        /// 連線座標組合(單條)公開接口
        /// </summary>
        public List<CellCoord> Coords => _coords;
        /// <summary>
        /// 連線方向
        /// </summary>
        public MatchDirection Direction { get; }
        /// <summary>
        /// 連線的顏色
        /// </summary>
        public GemType Color { get; }
        /// <summary>
        /// 連線長度(資料紀錄數量)
        /// </summary>
        public int Length => _coords.Count;
        #endregion 公開資訊

        #region 建構式
        public MatchLine(GemType color, MatchDirection direction, List<CellCoord> coords)
        {
            Color = color;
            Direction = direction;
            _coords = coords;
        }
        #endregion 建構式
    }
}