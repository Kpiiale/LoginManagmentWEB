using LoginManagmentWEB.Services.Auth;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;

    namespace LoginManagmentWEB.Services
    {
        public class AuthHeaderHandler : DelegatingHandler
        {
            private readonly ITokenProvider _tokenProvider;

            public AuthHeaderHandler(ITokenProvider tokenProvider)
            {
                _tokenProvider = tokenProvider;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // ⚠️ No llamamos LoadTokenAsync aquí para evitar JS interop durante prerendering
                var token = _tokenProvider.Token;

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }