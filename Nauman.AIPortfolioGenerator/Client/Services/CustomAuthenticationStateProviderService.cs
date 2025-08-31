using Client.Contracts;
using Client.Utility;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using System.Security.Claims;

namespace Client.Services
{
    public class CustomAuthenticationStateProviderService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public CustomAuthenticationStateProviderService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetStorageValueAsync<string>("token");

            Console.WriteLine($"Token: {token}");

            if (string.IsNullOrEmpty(token))
            {  
                return new AuthenticationState(_anonymous);            
            }

            var tokenContent = JwtUtility.ReadJwtToken(token);
            var claims = JwtUtility.ParseClaims(tokenContent);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        public void NotifyUserAuthentication(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }
    }
}

