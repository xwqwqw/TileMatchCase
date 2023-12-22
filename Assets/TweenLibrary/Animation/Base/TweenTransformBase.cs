using UnityEngine;

namespace TKK.TweenLibrary.Animation.Base
{
	public abstract class TweenTransformBase : TweenSingleBase
	{
		[SerializeField] protected Vector3 startValue;
		[SerializeField] protected Vector3 endValue;
		[SerializeField] protected Transform transformBase;
		
		public Vector3 GetVectorValue(float ratio)
		{
			return Vector3.LerpUnclamped(startValue, endValue, ratio);
		}
		
		public Quaternion GetQuaternionValue(float ratio)
		{
			var rotation = new Vector3
			{
				x = LerpAngleUnclamped(startValue.x, endValue.x, ratio),
				y = LerpAngleUnclamped(startValue.y, endValue.y, ratio),
				z = LerpAngleUnclamped(startValue.z, endValue.z, ratio),
			};
			
			return Quaternion.Euler(rotation);
		}

		public override GameObject GetGameObject()
		{
			return transformBase.gameObject;
		}
		private const float MaxAngle = 360f;

		public static float LerpAngleUnclamped(float startValue, float endValue, float ratio)
		{
			var delta = endValue - startValue;
			var value = delta - Mathf.Floor(delta / MaxAngle) * MaxAngle;

			if (value < 0f)
			{
				value = 0f;
			}
			else if (value > MaxAngle)
			{
				value = MaxAngle;
			}
			else if (value > MaxAngle / 2f)
			{
				value -= MaxAngle;
			}
	
			return startValue + value * ratio;
		}
	}
	
}
