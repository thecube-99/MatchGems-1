using System.Collections.Generic;
using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// 單次的配對結果(多線整理)
    /// </summary>
    public class MatchResult
    {
        #region 唯讀紀錄
        /// <summary>
        /// 連線清單
        /// </summary>
        private readonly List<MatchLine> _lines = new List<MatchLine>();
        #endregion 唯讀紀錄

        #region 公開資訊
        public int LineCount => _lines.Count;
        /// <summary>
        /// 是否有產生任何配對
        /// </summary>
        public bool HasMatch => LineCount > 0;
        #endregion 公開資訊

        #region 公開方法
        /// <summary>
        /// 加入配對連線
        /// </summary>
        public void AddLine(MatchLine line)
        {
            _lines.Add(line);
        }
        #endregion 公開方法

    }
}
