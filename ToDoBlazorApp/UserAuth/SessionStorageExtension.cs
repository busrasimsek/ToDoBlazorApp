using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBlazorApp.UserAuth
{
    public static class SessionStorageExtension
    {
        //public async static Task<int> GetUserId(this ISessionStorageService sessionStorage)
        //{
        //    String userGuid = await sessionStorage.GetItemAsStringAsync("Id");

        //    return Guid.TryParse(userGuid, out Guid Id) ? Id : Guid.Empty;
        //}

        //public static Guid GetUserIdSync(this ISyncSessionStorageService sessionStorage)
        //{
        //    String userGuid = sessionStorage.GetItemAsString("Id");

        //    return Guid.TryParse(userGuid, out Guid Id) ? Id : Guid.Empty;
        //}

        //public async static Task<string> GetUsernameAsync(this ISessionStorageService SessionStorage)
        //{
        //    return await SessionStorage.GetItemAsStringAsync("username");
        //}

        //// Senkron olarak username alma
        //public static string GetUsernameSync(this ISyncSessionStorageService SessionStorage)
        //{
        //    return SessionStorage.GetItemAsString("username");
        //}

    }
}
