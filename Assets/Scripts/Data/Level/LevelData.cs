﻿using System.Collections.Generic;
using TKK.Tile.Data;
using UnityEngine;

namespace TKK.Data.Level
{
    public class LevelData : ScriptableObject
    {
        [field:SerializeField] public Sprite LevelViewData { get; private set; }
        [field: SerializeField] public LevelCurrencyData LevelCurrencyData { get; private set; }
        [field: SerializeField] public List<TileData> TileDatas { get; private set; } = new List<TileData>();
        public void GenerateTileData(List<TileData> tileDatas) => TileDatas = new List<TileData>(tileDatas);
    }
}