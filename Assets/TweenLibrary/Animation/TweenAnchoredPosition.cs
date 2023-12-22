using TKK.TweenLibrary.Animation.Base;

namespace TKK.TweenLibrary.Animation
{
	public class TweenAnchoredPosition : TweenRectTransformBase
	{
		protected override void UpdateValue(float ratio)
		{
			_transform.anchoredPosition = GetValue(ratio);
		}
	}
}