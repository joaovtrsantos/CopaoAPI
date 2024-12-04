using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO);
    }
}
