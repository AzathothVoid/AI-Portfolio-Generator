using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Utility
{
    public static class JwtUtility
    {
        private static JwtSecurityTokenHandler _tokenHandler;
        static JwtUtility()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }
        public static List<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

        public static JwtSecurityToken ReadJwtToken(string jwt)
        {
            return _tokenHandler.ReadJwtToken(jwt);
        }
    }
}
