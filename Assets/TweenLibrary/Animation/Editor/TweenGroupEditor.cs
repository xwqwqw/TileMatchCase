using EditorUtils;
using TKK.TweenLibrary.Animation;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

namespace TKK.Editor
{
    [CustomEditor(typeof(TweenGroup))]
    public class TweenGroupEditor : UnityEditor.Editor
    {
        public static int IndexValue = 0;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var tweenGroup = (TweenGroup)target;
            if (tweenGroup == null) return;
            DrawMainButtons(tweenGroup);
        }


        private void DrawMainButtons(TweenGroup tweenGroup)
        {
            DrawRegularButtons(tweenGroup);
        }

        private static void DrawRegularButtons(TweenGroup tweenGroup)
        {
            if (GUILayout.Button("Play Animation"))
                EditorCoroutineUtility.StartCoroutine(tweenGroup.AnimationCoroutine(), tweenGroup);
            if (GUILayout.Button("Undo Animation"))
                EditorCoroutineUtility.StartCoroutine(tweenGroup.ReversedAnimationCoroutine(), tweenGroup);
        }
    }
}