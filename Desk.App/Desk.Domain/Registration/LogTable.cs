using System;
using Desk.Domain.Common;

namespace Desk.Domain.Registration
{
    public class LogTable : IEntity
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string ErrorMessage { get; set; }

        public DateTime Created { get; set; }
    }
}
