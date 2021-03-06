﻿namespace ReadPlayCode.DataLayer.Entities
{
    public class UserEntity : Entity
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public virtual RoleEntity UserRole { get; set; }
    }
}
