using Interface;

namespace Tile.Base
{
    public abstract class BaseTileState : IState
    {
        public Tile Tile { get; set; }
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
        public abstract void OnReset();

    }
}