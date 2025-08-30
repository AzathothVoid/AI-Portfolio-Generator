using Client.Contracts;
using Client.Services.Base;
using Client.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Services
{
    public class AuthenticationService : BaseHttpService, Contracts.IAuthenticationService
    {  
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(IClient client,ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider) : base(client, localStorage)
        {
            _authStateProvider = authStateProvider;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest request = new AuthRequest() { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(request);

                if (authenticationResponse.Token != string.Empty)
                {
                    var tokenContent = JwtUtility.ReadJwtToken(authenticationResponse.Token);
                    var claims = JwtUtility.ParseClaims(tokenContent);
              
                    if (_authStateProvider is CustomAuthenticationStateProviderService custom)
                        custom.NotifyUserAuthentication(claims);

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

        public async Task<bool> Register(string email, string password, string firstName, string lastName, string userName)
        {
            RegistrationRequest request = new()
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName
            };

            var response = await _client.RegisterAsync(request);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }

            return false;
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token" });
           
        }


    }
}
