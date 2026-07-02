using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// 連線數
        /// </summary>
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

        /// <summary>
        /// 取得完全不重複的配對座標格清單
        /// </summary>
        /// <returns>不重複的配對座標格清單</returns>
        public List<CellCoord> GetUniqueCoords()
        {
            List<CellCoord> coords = new List<CellCoord>();

            for (int i = 0; i < _lines.Count; i++)
            {//抽線
                for (int j = 0; j < _lines[i].Coords.Count; j++)
                {//抽格
                    if (!coords.Contains(_lines[i].Coords[j]))
                    {
                        coords.Add(_lines[i].Coords[j]);
                    }
                }
            }

            return coords;
        }
        #endregion 公開方法

    }
}
