using System;
using EditorUtils;
using UnityEditor;
using UnityEngine;

namespace TKK.Editor
{
    [CustomEditor(typeof(LevelEditor))]
    public class LevelEditorEditor : UnityEditor.Editor
    {
        public static int IndexValue = 0;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var levelEditor = (LevelEditor)target;
            if (levelEditor == null) return;

            DrawInfoLabel(levelEditor);
            DrawErrorLabel(levelEditor);
            DrawTheArrowButtons(levelEditor);
            DrawMainButtons(levelEditor);
        }

        private void DrawInfoLabel(LevelEditor levelEditor)
        {
            if (levelEditor.CachedTile == null) return;
            var message = levelEditor.CachedTile.TileType
                          + " " + levelEditor.CachedTile.sortingLayerOrder;
            EditorGUILayout.HelpBox(message, MessageType.Info);
        }

        private void DrawErrorLabel(LevelEditor levelEditor)
        {
            if (levelEditor.tiles.Count % 3 != 0)
            {
                EditorGUILayout.HelpBox("Your Tile Count Should Be 3 Or Multiples.", MessageType.Error);
            }
        }

        private void DrawMainButtons(LevelEditor levelEditor)
        {
            DrawRegularButtons(levelEditor);
            DrawTileSelectionButtons(levelEditor);
        }

        private static void DrawRegularButtons(LevelEditor levelEditor)
        {
            if (GUILayout.Button("Assign Tile")) levelEditor.AssignTile();
            if (GUILayout.Button("Create Tile")) levelEditor.CreateTile();
            if (GUILayout.Button("Remove All")) levelEditor.RemoveAllTiles();
            if (GUILayout.Button("Assign Tiles Procedurally")) levelEditor.GenerateProceduralTiles();
            if (GUILayout.Button("Save Level")) levelEditor.SaveLevel();

            IndexValue = EditorGUILayout.IntField("Selected Index", IndexValue);
            if (GUILayout.Button("Remove From Index")) levelEditor.RemoveWithIndex(IndexValue);
        
            if (GUILayout.Button("Get Out From Level Editor")) LevelEditorDisplayBox.Init();
        }

        private static void DrawTileSelectionButtons(LevelEditor levelEditor)
        {
            if (levelEditor.tiles.Count <= 0) return;
            GUILayout.BeginVertical();

            var buttonsPerRow = 10;
            var buttonCount = levelEditor.tiles.Count;

            for (var i = 0; i < buttonCount; i += buttonsPerRow)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(100);

                for (int j = 0; j < buttonsPerRow && i + j < buttonCount; j++)
                {
                    if (GUILayout.Button((i + j).ToString(), GUILayout.Width(30), GUILayout.Height(30)))
                        levelEditor.ChangeTile(levelEditor.tiles[i + j]);
                }

                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
        }

        private static void DrawTheArrowButtons(LevelEditor levelEditor)
        {
            GUILayout.FlexibleSpace();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            DrawButton("↑", delegate
            {
                levelEditor.MoveTile(Vector2.up);
                levelEditor.ReArrangeAllTiles();
            });

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();

            DrawButton("←", delegate
            {
                levelEditor.MoveTile(Vector2.left);
                levelEditor.ReArrangeAllTiles();
            });

            GUILayout.FlexibleSpace();
            DrawButton("→", delegate
            {
                levelEditor.MoveTile(Vector2.right);
                levelEditor.ReArrangeAllTiles();
            });


            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            DrawButton("↓", delegate
            {
                levelEditor.MoveTile(Vector2.down);
                levelEditor.ReArrangeAllTiles();
            });

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        private static void DrawButton(string label, Action action)
        {
            if (GUILayout.Button(label, GUILayout.Width(25), GUILayout.Height(25))) action?.Invoke();
        }
    }
}