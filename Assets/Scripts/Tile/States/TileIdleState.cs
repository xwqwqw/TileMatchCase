using Tile.Base;

namespace Tile.States
{
    public class TileIdleState : BaseTileState
    {
        public override void OnEnter()
        {
            CheckForShadow();
        }

        private void CheckForShadow()
        {
            if (!ShadowBlocker()) return;
            Tile.TileShadowRenderer.gameObject.SetActive(false);
        }

        private bool ShadowBlocker() => Tile.TileCollisionHandler.ColliderCountReturner == 0;

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        public override void OnReset()
        {
        }
    }
}