using System;
using Desk.Domain.Dto.Common;

namespace Desk.Domain.Dto.Request
{
    public class RequestTypeDto : IDto
    {
        public int Id { get; set; }

        private string _name;

        public string Name
        {
            get => this._name;
            set => this._name = value.Trim();
        }

        public DateTime Created { get; set; }
    }
}
