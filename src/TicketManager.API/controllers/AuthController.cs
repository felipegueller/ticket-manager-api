using Microsoft.AspNetCore.Mvc;

namespace TicketManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("[action]")]
    public IActionResult Login()
    {
        return Ok("Login successful");
    }
}