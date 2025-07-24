using AuthAndUser.Application.Commands;
using AuthAndUser.Application.Security;
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

namespace AuthAndUser.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Auth module is alive");

        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
    

        public AuthController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _config = config;          
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthenticateCommand authenticateCommand)        
        {
            // Validate credentials manually or via CQRS handler...

            var authenticateResponse = await _mediator.Send(authenticateCommand);

            if( authenticateResponse == null)            
                return Unauthorized();
            
            return Ok(authenticateResponse);


        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand cmd)
        {
            var userId = await _mediator.Send(cmd);
            return Ok(new { UserId = userId });
        }
    }
    
}
