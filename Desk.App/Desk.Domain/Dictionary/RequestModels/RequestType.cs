using System;
using Desk.Domain.Common;

namespace Desk.Domain.Dictionary.RequestModels
{
    public class RequestType : IEntity
    {
        private string _name;

        public int Id { get; set; }

        public string Name
        {
            get => this._name;
            set => this._name = value.Trim();
        }

        public DateTime Created { get; set; }
    }
}
