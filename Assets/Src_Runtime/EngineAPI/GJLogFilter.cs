using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace GJ.Editor {

    public class GJLogFilter : EditorWindow {

        private static Dictionary<string, bool> logTypeFilters = new Dictionary<string, bool> {
            { "GJ_LOG", true },
            { "GJ_TODO", true },
            { "GJ_LAZY", true },
            { "GJ_Jack", true },
            { "GJ_WARNING", true },
            { "GJ_ERROR", true },
            { "GJ_ASSERT", true }
        };

        private Vector2 scrollPosition;
        private static bool isFilterEnabled = true;
        private static List<LogEntry> filteredLogs = new List<LogEntry>();
        private static GJLogFilter window;

        [MenuItem("GJ Tools/Log Filter")]
        public static void ShowWindow() {
            window = GetWindow<GJLogFilter>("GJ Log Filter");
            window.minSize = new Vector2(250, 300);
        }

        private void OnEnable() {
            Application.logMessageReceived += HandleLog;
            RefreshFilteredLogs();
        }

        private void OnDisable() {
            Application.logMessageReceived -= HandleLog;
        }

        private void OnGUI() {
            DrawFilterControls();
            DrawLogList();
        }

        private void DrawFilterControls() {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            
            // 总开关
            EditorGUILayout.BeginHorizontal();
            isFilterEnabled = EditorGUILayout.Toggle("Enable Filter", isFilterEnabled);
            if (GUILayout.Button("Clear All")) {
                ClearLogs();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            // 全选/全不选
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select All")) {
                SetAllFilters(true);
            }
            if (GUILayout.Button("Deselect All")) {
                SetAllFilters(false);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            // 过滤器选项
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Height(150));
            
            foreach (var filter in logTypeFilters.ToList()) {
                logTypeFilters[filter.Key] = EditorGUILayout.ToggleLeft($" {filter.Key}", filter.Value);
            }
            
            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndVertical();
        }

        private void DrawLogList() {
            EditorGUILayout.LabelField("Filtered Logs", EditorStyles.boldLabel);
            
            Rect logListRect = GUILayoutUtility.GetRect(0, position.height - 200, GUILayout.ExpandWidth(true));
            GUI.Box(logListRect, GUIContent.none);
            
            if (filteredLogs.Count == 0) {
                EditorGUILayout.LabelField("No logs to display", EditorStyles.centeredGreyMiniLabel);
                return;
            }

            Vector2 scroll = Vector2.zero;
            float currentY = 0;
            
            foreach (var log in filteredLogs) {
                DrawLogEntry(log, logListRect, ref currentY, ref scroll);
            }
        }

        private void DrawLogEntry(LogEntry log, Rect containerRect, ref float currentY, ref Vector2 scroll) {
            float entryHeight = 60;
            Rect entryRect = new Rect(0, currentY, containerRect.width, entryHeight);
            
            if (entryRect.y + entryHeight >= scroll.y && entryRect.y <= scroll.y + containerRect.height) {
                // 根据日志类型设置颜色
                Color bgColor = GetLogTypeColor(log.type);
                EditorGUI.DrawRect(entryRect, bgColor * 0.1f);
                
                GUIStyle labelStyle = new GUIStyle(EditorStyles.label);
                labelStyle.wordWrap = true;
                labelStyle.normal.textColor = Color.white;
                
                Rect contentRect = new Rect(entryRect.x + 5, entryRect.y + 5, entryRect.width - 10, entryRect.height - 10);
                
                EditorGUI.LabelField(new Rect(contentRect.x, contentRect.y, contentRect.width, 20), 
                    $"[{log.type}]", EditorStyles.boldLabel);
                
                EditorGUI.LabelField(new Rect(contentRect.x, contentRect.y + 20, contentRect.width, 40), 
                    log.message, labelStyle);
            }
            
            currentY += entryHeight;
        }

        private Color GetLogTypeColor(string type) {
            return type switch {
                "GJ_TODO" => Color.yellow,
                "GJ_LAZY" => Color.cyan,
                "GJ_Jack" => Color.green,
                "GJ_WARNING" => new Color(1, 0.5f, 0), // 橙色
                "GJ_ERROR" => Color.red,
                "GJ_ASSERT" => Color.red,
                _ => Color.white
            };
        }

        private void HandleLog(string logString, string stackTrace, LogType type) {
            if (!isFilterEnabled) return;

            // 解析日志类型
            string logType = "GJ_LOG";
            string message = logString;

            var match = Regex.Match(logString, @"^\[(GJ_\w+)\](.+)");
            if (match.Success) {
                logType = match.Groups[1].Value;
                message = match.Groups[2].Value.Trim();
            } else {
                // 如果不是GJ日志，使用Unity原生类型
                logType = type.ToString().ToUpper();
            }

            // 检查是否应该显示这个日志
            if (logTypeFilters.ContainsKey(logType) && logTypeFilters[logType]) {
                filteredLogs.Add(new LogEntry(logType, message, stackTrace, type));
                Repaint();
            }
        }

        private void RefreshFilteredLogs() {
            filteredLogs.Clear();
        }

        private void ClearLogs() {
            filteredLogs.Clear();
            Repaint();
        }

        private void SetAllFilters(bool value) {
            var keys = logTypeFilters.Keys.ToList();
            foreach (var key in keys) {
                logTypeFilters[key] = value;
            }
            RefreshFilteredLogs();
        }

        private class LogEntry {
            public string type;
            public string message;
            public string stackTrace;
            public LogType logType;

            public LogEntry(string type, string message, string stackTrace, LogType logType) {
                this.type = type;
                this.message = message;
                this.stackTrace = stackTrace;
                this.logType = logType;
            }
        }
    }
}