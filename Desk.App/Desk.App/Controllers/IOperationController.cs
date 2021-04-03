using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Desk.App.Controllers
{
    public interface IOperationController<in TDto>
    {
        [HttpGet]
        Task<IActionResult> List();

        [HttpGet]
        Task<IActionResult> Get(int id);

        [HttpPost]
        Task<IActionResult> Post([FromBody] TDto dto);

        [HttpPut]
        IActionResult Put([FromBody] TDto dto);

        [HttpDelete]
        Task<IActionResult> Delete(int id);
    }
}
