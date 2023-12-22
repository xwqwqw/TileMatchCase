using System.Collections.Generic;
using Constants;
using Tile.States;

namespace Tile
{
    public class TileCollisionManager
    {
        public void HandleCollision(List<Tile> otherTiles, Tile currentTile, CollisionContext context)
        {
            foreach (var otherTile in otherTiles)
            {
                if ((int)otherTile.sortingLayerOrder >= (int)currentTile.sortingLayerOrder) continue;
                ChangeTileState(otherTile, context);
            }
        }
    
        public void HandleCollisionForSingleTile(Tile otherTile, Tile currentTile, CollisionContext context)
        {
            if ((int)otherTile.sortingLayerOrder >= (int)currentTile.sortingLayerOrder) return;
            ChangeTileState(otherTile, context);
        }

        public void ChangeTileState(Tile tile, CollisionContext context)
        {
            if (context == CollisionContext.Enter) tile.ChangeState<TileShadowState>();
            else if (context == CollisionContext.Exit) tile.ChangeState<TileIdleState>();
        }
    }
}