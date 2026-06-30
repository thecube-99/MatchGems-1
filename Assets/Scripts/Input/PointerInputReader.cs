using UnityEngine;

namespace MatchGems.Inputs
{
    /// <summary>
    /// 指標輸入(螢幕座標)讀取器
    /// </summary>
    public class PointerInputReader
    {
        #region 基本參數
        private Touch touch;
        #endregion 基本參數

        #region 公開方法
        /// <summary>
        /// 嘗試取得指標點下的位置
        /// </summary>
        /// <param name="screenPos">out點擊滑鼠左鍵當下的位置</param>
        /// <returns>是否按下左鍵</returns>
        public bool TryGetPointerDown(out Vector2 screenPos)
        {
            if (Input.touchCount > 0)
            {//觸控點大於1時
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    screenPos = touch.position;
                    return true;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {//檢測滑鼠左鍵是否按下
                screenPos = Input.mousePosition;
                return true;
            }
            screenPos = Vector2.zero;
            return false;
        }
        /// <summary>
        /// 嘗試取得指標放開的位置
        /// </summary>
        /// <param name="screenPos">out滑鼠左鍵當下的位置</param>
        /// <returns>是否放開左鍵</returns>
        public bool TryGetPointerUp(out Vector2 screenPos)
        {
            if (Input.touchCount > 0)
            {//觸控點大於1時
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    screenPos = touch.position;
                    return true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {//檢測滑鼠左鍵是否放開
                screenPos = Input.mousePosition;
                return true;
            }
            screenPos = Vector2.zero;
            return false;
        }
        #endregion 公開方法
    }
}