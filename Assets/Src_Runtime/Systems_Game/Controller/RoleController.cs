using System;
using Unity.VisualScripting;
using UnityEngine;

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

            ctx.roleRepository.Add(role);
            return role;
        }
    }
}