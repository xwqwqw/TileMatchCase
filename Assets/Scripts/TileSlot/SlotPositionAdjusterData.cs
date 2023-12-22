using UnityEngine;

namespace TKK.TileSlot
{
    [CreateAssetMenu(menuName = "TileSlot/SlotPositionData", fileName = "SlotPositionAdjusterData")]
    public class SlotPositionAdjusterData : ScriptableObject
    {
        [field: SerializeField] public float StartingXPos { get; private set; }
        [field: SerializeField] public float IncrementalXPos { get; private set; }
    }
}