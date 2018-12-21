using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WorldWideFloors.Migrations;
using static WorldWideFloors.Migrations.Configuration;


namespace WorldWideFloors.Models
{
    public class WorldWideFloorsContext :DbContext 
    {
        
        public WorldWideFloorsContext() : base("WorldWideFloorsContext")
        {
            
        }

        public DbSet<Glue> Glues { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Project> Projects { get; set; }
        
    }
}