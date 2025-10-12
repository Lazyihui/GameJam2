using System.Collections;
using System.Collections.Generic;
using GJ.Modules_Input;
using UnityEngine;

namespace GJ {

    public class ClientMain : MonoBehaviour {

        static LoginSystem loginSystem;
        static GameSystem gameSystem;

        // ==== Modules ====
        static UICore uiCore;
        static AssetModule assetModule;
        static InputModule inputModule;

        // ==== Repository =====
        static RoleRepository roleRepository;
        static GameEntity gameEntity;

        bool isInit = false;
        bool isTearDown = false;

        public void Awake() {

            // ==== Ctor ==== 
            loginSystem = new LoginSystem();
            gameSystem = new GameSystem();
            gameEntity = new GameEntity();

            // Modules
            uiCore = GetComponentInChildren<UICore>();
            uiCore.Ctor();

            assetModule = GetComponentInChildren<AssetModule>();
            assetModule.Ctor();

            inputModule = GetComponentInChildren<InputModule>();
            inputModule.Ctor();

            //==== Repository ====
            roleRepository = new RoleRepository();

            // Inject
            uiCore.Inject(assetModule);
            loginSystem.Inject(assetModule, uiCore);
            gameSystem.Inject(assetModule, uiCore,
                                  roleRepository,
                                  gameEntity
            );

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
                gameSystem.NewGame();
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
            float dt = Time.deltaTime;
            inputModule.Tick(dt);
            
            gameSystem.Tick(dt);
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
