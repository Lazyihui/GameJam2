using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GJ {

    public class ClientMain : MonoBehaviour {

        static LoginSystem loginSystem;

        // ==== Modules ====
        static UICore uiCore;
        static AssetModule assetModule;

        bool isInit = false;
        bool isTearDown = false;

        public void Awake() {
            GJLog.Log("ClientMain Awake");

            // ==== Ctor ==== 
            loginSystem = new LoginSystem();

            // Modules
            uiCore = GetComponentInChildren<UICore>();
            uiCore.Ctor();

            assetModule = GetComponentInChildren<AssetModule>();
            assetModule.Ctor();

            // Inject
            uiCore.Inject(assetModule);
            loginSystem.Inject(assetModule, uiCore);


            // Start
            // ==== Bind Events ====
            BindEvents();

            // ==== Init ====
            StartCoroutine(InitIE());
        }

        void BindEvents() {
            // - Login
            var loginEvents = loginSystem.Events;
            loginEvents.OnStartHandle = () => {
                loginSystem.ExitWithoutNotify();
                // Debug.LogWarning("TODO: Enter Main Scene");
                GJLog.LogTodo("TODO: Enter Main Scene");
                GJLog.Log("Game Start!");
                GJLog.LogLazy("Game Start! (Lazy");
                GJLog.LogJacket("Game Start! (Jacket");
            };
        }
        #region Init IE
        IEnumerator InitIE() {

            yield return assetModule.LoadAllIE();
            isInit = true;

            loginSystem.Enter();
        }
        #endregion
        void Update() {
            if (!isInit) {
                return;
            }
        }
        #region TearDown
        void OnApplicationQuit() {
            TearDown();
        }

        void OnDestroy() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;

            assetModule.ReleaseAll();
        }
        #endregion
    }
}
