using System.Collections.Generic;
using UnityEngine;

namespace MatchGems.View
{
    /// <summary>
    /// GemTile物件回收池
    /// </summary>
    public class GemTilePool
    {
        #region 基本參數
        /// <summary>
        /// GemTile預製物
        /// </summary>
        private readonly GemTile _prefab;
        /// <summary>
        /// GemTile父層(活動區)
        /// </summary>
        private readonly Transform _parent;
        /// <summary>
        /// 回收池(物件池設計模式)
        /// 隊列：先進先出
        /// </summary>
        private readonly Queue<GemTile> _pool = new Queue<GemTile>();
        #endregion 基本參數

        #region 建構
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="prefab">設定預製體</param>
        /// <param name="parent">設定父層</param>
        public GemTilePool(GemTile prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }
        #endregion 建構

        #region 公開方法
        /// <summary>
        /// 取用功能
        /// </summary>
        /// <param name="spawnPos"></param>
        /// <returns></returns>
        public GemTile Get(Vector3 spawnPos)
        {
            GemTile tile = _pool.Count > 0 ? _pool.Dequeue() : CreateTile();//當有物件在隊列時正常抽取，否則建立新的到指定位置
            tile.transform.position = spawnPos;//重設位置
            tile.transform.localScale = Vector3.one;//重設縮放
            return tile;
        }

        /// <summary>
        /// 回收功能
        /// </summary>
        /// <param name="tile"></param>
        public void Release(GemTile tile)
        {
            if (tile == null) return;
            _pool.Enqueue(tile);
        }
        #endregion 公開方法

        #region 私有方法
        private GemTile CreateTile()
        {
            return Object.Instantiate(_prefab, _parent);
        }
        #endregion 私有方法
    }
}
