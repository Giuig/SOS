using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SOS.Infrastructure.Database;
using Testcontainers.PostgreSql;

namespace SOS.Tests
{
    public class CustomFactory : WebApplicationFactory<Program>
    {
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder().Build();

        // Gives a fixture an opportunity to configure the application before it gets built.
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Remove AppDbContext
                services.RemoveDbContext<SOSContext>();

                // Add DB context pointing to test container
                services.AddDbContext<SOSContext>(options => { options.UseNpgsql(_postgreSqlContainer.GetConnectionString()); });

                // Ensure schema gets created
                services.EnsureDbCreated<SOSContext>();
            });
        }
    }
}