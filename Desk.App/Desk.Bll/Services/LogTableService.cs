using System.Threading.Tasks;
using AutoMapper;
using Desk.Core.Services;
using Desk.DAL.Context;
using Desk.Domain.Dto;
using Desk.Domain.Registration;

namespace Desk.Bll.Services
{
    public class LogTableService : ILogTableService
    {
        private readonly DeskContext _context;

        private readonly IMapper _mapper;

        public LogTableService(DeskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(LogTableDto dto)
        {
            var entity = this._mapper.Map<LogTable>(dto);

            await this._context.AddAsync(entity);
        }
    }
}
