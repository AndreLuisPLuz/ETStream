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
        public async Task<IActionResult> CreateSchool(
                [FromServices] SchoolCommandHandler commandHandler,
                [FromServices] SchoolQueryHandler queryHandler,
                [FromBody] CreateSchoolProperties payload)
        {
            var schoolId = await commandHandler.HandleAsync(new CreateSchool(payload));
            var result = await queryHandler.HandleAsync(new GetSchoolDetails(new()
            {
                SchoolId = schoolId
            }));

            return Json(result);
        }
    }
}