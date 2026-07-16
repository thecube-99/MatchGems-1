using System.Collections.Generic;
using UnityEngine;

namespace MatchGems.Core
{
    public class BoardFlowController
    {
        #region 基本組件
        /// <summary>
        /// 配對檢查器
        /// </summary>
        private readonly MatchFinder _matchFinder = new MatchFinder();
        /// <summary>
        /// 落下解析器
        /// </summary>
        private readonly GravityResolver _gravityResolver = new GravityResolver();
        /// <summary>
        /// 寶石填充服務
        /// </summary>
        private readonly FillService _fillService = new FillService();
        #endregion 基本組件

        #region 公開參數
        /// <summary>
        /// 當前遊戲所處的狀態
        /// </summary>
        public BoardState State { get; private set; } = BoardState.Idle;
        #endregion 公開參數

        #region 公開方法
        /// <summary>
        /// 回到待命狀態
        /// </summary>
        public void SetIdle()
        {
            State = BoardState.Idle;

        }
        /// <summary>
        /// 嘗試執行玩家的資料交換操作
        /// </summary>
        /// <returns>是否成功</returns>
        public bool TrySwap(BoardModel board, CellCoord from, CellCoord to)
        {
            if (State != BoardState.Idle || !board.IsInside(to) || !board.IsAdjacent(from, to)) return false;
            //轉換狀態
            State = BoardState.Swapping;
            board.SwapGems(from, to);
            return true;
        }

        /// <summary>
        /// 搜索棋盤上全部的配對線結果
        /// </summary>
        /// <returns>配對線結果</returns>
        public MatchResult FindMatches(BoardModel board)
        {
            return _matchFinder.FindMatches(board);
        }
        /// <summary>
        /// 一組一拍式清除流程
        /// </summary>
        /// <param name="board"></param>
        /// <param name="result"></param>
        public void ClearStep(BoardModel board, MatchResult result)
        {
            State = BoardState.Clearing;
            List<CellCoord> coords = result.GetUniqueCoords();
            //清除資料
            board.ClearGems(coords);
        }

        /// <summary>
        /// 結算：落珠/補珠
        /// </summary>
        /// <param name="board"></param>
        public void Settle(BoardModel board)
        {
            //移動資料
            State = BoardState.Falling;
            _gravityResolver.Resolve(board);
            //補齊資料
            State = BoardState.Filling;
            Fill(board);
        }

        /// <summary>
        /// 補充寶石
        /// </summary>
        /// <param name="board"></param>
        public void Fill(BoardModel board)
        {
            _fillService.Fill(board);
        }

        /// <summary>
        /// 套用重力：落下
        /// </summary>
        /// <param name="board"></param>
        public List<TileMove> ApplyGravity(BoardModel board)
        {
            //移動資料
            State = BoardState.Falling;
            return _gravityResolver.Resolve(board);
        }
        /// <summary>
        /// 套用填補：天降
        /// </summary>
        /// <param name="board"></param>
        public List<TileMove> ApplyFill(BoardModel board)
        {
            State = BoardState.Filling;
            return _fillService.Fill(board);
        }
        #endregion 公開方法
    }
}