using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TKK.Utility
{
    public static class CheckOverUI
    {
        public static bool IsOverUI()
        {
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }    
    }
}