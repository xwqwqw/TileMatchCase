using System;
using TKK.TweenLibrary.Animation.DataTypes;
using UnityEngine;
using UnityEngine.Serialization;

namespace TKK.TweenLibrary.Animation.Base
{
    public abstract class TweenSingleBase : Tween
    {
        [HideInInspector] [SerializeField] private bool isPlaybackAvailable;
        [SerializeField] public EasingType easing;

        [SerializeField] protected AnimationCurve curve;

        [SerializeField] [Range(1, 25)] protected int cycles = 1;

        [SerializeField] public TweenTimingsValue timings;

        public bool IsPlaybackAvailable => isPlaybackAvailable;

        protected Func<float, float> EasingMethod;

        protected float NormalizedTime = -1f;

        protected void InitializeEasing()
        {
            EasingMethod = easing == EasingType.Curve
                ? curve.Evaluate
                : Easing.GetEasingMethod(easing);
        }

        public override void UpdateTime(float time)
        {
            var totalDuration = GetDuration();
            var normalizedTime = 0f;

#if UNITY_EDITOR
            InitializeEasing();
#else
			if (_easingMethod == null)
			{
				InitializeEasing();
			}
#endif

            if (time >= timings.Delay + GroupDelay)
            {
                if (time < totalDuration)
                    normalizedTime = (time - (timings.Delay + GroupDelay)) / timings.Duration % 1f;
                else
                    normalizedTime = 1f;
            }

            if (normalizedTime == NormalizedTime) return;
            var ratio = EasingMethod(normalizedTime);
            UpdateValue(ratio);
            NormalizedTime = normalizedTime;
        }

        public override float GetDuration()
        {
            return timings.Delay + GroupDelay + timings.Duration * cycles;
        }

        [ContextMenu("Set Playback Enabled")]
        private void SetPlaybackEnabled()
        {
            isPlaybackAvailable = true;
        }

        [ContextMenu("Set Playback Disabled")]
        private void SetPlaybackDisabled()
        {
            isPlaybackAvailable = false;
        }

        protected abstract void UpdateValue(float ratio);
    }
}