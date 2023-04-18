using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SOS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SOS.Model.RequestModels;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Configurations;
using System.Net.Http.Json;
using Docker.DotNet.Models;
using Testcontainers.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace SOS.Tests
{
    public class TeamMemberControllerIntegrationTests : IClassFixture<IntegrationTestFactory<Program, SOSContext>>
    {
        private readonly IntegrationTestFactory<Program, SOSContext> _factory;
        public TeamMemberControllerIntegrationTests(IntegrationTestFactory<Program, SOSContext> factory) => _factory = factory;

        [Fact]
        public async Task Create_ShouldCreateNewTeamMember()
        {

            var client = _factory.CreateClient();

            var myObject = new CreateTeamMemberModel
            {
                Name = "Test",
                Surname = "Test",
                BirthDate = DateTime.Now.ToUniversalTime(),
            };

            var content = new StringContent(JsonConvert.SerializeObject(myObject), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/TeamMember", content);
            response.EnsureSuccessStatusCode();

            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SOSContext>();
            var result = await dbContext.TeamMember.SingleAsync(o => o.Id == 1);
            Assert.NotNull(result);
            Assert.Equal(myObject.Name, result.Name);
            Assert.Equal(myObject.Surname, result.Surname);
            Assert.Equal(myObject.BirthDate.Date, result.BirthDate.Date);
        }
    }
}
