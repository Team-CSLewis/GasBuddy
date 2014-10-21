namespace GassBuddy.Data.Migrations
{
    using GassBuddy.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Hosting;

    internal sealed class Configuration : DbMigrationsConfiguration<GasBuddyDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GasBuddyDbContext context)
        {
            if (context.GasStations.Count() != 0)
            {
                return;
            }
            var xmlReader = new XMLGasStationReader();
            var rootPath = HostingEnvironment.MapPath("~/");

            var shellPath = rootPath + @"../GassBuddy.Data/SeedData/fuelo-Shell-gasstations-20141021.xml";
            var lukoilPath = rootPath + @"../GassBuddy.Data/SeedData/fuelo-Lukoil-gasstations-20141021.xml";
            var ekoPath = rootPath + @"../GassBuddy.Data/SeedData/fuelo-Eko-gasstations-20141021.xml";
            var omvPath = rootPath + @"../GassBuddy.Data/SeedData/fuelo-OMV-gasstations-20141021.xml";

            var shellGasStations = xmlReader.GetGasStations(shellPath);
            var lukoilGasStations = xmlReader.GetGasStations(lukoilPath);
            var ekoGasStations = xmlReader.GetGasStations(ekoPath);
            var omvGasStations = xmlReader.GetGasStations(omvPath);

            var chains = new List<Chain>()
            {
                new Chain()
                {
                    Name = "Shell",
                    GasStations = new HashSet<GasStation>(shellGasStations)                    
                },
                new Chain()
                {
                    Name = "OMV",
                    GasStations = new HashSet<GasStation>(omvGasStations)                    
                },
                new Chain()
                {
                    Name = "EKO",
                    GasStations = new HashSet<GasStation>(ekoGasStations)                    
                },
                new Chain()
                {
                    Name = "Lukoil",
                    GasStations = new HashSet<GasStation>(lukoilGasStations)                    
                },
            };
            foreach (var chain in chains)
            {
                context.Chains.Add(chain);
            }
        }
    }
}
