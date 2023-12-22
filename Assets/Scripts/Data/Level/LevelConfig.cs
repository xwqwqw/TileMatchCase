using System.Collections.Generic;
using System.Linq;
using Tile.Data;
using TKK.TileSlot;
using UnityEditor;
using UnityEngine;

namespace Data.Level
{
    [CreateAssetMenu(menuName = "TileData/LevelConfig", fileName = "Assets/Resources/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public Tile.Tile TilePrefab { get; private set; }
        [field: SerializeField] public TileSlot TileSlotPrefab { get; private set; }

        [field: SerializeField] public List<LevelData> GameLevels { get; private set; } = new List<LevelData>();

#if UNITY_EDITOR
        public void CreateLevel(List<TileData> tileData)
        {
            var data = CreateInstance<LevelData>();
            data.GenerateTileData(tileData);

            SaveScriptableObject(data);

            var levelsToAdd = new List<LevelData>();

            foreach (var level in GameLevels.Where(level => level.name != EditorPrefs.GetString("SavedIndex")))
            {
                levelsToAdd.Add(data);
            }

            GameLevels.Add(levelsToAdd.Count > 0 ? levelsToAdd[0] : data);
        }


        private void SaveScriptableObject(LevelData LevelData)
        {
            var name = EditorPrefs.GetString("SavedIndex", "");
            var path = "Assets/Resources/" + name + ".asset";

            AssetDatabase.CreateAsset(LevelData, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(this);
            AssetDatabase.Refresh();
        }
#endif
    }
}