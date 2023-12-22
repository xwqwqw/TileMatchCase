using System;
using System.Collections.Generic;
using System.Linq;

namespace TKK.Tile.Base
{
    public class BaseTileStatePool
    {
        private Dictionary<Type, BaseTileState> _states = new Dictionary<Type, BaseTileState>();

        public void InitializeStatePool(Tile tile)
        {
            var stateTypes = typeof(BaseTileState).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(BaseTileState)));

            foreach (var stateType in stateTypes)
            {
                var stateInstance = Activator.CreateInstance(stateType, tile) as BaseTileState;
                stateInstance.Tile = tile;
                AddStateToDictionary(stateInstance);
            }
        }

        private void AddStateToDictionary(BaseTileState state)
        {
            var stateType = state.GetType();

            if (!_states.ContainsKey(stateType))
            {
                _states.Add(stateType, state);
            }
        }

        public T GetState<T>() where T : BaseTileState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                return (T)_states[typeof(T)];
            }

            return null;
        }
    }
}