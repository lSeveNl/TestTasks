using System.Collections.Generic;
using System.Threading.Tasks;
using Desk.Domain.Dto.Common;

namespace Desk.Core.Services.Common
{
    public interface ISearchableService<TDto, in TRequest> 
        where TDto : IDto
        where TRequest : ISearchRequestBase
    {
        Task<List<TDto>> Search(TRequest request);
    }
}
