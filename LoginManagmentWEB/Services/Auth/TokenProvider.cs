using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;

namespace LoginManagmentWEB.Services.Auth
{
    public class TokenProvider : ITokenProvider
    {
        private readonly ProtectedSessionStorage _session;
        private string? _token;

        public TokenProvider(ProtectedSessionStorage session)
        {
            _session = session;
        }

        public string? Token => _token;

        public async Task LoadTokenAsync()
        {
            if (!string.IsNullOrEmpty(_token)) return;

            var result = await _session.GetAsync<string>("authToken");
            if (result.Success)
                _token = result.Value;
        }

        public async Task SetTokenAsync(string token)
        {
            _token = token;
            await _session.SetAsync("authToken", token);
        }
        public string? GetUsernameFromToken()
        {
            if (string.IsNullOrEmpty(Token))
                return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(Token);

            var usernameClaim = jwt.Claims.FirstOrDefault(c =>
                c.Type == "unique_name" || c.Type == "name" || c.Type == "username");

            return usernameClaim?.Value;
        }

        public string? GetUserIdFromToken()
        {
            if (string.IsNullOrEmpty(Token))
                return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(Token);

            var idClaim = jwt.Claims.FirstOrDefault(c =>
                c.Type == "nameid" || c.Type == "id" || c.Type == "sub");

            return idClaim?.Value;
        }

        public string? GetRoleFromToken()
        {
            if (string.IsNullOrEmpty(Token))
                return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(Token);

            var roleClaim = jwt.Claims.FirstOrDefault(c => c.Type == "role");

            return roleClaim?.Value;
        }
    }
 }
