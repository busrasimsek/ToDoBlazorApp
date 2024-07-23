using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ToDoBlazorApp.UserAuth
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        //private readonly ISessionStorageService _sessionStorage;
        //private readonly HttpClient client;
        //private readonly AuthenticationState anonymous;

        //public AuthStateProvider(ISessionStorageService sessionStorage, HttpClient Client)
        //{
        //    _sessionStorage = sessionStorage;
        //    client = Client;
        //    anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        //}

        //public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    String apiToken = await _sessionStorage.GetItemAsStringAsync("token");

        //    if (String.IsNullOrEmpty(apiToken))
        //        return anonymous;


        //    String user = await _sessionStorage.GetItemAsStringAsync("user");

        //    var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user) }, "jwtAuthType"));
        //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

        //    return new AuthenticationState(cp);
        //}

        //public void NotifyUserLogin(String user)
        //{
        //    var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user) }, "jwtAuthType"));
        //    var authState = Task.FromResult(new AuthenticationState(cp));

        //    NotifyAuthenticationStateChanged(authState);
        //}

        //public void NotifyUserLogout()
        //{
        //    var authState = Task.FromResult(anonymous);
        //    NotifyAuthenticationStateChanged(authState);
        //}
    }
}
