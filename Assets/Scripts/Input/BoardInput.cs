using MatchGems.Core;
using System;
using UnityEngine;

namespace MatchGems.Inputs
{
    /// <summary>
    /// 棋盤輸入操作偵測
    /// </summary>
    public class BoardInput : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private Camera _camera;
        private GridMapper _gridMapper;
        private readonly PointerInputReader _PIR = new PointerInputReader();
        #endregion 基本參數

        #region 狀態參數
        private bool IsReady => _camera != null && _gridMapper != null;
        #endregion 狀態參數

        #region 公開方法
        public void Configure(GridMapper gridMapper)
        {
            _gridMapper = gridMapper;
            //以防萬一攝影機忘記設定
            if (_camera == null) _camera = Camera.main;
        }
        #endregion 公開方法

        #region UNITY生命週期
        void Update()
        {
            if (!IsReady) return;
            //準備完成：隨時監看輸入操作
            if (_PIR.TryGetPointerDown(out Vector2 downPos)) BeginPointer(downPos);
            if (_PIR.TryGetPointerUp(out Vector2 upPos)) EndPointer(upPos);
        }
        #endregion UNITY生命週期

        #region 私有方法
        /// <summary>
        /// 按下起始邏輯
        /// </summary>
        /// <param name="downPos">按下的位置</param>
        private void BeginPointer(Vector2 downPos)
        {

        }
        /// <summary>
        /// 鬆開結束邏輯
        /// </summary>
        /// <param name="upPos">鬆開的位置</param>
        private void EndPointer(Vector2 upPos)
        {

        }
        #endregion 私有方法
    }
}