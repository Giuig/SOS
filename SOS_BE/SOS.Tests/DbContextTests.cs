namespace SOS.Tests
{
    using global::SOS.Infrastructure.Database;
    using global::SOS.Infrastructure.DTO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Xml.Serialization;
    using Xunit;

    public class DbContextTests : IClassFixture<IntegrationTestFactory<Program, SOSContext>>
    {
        private readonly IntegrationTestFactory<Program, SOSContext> _factory;

        public DbContextTests(IntegrationTestFactory<Program, SOSContext> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CanRetrieveEntitiesFromDatabase()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SOSContext>();

            // Act
            var entities = await dbContext.Set<TeamMemberDTO>().ToListAsync();

            // Assert
            Assert.NotNull(entities);
            Assert.True(entities.Count >= 0);
        }
    }
}