using ETStream.Application.Commands;
using ETStream.Application.Handlers;
using ETStream.Application.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ETStream.Presentation.Controllers
{
    [ApiController]
    [Route("/api/v1/school")]
    public class SchoolController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateSchool(
                [FromServices] SchoolCommandHandler commandHandler,
                [FromServices] SchoolQueryHandler queryHandler,
                [FromBody] CreateSchoolCommandProperties payload)
        {
            var command = new CreateSchoolCommand(payload);
            var schoolId = await commandHandler.HandleAsync(command);

            if (schoolId is null)
                return BadRequest();
            
            var query = new GetSchoolDetails(new()
            {
                SchoolId = schoolId.Value
            });

            var result = await queryHandler.HandleAsync(query);

            return Ok();
        }
    }
}