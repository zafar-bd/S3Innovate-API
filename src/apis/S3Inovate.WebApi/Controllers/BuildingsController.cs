using MediatR;
using Microsoft.AspNetCore.Mvc;
using S3Inovate.Core.Cqrs.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace S3Inovate.WebApi.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BuildingsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            var buildings = await _mediator.Send(new BuildingQuery());

            if (!buildings.Any())
                return NoContent();

            return Ok(buildings);
        }
    }
}
