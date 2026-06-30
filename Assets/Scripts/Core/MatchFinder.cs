using System.Collections.Generic;
using UnityEngine;

namespace MatchGems.Core
{
    /// <summary>
    /// 配對掃描(演算)
    /// </summary>
    public class MatchFinder
    {
        #region 公開方法
        /// <summary>
        /// 尋找配對結果
        /// </summary>
        /// <param name="board">棋盤資料</param>
        /// <returns>配對結果</returns>
        public MatchResult FindMatches(BoardModel board)
        {
            MatchResult result = new MatchResult();
            //掃橫排
            FindHorizontal(board, result);
            //掃直排
            FindVertical(board, result);
            return result;
        }
        #endregion 公開方法

        #region 私有方法
        /// <summary>
        /// 直線掃描
        /// </summary>
        /// <param name="board">棋盤資料</param>
        /// <param name="result">結果容器</param>
        private void FindVertical(BoardModel board, MatchResult result)
        {
            for (int x = 0; x < board.Width; x++)
            {
                int y = 0;
                while (y < board.Height)
                {//沒有連3以上後的Y是多少
                    y = ScanLine(board, result, new CellCoord(x, y), MatchDirection.Vertical);
                }
            }
        }
        /// <summary>
        /// 橫線掃描
        /// </summary>
        /// <param name="board">棋盤資料</param>
        /// <param name="result">結果容器</param>
        private void FindHorizontal(BoardModel board, MatchResult result)
        {
            for (int y = 0; y < board.Height; y++)
            {
                int x = 0;
                while (x < board.Width)
                {//沒有連3以上後的X是多少
                    x = ScanLine(board, result, new CellCoord(x, y), MatchDirection.Horizontal);
                }
            }
        }

        /// <summary>
        /// 掃描線(湊三以上成組紀錄)，回報下個起始位置
        /// </summary>
        /// <param name="board">資料</param>
        /// <param name="result">結果</param>
        /// <param name="start">掃描起點</param>
        /// <param name="direction">方向</param>
        /// <returns>跳過後的位置</returns>
        private int ScanLine(BoardModel board, MatchResult result, CellCoord start, MatchDirection direction)
        {
            //先記錄起始顏色
            GemType color = board.GetGemColor(start);
            //下一顆的座標資料
            CellCoord target = GetNextCoord(start, direction);
            //預記綠清單
            List<CellCoord> list = new List<CellCoord>{ start };
            //檢查循環
            while (board.HasGem(target) && board.GetGemColor(target) == color)
            {//加進清單
                list.Add(target);
                //遞補至下一個
                target = GetNextCoord(target, direction);
            }
            //是否連3以上
            if (list.Count >= 3)
            {
                result.AddLine(new MatchLine(color, direction, list));
            }

            return GetNextIndex(target, direction);
        }

        private CellCoord GetNextCoord(CellCoord start, MatchDirection direction)
        {
            return direction == MatchDirection.Horizontal 
                ? new CellCoord(start.X + 1, start.Y) 
                : new CellCoord(start.X, start.Y + 1);
        }

        private int GetNextIndex(CellCoord start, MatchDirection direction)
        {
            return direction == MatchDirection.Horizontal
                ? start.X : start.Y;
        }
        #endregion 私有方法
    }
}