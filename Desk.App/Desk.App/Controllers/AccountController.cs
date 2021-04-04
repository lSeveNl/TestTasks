using System;
using System.Threading.Tasks;
using Desk.Core.Services;
using Desk.Domain.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desk.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthService _service;

        public AccountController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] AuthRequest request )
        {
            var result = await this._service.GetToken(request.Login, request.Password);

            if (result.StatusCode == 200)
            {
                this.Response.Headers.Add("Authorization", "Bearer " + result.Token);

                this.Response.Cookies.Append("token", result.Token, new CookieOptions { Expires = DateTime.Now.AddDays(3) });
            }

            return this.Ok(Json(result));
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete("token");

            return this.Ok();
        }
    }
}
