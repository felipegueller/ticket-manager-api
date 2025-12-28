using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TicketManager.DTO.Authentication;
using TicketManager.Model.Models;
using TicketManager.Model.ModelsNotMapped.Authentication;
using TicketManager.Model.ModelsNotMapped.Exceptions;
using TicketManager.Service.IServices;

namespace TicketManager.Service.Services;

public class AuthService(
    IPasswordHasher<User> passwordHasher,
    IConfiguration configuration) : IAuthService
{
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly IConfiguration _configuration = configuration;

    public Task<string?> Login(LoginDto loginDto)
    {
        // change to get user from database
        User user = new("felipe", "AQAAAAIAAYagAAAAEDlmJNM5rOv70Ry2wr0eisY4i3v34OTlIpXWfZ/Doo6G35Ciwh7WKqvARNIG8CErAQ==", "mail@mail.com");

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.Password,
            loginDto.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new UnauthorizedAccessException();

        string token = GenerateJwtToken(user);

        return Task.FromResult<string?>(token);
    }

    public void Register(Register register)
    {
        User user = new(register.Username!, register.Password!, register.Email!);
        string passwordHash = _passwordHasher.HashPassword(user, register.Password!);

        user.UpdatePassword(passwordHash);
        System.Console.WriteLine($"User {user.Username} registered with hashed password: {user.Password}");
        // Save user to the database (not implemented here)
    }

    private string GenerateJwtToken(User user)
    {
        var secret = _configuration["JwtSettings:Secret"]
            ?? throw new ServiceException("The JWT Secret key was not found.");
        var key = Encoding.UTF8.GetBytes(secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }
}
