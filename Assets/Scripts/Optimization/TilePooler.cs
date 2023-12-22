using System;
using TKK.Managers;

namespace TKK.Optimization
{
    public class TilePooler : PoolerBase<Tile.Tile>
    {
        private void Awake() => InitPool(LevelManager.Instance.LevelConfig.TilePrefab, 0, 200);

        public Tile.Tile GetTile() => Get();

        public void ReleaseTile(Tile.Tile tile) => Release(tile);
    }
}