using DG.Tweening;
using Managers;
using Tile.Base;
using UnityEngine;

namespace Tile.States
{
    public class TileMatchedState : BaseTileState
    {
        private Sequence _matchMovementSequence;

        public override void OnEnter()
        {
            StartObjectAnimation();
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

        private void StartObjectAnimation()
        {
            DOTween.Kill(Tile.transform);
            _matchMovementSequence = DOTween.Sequence();

            _matchMovementSequence.Insert(0f,
                    Tile.transform.DOLocalRotate(new Vector3(0f, 0f, Random.Range(10f, 35f)), 0.25f))
                .SetEase(Ease.OutQuad);
            _matchMovementSequence.Insert(0f, Tile.transform.DOLocalMoveY(Tile.transform.position.y + 2f, 0.5f))
                .SetEase(Ease.OutQuad);
            _matchMovementSequence.Insert(0.5f, Tile.transform.DOLocalMoveY(Tile.transform.position.y - 10f, 0.5f))
                .SetEase(Ease.InQuad);
            _matchMovementSequence.Insert(0.25f, Tile.transform.DOLocalRotate(Vector3.zero, 0.1f));
            _matchMovementSequence.OnComplete(OnMovementCompleted);
        }

        private void OnMovementCompleted()
        {
            SendObjectToPool();
            CallGameEvent();
        }

        private void CallGameEvent()
        {
            Events.OnMatchComplete.Invoke(Tile.CurrentTileSlot);
            Events.OnCheckGameOver.Invoke();
        }

        private void SendObjectToPool() => LevelManager.Instance.DespawnTile(Tile);
    }
}