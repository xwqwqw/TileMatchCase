using UnityEditor;
using UnityEngine;
using HeaderAttribute = Utility.HeaderAttribute;

namespace TKK.Editor
{
    [CustomPropertyDrawer(typeof(HeaderAttribute))]
    public class HeaderDrawer : DecoratorDrawer
    {
        #region Overrides of DecoratorDrawer

        public override void OnGUI(Rect position)
        {
            if (!(attribute is HeaderAttribute headerAttribute)) return;
            position = EditorGUI.IndentedRect(position);
            position.yMin += EditorGUIUtility.singleLineHeight * (headerAttribute.textHeightIncrease-0.5f);

            GUIStyle style = new GUIStyle(EditorStyles.label) { richText = true };
            GUIContent label = new GUIContent(
                $"<color={headerAttribute.colorString}><size={style.fontSize + headerAttribute.textHeightIncrease}><b>{headerAttribute.header}</b></size></color>");

            Vector2 textSize = style.CalcSize(label);
            float seperatorWidth = (position.width - textSize.x) / 2.0f;

            Rect prefixRect = new Rect(position.xMin - 5, position.yMin+3f,
                seperatorWidth, headerAttribute.textHeightIncrease);
            Rect labelRect = new Rect(position.xMin + seperatorWidth, position.yMin-3f, textSize.x, position.height);
            Rect postRect = new Rect(position.xMin + seperatorWidth + 5f + textSize.x,
                position.yMin+3f, seperatorWidth, headerAttribute.textHeightIncrease);
            EditorGUI.DrawRect(prefixRect,headerAttribute.color);
            EditorGUI.LabelField(labelRect,label,style);
            EditorGUI.DrawRect(postRect,headerAttribute.color);


        }

        public override float GetHeight()
        {
            HeaderAttribute headerAttribute=attribute as HeaderAttribute;
            return EditorGUIUtility.singleLineHeight * (headerAttribute?.textHeightIncrease + 0.5f ?? 0);
        }

        #endregion
    }
}