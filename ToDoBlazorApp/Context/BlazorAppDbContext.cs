using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using ToDoBlazorApp.Data;

namespace ToDoBlazorApp.Context
{
    public class BlazorAppDbContext : DbContext
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public BlazorAppDbContext(DbContextOptions options, AuthenticationStateProvider authenticationStateProvider)
        : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            _authenticationStateProvider = authenticationStateProvider;
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
            string username = "Unknown";
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(user.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value))
                {
                    username = user.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
                }
            }
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
