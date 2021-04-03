using System.Threading.Tasks;
using Desk.Domain.Dto;

namespace Desk.Core.Services
{
    public interface ILogTableService
    {
        Task AddAsync(LogTableDto dto);
    }
}
