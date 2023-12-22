using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenScaleFloat : TweenFloatBase
    {
        [SerializeField] public RectTransform rectTransform;

        protected override void UpdateValue(float ratio)
        {
            var scale = GetValue(ratio);
            rectTransform.localScale = new Vector3(scale, scale, scale);
        }

        public override GameObject GetGameObject() => rectTransform.gameObject;
    }
}