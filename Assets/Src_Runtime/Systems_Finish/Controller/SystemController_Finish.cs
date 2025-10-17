using System;
using UnityEngine;

namespace GJ.Systems_Finish {

    public static class SystemController {

        public static void NewFinish(FinishSystemContext ctx) {
            GJLog.Log("进入结算");
            ctx.status = SystemStatus.Running;
        }

        public static void OnResume(FinishSystemContext ctx) {

        }


        public static void OnExitFinish(FinishSystemContext ctx) {
            ctx.status = SystemStatus.Stopped;
        }

    }
}