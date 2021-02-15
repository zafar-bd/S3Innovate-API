using MediatR;
using Microsoft.AspNetCore.Mvc;
using S3Inovate.Core.Cqrs.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace S3Inovate.WebApi.Controllers
{
    [Route("api/readings")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReadingsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReadings([FromQuery] ReadingQuery args)
        {
            var readings = await _mediator.Send(args);

            if (!readings.Any())
                return NoContent();

            return Ok(readings);
        }
    }
}
