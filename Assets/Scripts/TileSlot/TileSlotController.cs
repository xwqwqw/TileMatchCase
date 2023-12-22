using System;
using System.Collections.Generic;
using Managers;
using Tile.States;
using TKK.Optimization;
using UnityEngine;

namespace TKK.TileSlot
{
    public class TileSlotController : MonoBehaviour
    {
        [field: SerializeField] public SlotPositionAdjusterData SlotPositionAdjusterData { get; private set; }
        public List<Tile.Tile> currentTiles;
        public TileSlotPooler TileSlotPooler;
        private Transform _slotParent;
        private List<TileSlot> _tileSlots = new List<TileSlot>();

        private void Start()
        {
            InitializeComponents();
            ListenEvents();
        }

        private void ListenEvents()
        {
            Events.OnTileClicked.AddListener(GenerateNewTile);
            Events.OnCheckMatch.AddListener(CheckMatches);
            Events.OnCheckMatch.AddListener(CheckFail);
            Events.OnMatchComplete.AddListener(OnMatchComplete);
        }

        private void CheckFail()
        {
            if (currentTiles.Count <= 6) return;
            Events.OnGameOver.Invoke();
            foreach (var tileSlot in _tileSlots)
            {
                tileSlot.SetCurrentTileNull();
                OnMatchComplete(tileSlot);
            }
            _tileSlots.Clear();
            currentTiles.Clear();
        }

        private void OnMatchComplete(TileSlot tileSlot) => TileSlotPooler.ReleaseTileSlot(tileSlot);

        private void InitializeComponents() => _slotParent = transform;

        private void GenerateNewTile(Tile.Tile tile)
        {
            currentTiles.Add(tile);
            var targetSlot = TileSlotPooler.Get();
            var indexOfSlot = currentTiles.IndexOf(tile);

            targetSlot.transform.SetParent(_slotParent);
            targetSlot.transform.localPosition = Vector3.zero;

            _tileSlots.Add(targetSlot);
            targetSlot.SetSlot(tile, indexOfSlot);
            ReorderTileIndexesByType();
            ReorderAllTilePositions();
        }

        private void ReorderTileIndexesByType()
        {
            Dictionary<int, List<Tile.Tile>> tileTypeGroups = new Dictionary<int, List<Tile.Tile>>();

            foreach (var tile in currentTiles)
            {
                var tileType = (int)tile.TileType;
                if (!tileTypeGroups.ContainsKey(tileType))
                {
                    tileTypeGroups[tileType] = new List<Tile.Tile>();
                }

                tileTypeGroups[tileType].Add(tile);
            }

            var currentIndex = 0;
            foreach (var tileTypeGroup in tileTypeGroups.Values)
            {
                foreach (var tile in tileTypeGroup)
                {
                    tile.CurrentTileSlot.CurrentIndex = currentIndex++;
                }
            }
        }

        private void ReorderAllTilePositions()
        {
            foreach (var tileSlot in _tileSlots)
            {
                tileSlot.SetSlotPositionAnimated();
            }
        }

        private void CheckMatches()
        {
            Dictionary<int, List<Tile.Tile>> tileTypeGroups = new Dictionary<int, List<Tile.Tile>>();

            foreach (var tile in currentTiles)
            {
                var tileType = (int)tile.TileType;
                if (!tileTypeGroups.ContainsKey(tileType))
                {
                    tileTypeGroups[tileType] = new List<Tile.Tile>();
                }

                tileTypeGroups[tileType].Add(tile);
            }

            foreach (var tileTypeGroup in tileTypeGroups.Values)
            {
                if (tileTypeGroup.Count >= 3)
                {
                    PerformMatch(tileTypeGroup);
                }
            }
        }

        private void PerformMatch(List<Tile.Tile> matchedTiles)
        {
            foreach (var tile in matchedTiles)
            {
                currentTiles.Remove(tile);
                tile.ChangeState<TileMatchedState>();
            }

            ReorderTileIndexesByType();
            ReorderAllTilePositions();
            CheckFail();
        }
    }
}