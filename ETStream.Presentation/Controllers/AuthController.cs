using ETStream.Application.Commands;
using ETStream.Application.Handlers;
using ETStream.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ETStream.Presentation.Controllers
{
    [ApiController]
    [Route("/api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUser(
                [FromServices] UserCommandHandler userCommandHandler,
                [FromServices] UserQueryHandler userQueryHandler,
                [FromBody] CreateUserProperties payload)
        {
            var userId = await userCommandHandler.HandleAsync(new CreateUser(payload));
            var result = await userQueryHandler.HandleAsync(new GetUserDetails(new()
            {
                UserId = userId!.Value
            }));

            return Json(result);
        }
    }
}