using Interface;
using Managers;
using TKK.Managers.GameManagerStates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.Views
{
    public class MenuView : BaseView
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private Button continueButton;

        private void Start()
        {
            AddListeners();
        }

        private void AddListeners()
        {
            Events.OnCoinUpdated.AddListener(CoinUpdated);
            continueButton.onClick.AddListener(delegate
            {
                UIManager.Instance.InGameLoading.StartLoading(delegate
                {
                    GameManager.Instance.ChangeState<GameManagerGamePlayState>();
                });
            });
        }

        private void CoinUpdated(int value)
        {
            coinText.text = value.ToString();
        }
    }
}