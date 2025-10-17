using System;


namespace GJ {

    public class FinishSystemContext {
        public SystemStatus status;
        public FinishSystemEvents events;
        public UICore uiCore;
        public AssetModule assetModule;

        public FinishSystemContext() {
            events = new FinishSystemEvents();
            status = SystemStatus.None;
        }
    }
}