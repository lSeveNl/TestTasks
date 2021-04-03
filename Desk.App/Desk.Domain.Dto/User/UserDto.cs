using Desk.Domain.Dto.Common;

namespace Desk.Domain.Dto.User
{
    public class UserDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Surname { get; set; }

        public string FullName { get; set; }
    }
}
