using TKK.TweenLibrary.Animation.Base;
using TMPro;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenTextAlpha : TweenFloatBase
    {
        [SerializeField] private TMP_Text tmpText;

        protected override void UpdateValue(float ratio)
        {
            var color = tmpText.color;
            color.a = GetValue(ratio);
            tmpText.color = color;
        }

        public override GameObject GetGameObject() => tmpText.gameObject;
    }
}