using System;
using UnityEngine;
using UnityEditor;

namespace GJ.Editors_Mission {

    [ExecuteInEditMode]
    public class PropSpawnerEM : MonoBehaviour {

        public PropSpawnerTM spawnerTM;

        void Update() {
            UpdateName();
            UpdateLocomotion();
            UpdateMod();
        }

        void UpdateName() {
            var so = spawnerTM.so;
            if (so == null) {
                return;
            }
            string n = $"Prop_{so.tm.typeID}_{so.tm.typeName}";
            if (this.name != n) {
                this.name = n;
            }
        }

        void UpdateLocomotion() {
            spawnerTM.whereOffset = transform.position;
        }

        void UpdateMod() {
            var so = spawnerTM.so;
            if (so == null) {
                return;
            }

            var tm = so.tm;

            var entity = GetComponentInChildren<PropEntity>();
            if (entity != null && entity.name != so.name) {
                GameObject.DestroyImmediate(entity);
                entity = null;
            }
            if (entity == null) {
                entity = PrefabUtility.InstantiatePrefab(tm.entityPrefab, transform) as PropEntity;
                entity.name = so.name;
            }
        }

    }

}