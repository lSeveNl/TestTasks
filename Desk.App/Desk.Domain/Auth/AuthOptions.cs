using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Desk.Domain.Auth
{
    public class AuthOptions
    {
        public const string publisher = "SevenServer";

        public const string client = "Client";

        public const string key = "Ljh3#666!!!78687676999999";

        public const int lifeTime = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }
    }
}
