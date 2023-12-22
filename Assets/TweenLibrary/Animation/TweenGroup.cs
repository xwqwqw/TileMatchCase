using System.Collections.Generic;
using System.Linq;
using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenGroup : Tween
    {
        [SerializeField] private bool autoUpdateChildren;
        [SerializeField] private float timeScale = 1f;
        [SerializeField] private List<Tween> tweens;
        [SerializeField] protected float groupItemDelay;

        public bool AutoUpdateChildren => autoUpdateChildren;
        public List<Tween> Tweens => tweens;

        private float _normalizedTime = -1f;
        private float _duration;

        public void UpdateTweensFromChildren()
        {
            tweens = GetComponentsInChildren<Tween>().Where(tween => tween != this).ToList();
        }

        internal override void OnStartPlaying()
        {
            var totalTweens = tweens.Count;

            for (int i = 0; i < totalTweens; i++)
            {
                var tween = tweens[i];
                tween.GroupDelay = i * groupItemDelay;
                tween.OnStartPlaying();
            }

            _duration = GetDuration();
        }

        public override void UpdateTime(float time)
        {
            var normalizedTime = 0f;

            if (time >= GroupDelay)
            {
                if (time < _duration)
                {
                    normalizedTime = (time - GroupDelay) / (_duration - GroupDelay);
                }
                else
                {
                    normalizedTime = 1f;
                }
            }

            if (normalizedTime == _normalizedTime) return;
            time = normalizedTime * (_duration - GroupDelay) * timeScale;

            for (int i = 0; i < tweens.Count; i++)
            {
                tweens[i].UpdateTime(time);
            }

            _normalizedTime = normalizedTime;
        }

        public override float GetDuration()
        {
            var totalTweens = tweens.Count;
            var result = 0f;

            for (int i = 0; i < totalTweens; i++)
            {
                var tween = tweens[i];
                var duration = tween.GetDuration();

                if (duration > result)
                {
                    result = duration;
                }
            }

            return result / timeScale + GroupDelay;
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}