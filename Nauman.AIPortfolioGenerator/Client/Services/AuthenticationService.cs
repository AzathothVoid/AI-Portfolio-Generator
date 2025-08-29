using Client.Contracts;
using Client.Services.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Services
{
    public class AuthenticationService : IAuthenticationService, BaseHttpService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _tokenHandler;

        public AuthenticationService(IClient client,ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor) : base(client, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest request = new AuthRequest() { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(request);

                if (authenticationResponse.Token != string.Empty)
                {
                    var tokenContent = _tokenHandler.ReadJwtToken(authenticaitonResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme))
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user)
                    _localStorage.SetStorageValue("token", authenticationResponse.Token);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public async Task<bool> Register(string email, string password, string firstName, string lastName, string userName);
        {
            RegistrationRequest request = new() { Email = email, Password = password, FirstName = firstName, LastName = lastName, UserName = userName }
            var response = await _client.RegisterAsync(request);
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
