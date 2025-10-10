using System;
using UnityEditor.Build.Pipeline.Tasks;
using UnityEngine.Video;


namespace GJ {

    public class GameSystemContext {

        public SystemStatus status;
        public GameSystemEvents events;

        // ==== External ====
        public UICore ui;

        public AssetModule assetModule;

        // ==== Internal ====
        public GameEntity gameEntity;

        public GameSystemContext() {
        }

        public void Inject(UICore ui, AssetModule assetModule) {
            this.ui = ui;
            this.assetModule = assetModule;
        }
    }
}