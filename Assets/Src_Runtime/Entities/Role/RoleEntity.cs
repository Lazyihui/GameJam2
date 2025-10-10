using UnityEngine;

namespace GJ {

    public class RoleEntity : MonoBehaviour, IEntityAsset {

        public EntityType EntityType => EntityType.Role;
        public UniqueID uniqueID;
        public TypeID typeID;

        public void Ctor() {

        }

        public void TearDown() {

        }
        
    }
}