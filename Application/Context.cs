using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Context : DbContext
    {
        public DbSet <Models> Models { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Thing> Things { get; set; }
        //public DbSet<Models> Models { get; set; }
    }
}
