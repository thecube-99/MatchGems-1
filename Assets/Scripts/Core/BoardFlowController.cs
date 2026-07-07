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
        /// 補充
        /// </summary>
        /// <param name="board"></param>
        public void Fill(BoardModel board)
        {
            State = BoardState.Falling;
            _fillService.Fill(board);
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
            //掃描結果
            MatchResult result = _matchFinder.FindMatches(board);
            if (!result.HasMatch)
            {//沒配對組
                State = BoardState.Idle;
                return false;
            }
            //
            ResolveMatches(board, result);
            return true;
        }
        #endregion 公開方法

        #region 私有方法
        private void ResolveMatches(BoardModel board, MatchResult result)
        {
            State = BoardState.Clearing;
            while (result.HasMatch)
            {
                board.ClearGems(result.GetUniqueCoords());
            }

        }
        #endregion 私有方法
    }
}