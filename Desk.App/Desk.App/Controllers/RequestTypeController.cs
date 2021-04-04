using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desk.Domain.Dto.Request;
using Desk.Core.Services;

namespace Desk.App.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class RequestTypeController : Controller, IOperationController<RequestTypeDto>
    {
        private readonly IRequestTypeService _service;

        public RequestTypeController(IRequestTypeService service)
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
        public async Task<IActionResult> Post([FromBody] RequestTypeDto dto)
        {
            await _service.AddAsync(dto);

            return this.Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] RequestTypeDto dto)
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
