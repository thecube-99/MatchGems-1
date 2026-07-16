
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
        /// <summary>
        /// 建立移動紀錄
        /// </summary>
        /// <param name="from">來源格</param>
        /// <param name="to">落點格</param>
        public TileMove(CellCoord from, CellCoord to)
        {
            From = from;
            To = to;
        }
    }
}