using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace SOS.Tests
{
    public class IntegrationTestFactory<TProgram, TDbContext> : WebApplicationFactory<TProgram>, IAsyncLifetime
        where TProgram : class where TDbContext : DbContext
    {

        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var conn = _postgreSqlContainer.GetConnectionString();
                services.RemoveDbContext<TDbContext>();
                services.AddDbContext<TDbContext>(options => { options.UseNpgsql(_postgreSqlContainer.GetConnectionString()); });
                services.EnsureDbCreated<TDbContext>();
            });
        }

        public async Task InitializeAsync() => await _postgreSqlContainer.StartAsync();

        public new async Task DisposeAsync() => await _postgreSqlContainer.DisposeAsync();
    }
}
