using Auth.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand cmd)
        {
            var userId = await _mediator.Send(cmd);
            return Ok(new { UserId = userId });
        }
    }
    
}
