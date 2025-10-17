using System;

namespace GJ {

    public class UserIDComponent {

        int role;

        public UserIDComponent() { }

        public UniqueID Role() => new UniqueID(EntityType.Role, ++role);

    }

}