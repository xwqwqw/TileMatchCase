using UnityEngine;

namespace TKK.Utility
{
	public class AutoRotate : MonoBehaviour
	{
		// Rotation speed & axis
		public Vector3 rotation;

		// Rotation space
		public Space space = Space.Self;
		void Update()
		{
			this.transform.Rotate(rotation * Time.deltaTime, space);
		}
	}
}