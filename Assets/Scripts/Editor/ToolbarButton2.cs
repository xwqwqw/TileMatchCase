using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;

namespace TKK.Editor
{
    [EditorToolbarElement(id2, typeof(SceneView))]
    class ToolbarButton2 : EditorToolbarButton
    {
        public const string id2 = "Level Button";

        public ToolbarButton2()
        {
            icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Scripts/Editor/heart_orange.png");
            clicked += OnClicked;
        }

        private void OnClicked()
        {
            LevelEditorCallWindow.ShowWindow();
        }
    }
}