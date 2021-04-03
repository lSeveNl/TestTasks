using System.Threading.Tasks;
using Desk.Core.Services.Common;
using Desk.Domain.Dto.Request;

namespace Desk.Core.Services
{
    public interface IRequestService : IServiceBase<RequestDto>, ISearchableService<RequestDto, RequestEntitySearchRequest>
    {
        new Task<bool> AddAsync(RequestDto dto);
    }
}
