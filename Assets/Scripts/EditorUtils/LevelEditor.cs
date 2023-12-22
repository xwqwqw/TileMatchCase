#if UNITY_EDITOR

using System.Collections.Generic;
using Constants;
using Data.Art;
using Data.Level;
using Managers;
using Tile.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EditorUtils
{
    public class LevelEditor : MonoBehaviour
    {
        [HideInInspector] public List<Tile.Tile> tiles = new List<Tile.Tile>();

        public TileType currentTileType;
        public SortingLayerOrder currentSortingLayerOrder;
        public List<TileType> proceduralTypes;

        private Tile.Tile _cachedTile;
        public Tile.Tile CachedTile => _cachedTile;

        public void MoveTile(Vector2 direction) =>
            _cachedTile.transform.position += new Vector3(direction.x, direction.y);

        public void AssignTile()
        {
            var targetSprite = DataManager<IconSpriteData>.Data.SpriteDataForIcons[(int)currentTileType];
            _cachedTile.AssignTileValue(currentTileType, targetSprite.SpriteIcon, currentSortingLayerOrder);
        }

        public void CreateTile()
        {
            var targetObject = DataManager<LevelConfig>.Data.TilePrefab;
            var position = _cachedTile ? _cachedTile.transform.position : Vector3.zero;
            var instance = Instantiate(targetObject, position, Quaternion.identity);

            tiles.Add(instance);
            ChangeTile(instance);
            AssignTile();
        }

        public void ChangeTile(Tile.Tile tile)
        {
            if (_cachedTile != null) _cachedTile.isSelectedTile = false;
            _cachedTile = tile;
            _cachedTile.isSelectedTile = true;
        }

        public void RemoveAllTiles()
        {
            foreach (var tile in tiles) DestroyImmediate(tile.gameObject);
            tiles.Clear();
        }

        public void ReArrangeAllTiles()
        {
            foreach (var tile in tiles)
            {
                tile.tileIndex = tiles.IndexOf(tile);
            }

            tiles.Sort((tile1, tile2) =>
            {
                var yDifference = Mathf.Abs(tile2.transform.position.y - tile1.transform.position.y);

                return yDifference >= 1.25f
                    ? tile2.transform.position.y.CompareTo(tile1.transform.position.y)
                    : tile1.transform.position.x.CompareTo(tile2.transform.position.x);
            });

            for (var i = 0; i < tiles.Count; i++)
            {
                tiles[i].SortingOrder = i + 1;
            }
        }

        public void FetchData(List<TileData> tileDatas)
        {
            if (tileDatas == null) return;
        
            RemoveAllTiles(); 

            foreach (var tileData in tileDatas)
            {
                var position = tileData.TilePosition;
                var tileType = tileData.TileType;
                var sortingLayerOrder = tileData.SortingLayerOrder;
                var sortingOrderIndex = tileData.SortingOrderIndex;

                var instance = Instantiate(DataManager<LevelConfig>.Data.TilePrefab, position, Quaternion.identity);
                var tileComponent = instance.GetComponent<Tile.Tile>();

                tileComponent.AssignTileValue(tileType,
                    DataManager<IconSpriteData>.Data.SpriteDataForIcons[(int)tileType].SpriteIcon, sortingLayerOrder);
                tileComponent.SortingOrder = sortingOrderIndex;

                tiles.Add(tileComponent);
            }
        }

        public void SaveLevel()
        {
            DataManager<LevelConfig>.Data.CreateLevel(GenerateTileDataValues());
        }

        private List<TileData> GenerateTileDataValues()
        {
            var tileDataList = new List<TileData>();

            foreach (var tile in tiles)
            {
                var tileData = new TileData
                {
                    TilePosition = tile.transform.position,
                    TileType = tile.TileType,
                    SortingLayerOrder = tile.sortingLayerOrder,
                    SortingOrderIndex = tile.SortingOrder
                };

                tileDataList.Add(tileData);
            }

            return tileDataList;
        }

        public void RemoveWithIndex(int index)
        {
            if (tiles.Count <= index) return;
            DestroyImmediate(tiles[index].gameObject);
            tiles.Remove(tiles[index]);
        }

        public void GetOutFromLevelEditor()
        {
            DestroyImmediate(gameObject);
            RemoveAllTiles();
        }

        #region ProceduralTileAssign

        public void GenerateProceduralTiles()
        {
            var requiredTileCount = 3;
            var allowedTypeCount = tiles.Count / requiredTileCount;

            if (tiles.Count % requiredTileCount != 0 || allowedTypeCount <= 0) return;

            var selectedTypes = GetRandomTileTypes(allowedTypeCount);

            var remainingTileTypes = new List<TileType>();

            foreach (var tileType in selectedTypes)
            {
                for (var i = 0; i < requiredTileCount; i++)
                {
                    remainingTileTypes.Add(tileType);
                }
            }

            remainingTileTypes.Sort((x, y) => Random.Range(-1, 2));

            for (var i = 0; i < tiles.Count; i++)
            {
                var remainingTileType = remainingTileTypes[i % remainingTileTypes.Count];
                AssignProceduralTileType(tiles[i], remainingTileType);
            }
        }

        private List<TileType> GetRandomTileTypes(int count)
        {
            var selectedTypes = new List<TileType>();
            var allTypes = new List<TileType>(proceduralTypes);

            if (allTypes.Count * 3 < tiles.Count)
            {
                allTypes.AddRange(proceduralTypes);
            }

            for (var i = 0; i < count; i++)
            {
                if (allTypes.Count == 0)
                {
                    break;
                }

                var randomIndex = Random.Range(0, allTypes.Count);
                var selectedType = allTypes[randomIndex];
                allTypes.RemoveAt(randomIndex);
                selectedTypes.Add(selectedType);
            }

            return selectedTypes;
        }

        private void AssignProceduralTileType(Tile.Tile tile, TileType tileType)
        {
            var targetSprite = DataManager<IconSpriteData>.Data.SpriteDataForIcons[(int)tileType];
            tile.AssignTileValue(tileType, targetSprite.SpriteIcon);
        }

        #endregion
    }
}
#endif
