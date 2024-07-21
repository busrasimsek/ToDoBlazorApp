using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace ToDoBlazorApp.UserAuth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly TokenService _tokenService;

        public CustomAuthenticationStateProvider(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _tokenService.GetTokenAsync();
            var identity = new ClaimsIdentity();

            if (!string.IsNullOrEmpty(token))
            {
                // Token'ı doğrulama ve claim'leri çıkarma işlemini burada yapın
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            }

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = Convert.FromBase64String(AddBase64Padding(payload));
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private string AddBase64Padding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return base64;
        }

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void NotifyUserLogout()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }
    }
}