// #if UNITY_EDITOR
// using System;
// using System.Reflection;

// namespace GJ {

//     public static class AAEditorBridge {

//         public static void TryAdd(Object obj, string group, string label) {
//             // Reflection: NJM.Editor.asmdef
//             var assembly = Assembly.Load("GJ.Editor");
//             if (assembly == null) return;

//             var type = assembly.GetType("GJ.AAHelper");
//             if (type == null) return;

//             var method = type.GetMethod("TryAdd", BindingFlags.Public | BindingFlags.Static);
//             method?.Invoke(null, new object[] { obj, group, label });
//         }

//     }

// }

// #endif