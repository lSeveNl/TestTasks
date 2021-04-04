using System.Threading.Tasks;
using AutoMapper;
using Desk.Bll.Services.Common;
using Desk.Core.Services;
using Desk.DAL.Context;
using Desk.Domain.Dictionary.RequestModels;
using Desk.Domain.Dto.Request;
using Microsoft.EntityFrameworkCore;

namespace Desk.Bll.Services
{
    public class RequestTypeService : BaseServiceOperations<RequestType, RequestTypeDto>, IRequestTypeService
    {
        public RequestTypeService(DeskContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task RemoveAsync(int id)
        {
            var result = await this.Context.Set<RequestType>()
                .SingleOrDefaultAsync(x => x.Id == id);

            result.IsDeleted = true;

            await this.Context.SaveChangesAsync();
        }
    }
}
