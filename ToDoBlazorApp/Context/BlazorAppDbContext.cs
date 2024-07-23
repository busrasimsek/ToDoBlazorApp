using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ToDoBlazorApp.Data;
using System.Xml;
using Microsoft.AspNetCore.Components.Authorization;

namespace ToDoBlazorApp.Context
{
    public class BlazorAppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlazorAppDbContext(DbContextOptions options , IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    //}
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        TrackChanges();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task TrackChanges()
    {
        //var authState =await  AuthenticationStateProvider.GetAuthenticationStateAsync();
        //var user = authState.User;
        var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unknown";

        foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedUser = username;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = DateTime.Now;
                    entry.Entity.UpdatedUser = username;
                    break;
                case EntityState.Deleted:
                    entry.Entity.IsActive = false;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.UpdatedDate = DateTime.Now;
                    entry.Entity.UpdatedUser = username;
                    entry.State = EntityState.Modified;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
            }
        }
    }
}
}
