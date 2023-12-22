using TKK.Utility;
using UnityEditor;
using UnityEngine;

namespace TKK.Editor
{
    public class AttributeColorEditorWindow : EditorWindow
    {
        private Color headerColor;
        private Color bigHeaderColor;

        private const string HeaderColorKey = "HeaderColor";
        private const string BigHeaderColorKey = "BigHeaderColor";

        [MenuItem("TKK/Attribute Color Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<AttributeColorEditorWindow>();
            window.titleContent = new GUIContent("Attribute Colors");
            window.Show();
        }

        private void OnEnable() => LoadColors();

        private void OnGUI()
        {
            GUILayout.Label("Header Attribute Color", EditorStyles.whiteLabel);
            headerColor = EditorGUILayout.ColorField("Color", headerColor);
            AttributeColorManager.HeaderColor = headerColor;

            GUILayout.Space(10);

            GUILayout.Label("BigHeader Attribute Color", EditorStyles.whiteLabel);
            bigHeaderColor = EditorGUILayout.ColorField("Color", bigHeaderColor);
            AttributeColorManager.BigHeaderColor = bigHeaderColor;
        }

        private void OnInspectorUpdate() => Repaint();

        private void OnDisable() => SaveColors();

        private void LoadColors()
        {
            var headerColorJson = EditorPrefs.GetString(HeaderColorKey);
            var bigHeaderColorJson = EditorPrefs.GetString(BigHeaderColorKey);

            headerColor = !string.IsNullOrEmpty(headerColorJson) ? 
                JsonUtility.FromJson<Color>(headerColorJson) : Color.magenta;

            bigHeaderColor = !string.IsNullOrEmpty(bigHeaderColorJson) ?
                JsonUtility.FromJson<Color>(bigHeaderColorJson) : Color.cyan;
        }

        private void SaveColors()
        {
            var headerColorJson = JsonUtility.ToJson(headerColor);
            var bigHeaderColorJson = JsonUtility.ToJson(bigHeaderColor);

            EditorPrefs.SetString(HeaderColorKey, headerColorJson);
            EditorPrefs.SetString(BigHeaderColorKey, bigHeaderColorJson);
        }
    }
}