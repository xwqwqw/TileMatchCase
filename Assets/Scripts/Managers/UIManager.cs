using System;
using TKK.Managers.GameManagerStates;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [field: SerializeField] public Button targetObject;

        private void Start()
        {
            targetObject.onClick.AddListener(delegate
            {
                GameManager.Instance.ChangeState<GameManagerGamePlayState>();
            });
        }
    }
}