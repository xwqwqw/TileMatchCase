using TKK.Data.Level;
using TKK.EditorUtils;
using TKK.Managers;
using UnityEditor;
using UnityEngine;

namespace TKK.Editor
{
    public class LevelEditorCallWindow : EditorWindow
    {
        private int indexValue = 0;
        private LevelData _cachedData;

        public static void ShowWindow()
        {
            GetWindow<LevelEditorCallWindow>("Level Selector");
        }

        private void OnGUI()
        {
            GUILayout.Label("The 0 means the Level 1 ", EditorStyles.helpBox);

            GUILayout.Label("Level value", EditorStyles.boldLabel);

            indexValue = EditorGUILayout.IntField("Level value", indexValue);

            if (!GUILayout.Button("Open Level Editor")) return;

            var nameOfLevel = "Level" + indexValue;
            EditorPrefs.SetString("SavedIndex", nameOfLevel);

            var instance = PrefabUtility.InstantiatePrefab(
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Scripts/Editor/LevelEditor.prefab")) as GameObject;

            PrefabUtility.UnpackPrefabInstance(instance, PrefabUnpackMode.Completely, InteractionMode.UserAction);

            Selection.activeGameObject = GameObject.Find("LevelEditor");
            Selection.activeGameObject.transform.position = Vector3.one * 100f;

            var levelEditor = Selection.activeGameObject.GetComponent<LevelEditor>();
            var targetData = DataManager<LevelConfig>.Data.GameLevels;
        
            foreach (var levelData in targetData)
            {
                if (levelData.name == EditorPrefs.GetString("SavedIndex"))
                {
                    _cachedData = levelData;
                }
            }

            if (_cachedData != null) levelEditor.FetchData(_cachedData.TileDatas);

            Close();
        }
    }
}