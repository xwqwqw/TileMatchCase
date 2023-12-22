using TKK.Managers;
using TKK.Managers.GameManagerStates;
using TKK.Views.Base;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.Views
{
    public class GameLostView : BaseView
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button restartButton;

        private void Start()
        {
            AddListeners();
        }

        private void AddListeners()
        {
            homeButton.onClick.AddListener(delegate
            {
                UIManager.Instance.InGameLoading.StartLoading(delegate
                {
                    GameManager.Instance.ChangeState<GameManagerMainMenuState>();
                });
                Hide();
            });
            restartButton.onClick.AddListener(delegate
            {
                UIManager.Instance.InGameLoading.StartLoading(delegate
                {
                    GameManager.Instance.ChangeState<GameManagerGamePlayState>();
                });
                Hide();
            });
        }
    }
}