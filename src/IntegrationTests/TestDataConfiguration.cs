using ProgrammingWithPalermo.ChurchBulletin.DataAccess;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace ProgrammingWithPalermo.ChurchBulletin.IntegrationTests
{
    internal class TestDataConfiguration : IDataConfiguration
    {
        private readonly IConfiguration _configuration;

        public TestDataConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("SqlConnectionString")!;
        }
    }
}