using System.Collections;
using UnityEngine;

namespace GJ {

    public class ClientMain : MonoBehaviour {

        static LoginSystem loginSystem;
        static GameSystem gameSystem;
        static FinishSystem finishSystem;

        // ==== Modules ====
        static UICore uiCore;
        static AssetModule assetModule;
        static InputModule inputModule;

        // ==== Repository =====
        static RoleRepository roleRepository;
        static GameEntity gameEntity;
        static UserEntity userEntity;

        bool isInit = false;
        bool isTearDown = false;

        public void Awake() {

            // ==== Init Systems ====
            loginSystem = new LoginSystem();
            gameSystem = new GameSystem();
            finishSystem = new FinishSystem();

            // ==== Entity ====
            gameEntity = new GameEntity();
            userEntity = new UserEntity();

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
            finishSystem.Inject(assetModule, uiCore);
            gameSystem.Inject(assetModule, uiCore,
                                  roleRepository,
                                  gameEntity,
                                  inputModule,
                                  userEntity
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

            // - Game
            var gameEvents = gameSystem.Events;
            gameEvents.OnCurtainHande = () => {
                finishSystem.Enter();
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
            finishSystem.Tick(dt);
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
