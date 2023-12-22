using UnityEngine;

namespace TKK.Data.Art
{
    [CreateAssetMenu(menuName = "AudioData/Audios")]
    public class AudioData : ScriptableObject
    {
        [field: SerializeField] public AudioClip MusicClip { get; private set; }
        [field: SerializeField] public AudioClip ButtonClick { get; private set; }
        [field: SerializeField] public AudioClip TileClip { get; private set; }
    }
}