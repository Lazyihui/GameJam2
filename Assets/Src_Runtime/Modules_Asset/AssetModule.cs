using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GJ {

    public class AssetModule : MonoBehaviour {


        Dictionary<PanelType, GameObject> panels;
        AsyncOperationHandle panelHandle;


        public void Ctor() {
            panels = new Dictionary<PanelType, GameObject>();
        }

        public IEnumerator LoadAllIE() {
            yield return Panel_Load();
        }

        public void ReleaseAll() {
            Panel_Release();
        }

        #region Panel
        IEnumerator Panel_Load() {
            var handle = Addressables.LoadAssetsAsync<GameObject>("Panel", null);
            while (!handle.IsDone) {
                yield return null;
            }
            var list = handle.Result;
            if (list == null || list.Count == 0) {
                Debug.LogWarning("No Panel assets found.");
                yield break;
            }
            foreach (var go in list) {
                var panel = go.GetComponent<IPanelAsset>();
                bool succ = panels.TryAdd(panel.Type, go);
                if (!succ) {
                    Debug.LogError($"Panel Type: {panel.Type} already exists!");
                }
            }
            panelHandle = handle;
        }

        void Panel_Release() {
            if (panelHandle.IsValid()) {
                Addressables.Release(panelHandle);
            }
        }

        public bool Panel_TryGet(PanelType type, out GameObject go) {
            return panels.TryGetValue(type, out go);
        }

        #endregion

    }

}