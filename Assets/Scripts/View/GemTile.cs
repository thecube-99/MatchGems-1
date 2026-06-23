using UnityEngine;
using MatchGems.Core;//導入核心資料

namespace MatchGems.View
{
    /// <summary>
    /// 單顆寶石的畫面元件(強制綁定SpriteRenderer)
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class GemTile : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] 
        private float _tileScale = 0.9f;
        private SpriteRenderer _spriteRenderer;
        /// <summary>
        /// 視覺渲染延遲讀取
        /// </summary>
        private SpriteRenderer SpriteRenderer => _spriteRenderer == null ? _spriteRenderer = GetComponent<SpriteRenderer>() : _spriteRenderer;
        /*{
            get
            {
                if (_spriteRenderer == null)
                {
                    _spriteRenderer = GetComponent<SpriteRenderer>();
                }
                return _spriteRenderer; 
            }
        }*/
        /// <summary>
        /// [靜態]共用Sprite變數
        /// </summary>
        private static Sprite _defaultSprite;
        #endregion 基本參數

        #region 公開功能
        /// <summary>
        /// 依照設定的寶石種類更新視覺
        /// </summary>
        /// <param name="gemType">寶石種類</param>
        /*public void SetGem(GemType gemType)
        {
            SpriteRenderer.sprite = GetDefaultSprite();
            SpriteRenderer.color = GetColor(gemType);
            transform.localScale = Vector3.one * _tileScale;
        }*/
        /// <summary>
        /// 設定寶石資料並更新視覺
        /// </summary>
        /// <param name="gemData">寶石資料</param>
        public void SetGem(GemData gemData)
        {
            SpriteRenderer.sprite = GetDefaultSprite();
            SpriteRenderer.color = GetColor(gemData.Color);
            transform.localScale = Vector3.one * _tileScale;
        }
        #endregion 公開功能

        #region 私有功能
        /// <summary>
        /// 取得預設Sprite圖片(白色)
        /// </summary>
        /// <returns>Sprite圖片</returns>
        private Sprite GetDefaultSprite()
        {
            if (_defaultSprite == null)
            {
                Texture2D texture = new Texture2D(1,1);//建立最小單位的貼圖
                texture.SetPixel(0, 0, Color.white);
                texture.Apply();
                //用指定參數格式建立圖片(貼圖, 預設矩形定位&尺寸, 錨點位置正中, 一單位容納像素值)
                _defaultSprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);
            }
            return _defaultSprite;
        }

        /// <summary>
        /// 取得寶石種類對應的色票
        /// </summary>
        /// <param name="gemType">寶石種類</param>
        /// <returns>對應的色票</returns>
        private Color GetColor(GemType gemType)
        {
            switch (gemType)
            {
                case GemType.Red: return Color.red;
                case GemType.Blue: return Color.blue;
                case GemType.Green: return Color.green;
                case GemType.Yellow: return Color.yellow;
                case GemType.Purple: return Color.purple;
                case GemType.Pink: return Color.pink;
            }
            return Color.white;
        }
        #endregion 私有功能
    }
}