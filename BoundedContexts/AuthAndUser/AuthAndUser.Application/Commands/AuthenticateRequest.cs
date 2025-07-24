using AuthAndUser.Application.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AuthAndUser.Application.Commands
{
    public class AuthenticateCommand : IRequest<AuthenticateResponse>
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}