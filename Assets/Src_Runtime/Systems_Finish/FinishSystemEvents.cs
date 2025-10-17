using System;

namespace GJ {

    public class FinishSystemEvents {
        public Action OnReStartHandle;
        public void OnReStart() => OnReStartHandle.Invoke();

        public FinishSystemEvents() { }
    }
}