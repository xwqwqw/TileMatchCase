using TKK.TweenLibrary.Animation.Base;
using TKK.TweenLibrary.Animation.DataTypes;
using TMPro;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenNumericTextInt : TweenSingleBase
    {
        [SerializeField] private TweenIntValue tweenIntValue;
        [SerializeField] private TMP_Text tmpText;

        private long _prevPrintedValue = -1;

        protected override void UpdateValue(float ratio)
        {
            var value = Mathf.CeilToInt(Mathf.Lerp(tweenIntValue.Start, tweenIntValue.End, ratio));

            if (value != _prevPrintedValue)
            {
                tmpText.text = value.ToString();
                _prevPrintedValue = value;
            }
        }

        public void SetValue(int start, int end)
        {
            tweenIntValue.Start = start;
            tweenIntValue.End = end;
        }

        public override GameObject GetGameObject()
        {
            return tmpText.gameObject;
        }
    }
}