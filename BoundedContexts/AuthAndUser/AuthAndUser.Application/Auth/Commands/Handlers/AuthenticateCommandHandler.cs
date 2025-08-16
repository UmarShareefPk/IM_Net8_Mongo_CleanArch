using AuthAndUser.Application.DTOs;
using AuthAndUser.Domain.Entities;
using AuthAndUser.Application.Security;
using MediatR;
using AuthAndUser.Domain.Repositories;


namespace AuthAndUser.Application.Auth.Commands.Handlers
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResponse?>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITeamRepository _teamRepository;

        public AuthenticateCommandHandler(IAuthRepository authRepository, IUserRepository userRepository, ITeamRepository teamRepository, IJwtTokenGenerator jwtTokenGenerator, 
            IPasswordHasher passwordHasher)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
            _teamRepository = teamRepository;
        }

        public async Task<AuthenticateResponse?> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
              

                var userLogin = await _authRepository.GetByUsernameAsync(request.Username);

            if (userLogin is null)
                return null;

            var hashBytes = Convert.FromBase64String(userLogin.PasswordHash);
            var saltBytes = Convert.FromBase64String(userLogin.PasswordSalt);

            var isValid = _passwordHasher.VerifyHash(request.Password, hashBytes, saltBytes);

            if(!isValid)
                return null;

            var user = await _userRepository.GetByIdAsync(userLogin.UserId);

            if (user is null)
                return null;

         

            string token = _jwtTokenGenerator.GenerateToken(user);
            Team team = await _teamRepository.GetByIdAsync(user.teamId);
            List<User> teamUsers = await _userRepository.GetAllTeamUsersAsync(user.teamId);

            return new AuthenticateResponse
            {
                Id = userLogin.UserId,
                Username = userLogin.Username,              
                user = user,
                Team = team,
                TeamUsers = teamUsers,
                Token = token,

            };
        }
    }
}
