using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

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
    }
    }
