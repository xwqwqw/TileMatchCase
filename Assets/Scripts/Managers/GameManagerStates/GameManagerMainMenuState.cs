using TKK.Managers.GameManagerStates.Base;

namespace TKK.Managers.GameManagerStates
{
    public class GameManagerMainMenuState : BaseGameManagerState
    {
        public override void OnEnter()
        {
            GameManager.Slot.gameObject.SetActive(false);
            UIManager.Instance.MenuView.Show();
            UIManager.Instance.LevelTextMesh.gameObject.SetActive(false);
            LevelManager.Instance.DemolishLevel();
        }

        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
            GameManager.Slot.gameObject.SetActive(true);
            UIManager.Instance.MenuView.Hide();
            UIManager.Instance.LevelTextMesh.gameObject.SetActive(true);
        }

        public override void OnReset()
        {
        }
    }
}