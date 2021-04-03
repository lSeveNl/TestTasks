using Desk.Domain.Common;
using Desk.Domain.Dictionary.RequestModels;
using Desk.Domain.Dto.Common;

namespace Desk.Domain.Dto.Request
{
    public class RequestDto : DictionaryBase, IDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Auth.User User { get; set; }

        public int RequestTypeId { get; set; }

        public RequestType RequestType { get; set; }
    }
}
