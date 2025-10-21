using System;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

namespace GJ.Editors_Mission {

    public class MissionEM : MonoBehaviour {
        [InlineEditor] public MissionSO so;

        [Button]
        void Bake() {

            // propSpawners
            var propSpawners = GetComponentsInChildren<PropSpawnerEM>();
            so.propSpawners = new PropSpawnerTM[propSpawners.Length];
            for (int i = 0; i < propSpawners.Length; i++) {
                so.propSpawners[i] = propSpawners[i].spawnerTM;
            }

            // 存到硬盘里
            EditorUtility.SetDirty(so);
        }
    }
}