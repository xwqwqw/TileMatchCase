using TKK.TweenLibrary.Animation.DataTypes;
using UnityEngine;

namespace TKK.TweenLibrary.Animation.Base
{
	public abstract class TweenFloatBase : TweenSingleBase
	{
		[SerializeField] public TweenFloatValue _value;
		
		public float GetValue(float ratio)
		{
			return (_value.End - _value.Start) * ratio + _value.Start;
		}
	}
}