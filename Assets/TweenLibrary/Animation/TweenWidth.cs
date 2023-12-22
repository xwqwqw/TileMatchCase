using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenWidth : TweenFloatBase
    {
        [SerializeField] protected RectTransform rectTransform;

        protected override void UpdateValue(float ratio)
        {
            var size = rectTransform.sizeDelta;
            size.x = GetValue(ratio);
            rectTransform.sizeDelta = size;
        }

        public override GameObject GetGameObject() => rectTransform.gameObject;
    }
}