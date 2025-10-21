using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

namespace GJ.Systems_Game {

    public static class RoleController {

        public static RoleEntity Spawn(GameSystemContext ctx, TypeID typeID) {

            bool has = ctx.assetModule.Entity_TryGet(EntityType.Role, out var prefab);
            if (!has) {
                Debug.LogError($"没有找到角色预制体 {typeID}");
                return null;
            }
            var go = GameObject.Instantiate(prefab);
            var role = go.GetComponent<RoleEntity>();
            role.Ctor();
            role.typeID = typeID;
            role.uniqueID = ctx.userEntity.userIDComponent.Role();

            ctx.roleRepository.Add(role);
            return role;
        }

        public static void UnSpawn(GameSystemContext ctx, RoleEntity role) {
            ctx.roleRepository.Remove(role);
        }

        public static void Tick_Owner(GameSystemContext ctx, RoleEntity role, float dt) {
            // 用户或者主角才是这个
            Input_Record(ctx, role, dt);
            // Loco
            Loco_PressE(ctx, role, dt);
            Loco_MoveAxis(ctx, role, dt);
        }

        public static void Input_Record(GameSystemContext ctx, RoleEntity role, float dt) {
            var input = ctx.inputModule.inputEntity;
            var inputComp = role.inputComponent;
            inputComp.PressE_Set(input.isKeyDownE);
            inputComp.MoveAxis_Set(input.moveAxis);
        }

        #region Loco
        public static void Loco_PressE(GameSystemContext ctx, RoleEntity role, float dt) {
            var inputComp = role.inputComponent;
            if (inputComp.PressE_Get()) {
                Debug.Log("Loco_PressE");
                ctx.events.Curtain_Open_Invoke();
            }
        }

        public static void Loco_MoveAxis(GameSystemContext ctx, RoleEntity role, float dt) {
            var inputComp = role.inputComponent;
            Vector2 axis = inputComp.MoveAxis_Get();
            // TODO: Speed from config
            // float speed = role.attributeComponent.GetFloat(AttributeFloatValueType.MoveSpeed);//还没配置
            float speed = 15f;
            role.Move(axis, speed, dt);
        }

        #endregion
    }
}