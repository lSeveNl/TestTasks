using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desk.Core.Services.Common
{
    public interface IServiceBase<TEntityDto>
        where TEntityDto : class
    {
        Task AddAsync(TEntityDto dto);

        Task<TEntityDto> GetAsync(int id);

        Task<List<TEntityDto>> ListAsync();

        Task UpdateAsync(TEntityDto dto);

        Task RemoveAsync(int id);
    }
}
