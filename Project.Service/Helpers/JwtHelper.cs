using System.IdentityModel.Tokens.Jwt;

namespace Project.Service.Helpers
{
    public static class JwtHelper
    {
        public static JwtSecurityToken GetTokenDataResponse(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(token);
        }
    }
}
