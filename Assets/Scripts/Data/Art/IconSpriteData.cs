using System.Collections.Generic;
using UnityEngine;

namespace Data.Art
{
    [CreateAssetMenu(menuName = "TileData/IconSpriteData", fileName = "Assets/Resources/IconSpriteData")]
    public class IconSpriteData : ScriptableObject
    {
        [field: SerializeField] public List<SpriteDataForIcons> SpriteDataForIcons { get; private set; }
    }
}