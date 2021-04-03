using Desk.Domain.Auth;
using Desk.Domain.Common;

namespace Desk.Domain.Dictionary.RequestModels
{
    public class Request : DictionaryBase, IEntity, ISoftDelete
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RequestTypeId { get; set; }

        public RequestType RequestType { get; set; }
    }
}
