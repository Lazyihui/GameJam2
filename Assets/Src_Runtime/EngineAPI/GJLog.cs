using UnityEngine;
using System.Collections.Generic;

namespace GJ {

    public static class GJLog {

        // 日志类型配置
        public static Dictionary<LogType, (Color color, bool bold)> logTypeConfigs = new Dictionary<LogType, (Color, bool)> {
            { LogType.Normal, (Color.white, true) },
            { LogType.Todo, (Color.yellow, true) },
            { LogType.Lazy, (Color.cyan, true) },
            { LogType.Jacket, (Color.magenta, true) }
        };

        // 日志类型标识符（用于筛选）
        static Dictionary<LogType, string> logTypeIdentifiers = new Dictionary<LogType, string> {
            { LogType.Normal, "GJ_LOG" },
            { LogType.Todo, "GJ_TODO" },
            { LogType.Lazy, "GJ_LAZY" },
            { LogType.Jacket, "GJ_JACKET" },
            { LogType.Warning, "GJ_WARNING" },
            { LogType.Error, "GJ_ERROR" },
            { LogType.Assert, "GJ_ASSERT" }
        };

        // 筛选配置
        public static HashSet<LogType> enabledLogTypes = new HashSet<LogType> {
            LogType.Normal, LogType.Todo, LogType.Lazy, LogType.Jacket,
            LogType.Warning, LogType.Error, LogType.Assert
        };

        public static LogType GetLogType(string identifier) {
            foreach (var kvp in logTypeIdentifiers) {
                if (kvp.Value == identifier) {
                    return kvp.Key;
                }
            }
            return LogType.Normal;
        }

        public static void Log(object msg) {
            if (enabledLogTypes.Contains(LogType.Normal)) {
                LogInternal(msg?.ToString(), LogType.Normal);
            }
        }

        public static void LogTodo(object msg) {
            if (enabledLogTypes.Contains(LogType.Todo)) {
                LogInternal(msg?.ToString(), LogType.Todo);
            }
        }

        public static void LogLazy(object msg) {
            if (enabledLogTypes.Contains(LogType.Lazy)) {
                LogInternal(msg?.ToString(), LogType.Lazy);
            }
        }

        public static void LogJacket(object msg) {
            if (enabledLogTypes.Contains(LogType.Jacket)) {
                LogInternal(msg?.ToString(), LogType.Jacket);
            }
        }

        public static void Warning(object msg) {
            if (enabledLogTypes.Contains(LogType.Warning)) {
                Debug.LogWarning($"[{logTypeIdentifiers[LogType.Warning]}]{msg?.ToString()}");
            }
        }

        public static void Error(object msg) {
            if (enabledLogTypes.Contains(LogType.Error)) {
                Debug.LogError($"[{logTypeIdentifiers[LogType.Error]}]{msg?.ToString()}");
            }
        }

        public static void Assert(bool condition, object msg) {
            if (enabledLogTypes.Contains(LogType.Assert)) {
                Debug.LogAssertion($"[{logTypeIdentifiers[LogType.Assert]}]{msg?.ToString()}");
            }
        }

        static void LogInternal(string message, LogType type) {
            if (logTypeConfigs.TryGetValue(type, out var config)) {
                string formattedMsg = FormatMessage(message, config.color, config.bold);
                Debug.Log($"[{logTypeIdentifiers[type]}]{formattedMsg}");
            }
        }

        static string FormatMessage(string message, Color color, bool bold) {
            string colorHex = ColorUtility.ToHtmlStringRGB(color);
            string boldTag = bold ? "<b>" : "";
            string boldEndTag = bold ? "</b>" : "";

            return $"{boldTag}<color=#{colorHex}>{message}</color>{boldEndTag}";
        }

        // 筛选控制方法
        public static void EnableLogType(LogType type) {
            enabledLogTypes.Add(type);
        }

        public static void DisableLogType(LogType type) {
            enabledLogTypes.Remove(type);
        }

        public static void SetLogTypeEnabled(LogType type, bool enabled) {
            if (enabled)
                enabledLogTypes.Add(type);
            else
                enabledLogTypes.Remove(type);
        }

        public static bool IsLogTypeEnabled(LogType type) {
            return enabledLogTypes.Contains(type);
        }
    }
}