using Managers;
using UnityEngine;

namespace Tile
{
    public class TileInputHandling : MonoBehaviour
    {
        private Tile _tile => GetComponentInParent<Tile>();

        private void OnMouseEnter()
        {
        }

        private void OnMouseDown()
        {
            Events.OnTileClicked.Invoke(_tile);
        }

        private void OnMouseExit()
        {
        }
    }
}