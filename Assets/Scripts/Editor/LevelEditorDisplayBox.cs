#if UNITY_EDITOR
using UnityEditor;
#endif
using TKK.EditorUtils;
using UnityEngine;

namespace TKK.Editor
{
    public static class LevelEditorDisplayBox
    {
#if UNITY_EDITOR

        public static int CachedIndex;
        public static void Init()
        {
            var option = EditorUtility.DisplayDialogComplex("Save",
                "Do you want to save the data?",
                "Save",
                "NO",
                "No");
            var levelEditor = GameObject.Find("LevelEditor").GetComponent<LevelEditor>();

            switch (option)
            {
                case 0:
                    levelEditor.SaveLevel();
                    levelEditor.GetOutFromLevelEditor();
                    break;
                case 1:
                    levelEditor.GetOutFromLevelEditor();
                    break;
                case 2:
                    levelEditor.GetOutFromLevelEditor();
                    break;
                default:
                    levelEditor.GetOutFromLevelEditor();
                    break;
            }
        }
#endif
    }
}