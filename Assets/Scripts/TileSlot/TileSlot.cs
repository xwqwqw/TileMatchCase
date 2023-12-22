using DG.Tweening;
using Managers;
using Tile.States;
using UnityEngine;

namespace TKK.TileSlot
{
    public class TileSlot : MonoBehaviour
    {
        private Tile.Tile _currentTile;
        private int _currentIndex;
        
        public int CurrentIndex
        {
            get => _currentIndex;
            set => _currentIndex = value;
        }

        public void SetCurrentTileNull()
        {
            _currentTile = null;
        }

        private TileSlotController _tileSlotController => GameManager.Instance.TileSlotController;

        public void SetSlot(Tile.Tile tile,int index)
        {
            CurrentIndex = index;
            _currentTile = tile;
            SetSlotPosition();
            _currentTile.CurrentTileSlot = this;
            _currentTile.ChangeState<TileMoveState>();
        }

        public void SetSlotPosition()
        {
            var multiplier = _tileSlotController.SlotPositionAdjusterData.IncrementalXPos * CurrentIndex;
            var xPos = _tileSlotController.SlotPositionAdjusterData.StartingXPos + multiplier;
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        public void SetSlotPositionAnimated()
        {
            var multiplier = _tileSlotController.SlotPositionAdjusterData.IncrementalXPos * CurrentIndex;
            var xPos = _tileSlotController.SlotPositionAdjusterData.StartingXPos + multiplier;
            transform.DOMoveX(xPos,.25f);
        }
    }
}