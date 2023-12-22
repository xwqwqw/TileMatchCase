using TKK.Interface;
using TKK.TweenLibrary.Animation;
using UnityEngine;

namespace TKK.Views.Base
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        [SerializeField] private TweenGroup showTweenGroup;
        [SerializeField] private TweenGroup hideTweenGroup;

        public virtual void Show()
        {
            gameObject.SetActive(true);
            StartCoroutine(showTweenGroup.AnimationCoroutine());
        }

        public void Hide() => StartCoroutine(hideTweenGroup.AnimationCoroutine(OnHide));

        protected virtual void OnHide() => gameObject.SetActive(false);
    }
}