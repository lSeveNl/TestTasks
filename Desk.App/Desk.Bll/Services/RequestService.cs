using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Desk.Bll.Services.Common;
using Desk.Core.Services;
using Desk.DAL.Context;
using Desk.Domain.Dictionary.RequestModels;
using Desk.Domain.Dto;
using Desk.Domain.Dto.Request;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Desk.Bll.Services
{
    public class RequestService : BaseServiceOperations<Request, RequestDto>, IRequestService
    {
        private readonly ILogger<RequestService> _logger;

        private readonly ILogTableService _logTableService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestService(DeskContext context, IMapper mapper, ILogger<RequestService> logger, ILogTableService logTableService, IHttpContextAccessor httpContextAccessor)
            :base(context, mapper)
        {
            Context = context;
            Mapper = mapper;
            _logger = logger;
            _logTableService = logTableService;
            _httpContextAccessor = httpContextAccessor;
        }

        async Task<bool> IRequestService.AddAsync(RequestDto dto)
        {
            dto.Id = int.Parse(this._httpContextAccessor.HttpContext.User.Identity.Name);

            var entity = this.Mapper.Map<Request>(dto);

            try
            {
                await this.Context.AddAsync(entity);

                return true;
            }
            catch (Exception e)
            {

                await this._logTableService.AddAsync(new LogTableDto
                {
                    ServiceName = nameof(RequestService),
                    ErrorMessage = e.Message
                });

                return false;
            }
        }

        public async Task RemoveAsync(int id)
        {
            var result = await this.Context.Set<Request>()
                .SingleOrDefaultAsync(x => x.Id == id);

            result.IsDeleted = true;

            await this.Context.SaveChangesAsync();
        }

        public async Task<List<RequestDto>> Search(RequestEntitySearchRequest request)
        {
            if (request.IdFilter != null)
            {
                return await this.Context.Set<Request>()
                    .Where(x => x.Id == request.IdFilter)
                    .Select(x => this.Mapper.Map<RequestDto>(x))
                    .ToListAsync();
            }

            var entities = Context.Set<Request>();

            var query = PredicateBuilder.New<Request>(true);

            if (request.RequestTypeFilter != 0)
            {
                query = query.And(x => x.RequestTypeId == request.RequestTypeFilter);
            }
            else if (!string.IsNullOrEmpty(request.NameFilter))
            {
                query = query.And(x => x.Name.Contains(request.NameFilter));
            }
            else if (request.UserIdFilter != 0)
            {
                query = query.And(x => x.UserId == request.UserIdFilter);
            }

            return await entities.AsExpandable()
                .Include(x => x.User)
                .Include(x => x.RequestType)
                .Where(query)
                .Select(x => this.Mapper.Map<RequestDto>(x))
                .ToListAsync();
        }
    }
}
