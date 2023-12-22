using Constants;
using UnityEngine;

namespace Data.Art
{
    [System.Serializable]
    public class SpriteDataForIcons
    {
        [field: SerializeField] public TileType SpriteTileType { get; private set; }
        [field: SerializeField] public Sprite SpriteIcon { get; private set; }
    }
}