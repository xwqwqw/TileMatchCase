using TKK.TweenLibrary.Animation.Base;

namespace TKK.TweenLibrary.Animation
{
    public class TweenScale : TweenTransformBase
    {
        protected override void UpdateValue(float ratio) => transformBase.localScale = GetVectorValue(ratio);
    }
}