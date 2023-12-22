using TKK.Constants;
using UnityEngine;

namespace TKK.Tile.Data
{
    [System.Serializable]
    public struct TileData
    {
        [field: SerializeField] public Vector3 TilePosition { get; set; }
        [field: SerializeField] public TileType TileType { get; set; }
        [field: SerializeField] public SortingLayerOrder SortingLayerOrder { get; set; }
        [field: SerializeField] public int SortingOrderIndex { get; set; }
    }
}