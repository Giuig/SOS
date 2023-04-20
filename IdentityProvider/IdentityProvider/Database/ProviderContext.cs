using IdentityProvider.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvider.Database
{
    public class ProviderContext : IdentityDbContext<ProviderUser>
    {

        public ProviderContext()
        {
        }

        public ProviderContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProviderUser> ProviderUsers { get; set; }
    }

}
