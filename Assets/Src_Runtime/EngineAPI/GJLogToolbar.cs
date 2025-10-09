using UnityEditor;
using UnityEngine;

namespace GJ.Editor {

    [InitializeOnLoad]
    public static class GJLogToolbar {

        static GJLogToolbar() {
            EditorApplication.update += Update;
        }

        static void Update() {
            // 在Console窗口添加按钮
            var consoleWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ConsoleWindow");
            if (consoleWindowType != null) {
                var field = consoleWindowType.GetField("ms_ConsoleWindow", 
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                
                if (field != null && field.GetValue(null) is EditorWindow consoleWindow) {
                    consoleWindow.titleContent = new GUIContent("Console (GJ Enhanced)");
                }
            }
        }

        [MenuItem("Window/Analysis/Console (GJ Enhanced)")]
        public static void ShowEnhancedConsole() {
            EditorApplication.ExecuteMenuItem("Window/General/Console");
            GJLogFilter.ShowWindow();
        }
    }
}