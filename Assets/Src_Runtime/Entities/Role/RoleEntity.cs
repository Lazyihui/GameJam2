using UnityEngine;

namespace GJ {

    public class RoleEntity : MonoBehaviour, IEntityAsset {

        public EntityType EntityType => EntityType.Role;
        public UniqueID uniqueID;
        public TypeID typeID;

        // Components
        public RoleInputComponent inputComponent;
        public void Ctor() {
            inputComponent = new RoleInputComponent();
        }

        public void TearDown() {

        }

    }
}