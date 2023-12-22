using Managers;
using TKK.Managers.GameManagerStates.Base;

namespace TKK.Managers.GameManagerStates
{
    public class GameManagerGamePlayState : BaseGameManagerState
    {
        public override void OnEnter()
        {
            LevelManager.Instance.BuildLevel();
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