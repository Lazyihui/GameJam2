using System;
using UnityEngine;

namespace GJ.Systems_Game {

    public static class SystemController {

        public static void NewGame(GameSystemContext ctx) {
            ctx.status = SystemStatus.Running;

        }

        public static void OnResume(GameSystemContext ctx) {
        }


        public static void OnExitGame(GameSystemContext ctx) {
            ctx.status = SystemStatus.Stopped;
        }

    }
}