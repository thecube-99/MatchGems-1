using MatchGems.Core;
using MatchGems.View;
using UnityEngine;

namespace MatchGems.Game
{
    public class MatchGemsGameController : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private BoardView _boardView;
        [SerializeField] private int _width = 8;
        [SerializeField] private int _height = 8;
        private BoardModel _boardModel;
        #endregion 基本參數

        #region 生命週期
        void Start()
        {
            _boardModel = new BoardModel(_width, _height);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _boardModel.SetGem(x, y, (GemType)Random.Range(0, 6));
                }
            }

            _boardView.Build(_boardModel);
        }
        #endregion 生命週期
    }
}