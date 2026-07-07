using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// 遊戲(棋盤)流程狀態
    /// </summary>
    public enum BoardState
    {
        /// <summary>
        /// 待機
        /// </summary>
        Idle,
        /// <summary>
        /// 資料交換中
        /// </summary>
        Swapping,
        /// <summary>
        /// 面板清除中
        /// </summary>
        Clearing,
        /// <summary>
        /// 落珠運算
        /// </summary>
        Falling,
        /// <summary>
        /// 補珠演出
        /// </summary>
        Filling
    }
}