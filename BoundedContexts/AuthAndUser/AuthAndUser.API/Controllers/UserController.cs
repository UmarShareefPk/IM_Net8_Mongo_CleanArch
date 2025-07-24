
using Auth.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Auth module is alive");

        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public UserController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _config = config;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        //public IActionResult Login([FromBody] AuthenticateRequest request)
        public IActionResult Login()
        {
            // Validate credentials manually or via CQRS handler...

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, "userId123"),
        //new Claim(ClaimTypes.Email, request.Email),
        new Claim(ClaimTypes.Role, "Admin")
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSecret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand cmd)
        {
            var userId = await _mediator.Send(cmd);
            return Ok(new { UserId = userId });
        }
    }
    
}
