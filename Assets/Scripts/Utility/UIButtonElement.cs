using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class UIButtonElement : MonoBehaviour
    {
        public UnityEvent OnClick;
        public void InvokeOnClick()
        { OnClick?.Invoke();
        }
    }
}