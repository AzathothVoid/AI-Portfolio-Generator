using Client.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<bool> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Register()
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            throw new NotImplementedException();
        }
    }
}
