using System.Threading.Tasks;
using Desk.Core.Services;
using Desk.Domain.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desk.App.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]/[action]/{id}")]
    [ApiController]
    public class UserController : Controller, IOperationController<UserDto>
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this._service.ListAsync();

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._service.GetAsync(id);

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            await this._service.AddAsync(dto);

            return this.Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserDto dto)
        {
            this._service.UpdateAsync(dto);

            return this.Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await this._service.RemoveAsync(id);

            return this.Ok();
        }
    }
}
