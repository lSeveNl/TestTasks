using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Desk.Core.Services;
using Desk.Domain.Dto.Request;
using Microsoft.AspNetCore.Authorization;

namespace Desk.App.Controllers
{
    [Route("api/[controller]/[action]/{id}")]
    [ApiController]
    [Authorize]
    public class RequestController : Controller, IOperationController<RequestDto>
    {
        private readonly IRequestService _service;

        public RequestController(IRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);

            return this.Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this._service.ListAsync();

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestDto dto)
        {
            var result = await _service.AddAsync(dto);

            return this.Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] RequestDto dto)
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
