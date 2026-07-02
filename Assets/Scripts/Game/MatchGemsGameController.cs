using MatchGems.Core;
using MatchGems.View;
using MatchGems.Inputs;
using UnityEngine;

namespace MatchGems.Game
{
    /// <summary>
    /// 遊戲流程主程式(控制)
    /// </summary>
    public class MatchGemsGameController : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private BoardView _boardView;
        [SerializeField] private BoardInput _boardInput;
        [SerializeField] private int _width = 8;
        [SerializeField] private int _height = 8;
        private BoardModel _boardModel;
        private GridMapper _gridMapper;
        /// <summary>
        /// 預建立的配對檢查器
        /// </summary>
        private readonly MatchFinder _matchFinder = new MatchFinder();
        /// <summary>
        /// 預建立的落下解析器
        /// </summary>
        private readonly GravityResolver _gravityResolver = new GravityResolver();
        /// <summary>
        /// 預建立的寶石填充服務
        /// </summary>
        private readonly FillService _fillService = new FillService();
        #endregion 基本參數

        #region 生命週期
        void Start()
        {
            CreateBoard();
            CreateMapper();
            BuildView();
            ConfigureInput();
        }
        #endregion 生命週期

        #region 私有方法
        /// <summary>
        /// 建立棋盤
        /// </summary>
        private void CreateBoard()
        {
            _boardModel = new BoardModel(_width, _height);

            _fillService.Fill(_boardModel);
        }
        /// <summary>
        /// 建立轉換器
        /// </summary>
        private void CreateMapper()
        {
            //建構Root物件座標即為原點
            _gridMapper = new GridMapper(_boardView.transform.position, _boardView.CellWorldSize);
        }
        /// <summary>
        /// 以資料驅動視覺
        /// </summary>
        private void BuildView()
        {
            _boardView.Build(_boardModel, _gridMapper);
        }
        /// <summary>
        /// 設置輸入操作
        /// </summary>
        private void ConfigureInput()
        {
            _boardInput.Configure(_gridMapper);//CellSize先走預設
            _boardInput.SwapAction = TrySwap;
        }

        /// <summary>
        /// 嘗試交換兩格的寶石資料
        /// </summary>
        /// <param name="from">起始</param>
        /// <param name="to">目標</param>
        private void TrySwap(CellCoord from, CellCoord to)
        {
            if (!_boardModel.IsInside(to)) return;
            if (!_boardModel.IsAdjacent(from, to)) return;
            _boardModel.SwapGems(from, to);
            //執行配對演算邏輯
            MatchLogic();
            //刷新視覺
            BuildView();
        }

        private void MatchLogic()
        {
            //掃描結果
            MatchResult result = _matchFinder.FindMatches(_boardModel);

            if (!result.HasMatch) return;
            //消除
            foreach (MatchLine line in result.Lines)
            {
                _boardModel.ClearGems(line.Coords);
            }
            //落珠
            _gravityResolver.Resolve(_boardModel);
            //補珠
            _fillService.Fill(_boardModel);
        }
        #endregion 私有方法
    }
}