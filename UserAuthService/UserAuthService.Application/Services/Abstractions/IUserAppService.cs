using UserAuthService.Application.DTOs;


namespace UserAuthService.Application.Services.Abstractions
{
    public interface IUserAppService
    {
        UserDTO LoginUser(LoginDTO loginDTO);
        bool SignUpUser(SignUpDTO signUpDTO);
        IEnumerable<UserDTO> GetAllUsers();
    }
}
