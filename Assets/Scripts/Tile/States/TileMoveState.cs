using DG.Tweening;
using TKK.Managers;
using TKK.Tile.Base;
using UnityEngine;

namespace TKK.Tile.States
{
    public class TileMoveState : BaseTileState
    {
        private Sequence _slotMovementSequence;

        public override void OnEnter()
        {
            Tile.TileCollisionHandler.BoxCollider2D.enabled = false;
            MakeTileChildOfSlotAndStartMovement();
        }


        public override void OnUpdate()
        {
        }

        public override void OnExit()
        {
        }

        public override void OnReset()
        {
        }

        private void MakeTileChildOfSlotAndStartMovement()
        {
            MakeChild();
            StartMovement();
        }

        private void MakeChild()
        {
            Tile.transform.parent = Tile.CurrentTileSlot.transform;
        }

        private void OnMovementCompleted()
        {
            Tile.SortingOrder = Tile.CurrentTileSlot.CurrentIndex;
            Events.OnCheckMatch.Invoke();
            Tile.TileShadowRenderer.gameObject.SetActive(false);
        }

        private void StartMovement()
        {
            DOTween.Kill(Tile.transform);
            _slotMovementSequence = DOTween.Sequence();
            _slotMovementSequence.Insert(0f, Tile.transform.DOScale(Vector3.one, .25f));
            _slotMovementSequence.Insert(0f, Tile.transform.DOLocalMove(Vector3.zero, .5f))
                .SetEase(Ease.OutQuad);
            _slotMovementSequence
                .Insert(0f, Tile.transform.DOLocalRotate(new Vector3(0f, 0f, Random.Range(10f, 35f)), 0.25f))
                .SetEase(Ease.OutQuad);
            _slotMovementSequence.Insert(0.25f, Tile.transform.DOLocalRotate(Vector3.zero, 0.1f));
            _slotMovementSequence.OnComplete(OnMovementCompleted);
        }
    }
}