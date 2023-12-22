using UnityEngine;

namespace TKK.Managers
{
    public static class Events
    {
        public static readonly CustomEvent OnFakeLoading = new CustomEvent();

        public static readonly CustomEvent<int> OnGameStart = new CustomEvent<int>();
        public static readonly CustomEvent OnCheckGameOver = new CustomEvent();
        public static readonly CustomEvent OnGameOver = new CustomEvent();

        public static readonly CustomEvent OnLevelStart = new CustomEvent();
        public static readonly CustomEvent OnLevelEnd = new CustomEvent();

        public static readonly CustomEvent<int> OnCoinUpdated = new CustomEvent<int>();
        // TileEvents

        public static readonly CustomEvent<Tile.Tile> OnTileClicked = new CustomEvent<Tile.Tile>();
        public static readonly CustomEvent OnCheckMatch = new CustomEvent();
        public static readonly CustomEvent<TileSlot.TileSlot> OnMatchComplete = new CustomEvent<TileSlot.TileSlot>();

        public static readonly CustomEvent<AudioClip> OnPlaySoundSfx = new CustomEvent<AudioClip>();
        public static readonly CustomEvent<AudioClip> OnPlaySoundMusic = new CustomEvent<AudioClip>();
        public static readonly CustomEvent<bool> OnSfxSettingsChanged = new CustomEvent<bool>();
        public static readonly CustomEvent<bool> OnMusicSettingsChanged = new CustomEvent<bool>();
    }
}