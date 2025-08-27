using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingWithPalermo.ChurchBulletin.DataAccess.Mappings
{
    public class DataContext : DbContext
    {
        private readonly IDataConfiguration _config;

        public DataContext(IDataConfiguration config)
        {
            this._config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(_config.GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ChurchBulletinMap().Map(modelBuilder);
        }

        public override string ToString()
        {
            return base.ToString() + "-" + this.GetHashCode();
        }
    }
}
