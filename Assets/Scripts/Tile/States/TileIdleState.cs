using TKK.Tile.Base;

namespace TKK.Tile.States
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