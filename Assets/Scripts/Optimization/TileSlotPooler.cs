using TKK.Managers;

namespace TKK.Optimization
{
    public class TileSlotPooler : PoolerBase<TileSlot.TileSlot>
    {
        private void Awake() => InitPool(LevelManager.Instance.LevelConfig.TileSlotPrefab, 0, 200);

        public TileSlot.TileSlot GetTileSlot() => Get();

        public void ReleaseTileSlot(TileSlot.TileSlot tileSlot) => Release(tileSlot);
    }
}