using UnityEditor;
using UnityEditor.Overlays;

namespace TKK.Editor
{
    [Overlay(typeof(SceneView), "LevelButton")]
    public class ToolbarOverlay : UnityEditor.Overlays.ToolbarOverlay
    {
        public ToolbarOverlay() : base(ToolbarButton.id,ToolbarButton2.id2)
        {
        
        }
    }
}