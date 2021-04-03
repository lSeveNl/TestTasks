using System;

namespace Desk.Domain.Common
{
    public abstract class DictionaryBase
    {
        private string _name;

        public string Name
        {
            get => this._name;
            set => this._name = value.Trim();
        }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
