using AuthAndUser.Application.Commands;
using AuthAndUser.Application.DTOs;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Domain.Interfaces;
using AuthAndUser.Application.Security;
using MediatR;


namespace AuthAndUser.Application.Handlers
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResponse?>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticateCommandHandler(IAuthRepository authRepository, IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticateResponse?> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
         
                var userLogin = await _authRepository.GetByUsernameAndPasswordAsync(request.Username, request.Password);

            if (userLogin is null)
                return null;

            var user = await _userRepository.GetByIdAsync(userLogin.userId);

            if (user is null)
                return null;

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticateResponse
            {
                Id = userLogin.Id,
                Username = userLogin.Username,              
                user = user,
                Token = token,

            };
        }
    }
}
