using TKK.TweenLibrary.Animation.Base;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.TweenLibrary.Animation
{
    public class TweenImageAlpha : TweenFloatBase
    {
        [SerializeField] private Image image;

        protected override void UpdateValue(float ratio)
        {
            var color = image.color;
            color.a = GetValue(ratio);
            image.color = color;
        }

        public override GameObject GetGameObject()
        {
            return image.gameObject;
        }
    }
}