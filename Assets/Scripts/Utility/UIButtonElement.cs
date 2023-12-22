using UnityEngine;
using UnityEngine.Events;

namespace TKK.Utility
{
    public class UIButtonElement : MonoBehaviour
    {
        public UnityEvent OnClick;
        public void InvokeOnClick()
        { OnClick?.Invoke();
        }
    }
}