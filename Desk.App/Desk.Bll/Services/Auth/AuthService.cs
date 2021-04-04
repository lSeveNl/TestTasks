using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Desk.Core.Services;
using Desk.DAL.Context;
using Desk.DAL.Extensions;
using Desk.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Desk.Bll.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DeskContext _context;

        public int CurrentUserId { get; set; }

        public string CurrentUserName { get; set; }

        public AuthService(DeskContext context)
        {
            this._context = context;
        }

        public async Task<AuthResponse> GetToken(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return new AuthResponse
                {
                    StatusCode = 400,
                    Messege = "Не заполнен логин или пароль"
                };
            }

            var identity = await this.GetIdentity(login, password);

            if (identity == null)
            {
                return new AuthResponse
                {
                    StatusCode = 401,
                    Messege = "Неверный логин или пароль"
                }; ;
            }

            var token = new JwtSecurityToken(
                issuer: AuthOptions.client,
                audience: AuthOptions.publisher,
                notBefore: DateTime.UtcNow,
                claims: identity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(AuthOptions.lifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var jwtEncoded = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                StatusCode = 200,
                Token = jwtEncoded
            };
        }

        public async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            var user = await this._context.Set<User>()
                .SingleOrDefaultAsync(x => x.Login == login && x.Password == password && x.IsActive);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.AuthRole.GetDescription())
                };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }
    }
}
