using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingWithPalermo.ChurchBulletin.Core.Queries
{
    public class ChurchBulletinItemByDateAndTimeQuery
    {
        public DateTime TargetDate { get; }

        public ChurchBulletinItemByDateAndTimeQuery(DateTime dateTime)
        {
            this.TargetDate = dateTime;
        }
    }
}
