using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;

namespace TKK.Editor
{
    [EditorToolbarElement(id, typeof(SceneView))][EditorToolbarElement(id, typeof(SceneView))]

    class ToolbarButton : EditorToolbarButton
    {
        public const string id = "ToolbarButton";

        public ToolbarButton()
        {
            icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Scripts/Editor/heart_green.png");
            clicked += OnClicked;
        }

        private void OnClicked()
        {
            Debug.Log("SS");
        }
    }
}