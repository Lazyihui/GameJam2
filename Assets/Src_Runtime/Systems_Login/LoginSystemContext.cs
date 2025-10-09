using System;

namespace GJ {

    public class LoginSystemContext {

        public LoginSystemEvents events;

        // ==== External ====
        public AssetModule assetModule;

        public LoginSystemContext() {
            events = new LoginSystemEvents();
        }

    }

}