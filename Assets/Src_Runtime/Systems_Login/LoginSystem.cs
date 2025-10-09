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

        public void Inject(AssetModule assetModule) {
            ctx.assetModule = assetModule;
        }

        public void Enter() {
            Debug.Log("LoginSystem Enter");
        }

        public void ExitWithoutNotify() {

        }
    }
}