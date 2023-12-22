using System.Collections.Generic;
using TKK.Constants;
using TKK.Tile.States;

namespace TKK.Tile
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

        private void ChangeTileState(Tile tile, CollisionContext context)
        {
            if (context == CollisionContext.Enter) tile.ChangeState<TileShadowState>();
            else if (context == CollisionContext.Exit) tile.ChangeState<TileIdleState>();
        }
    }
}