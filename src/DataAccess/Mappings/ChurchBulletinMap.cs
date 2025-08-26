using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class ChurchBulletinMap : EntityMapBase<ChurchBulletin>
    {
        protected override void MapMembers(EntityTypeBuilder<ChurchBulletin> entity)
        {

        }
    }
}
