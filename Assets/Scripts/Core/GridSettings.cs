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

        private void Start()
        {
            Debug.Log(_cellSize);
        }

        private void Update()
        {
            Debug.Log(_pixelPerUnit);
        }
    }
}