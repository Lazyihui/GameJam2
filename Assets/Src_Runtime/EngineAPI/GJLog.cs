using UnityEngine;

namespace GJ {

    public static class GJLog {

        // 默认样式配置
        public static Color defaultColor = Color.white;
        public static bool defaultBold = true;

        public static void Log(object msg) {
            string formattedMsg = FormatMessage(msg?.ToString(), defaultColor, defaultBold);
            Debug.Log($"[GJ_LOG]{formattedMsg}");
        }

        public static void LogTodo(object msg) {
            string formattedMsg = FormatMessage(msg?.ToString(), Color.yellow, true);
            Debug.Log($"[GJ_TODO]{formattedMsg}");
        }

        public static void LogLazy(object msg) {
            string formattedMsg = FormatMessage(msg?.ToString(), Color.cyan, true);
            Debug.Log($"[GJ_LAZY]{formattedMsg}");
        }

        public static void LogJacket(object msg) {
            string formattedMsg = FormatMessage(msg?.ToString(), Color.magenta, true);
            Debug.Log($"[GJ_JACKET]{formattedMsg}");
        }

        public static void Warning(object msg) {
            Debug.LogWarning(msg);
        }

        public static void Error(object msg) {
            Debug.LogError(msg);
        }

        public static void Assert(bool condition, object msg) {
            Debug.Assert(condition, msg);
        }

        private static string FormatMessage(string message, Color color, bool bold) {
            string colorHex = ColorUtility.ToHtmlStringRGB(color);
            string boldTag = bold ? "<b>" : "";
            string boldEndTag = bold ? "</b>" : "";

            return $"{boldTag}<color=#{colorHex}>{message}</color>{boldEndTag}";
        }
    }
}