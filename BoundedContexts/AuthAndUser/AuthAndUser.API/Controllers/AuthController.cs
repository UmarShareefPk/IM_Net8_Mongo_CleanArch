using AuthAndUser.Application.Auth.Commands;
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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Auth module is alive");

        private readonly IMediator _mediator;  
    
        public AuthController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;          
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthenticateCommand authenticateCommand)        
        {
            var authenticateResponse = await _mediator.Send(authenticateCommand);

            if( authenticateResponse == null)            
                return Unauthorized();
            
            return Ok(authenticateResponse);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(InsertUserLoginCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateUserLoginCommand command)
        {
            if (id != command.Id) return BadRequest();
            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeleteUserLoginCommand(id));
            return result ? Ok() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            // Optional: Add query/handler to fetch UserLogin by ID
            return Ok();
        }


    }
    
}
