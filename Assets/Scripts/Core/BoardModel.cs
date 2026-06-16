namespace MatchGems.Core
{
    public class BoardModel
    {
        #region 基本參數
        /// <summary>
        /// 寶石陣 (二維)
        /// </summary>
        private GemData[,] _gems;
        #endregion 基本參數

        #region 公開參數接口
        /// <summary>
        /// 棋盤寬度
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// 棋盤高度
        /// </summary>
        public int Height { get; }
        #endregion 公開參數接口

        #region 建構式
        /// <summary>
        /// 建立指定尺寸的棋盤
        /// </summary>
        /// <param name="w">寬</param>
        /// <param name="h">高</param>
        public BoardModel(int w, int h) 
        {
            Width = w;
            Height = h;
            _gems = new GemData[Width, Height];
        }
        #endregion 建構式

        #region 公開方法
        /// <summary>
        /// 設定指定格子的寶石
        /// </summary>
        /// <param name="coord">定位資料</param>
        /// <param name="gemType">寶石類型</param>
        public void SetGem(CellCoord coord, GemType gemType)
        {
            _gems[coord.X, coord.Y] = new GemData(gemType);
        }
        /// <summary>
        /// 設定指定格子的寶石
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="gemType">寶石類型</param>
        public void SetGem(int x, int y, GemType gemType)
        {
            _gems[x, y] = new GemData(gemType);
        }
        /// <summary>
        /// 取得指定格子的寶石
        /// </summary>
        /// <param name="coord">定位資料</param>
        /// <returns>寶石資料</returns>
        public GemData GetGem(CellCoord coord)
        {
            return _gems[coord.X, coord.Y];
        }
        /// <summary>
        /// 取得指定格子的寶石
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <returns>寶石資料</returns>
        public GemData GetGem(int x, int y)
        {
            return _gems[x, y];
        }
        #endregion 公開方法
    }

}