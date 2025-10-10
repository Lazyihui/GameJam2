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
        public RoleRepository roleRepository;

        // ==== Internal ====
        public GameEntity gameEntity;

        public GameSystemContext() {
        }

    }
}