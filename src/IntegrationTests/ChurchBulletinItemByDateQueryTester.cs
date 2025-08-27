﻿using Microsoft.Extensions.Configuration;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;
using ProgrammingWithPalermo.ChurchBulletin.Core.Queries;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess.Handlers;
using ProgrammingWithPalermo.ChurchBulletin.DataAccess.Mappings;
using Shouldly;

namespace ProgrammingWithPalermo.ChurchBulletin.IntegrationTests;

public class ChurchBulletinItemByDateQueryTester
{
    [Test]
    public void ShouldGetWithinDate()
    {
        // arrange
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        EmptyDatabase(configuration);
        var item1 = new ChurchBulletinItem() { Date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
        var item2 = new ChurchBulletinItem() { Date = new DateTime(1999, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
        var item3 = new ChurchBulletinItem() { Date = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
        var item4 = new ChurchBulletinItem() { Date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc) };

        using (var context = new DataContext(new TestDataConfiguration(configuration)))
        {
            context.AddRange(item1,  item2, item3, item4);
            context.SaveChanges();
        }

        var query = new ChurchBulletinItemByDateAndTimeQuery(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc));
        var handler = new ChurchBulletinItemByDateHandler(new DataContext(new TestDataConfiguration(configuration)));

        //act
        IEnumerable<ChurchBulletinItem> items = handler.Handle(query).ToList();
        
        // assert
        items.Count().ShouldBe(2);
        items.ShouldContain(item1);
        items.ShouldContain(item4);
        items.ShouldNotContain(item2);
        items.ShouldNotContain(item3);
    }

    private static void EmptyDatabase(IConfiguration config)
    {
        DatabaseEmptier.DeleteAllData(config);
    }
}
