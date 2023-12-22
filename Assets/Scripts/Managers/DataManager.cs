using UnityEngine;

namespace TKK.Managers
{
    public abstract class DataManager<T> where T : ScriptableObject
    {
        private static T _data;
        public static T Data
        {
            get
            {
                if (_data != null) return _data;
                _data = Resources.Load<T>(Path);
                if (_data == null) Debug.LogError($"You should create a {typeof(T).Name} data.");
                return _data;
            }
        }
        private static string Path => typeof(T).Name;
    }
}