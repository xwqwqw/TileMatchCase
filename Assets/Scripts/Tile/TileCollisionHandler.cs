using System.Collections.Generic;
using Constants;
using UnityEngine;

namespace Tile
{
    public class TileCollisionHandler : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;
        public BoxCollider2D BoxCollider2D => _boxCollider2D;
        private Tile _tile;
        private TileCollisionManager _tileCollisionManager;
        private List<Tile> _collidingTiles = new List<Tile>();
        public int ColliderCountReturner => _collidingTiles.Count - 1;

        private void Awake()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _tile = GetComponentInParent<Tile>();
            _tileCollisionManager = new TileCollisionManager();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (ShouldIgnoreCollision(other)) return;
            if (!other.transform.parent.TryGetComponent(out Tile tile)) return;
            OnEnter(tile);
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (ShouldIgnoreCollision(other)) return;
            if (!other.transform.parent.TryGetComponent(out Tile tile)) return;
            OnExit(tile);
        }

        private void OnExit(Tile tile)
        {
            if (ColliderCountReturner == 0)
                _tileCollisionManager.HandleCollision(_collidingTiles, _tile, CollisionContext.Exit);
            Debug.Log(tile.sortingLayerOrder + tile.transform.position.ToString());

            foreach (var tilee in _collidingTiles)
            {
                Debug.Log(tile.sortingLayerOrder.ToString() + tile.transform.position.ToString() + tilee.sortingLayerOrder.ToString() + tilee.transform.position);
                tilee.TileCollisionHandler._tileCollisionManager.HandleCollisionForSingleTile(_tile,
                    tilee, CollisionContext.Exit);
            }

            _collidingTiles.Remove(tile);
        }

        private void OnEnter(Tile tile)
        {
            _collidingTiles.Add(tile);
            _tileCollisionManager.HandleCollision(_collidingTiles, _tile, CollisionContext.Enter);
        }

        private bool ShouldIgnoreCollision(Collider2D other)
            => other == _boxCollider2D || !other.transform.parent.TryGetComponent(out Tile _);

    }
}