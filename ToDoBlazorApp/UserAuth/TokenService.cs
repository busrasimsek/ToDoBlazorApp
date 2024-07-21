using Blazored.SessionStorage;

namespace ToDoBlazorApp.UserAuth
{
    public class TokenService
    {
        private readonly ISessionStorageService _sessionStorage;

        public TokenService(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task SaveTokenAsync(string token)
        {
            await _sessionStorage.SetItemAsync("token", token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await _sessionStorage.GetItemAsStringAsync("token");
            //await _sessionStorage.GetItemAsync<string>("token");
        }

        public async Task RemoveTokenAsync()
        {
            await _sessionStorage.RemoveItemAsync("token");
        }
    }
}
