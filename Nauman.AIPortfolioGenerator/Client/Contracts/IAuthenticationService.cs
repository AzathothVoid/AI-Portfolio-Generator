using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(string email, string password, string firstName, string lastName, string userName);
        Task Logout();
    }
}
