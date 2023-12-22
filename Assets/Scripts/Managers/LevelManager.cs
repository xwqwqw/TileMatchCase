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
        [field: SerializeField] public LevelData CurrentLevelData { get; private set; }
        [field: SerializeField] public LevelConfig LevelConfig { get; private set; }

        [SerializeField] private Transform poolParents;
        [SerializeField] private SpriteRenderer backgroundView;

        public List<Tile.Tile> currentTiles;

        public TilePooler TilePooler;
        private int _targetLevel => GameManager.Instance.LevelNumberToBuildLevel;
        private int _targetViewLevel => GameManager.Instance.LevelNumberToDisplayLevel;

        private void Awake()
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

        public void DemolishLevel()
        {
            if (currentTiles.Count <= 0) return;
            foreach (var tile in currentTiles)
            {
                TilePooler.ReleaseTile(tile);
            }

            currentTiles.Clear();
        }

        public void BuildLevel()
        {
            AssignViewAndText(LevelConfig.GameLevels[_targetLevel]);
            InstantiateTilesFromLevelData(LevelConfig.GameLevels[_targetLevel]);
            UIManager.Instance.SetLevelHeader();
        }

        private void AssignViewAndText(LevelData levelData)
        {
            if (levelData.LevelViewData == null) return;
            backgroundView.sprite = levelData.LevelViewData;
        }

        private void InstantiateTilesFromLevelData(LevelData levelData)
        {
            CurrentLevelData = levelData;
            foreach (var tileData in levelData.TileDatas)
            {
                var targetTile = TilePooler.GetTile();
                targetTile.transform.SetParent(poolParents);
                AssignTile(targetTile, tileData);
                currentTiles.Add(targetTile);
                TileReset(targetTile);
            }
        }

        private void TileReset(Tile.Tile targetTile)
        {
            targetTile.CurrentTileSlot = null;
            targetTile.TileCollisionHandler.BoxCollider2D.enabled = true;
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