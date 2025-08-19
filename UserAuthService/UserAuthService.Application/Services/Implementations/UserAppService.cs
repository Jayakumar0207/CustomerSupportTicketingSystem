using UserAuthService.Application.DTOs;
using UserAuthService.Application.Repositories;
using UserAuthService.Application.Services.Abstractions;
using UserAuthService.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace UserAuthService.Application.Services.Implementations
{
    public class UserAppService : IUserAppService
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        IConfiguration _configuration;
        public UserAppService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        private string GenerateJwtToken(UserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int ExpireMinutes = Convert.ToInt32(_configuration["Jwt:ExpireMinutes"]);

            var claims = new[] {
                             new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                             new Claim(JwtRegisteredClaimNames.Email, user.Email),
                             new Claim("Roles", string.Join(",",user.Role)),
                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                             };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                            _configuration["Jwt:Audience"],
                                            claims,
                                            expires: DateTime.UtcNow.AddMinutes(ExpireMinutes), //token expiry minutes
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO LoginUser(LoginDTO loginDTO)
        {
            User user = _userRepository.GetUserByEmail(loginDTO.Email);
            if(user!=null)
            {
                bool isValidPassword = BC.Verify(loginDTO.Password, user.Password);
                if (isValidPassword)
                {
                    UserDTO userDTO = _mapper.Map<UserDTO>(user);
                    userDTO.Token = GenerateJwtToken(userDTO);
                    return userDTO;
                }
            }
            return null!;
        }

        public bool SignUpUser(SignUpDTO signUpDTO)
        {
            User userObj = _userRepository.GetUserByEmail(signUpDTO.Email);
            if (userObj == null)
            {
                User user = _mapper.Map<User>(signUpDTO);
                user.Password = BC.HashPassword(signUpDTO.Password);
                return _userRepository.RegisterUser(user);
            }
            return false;
        }
    }
}
