namespace WorldWideFloors.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using WorldWideFloors.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorldWideFloors.Models.WorldWideFloorsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorldWideFloors.Models.WorldWideFloorsContext context)
        {
            var collections = new List<Collection>
            {
                new Collection {Name = "American Oak", Desc="Fine"}
            };
            collections.ForEach(c => context.Collections.AddOrUpdate(collection => collection.Name, c));
            context.SaveChanges();
        }
    }
}
