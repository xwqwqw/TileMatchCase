using UnityEngine;

namespace Utility
{
    [System.AttributeUsage(System.AttributeTargets.Field,AllowMultiple = true)]
    public class HeaderAttribute : PropertyAttribute
    {
        public readonly string header;
        public readonly string colorString;
        public readonly Color color;
        public readonly float textHeightIncrease;
    
        public HeaderAttribute(string header,string colorString) : this(header,1,colorString){ }
    

        public HeaderAttribute(string header,float textHeightIncrease=1 ,string colorString="magenta")
        {
            this.header = header;
            this.colorString = colorString;

            this.textHeightIncrease = Mathf.Max(1, textHeightIncrease);
            if (ColorUtility.TryParseHtmlString(colorString, out this.color)) return;

            color = Color.magenta;
            this.colorString = "magenta";
        }
    }
}
