using System;
using UnityEngine;
using UnityEngine.Video;

namespace GJ {

    public class LoginSystem {

        LoginSystemContext ctx;

        public LoginSystemEvents Events => ctx.events;

        public LoginSystem() {
            ctx = new LoginSystemContext();
        }

        public void Inject(AssetModule assetModule, UICore uiCore) {
            ctx.assetModule = assetModule;
            ctx.uiCore = uiCore;
        }

        public void Enter() {
            Debug.Log("LoginSystem Enter");
            PanelController.Login_Open(ctx);

            ctx.status = SystemStatus.Running;

        }

        public void ExitWithoutNotify() {
            PanelController.Login_Close(ctx);

            ctx.status = SystemStatus.Stopped;
        }
    }
}