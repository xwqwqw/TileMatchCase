using TKK.Managers.GameManagerStates.Base;

namespace TKK.Managers.GameManagerStates
{
    public class GameManagerFailState : BaseGameManagerState
    {
        public override void OnEnter()
        {
            CallUI();
            DemolishLevel();
        }

        private void DemolishLevel() => LevelManager.Instance.DemolishLevel();
        private void CallUI() => UIManager.Instance.GameLostView.Show();

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