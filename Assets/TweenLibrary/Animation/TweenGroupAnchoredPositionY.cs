using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenGroupAnchoredPositionY : TweenFloatBase
    {
        [SerializeField] protected float groupItemDelay;
        [SerializeField] protected RectTransform[] rectTransforms;

        public override void UpdateTime(float time)
        {
            if (EasingMethod == null)
            {
                InitializeEasing();
            }

            for (int i = 0; i < rectTransforms.Length; i++)
            {
                var delay = timings.Delay + i * groupItemDelay;
                var duration = timings.Delay + timings.Duration + delay;

                if (time >= delay)
                {
                    if (time < duration)
                    {
                        var ratio = EasingMethod((time - delay) / timings.Duration);
                        UpdateValue(i, ratio);
                    }
                    else
                    {
                        var ratio = EasingMethod(1f);
                        UpdateValue(i, ratio);
                    }
                }
                else
                {
                    var ratio = EasingMethod(0f);
                    UpdateValue(i, ratio);
                }
            }
        }

        protected void UpdateValue(int index, float ratio)
        {
            var transform = rectTransforms[index];
            var position = transform.anchoredPosition;
            position.y = GetValue(ratio);
            transform.anchoredPosition = position;
        }

        protected override void UpdateValue(float ratio)
        {
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }

        public override float GetDuration()
        {
            return timings.Delay + timings.Duration + groupItemDelay * (rectTransforms.Length - 1);
        }
    }
}