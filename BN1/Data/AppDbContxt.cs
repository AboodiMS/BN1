using BN1.Data.Entities;
using BN1.Migrations;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BN1.Data
{
    public class AppDbContxt : DbContext
    {
        public DbSet<Table1> Table1s { get; set; }
        public AppDbContxt() : base("name=AppDbContxt")
        {
        }
        public void MigrateDatabase()
        {
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}