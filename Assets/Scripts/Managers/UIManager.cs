using TKK.Loading;
using TKK.Utility;
using TKK.Views.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [field: SerializeField] public BaseView GameWonView { get; private set; }
        [field: SerializeField] public BaseView SettingsView { get; private set; }
        [field: SerializeField] public InGameLoading InGameLoading { get; private set; }
        [field: SerializeField] public Button SettingsButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI LevelTextMesh { get; private set; }
        [field: SerializeField] public BaseView MenuView { get; private set; }
        [field: SerializeField] public BaseView GameLostView { get; private set; }

        private void Start()
        {
            AddListeners();
        }

        public void SetLevelHeader()
        {
            LevelTextMesh.text = "Level " +
                                 GameManager.Instance.LevelNumberToDisplayLevel;
        }

        private void AddListeners()
        {
            SettingsButton.onClick.AddListener(SettingsView.Show);
        }
    }
}