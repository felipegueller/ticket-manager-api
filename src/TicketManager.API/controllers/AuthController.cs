using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketManager.DTO.Authentication;
using TicketManager.Service.IServices;

namespace TicketManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthController(IAuthService authenticationService) : ControllerBase
{
    private readonly IAuthService _authService = authenticationService;

    [HttpPost("[action]")]
    [AllowAnonymous]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {
        this._authService.Register(registerDto.ToModel());

        return Ok("Your account has been created successfully.");
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        string? token = await this._authService.Login(loginDto);

        return Ok(token);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> TokenValido()
    {
        return Ok("Token válido.");
    }
}