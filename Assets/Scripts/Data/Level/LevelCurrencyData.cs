using UnityEngine;

namespace TKK.Data.Level
{
    [System.Serializable]

    public struct LevelCurrencyData
    {
        [field: SerializeField] public int TotalEarnedCoinAmount { get; private set; }
    }
}