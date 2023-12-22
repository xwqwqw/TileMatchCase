using TKK.Managers;
using TKK.Managers.GameManagerStates;
using TKK.Views.Base;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.Views
{
    public class SettingsView : BaseView
    {
        [SerializeField] private Button sfxButton;
        [SerializeField] private Button soundButton;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button tapToClose;

        [SerializeField] private Sprite toggleEnabled;
        [SerializeField] private Sprite toggleDisabled;

        private void Start()
        {
            SetupButtons();
            AddButtonListeners();
        }

        private void SetupButtons()
        {
            SetButtonSprite(sfxButton, toggleEnabled);
            SetButtonSprite(soundButton, toggleEnabled);
        }

        private void SetButtonSprite(Button button, Sprite sprite)
        {
            button.GetComponent<Image>().sprite = sprite;
        }

        private void AddButtonListeners()
        {
            tapToClose.onClick.AddListener(Hide);
            sfxButton.onClick.AddListener(() => OnButtonClicked(sfxButton, Events.OnSfxSettingsChanged));
            soundButton.onClick.AddListener(() => OnButtonClicked(soundButton, Events.OnMusicSettingsChanged));
            homeButton.onClick.AddListener(delegate
            {
                UIManager.Instance.InGameLoading.StartLoading(delegate
                {
                    GameManager.Instance.ChangeState<GameManagerMainMenuState>();
                    GameManager.Instance.TileSlotController.ResetTileSlot();
                });
                Hide();
            });
        }

        private void OnButtonClicked(Button button, CustomEvent<bool> settingsEvent)
        {
            var isEnabled = button.GetComponent<Image>().sprite == toggleEnabled;
            SetButtonSprite(button, isEnabled ? toggleDisabled : toggleEnabled);

            settingsEvent.Invoke(isEnabled);
        }
    }
}