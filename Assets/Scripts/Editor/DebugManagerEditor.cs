using TKK.Utility;
using UnityEditor;
using UnityEngine;

namespace TKK.Editor
{
    public class DebugManagerEditor : EditorWindow
    {
        bool verbose;
        [MenuItem("TKK/Debug Manager Mode")]
        static void Init()
        {
            var window = (DebugManagerEditor)GetWindow(typeof(DebugManagerEditor), true, "Debug Manager Window");
            window.Show();
        }

        private void OnEnable()
        {
            verbose = EditorPrefs.GetBool("verbose");
        }

        void ChangeBoolValue()
        {
            verbose = DebugManager.DebugMode != DEBUGMODE.RELEASE;
        }
        void OnGUI()
        {
            EditorPrefs.SetBool("verbose", verbose);

            var selectedDebugMode = (DEBUGMODE)EditorGUILayout.EnumPopup("Debug Mode", DebugManager.DebugMode);

            if (selectedDebugMode != DebugManager.DebugMode)
            {
                DebugManager.DebugMode = selectedDebugMode;
                ChangeBoolValue();
            }

            if (GUILayout.Button("Change Mode"))
                DebugManager.ChangeDebugMode(verbose);

            if (GetWindow<DebugManagerEditor>()) return;
            ChangeBoolValue();
        }

    }
}