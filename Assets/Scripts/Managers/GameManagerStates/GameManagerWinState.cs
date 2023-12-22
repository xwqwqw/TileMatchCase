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
            UIManager.Instance.targetObject.gameObject.SetActive(true);
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
        }

        public override void OnReset()
        {
        }
    }
}