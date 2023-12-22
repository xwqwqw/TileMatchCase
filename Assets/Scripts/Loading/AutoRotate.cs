using UnityEngine;

namespace TKK.Loading
{
    public class AutoRotate : MonoBehaviour
    {
        public Vector3 rotation;

        public Space space = Space.Self;

        void Update()
        {
            this.transform.Rotate(rotation * Time.deltaTime, space);
        }
    }
}