using TKK.Constants;
using UnityEngine;

namespace TKK.Data.Art
{
    [System.Serializable]
    public class SpriteDataForIcons
    {
        [field: SerializeField] public TileType SpriteTileType { get; private set; }
        [field: SerializeField] public Sprite SpriteIcon { get; private set; }
    }
}