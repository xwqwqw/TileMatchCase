using TKK.TweenLibrary.Animation.Base;

namespace TKK.TweenLibrary.Animation
{
	public class TweenRotation : TweenTransformBase
	{
		protected override void UpdateValue(float ratio) =>	transformBase.localRotation = GetQuaternionValue(ratio);
	}
}