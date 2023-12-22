using Managers;
using TKK.Managers.GameManagerStates.Base;
using Utility;

namespace TKK.Managers.GameManagerStates
{
    public class GameManagerWinState : BaseGameManagerState
    {
        public override void OnEnter()
        {
            UpgradeLevel();
            CallUI();
        }

        private void CallUI()
        {
            UIManager.Instance.GameWonView.Show();
        }

        private void UpgradeLevel()
        {
            GameManager.LevelNumberToBuildLevel++;
            GameManager.LevelNumberToDisplayLevel++;
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            GameManager.Coin += LevelManager.Instance.
                CurrentLevelData.LevelCurrencyData.TotalEarnedCoinAmount;
            Events.OnCoinUpdated.Invoke(GameManager.Coin);
        }

        public override void OnReset()
        {
        }
    }
}