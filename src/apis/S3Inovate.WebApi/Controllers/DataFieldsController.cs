using MediatR;
using Microsoft.AspNetCore.Mvc;
using S3Inovate.Core.Cqrs.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace S3Inovate.WebApi.Controllers
{
    [Route("api/dataFields")]
    [ApiController]
    public class DataFieldsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataFieldsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDataFields()
        {
            var dataFields = await _mediator.Send(new DataFieldsQuery());

            if (!dataFields.Any())
                return NoContent();

            return Ok(dataFields);
        }
    }
}
