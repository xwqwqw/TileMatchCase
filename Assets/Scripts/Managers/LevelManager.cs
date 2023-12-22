using System.Collections.Generic;
using Data.Art;
using Data.Level;
using Tile.Data;
using TKK.Managers.GameManagerStates;
using TKK.Optimization;
using UnityEngine;
using Utility;

namespace Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        [field: SerializeField] public LevelConfig LevelConfig { get; private set; }
        [SerializeField] private Transform poolParents;
        public List<Tile.Tile> currentTiles;

        public TilePooler TilePooler;
        private int _targetLevel => GameManager.Instance.LevelNumberToBuildLevel;

        private void Start()
        {
            ListenEvents();
        }

        private void ListenEvents()
        {
            Events.OnCheckGameOver.AddListener(CheckTileCountForGameWin);
        }

        private bool GameOver => currentTiles.Count <= 0;

        private void CheckTileCountForGameWin()
        {
            if (!GameOver) return;
            GameManager.Instance.ChangeState<GameManagerWinState>();
        }

        public void DespawnTile(Tile.Tile tile)
        {
            currentTiles.Remove(tile);
            TilePooler.ReleaseTile(tile);
        }

        private void DemolishLevel()
        {
            foreach (var tile in currentTiles)
            {
                TilePooler.ReleaseTile(tile);
            }

            currentTiles.Clear();
        }

        public void BuildLevel() => InstantiateTilesFromLevelData(LevelConfig.GameLevels[_targetLevel]);

        private void InstantiateTilesFromLevelData(LevelData levelData)
        {
            foreach (var tileData in levelData.TileDatas)
            {
                var targetTile = TilePooler.GetTile();
                targetTile.transform.SetParent(poolParents);
                AssignTile(targetTile, tileData);
                currentTiles.Add(targetTile);
            }
        }

        private static void AssignTile(Tile.Tile targetTile, TileData tileData)
        {
            var targetSprite = DataManager<IconSpriteData>.Data.SpriteDataForIcons[(int)tileData.TileType]
                .SpriteIcon;

            targetTile.AssignTileInGame(tileData.TileType, targetSprite, tileData.SortingOrderIndex,
                tileData.SortingLayerOrder);
            targetTile.transform.position = tileData.TilePosition;
        }
    }
}