namespace Application.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Application.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Application.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Manufacturers.AddOrUpdate(n=>n.Name, new Manufacturer {Name="Apple", FoundationYear = new DateTime(1990,5,3)});
            context.Manufacturers.AddOrUpdate(n=>n.Name, new Manufacturer { Name = "Sony", FoundationYear = new DateTime(1991,6,10) });
            context.SaveChanges();
            context.Models.AddOrUpdate(m=>m.Name, new Models { Name = "Xperia", ModelManufacturer = context.Manufacturers.Single(n => n.Name == "Sony"), Year = new DateTime(1994, 5, 3) });
            context.Models.AddOrUpdate(m => m.Name, new Models { Name = "iPhone 6s", ModelManufacturer = context.Manufacturers.Single(n => n.Name == "Apple"), Year = new DateTime(1997, 5, 3) });
            context.SaveChanges();
            context.Things.AddOrUpdate(m => m.Serial, new Thing { model = context.Models.Single(n => n.Name == "iPhone 6s"), Serial = 0 });
            context.Things.AddOrUpdate(m => m.Serial, new Thing { model = context.Models.Single(n => n.Name == "iPhone 6s"), Serial = 3 });
            context.Things.AddOrUpdate(m => m.Serial, new Thing { model = context.Models.Single(n => n.Name == "iPhone 6s"), Serial = 4 });
            context.Things.AddOrUpdate(m => m.Serial,new Thing { model = context.Models.Single(n => n.Name == "Xperia"), Serial = 117 });
        }
    }
}
