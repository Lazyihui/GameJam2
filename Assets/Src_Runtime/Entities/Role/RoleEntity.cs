using UnityEditor.Callbacks;
using UnityEngine;

namespace GJ {

    public class RoleEntity : MonoBehaviour, IEntityAsset {

        public EntityType EntityType => EntityType.Role;
        public UniqueID uniqueID;
        public TypeID typeID;

        [SerializeField] Rigidbody2D rb;
        // Components
        public RoleInputComponent inputComponent;
        public RoleMoveComponent moveComponent;
        public AttributeComponent attributeComponent;
        public void Ctor() {
            inputComponent = new RoleInputComponent();
            moveComponent = new RoleMoveComponent();
            attributeComponent = new AttributeComponent();
        }

        #region Move
        public void Move(Vector2 direction, float speed, float dt) {
            rb.MovePosition(rb.position + direction * speed * dt);
        }

        #endregion

        public void TearDown() {

        }

    }
}