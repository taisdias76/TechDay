    using Microsoft.AspNetCore.Mvc;
using MinasBank.Areas.Devs.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinasBank.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevController : Controller
    {
        private readonly IDevService _devService;

        public DevController(IDevService devService)
        {
            _devService = devService;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Apagar([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _devService.Apagar(id, cancellationToken).ConfigureAwait(false);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        
    }
}
