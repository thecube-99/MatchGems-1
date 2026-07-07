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
        /// 預建立的流程控制器
        /// </summary>
        private readonly BoardFlowController _boardFlowController = new BoardFlowController();
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
            //流程控制：補珠
            _boardFlowController.Fill(_boardModel);
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
            if (!_boardFlowController.TrySwap(_boardModel, from, to)) return;
            //刷新視覺
            BuildView();
        }
        #endregion 私有方法
    }
}