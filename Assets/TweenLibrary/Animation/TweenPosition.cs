using TKK.TweenLibrary.Animation.Base;

namespace TKK.TweenLibrary.Animation
{
    public class TweenPosition : TweenTransformBase
    {
        protected override void UpdateValue(float ratio) => transformBase.localPosition = GetVectorValue(ratio);
    }
}