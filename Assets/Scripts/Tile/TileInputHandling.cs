using Data.Art;
using Managers;
using TKK.Utility;
using UnityEngine;

namespace Tile
{
    public class TileInputHandling : MonoBehaviour
    {
        private Tile _tile => GetComponentInParent<Tile>();
        private AudioClip _audioClip => DataManager<AudioData>.Data.TileClip;

        private void OnMouseDown()
        {
            if (CheckOverUI.IsOverUI()) return;
            if (CheckIfShadowed()) return;
            if (CheckOnSlot()) return;
            Events.OnTileClicked.Invoke(_tile);
            Events.OnPlaySoundSfx.Invoke(_audioClip);
        }

        private bool CheckIfShadowed()
            => _tile.TileShadowRenderer.gameObject.activeInHierarchy;

        private bool CheckOnSlot() => _tile.CurrentTileSlot;
    }
}