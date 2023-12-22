using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Utility
{
    public static class TKKDebug
    {
        #region Variables

        public static int FontSize = 12;

        #endregion

        public static void Log(
            object message, string color = TKKColors.COLOR_BLUE, DEBUGMODE debugmode = DEBUGMODE.RELEASE,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            color ??= TKKColors.COLOR_BLUE;
            if (PlayerPrefs.GetInt("DebugMode", 0) == (int)DEBUGMODE.RELEASE && debugmode == DEBUGMODE.RELEASE ||
                PlayerPrefs.GetInt("DebugMode", 0) == (int)DEBUGMODE.VERBOSE && debugmode == DEBUGMODE.RELEASE)
            {
                Debug.Log(
                    ApplyStyles(color,
                        FormatCallerAttributes(sourceFilePath, memberName, sourceLineNumber),
                        message));
            }

            if (PlayerPrefs.GetInt("DebugMode", 0) == (int)DEBUGMODE.VERBOSE && debugmode == DEBUGMODE.VERBOSE)
            {
                Debug.Log(
                    ApplyStyles(color,
                        FormatCallerAttributes(sourceFilePath, memberName, sourceLineNumber),
                        message));
            }
        }

        public static void Warn(
            object message, string color = TKKColors.COLOR_WARN,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.LogWarning(
                ApplyStyles(color,
                    FormatCallerAttributes(sourceFilePath, memberName, sourceLineNumber),
                    message
                ));
        }

        public static void Error(
            object message, string color = TKKColors.COLOR_ERROR,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.LogError(
                ApplyStyles(color,
                    FormatCallerAttributes(sourceFilePath, memberName, sourceLineNumber),
                    message
                ));
        }

        public static void Break(
            object message, string color = TKKColors.COLOR_ERROR,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Debug.LogError(
                ApplyStyles(color,
                    FormatCallerAttributes(sourceFilePath, memberName, sourceLineNumber),
                    message
                ));
#if UNITY_EDITOR
            EditorApplication.isPaused = true;
#endif
        }


        private static object ApplyStyles(string color, string context, object message)
        {
            object log =
                "<size=" + FontSize + ">"
                + "<color=" + color + ">"
                + "<b>[" + context + "]</b>: "
                + message
                + "</color>"
                + "</size>";

            return log;
        }

        private static string FormatCallerAttributes(string path, string member, int line)
            =>   Path.GetFileNameWithoutExtension(path) + ":" + member + ":" + line;
    
    }
}