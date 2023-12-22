using System;
using System.Collections.Generic;
using System.Linq;
using Managers;

namespace TKK.Managers.GameManagerStates.Base
{
    public class BaseGameManagerStatePool
    {
        private Dictionary<Type, BaseGameManagerState> _states = new Dictionary<Type, BaseGameManagerState>();

        public void InitializeStatePool(GameManager gameManager)
        {
            var stateTypes = typeof(BaseGameManagerState).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseGameManagerState)));

            foreach (var stateType in stateTypes)
            {
                var stateInstance = Activator.CreateInstance(stateType) as BaseGameManagerState;
                stateInstance.GameManager = gameManager;
                AddStateToDictionary(stateInstance);
            }
        }

        private void AddStateToDictionary(BaseGameManagerState state)
        {
            var stateType = state.GetType();

            if (!_states.ContainsKey(stateType))
            {
                _states.Add(stateType, state);
            }
        }

        public T GetState<T>() where T : BaseGameManagerState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                return (T)_states[typeof(T)];
            }

            return null;
        }
    }
}