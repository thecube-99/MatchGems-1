using MatchGems.Core;
using MatchGems.View;
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
        [SerializeField] private int _width = 8;
        [SerializeField] private int _height = 8;
        private BoardModel _boardModel;
        private GridMapper _gridMapper;
        #endregion 基本參數

        #region 生命週期
        void Start()
        {
            CreateBoard();
            CreateMapper();
            _boardView.Build(_boardModel, _gridMapper);
        }
        #endregion 生命週期

        #region 私有方法
        /// <summary>
        /// 建立棋盤
        /// </summary>
        private void CreateBoard()
        {
            _boardModel = new BoardModel(_width, _height);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _boardModel.SetGem(x, y, (GemType)Random.Range(0, 6));
                }
            }
        }
        /// <summary>
        /// 建立轉換器
        /// </summary>
        private void CreateMapper()
        {
            //建構Root物件座標即為原點
            _gridMapper = new GridMapper(_boardView.transform.position, _boardView.CellWorldSize);
        }
        #endregion 私有方法
    }
}