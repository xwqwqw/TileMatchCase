using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
    public class TweenShakeRotationZ : TweenSingleBase
    {
        [SerializeField] private float amplitude = 10;
        [SerializeField, Range(0, 10)] private int shakeCycles = 4;
        [SerializeField] protected Transform transformBase;

        protected override void UpdateValue(float ratio)
        {
            var rotation = transformBase.localRotation.eulerAngles;
            rotation.z = amplitude * Mathf.Sin(Mathf.PI * shakeCycles * ratio) * (1f - ratio);

            transformBase.localRotation = Quaternion.Euler(rotation);
        }

        public override GameObject GetGameObject() => transformBase.gameObject;
    }
}