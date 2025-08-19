
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using ProveedoresApp.Dto.User;
using ProveedoresApp.Infrastructure;
using ProveedoresApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;


namespace ProveedoresApp.Api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class AuthController : ControllerBase
    {
        private readonly ProveedoresDbContext _context;
        private readonly IJwtService _jwtService; 

        public AuthController(ProveedoresDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized();

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }

}
