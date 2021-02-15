using MediatR;
using Microsoft.AspNetCore.Mvc;
using S3Inovate.Core.Cqrs.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace S3Inovate.WebApi.Controllers
{
    [Route("api/objects")]
    [ApiController]
    public class ObjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ObjectsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetObjects()
        {
            var objects = await _mediator.Send(new ObjectQuery());

            if (!objects.Any())
                return NoContent();

            return Ok(objects);
        }
    }
}
