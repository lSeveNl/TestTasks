using System;
using Desk.Domain.Dto.Common;
using Desk.Domain.Enums;

namespace Desk.Domain.Dto.User
{
    public class UserDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Surname { get; set; }

        public string Login { get; set; }

        public AuthRole AuthRole { get; set; }

        public string AuthRoleName { get; set; }

        public string Password { get; set; }

        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
