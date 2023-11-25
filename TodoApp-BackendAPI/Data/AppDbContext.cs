using Microsoft.EntityFrameworkCore;
using TodoApp_BackendAPI.Models;

namespace TodoApp_BackendAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
