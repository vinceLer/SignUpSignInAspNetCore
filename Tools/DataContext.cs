using Microsoft.EntityFrameworkCore;
using SignUpSignInAspNetCore.Models;

namespace SignUpSignInAspNetCore.Tools
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v-app;Integrated Security=True");
        }
    }
}
