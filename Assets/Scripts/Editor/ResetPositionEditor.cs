using UnityEditor;
using UnityEngine;
using Utility;

namespace TKK.Editor
{
    [CustomEditor(typeof(ResetPosition))]
    public class ResetPositionEditor : UnityEditor.Editor
    {
        private ResetPosition resetPosition;
        private void OnEnable()
        {
            resetPosition = (ResetPosition)target;
            resetPosition.transform.position = Vector3.zero;
            resetPosition.transform.eulerAngles = Vector3.zero;
        }
        private void OnDisable()
        {
            if (resetPosition)
            {
                resetPosition.transform.position = Vector3.zero;
                resetPosition.transform.eulerAngles = Vector3.zero;
            }
        }
        public override void OnInspectorGUI()
        {
        }
    }
}