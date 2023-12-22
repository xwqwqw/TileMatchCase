using TKK.Utility;
using UnityEditor;
using UnityEngine;

namespace TKK.Editor
{
    [CustomEditor(typeof(FixScale))]
    public class FixScaleEditor : UnityEditor.Editor
    {
        private FixScale fixScale;
        private void OnEnable()
        {
            fixScale = (FixScale)target;
            fixScale.transform.localScale = Vector3.one;
        }
        private void OnDisable()
        {
            if (fixScale)
                fixScale.transform.localScale = Vector3.one;
        }
        public override void OnInspectorGUI()
        {
        }
    }
}