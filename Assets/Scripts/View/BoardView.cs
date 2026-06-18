using UnityEngine;
using MatchGems.Core;

namespace MatchGems.View
{
    /// <summary>
    /// 棋盤和寶石視覺整體
    /// </summary>
    public class BoardView : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private int _cellSize = 64;
        [SerializeField] private float _pixelPerUnit = 64f;
        [SerializeField] private GemTile _tilePrefab;
        private GemTile[,] _tiles;
        #endregion 基本參數

        #region 公開屬性
        /// <summary>
        /// 單一格的像素尺寸
        /// </summary>
        public int CellSize => _cellSize;
        /// <summary>
        /// 一個Unity單位對應的像素值
        /// </summary>
        private float PixelPerUnit => _pixelPerUnit;
        /// <summary>
        /// 單一格在世界座標的單位比例
        /// </summary>
        private float CellWorldSize => _cellSize / _pixelPerUnit;
        #endregion 公開屬性

        #region 公開方法
        /// <summary>
        /// 依棋盤資料建立全部Tile視覺
        /// </summary>
        /// <param name="board">棋盤資料</param>
        public void Build(BoardModel board)
        {
            //清理舊資料
            //產生與資料相同的視覺尺寸
            _tiles = new GemTile[board.Width, board.Height];

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    _tiles[x, y] = CreateTile(x, y);
                }
            }
        }
        #endregion 公開方法

        #region 私有方法
        /// <summary>
        /// 依照定位實例化寶石磚
        /// </summary>
        /// <param name="x">座標X</param>
        /// <param name="y">座標Y</param>
        /// <returns>寶石磚</returns>
        private GemTile CreateTile(int x, int y)
        {
            Vector3 position = new Vector3(x * CellWorldSize, y * CellWorldSize, 0);
            return Instantiate(_tilePrefab, position, Quaternion.identity, transform);
        }
        #endregion 私有方法

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }
    }
}

