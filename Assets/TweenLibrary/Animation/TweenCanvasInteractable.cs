using TKK.TweenLibrary.Animation.Base;
using UnityEngine;

namespace TKK.TweenLibrary.Animation
{
	public class TweenCanvasInteractable : Tween
	{
		[SerializeField] private float duration;
		[SerializeField] private bool targetValue;
		[SerializeField] private CanvasGroup canvasGroup;
		
		protected float _normalizedTime = -1f;
		
		public override void UpdateTime(float time)
		{
			var normalizedTime = time < duration ? time / duration : 1f;

			if (normalizedTime != _normalizedTime)
			{
				_normalizedTime = normalizedTime;
				var value = _normalizedTime == 1f ? targetValue : !targetValue;
				canvasGroup.interactable = value;
				canvasGroup.blocksRaycasts = value;
			}
		}

		public override float GetDuration()
		{
			return duration;
		}

		public override GameObject GetGameObject()
		{
			return canvasGroup.gameObject;
		}
		
	}
}