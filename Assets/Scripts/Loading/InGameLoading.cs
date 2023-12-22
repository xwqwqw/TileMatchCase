using System;
using UnityEngine;
using DG.Tweening;

namespace TKK.Loading
{
    public class InGameLoading : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeInDuration = 1f;
        [SerializeField] private float fadeOutDuration = 1f;
        [SerializeField] private float delay = 1f;

        private Action _cachedAction;

        public void StartLoading(Action completeAction)
        {
            _cachedAction = completeAction;
            canvasGroup.alpha = 0;
            canvasGroup.gameObject.SetActive(true);

            canvasGroup.DOFade(1f, fadeInDuration)
                .OnComplete(DelayBeforeFadeOut);
        }

        private void DelayBeforeFadeOut()
        {
            _cachedAction?.Invoke();
            DOVirtual.DelayedCall(delay, FadeOut);
        }

        private void FadeOut() => canvasGroup.DOFade(0f, fadeOutDuration)
            .OnComplete(OnLoadingComplete);

        private void OnLoadingComplete() => canvasGroup.gameObject.SetActive(false);
    }
}