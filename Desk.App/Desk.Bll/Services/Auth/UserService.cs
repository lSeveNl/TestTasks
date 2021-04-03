using System.Threading.Tasks;
using AutoMapper;
using Desk.Bll.Services.Common;
using Desk.Core.Services;
using Desk.DAL.Context;
using Desk.Domain.Auth;
using Desk.Domain.Dto.User;
using Microsoft.EntityFrameworkCore;

namespace Desk.Bll.Services.Auth
{
    public class UserService : BaseServiceOperations<User, UserDto>, IUserService
    {
        public UserService(DeskContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task RemoveAsync(int id)
        {
            var result = await this.Context.Set<User>()
                .SingleOrDefaultAsync(x => x.Id == id);

            result.IsDeleted = true;

            await this.Context.SaveChangesAsync();
        }
    }
}
