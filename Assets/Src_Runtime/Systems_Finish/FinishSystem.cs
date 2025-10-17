using System;
using UnityEngine;
using GJ.Systems_Finish ;

namespace GJ {

    public class FinishSystem {

        FinishSystemContext ctx;
        public FinishSystemEvents Events => ctx.events;

        public FinishSystem() {
            ctx = new FinishSystemContext();
        }

        public void Inject(AssetModule assetModule, UICore uiCore) {
            ctx.assetModule = assetModule;
            ctx.uiCore = uiCore;
        }

        public void Tick(float dt) {
            if (ctx.status != SystemStatus.Running) {
                return;
            }
        }

        public void Enter() {
            SystemController.NewFinish(ctx);
            // PanelController.Finish_Open(ctx);
            ctx.status = SystemStatus.Running;
        }

    }
}