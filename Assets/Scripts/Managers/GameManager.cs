using DG.Tweening;
using Interface;
using TKK.Managers.GameManagerStates;
using TKK.Managers.GameManagerStates.Base;
using TKK.TileSlot;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [field: SerializeField] public TileSlotController TileSlotController { get; private set; }

        private BaseGameManagerStatePool BaseGameManagerStatePool
        {
            get
            {
                var baseGameManagerStatePool = new BaseGameManagerStatePool();
                baseGameManagerStatePool.InitializeStatePool(this);
                return baseGameManagerStatePool;
            }
        }

        private IState _currentState;

        public IState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        public int LevelNumberToBuildLevel
        {
            get => PlayerPrefs.GetInt("LevelNumberToBuildLevel", 0);
            set =>
                PlayerPrefs.SetInt("LevelNumberToBuildLevel",
                    value == LevelManager.Instance.LevelConfig.GameLevels.Count ? 0 : value);
        }

        public int LevelNumberToDisplayLevel
        {
            get => PlayerPrefs.GetInt("LevelNumberToDisplayLevel", 0);
            set => PlayerPrefs.SetInt("LevelNumberToDisplayLevel", value);
        }

        private void Start()
        {
            SetDevice();
            IncreaseTweenCapacity();
            InitializeGameManager();
        }

        private void Update() => CurrentState?.OnUpdate();
        private static void IncreaseTweenCapacity() => DOTween.SetTweensCapacity(2000, 500);
        private void SetDevice() => Application.targetFrameRate = 60;

        private void InitializeGameManager()
        {
            CurrentState = BaseGameManagerStatePool.GetState<GameManagerGamePlayState>();
            CurrentState.OnEnter();
        }

        public void ChangeState<T>() where T : BaseGameManagerState
        {
            CurrentState.OnExit();
            CurrentState = BaseGameManagerStatePool.GetState<T>();
            CurrentState.OnEnter();
        }
    }
}