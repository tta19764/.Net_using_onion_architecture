using ProgrammingWithPalermo.ChurchBulletin.DataAccess.Mappings;
using Microsoft.Extensions.Configuration;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;
using Shouldly;
using System.Globalization;

namespace ProgrammingWithPalermo.ChurchBulletin.IntegrationTests
{
    public class ChurchBulletinMappingTester
    {
        [Test]
        public void ShouldMapChurchBulletin()
        {
            var bulletin = new ChurchBulletinItem();
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

            ChurchBulletinItem? rehydratedEntity;
            using (var context = new DataContext(new TestDataConfiguration(configuration)))
            {
                rehydratedEntity = context.Set<ChurchBulletinItem>()
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