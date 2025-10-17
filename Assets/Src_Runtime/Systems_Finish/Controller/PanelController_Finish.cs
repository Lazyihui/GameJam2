using System;
using UnityEngine;

namespace GJ.Systems_Finish {

    public static class PanelController_Finish {

        #region Curtain
        public static void Curtain_Open(FinishSystemContext ctx) {
            PanelOpenResult res = ctx.uiCore.P_TryOpen<Panel_Curtain>(PanelType.Curtain, UIRootLevel.SuperTop, out var panel);
            if (res == PanelOpenResult.FirstOpen) {
                panel.Ctor();

                panel.OnStartHandle = ctx.events.OnReStart;
                panel.OnExitGameHandle = () => {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                };
            }
            panel.Init();
        }

        public static void Curtain_Close(FinishSystemContext ctx) {
            bool has = ctx.uiCore.P_TryGet<Panel_Curtain>(PanelType.Curtain, out var panel);
            if (has) {
                ctx.uiCore.P_Remove(panel);
                panel.Close();
            }
        }
        #endregion

    }

}