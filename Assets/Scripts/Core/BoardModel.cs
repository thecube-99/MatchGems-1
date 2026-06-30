using System;
using UnityEngine;

namespace MatchGems.Core
{
    public class BoardModel
    {
        #region 基本參數
        /// <summary>
        /// 寶石陣 (二維)
        /// </summary>
        private GemData[,] _gems;
        #endregion 基本參數

        #region 公開參數接口
        /// <summary>
        /// 棋盤寬度
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// 棋盤高度
        /// </summary>
        public int Height { get; }
        #endregion 公開參數接口

        #region 建構式
        /// <summary>
        /// 建立指定尺寸的棋盤
        /// </summary>
        /// <param name="w">寬</param>
        /// <param name="h">高</param>
        public BoardModel(int w, int h) 
        {
            Width = Math.Max(1, w);//至少為1的安全機制
            Height = Math.Max(1, h);//至少為1的安全機制
            _gems = new GemData[Width, Height];
        }
        #endregion 建構式

        #region 公開方法
        /// <summary>
        /// 設定指定格子的寶石
        /// </summary>
        /// <param name="coord">定位資料</param>
        /// <param name="gemType">寶石類型</param>
        public void SetGem(CellCoord coord, GemType gemType)
        {
            _gems[coord.X, coord.Y] = new GemData(gemType);
        }
        /// <summary>
        /// 設定指定格子的寶石
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="gemType">寶石類型</param>
        public void SetGem(int x, int y, GemType gemType)
        {
            _gems[x, y] = new GemData(gemType);
        }
        /// <summary>
        /// 取得指定格子的寶石
        /// </summary>
        /// <param name="coord">定位資料</param>
        /// <returns>寶石資料</returns>
        public GemData GetGem(CellCoord coord)
        {
            //三元運算，條件判斷(是/否) ? 是(回應) : 否(回應)
            return IsInside(coord) ? _gems[coord.X, coord.Y] : null;
        }
        /// <summary>
        /// 取得指定格子的寶石
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <returns>寶石資料</returns>
        public GemData GetGem(int x, int y)
        {
            return IsInside(x, y) ? _gems[x, y] : null;
        }

        public GemType GetGemColor(CellCoord coord)
        {
            return GetGem(coord).Color;
        }

        /// <summary>
        /// 交換兩格的寶石資料
        /// </summary>
        /// <param name="from">起始</param>
        /// <param name="to">目標</param>
        public void SwapGems(CellCoord from, CellCoord to)
        {
            //Debug.Log($"{_gems[from.X, from.Y].Color}→{_gems[to.X, to.Y].Color}");
            GemData tmp = _gems[to.X, to.Y];
            _gems[to.X, to.Y] = _gems[from.X, from.Y];
            _gems[from.X, from.Y] = tmp;
           // Debug.Log($"{_gems[from.X, from.Y].Color}｜{_gems[to.X, to.Y].Color}");
        }
        #endregion 公開方法

        #region 安全查驗功能
        /// <summary>
        /// 範圍檢查
        /// </summary>
        /// <param name="coord">座標資料組</param>
        /// <returns>是/否</returns>
        public bool IsInside(CellCoord coord)
        {
            return coord.X >= 0 && coord.X < Width && coord.Y >= 0 && coord.Y < Height;
        }
        /// <summary>
        /// 範圍檢查
        /// </summary>
        /// <param name="x">座標X</param>
        /// <param name="y">座標Y</param>
        /// <returns>是/否</returns>
        public bool IsInside(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
        /// <summary>
        /// 座標位置是否存在寶石
        /// </summary>
        /// <param name="coord">座標資料組</param>
        /// <returns>是/否</returns>
        public bool HasGem(CellCoord coord)
        {
            return IsInside(coord) && _gems[coord.X, coord.Y] != null;
        }
        /// <summary>
        /// 座標位置是否存在寶石
        /// </summary>
        /// <param name="x">座標X</param>
        /// <param name="y">座標Y</param>
        /// <returns>是/否</returns>
        public bool HasGem(int x, int y)
        {
            return IsInside(x, y) && _gems[x, y] != null;
        }
        /// <summary>
        /// 檢查兩格是否為相鄰為置
        /// </summary>
        /// <param name="a">A格座標</param>
        /// <param name="b">B格座標</param>
        /// <returns></returns>
        public bool IsAdjacent(CellCoord a, CellCoord b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) == 1;
        }
        #endregion 安全查驗功能
    }

}