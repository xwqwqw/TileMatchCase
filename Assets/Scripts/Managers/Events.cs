using TKK.TileSlot;

namespace Managers
{
    public static class Events
    {
        public static readonly CustomEvent OnFakeLoading = new CustomEvent();
        
        public static readonly CustomEvent<int> OnGameStart = new CustomEvent<int>();
        public static readonly CustomEvent OnCheckGameOver = new CustomEvent();
        public static readonly CustomEvent OnGameOver = new CustomEvent();
        
        public static readonly CustomEvent OnLevelStart = new CustomEvent();
        public static readonly CustomEvent OnLevelEnd = new CustomEvent();
    
        
        // TileEvents

        public static readonly CustomEvent<Tile.Tile> OnTileClicked = new CustomEvent<Tile.Tile>();
        public static readonly CustomEvent OnCheckMatch = new CustomEvent();
        public static readonly CustomEvent<TileSlot> OnMatchComplete = new CustomEvent<TileSlot>();

    }
}