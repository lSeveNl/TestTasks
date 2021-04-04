using System.Security.Claims;
using System.Threading.Tasks;
using Desk.Domain.Auth;

namespace Desk.Core.Services
{
    public interface IAuthService
    {
        int CurrentUserId { get; set; }

        string CurrentUserName { get; set; }

        Task<AuthResponse> GetToken(string login, string password);

        Task<ClaimsIdentity> GetIdentity(string login, string password);
    }
}
