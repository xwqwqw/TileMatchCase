using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
	public class TweenAnchoredPositionY : TweenFloatBase
	{
		[SerializeField] protected RectTransform rectTransform;
		
		protected override void UpdateValue(float ratio)
		{
			var position = rectTransform.anchoredPosition;
			position.y = GetValue(ratio);
			rectTransform.anchoredPosition = position;
		}

		public override GameObject GetGameObject()
		{
			return rectTransform.gameObject;
		}
	}
}