using UnityEngine;//導入UNITY引擎標準程式庫(前端)

//消除寶石的核心命名空間
namespace MatchGems.Core
{
    /// <summary>
    /// 棋盤格尺寸設定
    /// </summary>
    public class GridSettings : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private int _cellSize = 64;
        [SerializeField] private float _pixelPerUnit = 64f;
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

        private void Start()
        {
            
        }
    }
}