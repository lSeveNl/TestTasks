using System;
using Desk.Domain.Common;
using Desk.Domain.Enums;

namespace Desk.Domain.Auth
{
    public class User : IEntity, ISoftDelete
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Surname { get; set; }

        public string Login { get; set; }

        public AuthRole AuthRole { get; set; }

        public string Password { get; set; }

        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
