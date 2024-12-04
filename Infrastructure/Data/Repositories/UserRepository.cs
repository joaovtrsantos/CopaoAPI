using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository(CopaoDbContext context, IConfiguration configuration) : IUserRepository
    {
        private readonly CopaoDbContext _copaoDbContext = context;

        public async Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            var user = await FindUserByEmail(loginUserDTO.Email);

            if (user == null)
                return new LoginResponse(false, "User not found.", "");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Password);
            if (checkPassword)
                return new LoginResponse(true, "Login successfully!", GenerateJWTToken(user));
            else
                return new LoginResponse(false, "Invalid credentials.", "");
        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<User?> FindUserByEmail(string email)
        {
            var user = await _copaoDbContext.User.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var user = await FindUserByEmail(registerUserDTO.Email);
            if (user == null)
            {
                _copaoDbContext.User.Add(new User
                {
                    UserName = registerUserDTO.UserName,
                    FirstName = registerUserDTO.FirstName,
                    LastName = registerUserDTO.LastName,
                    Email = registerUserDTO.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
                });
                await _copaoDbContext.SaveChangesAsync();
                return new RegistrationResponse(true, "Registration completed");
            }
            else
                return new RegistrationResponse(false, "User already exist");
        }
    }
}