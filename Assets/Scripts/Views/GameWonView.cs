using Interface;
using Managers;
using TKK.Managers.GameManagerStates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.Views
{
    public class GameWonView : BaseView
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private TextMeshProUGUI earnedCoinTmp;

        private void Start()
        {
            AddListeners();
        }

        public override void Show()
        {
            base.Show();
            AssignCoinText();
        }

        private void AssignCoinText()
        {
            earnedCoinTmp.text =
                LevelManager.Instance.CurrentLevelData.LevelCurrencyData.TotalEarnedCoinAmount.ToString();
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
            continueButton.onClick.AddListener(delegate
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