using MatchGems.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

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
        private GridMapper _gridMapper;
        #endregion 基本參數

        #region 公開屬性
        /// <summary>
        /// 單一格的像素尺寸
        /// </summary>
        public int CellSize => _cellSize;
        /// <summary>
        /// 一個Unity單位對應的像素值
        /// </summary>
        public float PixelPerUnit => _pixelPerUnit;
        /// <summary>
        /// 單一格在世界座標的單位比例
        /// </summary>
        public float CellWorldSize => _cellSize / _pixelPerUnit;
        #endregion 公開屬性

        #region 公開方法
        /// <summary>
        /// 依棋盤資料建立全部Tile視覺
        /// </summary>
        /// <param name="board">棋盤資料</param>
        public void Build(BoardModel board, GridMapper gridMapper)
        {
            _gridMapper = gridMapper;
            //清理舊視覺資料
            //ClearTiles();
            //產生與資料相同的視覺尺寸
            _tiles = new GemTile[board.Width, board.Height];

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    _tiles[x, y] = CreateTile(x, y);
                    _tiles[x, y].SetGem(board.GetGem(x, y));
                }
            }
        }

        public void GemTileAsync(CellCoord from, CellCoord to)
        {
            GemTile tmp = _tiles[to.X, to.Y];
            _tiles[to.X, to.Y] = _tiles[from.X, from.Y];
            _tiles[from.X, from.Y] = tmp;
        }
        /// <summary>
        /// [等候型任務]寶石交換動畫
        /// </summary>
        /// <param name="A">A石</param>
        /// <param name="B">B石</param>
        /// <param name="duration">運作時長</param>
        /// <returns>任務狀態</returns>
        public async Task AnimateSwapAsync(CellCoord A, CellCoord B, float duration)
        {
            GemTile tileA = GetTile(A);
            GemTile tileB = GetTile(B);
            if (tileA == null || tileB == null) return;//任務結束
            //各別建立交換任務
            Task moveA = tileA.MoveToAsync(_gridMapper.ToWorld(B), duration);
            Task moveB = tileB.MoveToAsync(_gridMapper.ToWorld(A), duration);
            //等待任務都完成
            await Task.WhenAll(moveA, moveB);
            GemTileAsync(A, B);//實體視覺資料位置同步
        }
        /// <summary>
        /// [等候型任務]寶石清除動畫
        /// </summary>
        /// <param name="list">配對寶石清單</param>
        /// <param name="duration">運作時長</param>
        /// <returns>任務狀態</returns>
        public async Task AnimationClearAsync(List<CellCoord> list, float duration)
        {//準備對應的任務清單：執行消除任務 * N
            List<Task> pops = new List<Task>();
            for (int i = 0; i < list.Count; i++)
            {
                GemTile tile = GetTile(list[i]);
                _tiles[list[i].X, list[i].Y] = null;//消除紀錄
                pops.Add(tile.PopAsync(duration));//加入任務待辦
            }
            //等待整組任務都完成
            await Task.WhenAll(pops);
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

        /// <summary>
        /// 取得指定位置的寶石元件
        /// </summary>
        /// <param name="coord">定位</param>
        /// <returns>寶石元件</returns>
        private GemTile GetTile(CellCoord coord)
        {
            if (_tiles == null || coord.X < 0 || coord.Y < 0 || coord.X >= _tiles.GetLength(0) || coord.Y >= _tiles.GetLength(1)) return null;
            //檢查視覺圖陣列是否存在，以及訪問座標在陣列內
            return _tiles[coord.X, coord.Y];
        }
        #endregion 私有方法
    }
}

