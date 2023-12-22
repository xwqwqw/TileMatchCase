using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
	public class TweenCanvasAlpha : TweenFloatBase
	{
		[SerializeField] private CanvasGroup canvasGroup;
		
		protected override void UpdateValue(float ratio)
		{
			canvasGroup.alpha = GetValue(ratio);
		}

		public override GameObject GetGameObject()
		{
			return canvasGroup.gameObject;
		}
	}
}