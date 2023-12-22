using Interface;
using Managers;

namespace TKK.Managers.GameManagerStates.Base
{
    public abstract class BaseGameManagerState : IState
    {
        public GameManager GameManager { get; set; }
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
        public abstract void OnReset();
    }
}