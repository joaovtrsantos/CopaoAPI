using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class SignupTokensService : ISignupTokensService
    {
        //TODO: IMPORT USER REPOSITORY HERE
       public SignupTokensService() { }
        public Task<LoginResponse?> Authenticate(LoginRequest model)
        {
           
            // authentication successful so generate jwt token
            var token = await generateJwtToken(user);

            return new LoginResponse(user, token);
        }

        public Task<string> GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
