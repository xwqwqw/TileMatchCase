using Constants;
using Interface;
using Tile.Base;
using Tile.States;
using TKK.TileSlot;
using UnityEngine;

namespace Tile
{
    [SelectionBase]
    public class Tile : MonoBehaviour
    {
        public TileType TileType;
        public SortingLayerOrder sortingLayerOrder;
        public TileCollisionHandler TileCollisionHandler => GetComponentInChildren<TileCollisionHandler>();
        public TileInputHandling TileInputHandling => GetComponentInChildren<TileInputHandling>();

        private IState _currentState;

        public IState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        private int _sortingOrder;

        public int SortingOrder
        {
            get => _sortingOrder;
            set
            {
                _sortingOrder = value;
                tileBackGround.sortingOrder = value;
                tileIcon.sortingOrder = value + 1;
                tileShadow.sortingOrder = value + 2;
            }
        }

        private BaseTileStatePool BaseTileStatePool
        {
            get
            {
                var baseTileStatePool = new BaseTileStatePool();
                baseTileStatePool.InitializeStatePool(this);
                return baseTileStatePool;
            }
        }

        [SerializeField] private SpriteRenderer tileBackGround;
        [SerializeField] private SpriteRenderer tileIcon;
        [SerializeField] private SpriteRenderer tileShadow;

        public SpriteRenderer TileBackgroundRenderer
        {
            get => tileBackGround;
            private set => tileBackGround = value;
        }

        public SpriteRenderer TileIconRenderer
        {
            get => tileIcon;
            private set => tileIcon = value;
        }

        public SpriteRenderer TileShadowRenderer
        {
            get => tileShadow;
            private set => tileShadow = value;
        }

        private TileSlot _currentTileSlot;

        public TileSlot CurrentTileSlot
        {
            get => _currentTileSlot;
            set => _currentTileSlot = value;
        }

        private void Start() => InitializeTile();

        private void InitializeTile()
        {
            CurrentState = BaseTileStatePool.GetState<TileHoverState>();
            CurrentState.OnEnter();
        }

        private void Update() => CurrentState?.OnUpdate();

        public void ChangeState<T>() where T : BaseTileState
        {
            CurrentState.OnExit();
            CurrentState = BaseTileStatePool.GetState<T>();
            CurrentState.OnEnter();
        }

        public void AssignTileInGame(TileType tileType, Sprite iconSprite
            , int index, SortingLayerOrder sortingLayerId = SortingLayerOrder.Default)
        {
            tileIcon.sprite = iconSprite;
            TileType = tileType;
            SortingOrder = index;

            if (sortingLayerId == SortingLayerOrder.Default) return;
            sortingLayerOrder = sortingLayerId;

            tileIcon.sortingLayerID = SortingLayer.NameToID(sortingLayerOrder.ToString());
            tileShadow.sortingLayerID = SortingLayer.NameToID(sortingLayerOrder.ToString());
            tileBackGround.sortingLayerID = SortingLayer.NameToID(sortingLayerOrder.ToString());
        }

        #region ForEditor

#if UNITY_EDITOR

        public bool isSelectedTile;
        public int tileIndex;

        private void OnDrawGizmos()
        {
            if (Application.isPlaying) return;
            Gizmos.color = Color.red;
            if (isSelectedTile) Gizmos.DrawWireCube(transform.position, transform.localScale * 2);
            var style = new GUIStyle
            {
                fontSize = 25,
                normal =
                {
                    textColor = Color.black
                }
            };
            var position = transform.position + Vector3.up * .5f + Vector3.left * .35f;
            UnityEditor.Handles.Label(position, tileIndex.ToString(), style);
        }

        public void AssignTileValue(TileType tileType, Sprite iconSprite,
            SortingLayerOrder sortingLayerId = SortingLayerOrder.Default)
        {
            tileIcon.sprite = iconSprite;
            TileType = tileType;
            if (sortingLayerId == SortingLayerOrder.Default) return;
            sortingLayerOrder = sortingLayerId;

            tileIcon.sortingLayerID = SortingLayer.NameToID(sortingLayerOrder.ToString());
            tileShadow.sortingLayerID = SortingLayer.NameToID(sortingLayerOrder.ToString());
            tileBackGround.sortingLayerID = SortingLayer.NameToID(sortingLayerOrder.ToString());
        }
#endif

        #endregion
    }
}