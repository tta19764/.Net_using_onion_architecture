using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingWithPalermo.ChurchBulletin.DataAccess.Mappings
{
    public class ChurchBulletinMap : EntityMapBase<ChurchBulletinItem>
    {
        protected override void MapMembers(EntityTypeBuilder<ChurchBulletinItem> entity)
        {

        }
    }
}
