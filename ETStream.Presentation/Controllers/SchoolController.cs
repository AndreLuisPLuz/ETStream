using ETStream.Application.Commands;
using ETStream.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ETStream.Presentation.Controllers
{
    [ApiController]
    [Route("/api/v1/school")]
    public class SchoolController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> CreateSchool(
                [FromServices] SchoolCommandHandler handler,
                [FromBody] CreateSchoolCommandProperties payload)
        {
            var command = new CreateSchoolCommand(payload);
            var schoolId = await handler.HandleAsync(command);

            if (schoolId is null)
                return BadRequest();
            
            return Created();
        }
    }
}