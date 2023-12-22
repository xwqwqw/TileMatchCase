﻿using System.Collections.Generic;
using Tile.Data;
using UnityEngine;

namespace Data.Level
{
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public List<TileData> TileDatas { get; private set; } = new List<TileData>();
        public void GenerateTileData(List<TileData> tileDatas) => TileDatas = new List<TileData>(tileDatas);
    }
}