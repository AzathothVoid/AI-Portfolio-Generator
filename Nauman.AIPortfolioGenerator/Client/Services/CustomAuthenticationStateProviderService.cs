using Client.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Client.Services
{
    public class CustomAuthenticationStateProviderService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProviderService(ILocalStorageService  localStorage)
        {
            _localStorage = localStorage;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }

        public void NotifyUserAuthentication(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

