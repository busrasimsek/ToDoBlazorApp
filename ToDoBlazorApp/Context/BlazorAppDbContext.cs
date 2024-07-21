using Microsoft.EntityFrameworkCore;
using ToDoBlazorApp.Data;

namespace ToDoBlazorApp.Context
{
    public class BlazorAppDbContext : DbContext
    {
        public BlazorAppDbContext(DbContextOptions options) : base(options)
        {
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<User> Users { get; set; }
    }
}
