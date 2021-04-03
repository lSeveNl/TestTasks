using Desk.Domain.Dto.Common;

namespace Desk.Domain.Dto.Request
{
    public class RequestEntitySearchRequest : ISearchRequestBase
    {
        public int? IdFilter { get; set; }

        public string NameFilter { get; set; }

        public int UserIdFilter { get; set; }

        public int RequestTypeFilter { get; set; }
    }
}
