using TKK.TweenLibrary.Animation.Base;
using TKK.TweenLibrary.Animation.DataTypes;
using TMPro;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenNumericTextLong : TweenSingleBase
    {
        [SerializeField] private TweenLongValue tweenLongValue;
        [SerializeField] private TMP_Text tmpText;

        private long _prevPrintedValue = -1;

        protected override void UpdateValue(float ratio)
        {
            var value = (long)Mathf.Ceil(Mathf.Lerp(tweenLongValue.Start, tweenLongValue.End, ratio));

            if (value != _prevPrintedValue)
            {
                tmpText.text = value.ToString();
                _prevPrintedValue = value;
            }
        }

        public void SetValue(long start, long end)
        {
            tweenLongValue.Start = start;
            tweenLongValue.End = end;
        }

        public override GameObject GetGameObject()
        {
            return tmpText.gameObject;
        }
    }
}