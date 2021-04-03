using System;
using Desk.Domain.Dto.Common;

namespace Desk.Domain.Dto
{
    public class LogTableDto : IDto
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string ErrorMessage { get; set; }

        public DateTime Created { get; set; }
    }
}
