using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DbConnectionString")
        {   

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Log> Logs { get; set; }

    }
}
