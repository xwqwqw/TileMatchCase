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
            Tile.TileShadowRenderer.gameObject.SetActive(false);
        }

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