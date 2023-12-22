using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenSize : TweenRectTransformBase
    {
        protected override void UpdateValue(float ratio) => _transform.sizeDelta = GetValue(ratio);

        public override GameObject GetGameObject() => _transform.gameObject;
    }
}