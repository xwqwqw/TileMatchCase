using TKK.Tile.Base;

namespace TKK.Tile.States
{
    public class TileShadowState : BaseTileState
    {
        public override void OnEnter() => Tile.TileShadowRenderer.gameObject.SetActive(true);

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