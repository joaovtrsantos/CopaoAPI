using Application.DTOs;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository(CopaoDbContext context) : IUser
    {
        private readonly CopaoDbContext _copaoDbContext = context;

        public async Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            var user = await _copaoDbContext.User.FirstOrDefaultAsync(x => x.Email == loginUserDTO.Email
            && x.Password == loginUserDTO.Password);

            if (user == null)
                return new LoginResponse(false, "User not found.", "");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Password);
            if (checkPassword)
                return new LoginResponse(true, "Login successfully!", GenerateJWTToken(user));
            else
                return new LoginResponse(false, "Invalid credentials.", "");
        }

        public Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}