using Microsoft.EntityFrameworkCore;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;

namespace ProgrammingWithPalermo.ChurchBulletin.IntegrationTests;

[TestFixture]
public class ZDataLoader
{
    [Test]
    public void LoadData()
    {
        new DatabaseEmptier(TestHost.GetRequiredService<DbContext>().Database).DeleteAllData();

        var item1 = new ChurchBulletinItem { Date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), Name = "one" };
        var item2 = new ChurchBulletinItem { Date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), Name = "two" };
        var item3 = new ChurchBulletinItem { Date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), Name = "three" };
        var item4 = new ChurchBulletinItem { Date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), Name = "four" };

        using (var context = TestHost.GetRequiredService<DbContext>())
        {
            context.AddRange(item1, item2, item3, item4);
            context.SaveChanges();
        }

        Assert.Pass();
    }
}
