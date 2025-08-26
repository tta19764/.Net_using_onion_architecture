using DataAccess.Mappings;
using Microsoft.Extensions.Configuration;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;
using Shouldly;
using System.Globalization;

namespace IntegrationTests
{
    public class ChurchBulletinMappingTester
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldMapChurchBulletin()
        {
            var bulletin = new ChurchBulletin();
            bulletin.Name = "Worchip service";
            bulletin.Place = "Sanctuary";
            bulletin.Date = new DateTime(2025, 8, 26);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            using (var dataContext = new DataContext(new TestDataConfiguration(configuration)))
            {
                dataContext.Add(bulletin);
                dataContext.SaveChanges();
            }

            ChurchBulletin? rehydratedEntity;
            using (var context = new DataContext(new TestDataConfiguration(configuration)))
            {
                rehydratedEntity = context.Set<ChurchBulletin>()
                    .SingleOrDefault(b => b == bulletin);
            }

            rehydratedEntity.Id.ShouldBe(bulletin.Id);
            rehydratedEntity.ShouldBe(bulletin);
            rehydratedEntity.Place.ShouldBe(bulletin.Place);
            rehydratedEntity.Name.ShouldBe(bulletin.Name);
            rehydratedEntity.Date.ShouldBe(bulletin.Date);
        }
    }
}