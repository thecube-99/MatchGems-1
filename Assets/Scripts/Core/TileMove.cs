
namespace MatchGems.Core
{
    /// <summary>
    /// 一回合內寶石移動資訊紀錄
    /// </summary>
    public readonly struct TileMove
    {
        /// <summary>
        /// 來源格(活珠原位)
        /// </summary>
        public CellCoord From { get; }
        /// <summary>
        /// 落點格
        /// </summary>
        public CellCoord To { get; }

        public bool IsNew { get; }

        /// <summary>
        /// 建立舊紀錄(移動)
        /// </summary>
        /// <param name="from">來源格</param>
        /// <param name="to">落點格</param>
        public TileMove(CellCoord from, CellCoord to)
        {
            From = from;
            To = to;
            IsNew = false;//舊珠
        }
        /// <summary>
        /// 建立新紀錄(天降)
        /// </summary>
        /// <param name="coord">定位格</param>
        public TileMove(CellCoord coord)
        {
            From = coord;
            To = coord;
            IsNew = true;//新珠：需要從畫面外下來
        }
    }
}