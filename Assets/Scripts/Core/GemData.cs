namespace MatchGems.Core
{
    /// <summary>
    /// 寶石單體資料
    /// </summary>
    public class GemData
    {
        #region 公開屬性
        /// <summary>
        /// 顏色種類
        /// </summary>
        public GemType Color { get; }
        #endregion 公開屬性

        #region 建構式
        public GemData(GemType color)
        {
            Color = color;
        }
        #endregion 建構式
    }
}


